//----------------------------------------------------------------
// <copyright file="CriInterpClientData.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//----------------------------------------------------------------

namespace Product.ConfigurableInterp.Client.ServiceCode
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Services.Protocols;

    using FluentNHibernate.Conventions;
    using Product.ConfigurableInterp.Client.Models;
    using DC = ConfigInterp.Contracts.DataContracts;
    #endregion

    /// <summary>
    /// This class provide methods for CRI Mock service
    /// </summary>
    [Serializable]
    public sealed class CriInterpClientData
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="CriInterpClientData" /> class from being created.
        /// </summary>
        private CriInterpClientData()
        {
        }

        /// <summary>
        /// Gets Dashboard modal object
        /// </summary>
        public static DashboardModel DashboardModel
        {
            get
            {
                return new DashboardModel();
            }
        }

        /// <summary>
        /// Gets Interp Errors collection object
        /// </summary>
        public static ICollection<InterpError> NewExceptions
        {
            get
            {
                var exceptionTypeResponse = InterpClientData.GetExceptionTypes;
                var exception = new List<Models.InterpError>();
                var sortedExceptions = new SortedList<short, string>();
                if (exceptionTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in exceptionTypeResponse.Descriptions)
                    {
                        sortedExceptions.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedExceptions)
                    {
                        exception.Add(new Models.InterpError()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return exception;
            }
        }

        /// <summary>
        /// Gets Property will return New Condition object
        /// </summary>
        public static Models.Condition NewCondition
        {
            get
            {
                var condition = new Models.Condition();
                condition.SetCompareTypes(CompareTypes);
                condition.SetConditionTypes(ConditionTypes);
                condition.SetFieldTypes(FieldTypes);
                condition.SetFieldnames(FieldNames);
                return condition;
            }
        }

        /// <summary>
        /// Gets Property will return New Action object
        /// </summary>
        public static Models.Action NewAction
        {
            get
            {
                var action = new Models.Action();
                action.SetActionNames(ActionNames);
                action.SetActionType(ActionTypes);
                action.SetResults(ActionResults);
                return action;
            }
        }

        /// <summary>
        /// Gets Action Names Collection object
        /// </summary>
        private static List<ActionName> ActionNames
        {
            get
            {
                var actionResponse = InterpClientData.GetActions(2, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
                var actionName = new List<ActionName>();
                var sortedActionNames = new SortedList<short, string>();
                if (actionResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in actionResponse.Descriptions)
                    {
                        sortedActionNames.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedActionNames)
                    {
                        actionName.Add(new Models.ActionName()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return actionName;
            }
        }

        /// <summary>
        /// Gets Action Types collection object
        /// </summary>
        private static List<ActionType> ActionTypes
        {
            get
            {
                var actionTypeResponse = InterpClientData.GetActionTypes(ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
                var actionTypes = new List<ActionType>();
                var sortedActionTypes = new SortedList<short, string>();
                if (actionTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in actionTypeResponse.Descriptions)
                    {
                        sortedActionTypes.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedActionTypes)
                    {
                        actionTypes.Add(new Models.ActionType()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return actionTypes;
            }
        }

        /// <summary>
        /// Gets Action Results Collection object
        /// </summary>
        private static List<Result> ActionResults
        {
            get
            {
                var compareTypeResponse = InterpClientData.GetCompareTypes(7, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
                var actionResult = new List<Models.Result>();
                var sortedCompareTypes = new SortedList<short, string>();
                if (compareTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in compareTypeResponse.Descriptions)
                    {
                        sortedCompareTypes.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedCompareTypes)
                    {
                        actionResult.Add(new Models.Result()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return actionResult;
            }
        }

        /// <summary>
        /// Gets Compare Types Collection object
        /// </summary>
        private static List<CompareType> CompareTypes
        {
            get
            {
                var compareTypeResponse = InterpClientData.GetCompareTypes(1, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
                var compareType = new List<Models.CompareType>();
                var sortedCompareTypes = new SortedList<short, string>();
                if (compareTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in compareTypeResponse.Descriptions)
                    {
                        sortedCompareTypes.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedCompareTypes)
                    {
                        compareType.Add(new Models.CompareType()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return compareType;
            }
        }

        /// <summary>
        /// Gets Condition Types collection object
        /// </summary>
        private static List<ConditionType> ConditionTypes
        {
            get
            {
                var conditionTypeResponse = InterpClientData.GetConditionTypes;
                var conditionType = new List<Models.ConditionType>();
                var sortedConditions = new SortedList<short, string>();
                if (conditionTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in conditionTypeResponse.Descriptions)
                    {
                        sortedConditions.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedConditions)
                    {
                        conditionType.Add(new Models.ConditionType()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return conditionType;
            }
        }

        /// <summary>
        /// Gets Field types collection object
        /// </summary>
        private static List<FieldType> FieldTypes
        {
            get
            {
                var fieldTypeResponse = InterpClientData.GetFieldTypes;
                var fieldType = new List<Models.FieldType>();
                var sortedFieldTypes = new SortedList<short, string>();
                if (fieldTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in fieldTypeResponse.Descriptions)
                    {
                        sortedFieldTypes.Add(item.TypeId, item.Description);
                    }

                    foreach (KeyValuePair<short, string> kvp in sortedFieldTypes)
                    {
                        fieldType.Add(new Models.FieldType()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return fieldType;
            }
        }

        /// <summary>
        /// Gets Field Names collection object
        /// </summary>
        private static List<Fieldname> FieldNames
        {
            get
            {
                var fieldNameResponse = InterpClientData.GetFieldnames(1, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
                var fieldName = new List<Models.Fieldname>();
                var sortedFieldNames = new SortedList<string, string>();
                if (fieldNameResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                {
                    foreach (var item in fieldNameResponse.Descriptions)
                    {
                        sortedFieldNames.Add(item.FieldId, item.FieldDescription);
                    }

                    foreach (KeyValuePair<string, string> kvp in sortedFieldNames)
                    {
                        fieldName.Add(new Models.Fieldname()
                        {
                            Id = kvp.Key.ToString(CultureInfo.CurrentCulture),
                            Name = kvp.Value
                        });
                    }
                }

                return fieldName;
            }
        }

        /// <summary>
        /// Convert Time zone to short format
        /// </summary>
        /// <param name="source">time zone string</param>
        /// <returns>Abbreviation string</returns>
        public static string Abbreviation(string source)
        {
            var map = new Dictionary<string, string>()
            {
                { "EASTERN STANDARD TIME", "EST" },
                { "MOUNTAIN STANDARD TIME", "MST" },
                { "CENTRAL STANDARD TIME", "CST" },
                { "PACIFIC STANDARD TIME", "PST" }
            };

            return map[source.ToUpper(CultureInfo.InvariantCulture)];
        }

        /// <summary>
        /// This method will return Interp object
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <returns>Interp object</returns>
        public static Interp GetInterpDetails(string interpId)
        {
            try
            {
                var interp = new Interp();
                var client = new InterpClientData();
                if (string.IsNullOrEmpty(interpId))
                {
                    return interp;
                }
                else
                {
                    var interpNarrative = client.GetInterpHeader(interpId); //This is the Narrative information

                    interp.InterpId = interpId;
                    if (interpNarrative != null && interpNarrative.Data != null)
                    {
                        DC.InterpStatus currentStatus = DC.InterpStatus.None;
                        switch (interpNarrative.Data.Status)
                        {
                            case DC.Status.Active:
                                currentStatus = DC.InterpStatus.Active;
                                break;
                            case DC.Status.Maintenance:
                                var interpHeader = client.GetInterp(interpId, DC.InterpStatus.Draft);

                                if (interpHeader.Status == DC.ResponseStatus.Success)
                                {
                                    currentStatus = DC.InterpStatus.Draft;
                                }
                                else
                                {
                                    interpHeader = client.GetInterp(interpId, DC.InterpStatus.Test);
                                    if (interpHeader.Status == DC.ResponseStatus.Success)
                                    {
                                        currentStatus = DC.InterpStatus.Test;
                                    }
                                    else
                                    {
                                        interpHeader = client.GetInterp(interpId, DC.InterpStatus.DraftRevision);
                                        if (interpHeader.Status == DC.ResponseStatus.Success)
                                        {
                                            currentStatus = DC.InterpStatus.DraftRevision;
                                        }
                                        else
                                        {
                                            currentStatus = DC.InterpStatus.None;
                                        }
                                    }
                                }

                                break;
                            default:
                                currentStatus = DC.InterpStatus.None;
                                break;
                        }

                        var interpDetails = client.GetInterpDetails(interpId, currentStatus); //This is the CIP information, what to display on the UI

                        interp.Username = interpNarrative.Data.EmployeeName;
                        interp.UserId = interpNarrative.Data.EmployeeNumber;
                        interp.Status = interpDetails.Data != null ? interpDetails.Data.CurrentStatus.ToString() : DC.InterpStatus.None.ToString(); //This line is the CIP status and what should be displayed on the UI 
                        interp.ActivatedDate = interpNarrative.Data.StatusDate.HasValue ? interpNarrative.Data.StatusDate.Value.ToString("MM/dd/yy HH:mm:ss ", CultureInfo.InvariantCulture) + Abbreviation(TimeZoneInfo.Local.Id) : string.Empty;
                        interp.MaintenanceDate = interpNarrative.Data.MaintenanceDate.HasValue ? interpNarrative.Data.MaintenanceDate.Value.ToString("MM/dd/yy HH:mm:ss ", CultureInfo.InvariantCulture) + Abbreviation(TimeZoneInfo.Local.Id) : string.Empty;
                    }

                    // Create Tasks In Parallel
                    Parallel.Invoke(
                        () =>
                    {
                        interp.SetSections(new InterpSections(client, interpId, false));
                    },
                    () =>
                    {
                        CreateNewConditions(interp);
                    },
                    () =>
                    {
                        CreateNewActions(interp);
                    },
                     () =>
                    {
                        interp.SetExceptions(NewExceptions);
                    });

                    return interp;

               ------------------------------------------------------------------------------------------------------------99999999999999999999999999999999999999999999999---------------------------}
            }
            catch (SoapException)
            {
                return new Interp();
            }
        }

        /// <summary>
        /// This is to create new actions.
        /// </summary>
        /// <param name="interp">The interp object</param>
        public static void CreateNewActions(Interp interp)
        {
            List<Models.Action> actions;

            if (interp.Actions != null && interp.Actions.Count > 0)
            {
                actions = new List<Models.Action>(interp.Actions);
            }
            else
            {
                actions = new List<Models.Action>();
            }

            actions.Add(NewAction);
            interp.SetActions(actions);
        }

        /// <summary>
        /// This is to create new Conditions.
        /// </summary>
        /// <param name="interp">The interp object</param>
        public static void CreateNewConditions(Interp interp)
        {
            List<Condition> conditions;

            if (interp.Conditions != null && interp.Conditions.Count > 0)
            {
                conditions = new List<Condition>(interp.Conditions);
            }
            else
            {
                conditions = new List<Condition>();
            }

            conditions.Add(NewCondition);
            interp.SetConditions(conditions);
        }
    }
}