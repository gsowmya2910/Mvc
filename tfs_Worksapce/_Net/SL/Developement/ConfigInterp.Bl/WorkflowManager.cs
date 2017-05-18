// ----------------------------------------------------------------------
// <copyright file="WorkFlowManager.cs" company="CoreLink">
//        Copyright © CoreLink 2016. All Rights Reserved.
// </copyright>
// ----------------------------------------------------------------------
namespace ConfigInterp.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using BenefitMatrix;
    using Contracts.DataContracts;
    using Inquire;
    using Interfaces;
    using Update;

    /// <summary>
    /// the class
    /// </summary>
    /// <seealso cref="ConfigInterp.Bl.Interfaces.IWorkflowManager" />
    public class WorkflowManager : IWorkflowManager
    {
        /// <summary>
        /// The maximum batches
        /// </summary>
        private const short MaxBatches = 7;

        /// <summary>
        /// The _benefit matrix
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly IBenefitMatrixHandler _benefitMatrix;

        /// <summary>
        /// The _inquire
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly ICipInquireHandler _inquire;

        /// <summary>
        /// The _update
        /// </summary>
        [SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1309:FieldNamesMustNotBeginWithUnderscore", Justification = "Legacy code")]
        private readonly ICipUpdateHandler _update;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkflowManager" /> class.
        /// </summary>
        /// <param name="benefitMatrix">The benefit matrix.</param>
        /// <param name="update">The update.</param>
        /// <param name="inquire">The inquire.</param>
        public WorkflowManager(IBenefitMatrixHandler benefitMatrix, ICipUpdateHandler update, ICipInquireHandler inquire)
        {
            this._benefitMatrix = benefitMatrix;
            this._update = update;
            this._inquire = inquire;
        }

        /// <summary>
        /// Clones the interp.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The value
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        [SuppressMessage("ReSharper", "FunctionComplexityOverflow", Justification = "Dev")]
        public CloneInterpResult CloneInterp(ICloneInterpData value)
        {
            var targetInterp = new Interp
            {
                Outline = value.Target.Outline,
                Category = value.Target.Category,
                AdmitInterp = value.Target.AdmitInterp,
                SubCategory = value.Target.SubCategory,
                Level = value.SystemType.NarrativeType()
            };
            var sourceInterp = new Interp
            {
                AdmitInterp = value.Source.AdmitInterp,
                Outline = value.Source.Outline,
                Category = value.Source.Category,
                SubCategory = value.Source.SubCategory,
                Level = value.SystemType.NarrativeType()
            };
            var createInput = new BenefitMatrixCreateInput
            {
                Region = value.Region,
                BlueUser = value.BlueUser,
                MainframeUsercode = value.MainFrameUsercode,
                Interp = targetInterp
            };
            var createResult = this._benefitMatrix.CreateNarrative(createInput);
            if (createResult.Result == OperationResult.Success && createResult.Success)
            {
                var inquireInput = new InquireInput
                {
                    Region = value.Region,
                    Status = value.CurrentStatus,
                    MainFrameUsercode = value.MainFrameUsercode,
                    Outline = value.Source.Outline,
                    Category = value.Source.Category,
                    AdmitInterp = value.Source.AdmitInterp,
                    SubCategory = value.Source.SubCategory,
                    SystemType = value.SystemType
                };
                var inquireFromResult = this._inquire.InquireInterpDetail(inquireInput);
                if (inquireFromResult.Success && inquireFromResult.Result == OperationResult.Success)
                {
                    var now = DateTime.Now;

                    var comment = string.Format("Copied from ADM {0}", sourceInterp.DebugDisplay);

                    var matrixChange = new BenefitMatrixChange
                    {
                        Region = value.Region,
                        Status = Resolve(value.CurrentStatus),
                        BlueUser = value.BlueUser,
                        Interp = targetInterp,
                        MainframeUsercode = value.MainFrameUsercode,

                        Narrative = new[] { comment }
                    };
                    var narrUpdateResult = this._benefitMatrix.UpdateNarrative(matrixChange);

                    if (narrUpdateResult.Success && narrUpdateResult.Result == OperationResult.Success)
                    {
                        var updateInput = new UpdateInterpSteps
                            {
                                Region = value.Region,
                                MainFrameUsercode = value.MainFrameUsercode,
                                CurrentStatus = InterpStatus.Draft,
                                Outline = value.Target.Outline,
                                Category = value.Target.Category,
                                SubCategory = value.Target.SubCategory,
                                AdmitInterp = value.Target.AdmitInterp,
                                SystemType = value.SystemType,
                                Comment = comment,
                                EmployeeNumber = Utilities.GetOnlyNumber(value.BlueUser),
                                EmployeeRegion = inquireFromResult.EmployeeRegion,
                                StatusDateTime = now,
                                Steps = inquireFromResult.StepData,
                            };
                        var updateResult = this._update.UpdateInterp(updateInput);
                        var cloneResult = new CloneInterpResult
                        {
                            MessageNumber = updateResult.MessageNumber,
                            MessageText = string.Format("CIP Update {0}", updateResult.MessageText),
                            Result = updateResult.Result,
                            Exception = updateResult.Exception
                        };
                        if (updateResult.Success && updateResult.Result == OperationResult.Success)
                        {
                            cloneResult.AdmitInterp = updateInput.AdmitInterp;
                            cloneResult.Category = updateInput.Category;
                            cloneResult.Comment = inquireFromResult.Comment;
                            cloneResult.CurrentStatus = inquireFromResult.CurrentStatus;
                            cloneResult.EmployeeNumber = (short)updateInput.EmployeeNumber;
                            cloneResult.EmployeeRegion = updateInput.EmployeeRegion;
                            cloneResult.Level = inquireFromResult.Level;
                            cloneResult.Outline = updateInput.Outline;
                            cloneResult.RevisionNumber = 1;
                            cloneResult.RevisionSequence = 1;
                            cloneResult.CreateByRevision = 1;
                            cloneResult.StatusDateTime = now;
                            cloneResult.StepCount = inquireFromResult.StepCount;
                            cloneResult.StepData = inquireFromResult.StepData;
                            cloneResult.SubCategory = updateInput.SubCategory;
                            cloneResult.SystemType = inquireFromResult.SystemType;
                            cloneResult.TableOccurs = inquireFromResult.TableOccurs;
                        }

                        return cloneResult;
                    }

                    return new CloneInterpResult
                    {
                        Result = narrUpdateResult.Result,
                        MessageNumber = narrUpdateResult.MessageNumber,
                        MessageText = string.Format("Narr Update {0}", narrUpdateResult.MessageText),
                        Exception = narrUpdateResult.Exception
                    };
                }

                var inquireFailResult = new CloneInterpResult
                {
                    MessageNumber = inquireFromResult.MessageNumber,
                    MessageText = string.Format("CIP Inquire {0}", inquireFromResult.MessageText),
                    Result = inquireFromResult.Result,
                    Exception = inquireFromResult.Exception
                };
                return inquireFailResult;
            }

            var createFailResult = new CloneInterpResult
            {
                MessageNumber = createResult.MessageNumber,
                MessageText = string.Format("Nar Create {0}", createResult.MessageText),
                Result = createResult.Result,
                Exception = createResult.Exception
            };
            return createFailResult;
        }

        /// <summary>
        /// Deletes the Interp
        /// </summary>
        /// <param name="input">Delete Request</param>
        /// <returns>
        /// The result
        /// </returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        public UpdateResult DeleteInterp(IDeleteInterpIntialData input)
        {
            IBenefitMatrixNarrativeInquireable inqureNarInput = InquireNarInput(input);
            var inquireNarResult = this._benefitMatrix.InquireNarrative(inqureNarInput);
            if (inquireNarResult.Result == OperationResult.Success && inquireNarResult.Success)
            {
                var narrativeDeleteable = Convert(inquireNarResult.Narrative, input);
                var deleteNarResult = this._benefitMatrix.DeleteNarrative(narrativeDeleteable);
                if (deleteNarResult.Result == OperationResult.Success && deleteNarResult.Success)
                {
                    var inquireCipInput = Convert(input);
                    var inquireCipResult = this._inquire.InquireSimpleData(inquireCipInput);
                    if (inquireCipResult.Result == OperationResult.Success && inquireCipResult.Success)
                    {
                        IDeleteInterp inquireInput = ConvertCipDelete(input, inquireCipResult);
                        var deleteCipResult = this._update.DeleteInterp(inquireInput);

                        return new UpdateResult
                        {
                            MessageNumber = deleteCipResult.MessageNumber,
                            MessageText = deleteCipResult.MessageText,
                            Result = deleteCipResult.Result,
                            Exception = deleteCipResult.Exception
                        };
                    }

                    if (inquireCipResult.Result == OperationResult.NotFound)
                    {
                        return new UpdateResult
                        {
                            Result = OperationResult.Success
                        };
                    }

                    return new UpdateResult
                    {
                        MessageNumber = inquireCipResult.MessageNumber,
                        MessageText = inquireCipResult.MessageText,
                        Result = inquireCipResult.Result,
                        Exception = inquireCipResult.Exception
                    };
                }

                return new UpdateResult
                {
                    Result = deleteNarResult.Result,
                    MessageNumber = deleteNarResult.MessageNumber,
                    MessageText = deleteNarResult.MessageText,
                    Exception = deleteNarResult.Exception
                };
            }

            return new UpdateResult
            {
                Result = inquireNarResult.Result,
                MessageNumber = inquireNarResult.MessageNumber,
                MessageText = inquireNarResult.MessageText,
                Exception = inquireNarResult.Exception
            };
        }

        /// <summary>
        /// Updates the narrative.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The value
        /// </returns>
        public CompletionResult UpdateNarrative(IBenefitMatrixChangeable value)
        {
            var deleteData = Convert(value);
            var deleteResult = this._benefitMatrix.DeleteNarrative(deleteData);

            if (deleteResult.Result == OperationResult.Success && deleteResult.Success)
            {
                var batches = value.Narrative.Batch(BenefitMatrixHandler.MaxLines).Take(MaxBatches).ToArray();
                short seed = 0;
                foreach (var batch in batches)
                {
                    var createInput = Convert(value, seed);
                    var createResult = this._benefitMatrix.CreateNarrative(createInput);
                    if (createResult.Result == OperationResult.Success && createResult.Success)
                    {
                        var updateInput = ConvertForBatching(value, batch, seed);
                        var updateResult = this._benefitMatrix.UpdateNarrative(updateInput);
                        if (!updateResult.Success || updateResult.Result == OperationResult.Failed)
                        {
                            return new CompletionResult
                            {
                                MessageNumber = updateResult.MessageNumber,
                                MessageText = updateResult.MessageText,
                                Result = updateResult.Result,
                                Exception = updateResult.Exception
                            };
                        }
                    }
                    else
                    {
                        return new CompletionResult
                        {
                            MessageNumber = createResult.MessageNumber,
                            MessageText = createResult.MessageText,
                            Result = createResult.Result,
                            Exception = createResult.Exception
                        };
                    }

                    seed++;
                }
            }
            else
            {
                return new CompletionResult
                {
                    MessageNumber = deleteResult.MessageNumber,
                    MessageText = deleteResult.MessageText,
                    Result = deleteResult.Result,
                    Exception = deleteResult.Exception
                };
            }

            return new CompletionResult
            {
                Result = OperationResult.Success,
            };
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The value
        /// </returns>
        public StatusChangeResult UpdateStatus(IStatusChangeData value)
        {
            var inqureInput = new BenefitMatrixInqureInput
            {
                Region = value.Region,
                BlueUser = value.BlueUser,
                Status = Resolve(value.CurrentStatus),
                MainframeUsercode = value.MainFrameUsercode,
                Interp = new Interp
                {
                    Outline = value.Outline,
                    Category = value.Category,
                    AdmitInterp = value.AdmitInterp,
                    SubCategory = value.SubCategory,
                    Level = value.SystemType.NarrativeType()
                }
            };
            var narInquire = this._benefitMatrix.InquireNarrative(inqureInput);
            if (narInquire.Result == OperationResult.Success && narInquire.Success)
            {
                var change = new BenefitMatrixChange
                {
                    Region = value.Region,
                    BlueUser = value.BlueUser,
                    Status = Resolve(value.TargetStatus),
                    MainframeUsercode = value.MainFrameUsercode,
                    Interp = new Interp
                    {
                        Outline = value.Outline,
                        Category = value.Category,
                        AdmitInterp = value.AdmitInterp,
                        SubCategory = value.SubCategory,
                        Level = value.SystemType.NarrativeType()
                    },
                    Narrative = narInquire.Narrative.Lines
                };
                var narUpdate = this._benefitMatrix.UpdateNarrative(change);
                if (narUpdate.Success && narUpdate.Result == OperationResult.Success)
                {
                    var inquireInput = new InquireInput
                    {
                        Region = value.Region,
                        MainFrameUsercode = value.MainFrameUsercode,
                        Status = value.CurrentStatus,
                        Outline = value.Outline,
                        Category = value.Category,
                        SubCategory = value.SubCategory,
                        AdmitInterp = value.AdmitInterp,
                        SystemType = value.SystemType
                    };
                    var inquireCip = this._inquire.InquireSimpleData(inquireInput);
                    if (inquireCip.Success && inquireCip.Result == OperationResult.Success)
                    {
                        var statusData = new UpdateStatusData
                        {
                            Region = value.Region,
                            EmployeeNumber = inquireCip.EmployeeNumber,
                            SubCategory = value.SubCategory,
                            Category = value.Category,
                            Outline = value.Outline,
                            AdmitInterp = value.AdmitInterp,
                            SystemType = value.SystemType,
                            Comment = inquireCip.Comment,
                            EmployeeRegion = inquireCip.EmployeeRegion,
                            MainFrameUsercode = value.MainFrameUsercode,
                            StatusDateTime = DateTime.Now,
                            TargetStatus = value.TargetStatus,
                            RevisionSequence = (short)(inquireCip.RevisionSequence + 1),
                            RevisionNumber = inquireCip.RevisionNumber
                        };
                        var updateResult = this._update.UpdateStatus(statusData);

                        var result = new StatusChangeResult
                        {
                            Exception = updateResult.Exception,
                            Result = updateResult.Result,
                            MessageText = string.Format("CIP Update {0}", updateResult.MessageText),
                            MessageNumber = (short)(updateResult.Success ? 0 : 1)
                        };
                        return result;
                    }

                    return new StatusChangeResult
                    {
                        MessageNumber = inquireCip.MessageNumber,
                        MessageText = string.Format("CIP Inquire {0}", inquireCip.MessageText),
                        Result = inquireCip.Result,
                        Exception = inquireCip.Exception
                    };
                }

                return new StatusChangeResult
                {
                    MessageNumber = narUpdate.MessageNumber,
                    MessageText = string.Format("Narr Update {0}", narUpdate.MessageText),
                    Result = narUpdate.Result,
                    Exception = narUpdate.Exception
                };
            }

            return new StatusChangeResult
            {
                Result = narInquire.Result,
                MessageNumber = narInquire.MessageNumber,
                MessageText = string.Format("Nar Inquire {0}", narInquire.MessageText),
                Exception = narInquire.Exception
            };
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="seed">The seed.</param>
        /// <returns>
        /// The value
        /// </returns>
        private static IBenefitMatrixCreateInput Convert(IBenefitMatrixChangeable value, short seed)
        {
            return new BenefitMatrixCreateInput
            {
                Region = value.Region,
                BlueUser = value.BlueUser,
                Interp = new Interp
                {
                    Outline = value.Interp.Outline,
                    Category = value.Interp.Category,
                    SubCategory = value.Interp.SubCategory,
                    AdmitInterp = value.Interp.AdmitInterp,
                    Level = (short)(value.Interp.Level + seed)
                },
                MainframeUsercode = value.MainframeUsercode
            };
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The value
        /// </returns>
        private static IBenefitMatrixNarrativeDeleteable Convert(IBenefitMatrixChangeable value)
        {
            IBenefitMatrixNarrativeDeleteable val = new BenefitMatrixDeleteInput
        {
            Region = value.Region,
            BlueUser = value.BlueUser,
            Status = value.Status,
            Interp = value.Interp,
            MainframeUsercode = value.MainframeUsercode
        };
            return val;
        }

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        /// <returns>The value.</returns>
        private static IInquireInput Convert(IDeleteInterpIntialData narrative)
        {
            IInquireInput value = new InquireInput
            {
                Region = narrative.Region,
                MainFrameUsercode = narrative.MainFrameUsercode,
                Outline = narrative.Outline,
                Category = narrative.Category,
                SubCategory = narrative.SubCategory,
                AdmitInterp = narrative.AdmitInterp,
                SystemType = narrative.SystemType,
                Status = narrative.Status
            };
            return value;
        }

        /// <summary>
        /// Converts the specified narrative.
        /// </summary>
        /// <param name="narrative">The narrative.</param>
        /// <param name="input">The input.</param>
        /// <returns>The value.</returns>
        private static IBenefitMatrixNarrativeDeleteable Convert(INarrative narrative, IDeleteInterpIntialData input)
        {
            IBenefitMatrixNarrativeDeleteable value = new BenefitMatrixDeleteInput
            {
                Region = input.Region,
                Status = Resolve(input.Status),
                BlueUser = input.BlueUser,
                MainframeUsercode = input.MainFrameUsercode,
                Interp = new Interp
               {
                   Outline = input.Outline,
                   Category = input.Category,
                   SubCategory = input.SubCategory,
                   AdmitInterp = input.AdmitInterp,
                   Level = input.SystemType.NarrativeType()
               },
                SequenceNumber = narrative.SequenceNumber
            };
            return value;
        }

        /// <summary>
        /// Converts the cip delete.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="inquireCipResult">The inquire cip result.</param>
        /// <returns>The value.</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Legacy code")]
        private static IDeleteInterp ConvertCipDelete(IDeleteInterpIntialData input, ISimpleInquire inquireCipResult)
        {
            IDeleteInterp value = new DeleteInterpSteps
            {
                MainFrameUsercode = input.MainFrameUsercode,
                Region = input.Region,
                Outline = input.Outline,
                Category = input.Category,
                SubCategory = input.SubCategory,
                AdmitInterp = input.AdmitInterp,
                SystemType = input.SystemType,
                CurrentStatus = input.Status,
                Comment = string.Empty,
                EmployeeRegion = inquireCipResult.EmployeeRegion,
                EmployeeNumber = inquireCipResult.EmployeeNumber,
                StatusDateTime = inquireCipResult.StatusDateTime,
                CreateByRevision = inquireCipResult.CreateByRevision,
                RevisionSequence = inquireCipResult.RevisionSequence,
                RevisionNumber = inquireCipResult.RevisionNumber
            };
            return value;
        }

        /// <summary>
        /// Converts for batching.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="batch">The batch.</param>
        /// <param name="seed">The seed.</param>
        /// <returns>
        /// The value
        /// </returns>
        private static IBenefitMatrixChangeable ConvertForBatching(IBenefitMatrixChangeable value, IEnumerable<string> batch, short seed)
        {
            return new BenefitMatrixChange
            {
                Region = value.Region,
                BlueUser = value.BlueUser,
                Interp = new Interp
                {
                    Outline = value.Interp.Outline,
                    Category = value.Interp.Category,
                    SubCategory = value.Interp.SubCategory,
                    AdmitInterp = value.Interp.AdmitInterp,
                    Level = (short)(value.Interp.Level + seed)
                },
                MainframeUsercode = value.MainframeUsercode,
                Status = value.Status,
                Narrative = batch.ToArray()
            };
        }

        /// <summary>
        /// Inquires the narrative input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The value.</returns>
        private static IBenefitMatrixNarrativeInquireable InquireNarInput(IDeleteInterpIntialData input)
        {
            IBenefitMatrixNarrativeInquireable value = new BenefitMatrixInqureInput
            {
                Region = input.Region,
                Status = Resolve(input.Status),
                BlueUser = input.BlueUser,
                MainframeUsercode = input.MainFrameUsercode,
                Interp = new Interp
                {
                    Outline = input.Outline,
                    Category = input.Category,
                    SubCategory = input.SubCategory,
                    AdmitInterp = input.AdmitInterp,
                    Level = input.SystemType.NarrativeType()
                }
            };
            return value;
        }

        /// <summary>
        /// Resolves the specified current status.
        /// </summary>
        /// <param name="currentStatus">The current status.</param>
        /// <returns>
        /// The value.
        /// </returns>
        private static Status Resolve(InterpStatus currentStatus)
        {
            switch (currentStatus)
            {
                case InterpStatus.Active: return Status.Active;
                case InterpStatus.Deactivated: return Status.None;
                case InterpStatus.Draft: return Status.Maintenance;
                case InterpStatus.DraftRevision: return Status.Maintenance;
                case InterpStatus.None: return Status.None;
                case InterpStatus.Test: return Status.Maintenance;
            }

            return Status.None;
        }
    }
}