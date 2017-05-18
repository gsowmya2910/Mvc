//----------------------------------------------------------------
// <copyright file="InterpClientData.cs" company="CoreLink">
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
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Web.Services.Protocols;
    using ConfigInterp.Contracts.DataContracts;
    using FluentNHibernate.Conventions;
    using Product.ConfigurableInterp.Client.Models;
    using schemas.corelinksolutions.com.product.schema.configinterp;
    #endregion
    ////using InterpModel = Product.ConfigurableInterp.Client.Models;
    using Service = schemas.corelinksolutions.com.product.schema.configinterp;

    /// <summary>
    /// Enumeration for handling different sections of Interp Id
    /// </summary>
    public enum InterpIdSection
    {
        /// <summary>
        /// Outline value
        /// </summary>
        Outline,

        /// <summary>
        /// Category value
        /// </summary>
        Category,

        /// <summary>
        /// Subcategory value
        /// </summary>
        Subcategory,

        /// <summary>
        /// Interp Id value
        /// </summary>
        InterpId,

        /// <summary>
        /// Level value
        /// </summary>
        Level
    }

    /// <summary>
    /// This class will hold interp section handling functions
    /// </summary>
    public class InterpClientData
    {
        /// <summary>
        /// Contains the Membership object.
        /// </summary>
        private static Membership membership;

        /// <summary>
        /// Gets Condition Type value from service
        /// </summary>
        public static DescriptionCommonResponse GetConditionTypes
        {
            get
            {
                DescriptionCommonResponse conditionType;

                try
                {
                    conditionType = ServiceClient.GetConditionTypeDescription(new DefaultRequest()
                    {
                        ApplicationId = ApplicationId,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Region = Region,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode
                    });
                    Helpers.Utility.ConsoleLogger("GetConditionTypeDescription response: ", conditionType);
                }
                catch (SoapException)
                {
                    conditionType = new DescriptionCommonResponse();
                }

                return conditionType;
            }
        }

        /// <summary>
        /// Gets Field Type value from service
        /// </summary>
        /// <returns>Return DescriptionCommonResponse object</returns>
        public static DescriptionCommonResponse GetFieldTypes
        {
            get
            {
                DescriptionCommonResponse fieldType;

                try
                {
                    fieldType = ServiceClient.GetFieldTypeDescription(new SystemTypeRequest()
                    {
                        ApplicationId = ApplicationId,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Region = Region,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        LineOfBusiness = LineOfBusiness.Professional
                    });
                    Helpers.Utility.ConsoleLogger("GetFieldTypeDescription response: ", fieldType);
                }
                catch (SoapException)
                {
                    fieldType = new DescriptionCommonResponse();
                }

                return fieldType;
            }
        }

        /// <summary>
        /// Gets Exception Type value from service
        /// </summary>
        /// <returns>Return DescriptionCommonResponse object</returns>
        public static DescriptionCommonResponse GetExceptionTypes
        {
            get
            {
                DescriptionCommonResponse exceptionType;

                try
                {
                    exceptionType = ServiceClient.GetExceptionDescription(new SystemTypeRequest()
                    {
                        ApplicationId = ApplicationId,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Region = Region,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        LineOfBusiness = LineOfBusiness.Professional
                    });
                    Helpers.Utility.ConsoleLogger("GetExceptionDescription response: ", exceptionType);
                }
                catch (SoapException)
                {
                    exceptionType = new DescriptionCommonResponse();
                }

                return exceptionType;
            }
        }

        /// <summary>
        /// Gets or sets Indicator for Interp Section contains error 
        /// </summary>
        public string InterpError { get; set; }

        /// <summary>
        /// Gets or sets Error message from Web service
        /// </summary>
        public string InterpErrorText { get; set; }

        /// <summary>
        /// Gets or sets Status to check for create interp button
        /// </summary>
        public int CreateNewInterp { get; set; }

        /// <summary>
        /// Gets or sets Status to show View Interp link
        /// </summary>
        public int ViewInterp { get; set; }

        /// <summary>
        /// Gets or sets Status to indicate delete interp
        /// </summary>
        public int DeleteStatus { get; set; }

        /// <summary>
        /// Gets or sets Status to indicate updating of narrative
        /// </summary>
        public int UpdateNarrative { get; set; }

        /// <summary>
        /// Gets or sets Status to indicate updating of interp
        /// </summary>
        public int UpdateInterp { get; set; }

        /// <summary>
        /// Gets or sets Status to indicate status changes to an interp
        /// </summary>
        public int UpdateStatusStatus { get; set; }

        /// <summary>
        /// Gets or sets Interp Message from service
        /// </summary>
        public string InterpMessage { get; set; }

        /// <summary>
        /// Gets or sets Image show identifier
        /// </summary>
        public int InterpImage { get; set; }

        /// <summary>
        /// Gets User Id Value
        /// </summary>
        private static string UserId
        {
            get
            {
                GetMembership();
                return membership.UserId;
            }
        }

        /// <summary>
        /// Gets Unisys User code Value
        /// </summary>
        private static string UnisysUsercode
        {
            get
            {
                GetMembership();
                return membership.UnisysUsercode;
            }
        }

        /// <summary>
        /// Gets Region Value
        /// </summary>
        private static int Region
        {
            get
            {
                GetMembership();
                return membership.RegionCode;
            }
        }

        /// <summary>
        /// Gets Correspondence Location Value
        /// </summary>
        private static string CorrespondenceLocation
        {
            get { return "SD"; }
        }

        /// <summary>
        /// Gets Application Id Value
        /// </summary>
        private static string ApplicationId
        {
            get
            {
                GetMembership();
                return membership.ApplicationId;
            }
        }

        /// <summary>
        /// Gets Service Client object
        /// </summary>
        private static InterpServiceClient ServiceClient
        {
            get { return new InterpServiceClient("ConfigInterpServiceEndpoint"); }
        }

        /// <summary>
        /// Retrieve Compare type values from Service
        /// </summary>
        /// <param name="compareTypeId">Compare type id</param>
        /// <param name="business">business type</param>
        /// <returns>Returns DescriptionCommonResponse object</returns>
        public static DescriptionCommonResponse GetCompareTypes(int compareTypeId, LineOfBusiness business)
        {
            DescriptionCommonResponse compareType;

            try
            {
                compareType = ServiceClient.GetCompareTypeDescription(new ListRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Id = compareTypeId,
                    LineOfBusiness = business
                });
                Helpers.Utility.ConsoleLogger("GetCompareTypeDescription response: ", compareType);
            }
            catch (SoapException)
            {
                compareType = new DescriptionCommonResponse();
            }

            return compareType;
        }

        /// <summary>
        /// Retrieve Field name value from service
        /// </summary>
        /// <param name="fieldname">Field name Id</param>
        /// <param name="business">business type</param>
        /// <returns>Return FieldNameResponse object</returns>
        public static FieldNameResponse GetFieldnames(int fieldname, LineOfBusiness business)
        {
            FieldNameResponse fieldNameResult;

            try
            {
                fieldNameResult = ServiceClient.GetFieldNameDescription(new ListRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Id = fieldname,
                    LineOfBusiness = business
                });
                Helpers.Utility.ConsoleLogger("GetFieldNameDescription response: ", fieldNameResult);
            }
            catch (SoapException)
            {
                fieldNameResult = new FieldNameResponse();
            }

            return fieldNameResult;
        }

        /// <summary>
        /// Retrieve Actions value from service
        /// </summary>
        /// <param name="actionId">Action Id</param>
        /// <param name="business">business type</param>
        /// <returns>Return DescriptionCommonResponse object</returns>
        public static DescriptionCommonResponse GetActions(int actionId, LineOfBusiness business)
        {
            DescriptionCommonResponse actions;

            try
            {
                actions = ServiceClient.GetActionDescription(new ListRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Id = actionId,
                    LineOfBusiness = business
                });
                Helpers.Utility.ConsoleLogger("GetActionDescription response: ", actions);
            }
            catch (SoapException)
            {
                actions = new DescriptionCommonResponse();
            }

            return actions;
        }

        /// <summary>
        /// Retrieve Actions Type value from service
        /// </summary>
        /// <param name="business">business type</param>
        /// <returns>Return DescriptionCommonResponse object</returns>
        public static DescriptionCommonResponse GetActionTypes(LineOfBusiness business)
        {
            DescriptionCommonResponse actionTypes;

            try
            {
                actionTypes = ServiceClient.GetActionTypeDescription(new SystemTypeRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    LineOfBusiness = business
                });
                Helpers.Utility.ConsoleLogger("GetActionTypeDescription response: ", actionTypes);
            }
            catch (SoapException)
            {
                actionTypes = new DescriptionCommonResponse();
            }

            return actionTypes;
        }

        /// <summary>
        /// Retrieve the Field Validation Info data from the service
        /// </summary>
        /// <param name="fieldId">Field Name ID</param>
        /// <param name="typeId">Field Type ID</param>
        /// <returns>Return FieldValidationInfoResponse object</returns>
        public static FieldValidationInfoResponse GetFieldValidationInfo(int fieldId, int typeId)
        {
            FieldValidationInfoResponse validationInfo;
            try
            {
                validationInfo = ServiceClient.GetFieldValidationInfo(new FieldValidationInfoRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    LineOfBusiness = LineOfBusiness.Professional,
                    FieldId = fieldId,
                    TypeId = typeId
                });
                Helpers.Utility.ConsoleLogger("GetFieldValidationInfo response: ", validationInfo);
            }
            catch (SoapException)
            {
                validationInfo = new FieldValidationInfoResponse();
            }

            return validationInfo;
        }

        /// <summary>
        /// Retrieve the Action Parameter Description Validation Info data from the service
        /// </summary>
        /// <param name="actionId">Action ID</param>
        /// <returns>Return ActionParameterDescriptionValidationInfoResponse object</returns>
        public static ActionParameterDescriptionValidationInfoResponse GetActionParameterDescriptionValidationInfo(int actionId)
        {
            ActionParameterDescriptionValidationInfoResponse validationInfo;
            try
            {
                validationInfo = ServiceClient.GetActionParameterDescriptionValidationInfo(new ListRequest()
                {
                    ApplicationId = ApplicationId,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Region = Region,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    LineOfBusiness = LineOfBusiness.Professional,
                    Id = actionId
                });
                Helpers.Utility.ConsoleLogger("GetActionParameterDescriptionValidationInfo response: ", validationInfo);
            }
            catch (SoapException)
            {
                validationInfo = new ActionParameterDescriptionValidationInfoResponse();
            }

            return validationInfo;
        }

        /// <summary>
        /// Return interp section values, defaults to no interp validation checking
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <param name="section">section key from enumeration</param>
        /// <returns>return section value</returns>
        public string GetInterpSection(string interpId, InterpIdSection section)
        {
            return this.GetInterpSection(interpId, section, false);
        }

        /// <summary>
        /// Return interp section values
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <param name="section">section key from enumeration</param>
        /// <param name="validateInterp">Should validate the interp number? true = yes</param>
        /// <returns>return section value</returns>
        public string GetInterpSection(string interpId, InterpIdSection section, bool validateInterp)
        {
            var value = string.Empty;
            var sections = interpId.Split('-');
            switch (section)
            {
                case InterpIdSection.Outline:
                    if (sections.Length > 0)
                    {
                        value = sections[0];
                    }

                    break;
                case InterpIdSection.Category:
                    if (sections.Length > 1)
                    {
                        value = sections[1];
                    }

                    break;
                case InterpIdSection.Subcategory:
                    if (sections.Length > 2)
                    {
                        value = sections[2];
                    }

                    break;
                case InterpIdSection.InterpId:
                    if (sections.Length > 3)
                    {
                        value = sections[3];
                    }

                    if (validateInterp && value.Length == 4)
                    {
                        this.VerifyInterp(sections[0], sections[1], sections[2], sections[3]);
                    }

                    break;
                case InterpIdSection.Level:
                    if (sections.Length > 4)
                    {
                        value = sections[4];
                    }

                    break;
            }

            return value;
        }

        /// <summary>
        /// Return Outline description from web service
        /// </summary>
        /// <param name="outlineNumber">Outline Number</param>
        /// <returns>Outline description string</returns>
        public string OutlineDescription(string outlineNumber)
        {
            var outline = string.Empty;

            try
            {
                if (outlineNumber.IsNotEmpty() && outlineNumber.Length == 2)
                {
                    var response = ServiceClient.GetOutlineDescription(new OutlineRequest()
                    {
                        ApplicationId = ApplicationId,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        Region = Region,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Data = new schemas.corelinksolutions.com.product.schema.configinterp.OutlineData()
                        {
                            Outline = Convert.ToInt16(outlineNumber, CultureInfo.InvariantCulture)
                        }
                    });

                    Helpers.Utility.ConsoleLogger("GetOutlineDescription response: ", response);
                    if (response.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                    {
                        outline = response.Description;
                        this.InterpError = "No";
                    }
                    else
                    {
                        this.InterpError = "Yes";
                        this.InterpErrorText = "Outline is not configurable";
                    }
                }
            }
            catch (SoapException ex)
            {
                this.InterpError = "Yes";
                this.InterpErrorText = ex.Message;
            }

            return outline;
        }

        /// <summary>
        /// Return Category description from web service
        /// </summary>
        /// <param name="outlineNumber">Outline Number</param>
        /// <param name="categoryNumber">Category Number</param>
        /// <returns>Category description string</returns>
        public string CategoryDescription(string outlineNumber, string categoryNumber)
        {
            var category = string.Empty;

            try
            {
                if (outlineNumber.IsNotEmpty() && categoryNumber.IsNotEmpty() && categoryNumber.Length == 3)
                {
                    var response = ServiceClient.GetCategoryDescription(new CategoryRequest()
                    {
                        ApplicationId = ApplicationId,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        Region = Region,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Data = new schemas.corelinksolutions.com.product.schema.configinterp.CategoryData()
                        {
                            Outline = Convert.ToInt16(outlineNumber, CultureInfo.InvariantCulture),
                            Category = Convert.ToInt16(categoryNumber, CultureInfo.InvariantCulture)
                        }
                    });

                    Helpers.Utility.ConsoleLogger("GetCategoryDescription response: ", response);
                    if (response.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                    {
                        category = response.Description;
                        this.InterpError = "No";
                    }
                    else
                    {
                        this.InterpError = "Yes";
                        this.InterpErrorText = "Category is not configurable";
                    }
                }
            }
            catch (SoapException ex)
            {
                this.InterpError = "Yes";
                this.InterpErrorText = ex.Message;
            }

            return category;
        }

        /// <summary>
        /// Return Subcategory description from web service
        /// </summary>
        /// <param name="outlineNumber">Outline Number</param>
        /// <param name="categoryNumber">Category Number</param>
        /// <param name="subcategoryNumber">Subcategory Number</param>
        /// <returns>Subcategory description string</returns>
        public string SubcategoryDescription(string outlineNumber, string categoryNumber, string subcategoryNumber)
        {
            var subCategory = string.Empty;

            try
            {
                if (outlineNumber.IsNotEmpty() && categoryNumber.IsNotEmpty() && subcategoryNumber.IsNotEmpty() &&
                    subcategoryNumber.Length == 3)
                {
                    var response = ServiceClient.GetSubCategoryDescription(new SubCategoryRequest()
                    {
                        ApplicationId = ApplicationId,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        Region = Region,
                        CorrespondenceLocation = CorrespondenceLocation,
                        Data = new schemas.corelinksolutions.com.product.schema.configinterp.SubCategoryData()
                        {
                            Outline = Convert.ToInt16(outlineNumber, CultureInfo.InvariantCulture),
                            Category = Convert.ToInt16(categoryNumber, CultureInfo.InvariantCulture),
                            SubCategory = Convert.ToInt16(subcategoryNumber, CultureInfo.InvariantCulture)
                        }
                    });

                    Helpers.Utility.ConsoleLogger("GetSubCategoryDescription response: ", response);
                    if (response.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
                    {
                        subCategory = response.Description;
                        this.InterpError = "No";
                    }
                    else
                    {
                        this.InterpError = "Yes";
                        this.InterpErrorText = "Subcategory is not configurable";
                    }
                }
            }
            catch (SoapException ex)
            {
                this.InterpError = "Yes";
                this.InterpErrorText = ex.Message;
            }

            return subCategory;
        }

        /// <summary>
        /// Save New Interp object
        /// </summary>
        /// <param name="interpId">Interp id</param>
        public void SaveNewInterp(string interpId)
        {
            try
            {
                var response = ServiceClient.CreateInterpNarrative(new CreateInterpRequest()
                {
                    ApplicationId = ApplicationId,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Region = Region,
                    CorrespondenceLocation = CorrespondenceLocation,

                    Data = new CreateInterpNarrativeData()
                    {
                        Outline =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Outline),
                                CultureInfo.InvariantCulture),
                        Category =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Category),
                                CultureInfo.InvariantCulture),
                        SubCategory =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                                CultureInfo.InvariantCulture),
                        AdmitInterp =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.InterpId),
                                CultureInfo.InvariantCulture),
                        LineOfBusiness = LineOfBusiness.Professional
                    }
                });

                Helpers.Utility.ConsoleLogger("CreateInterpNarrative response: ", response);
                this.InterpMessage = string.Empty;
                this.ViewInterp = 0;
                this.CreateNewInterp = 0;
                if (response.Status == ResponseStatus.Success)
                {
                    this.ViewInterp = 1;
                    this.CreateNewInterp = 0;
                    this.InterpMessage = "Interp created successfully.";
                }
                else if (response.Status == ResponseStatus.Failure)
                {
                    this.ViewInterp = 0;
                    this.CreateNewInterp = 0;
                    this.InterpMessage = "Unable to create Interp - " + response.Errors[0].Message;
                }
            }
            catch (SoapException ex)
            {
                this.InterpMessage = ex.Message;
            }
        }

        /// <summary>
        /// Return Interp header
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <returns>Returns InquireInterpResponse object</returns>
        public InquireInterpResponse GetInterpHeader(string interpId)
        {
            var response = ServiceClient.InquireInterpNarrative(new InquireInterpRequest()
            {
                ApplicationId = ApplicationId,
                UserId = UserId,
                UnisysUsercode = UnisysUsercode,
                Region = Region,
                CorrespondenceLocation = CorrespondenceLocation,

                Data = new InquireInterpNarrativeData()
                {
                    Outline =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Outline),
                            CultureInfo.InvariantCulture),
                    Category =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Category),
                            CultureInfo.InvariantCulture),
                    SubCategory =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                            CultureInfo.InvariantCulture),
                    AdmitInterp =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.InterpId),
                            CultureInfo.InvariantCulture),
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = Status.Maintenance
                }
            });
            Helpers.Utility.ConsoleLogger("GetInterpHeader:InquireInterpNarrative response: ", response);

            return response;
        }

        /// <summary>
        /// Return Interp header
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <param name="status">interp status</param>
        /// <returns>Returns InquireInterpResponse object</returns>
        public SimpleInterpResponse GetInterp(string interpId, InterpStatus status)
        {
            var response = ServiceClient.GetInterp(new InquireRequest()
            {
                ApplicationId = ApplicationId,
                UserId = UserId,
                UnisysUsercode = UnisysUsercode,
                Region = Region,
                CorrespondenceLocation = CorrespondenceLocation,

                Data = new InquireInputData()
                {
                    Outline =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Outline),
                            CultureInfo.InvariantCulture),
                    Category =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Category),
                            CultureInfo.InvariantCulture),
                    SubCategory =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                            CultureInfo.InvariantCulture),
                    AdmitInterp =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.InterpId),
                            CultureInfo.InvariantCulture),
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = status
                }
            });

            return response;
        }

        /// <summary>
        /// Return Interp details
        /// </summary>
        /// <param name="interpId">Interp id</param>
        /// <param name="status">inter status</param>
        /// <returns>Returns detail response object</returns>
        public DetailedInterpResponse GetInterpDetails(string interpId, InterpStatus status)
        {
            var response = ServiceClient.GetInterpDetail(new InquireRequest()
            {
                ApplicationId = ApplicationId,
                UserId = UserId,
                UnisysUsercode = UnisysUsercode,
                Region = Region,
                CorrespondenceLocation = CorrespondenceLocation,
                Data = new InquireInputData()
                {
                    Outline =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Outline),
                            CultureInfo.InvariantCulture),
                    Category =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Category),
                            CultureInfo.InvariantCulture),
                    SubCategory =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                            CultureInfo.InvariantCulture),
                    AdmitInterp =
                        short.Parse(
                            this.GetInterpSection(interpId, InterpIdSection.InterpId),
                            CultureInfo.InvariantCulture),
                    LineOfBusiness = LineOfBusiness.Professional,
                    Status = status
                }
            });

            return response;
        }

        /// <summary>
        /// Method to Update interp config
        /// </summary>
        /// <param name="interpId">interp id</param>
        /// <param name="interp">interp type object</param>
        public void UpdateInterpConfig(string interpId, List<InterpJsonData> interp)
        {
            this.InterpMessage = string.Empty;
            this.UpdateInterp = 1;
            try
            {
                List<ConditionalStep> conditionalSteps = BuildConditionalSteps(interp);
                List<ExceptionStep> exceptionSteps = BuildExceptionData(interp);
                List<UnconditionalStep> unconditionalSteps = BuildUnConditionalSteps(interp);

                var response = ServiceClient.UpdateInterpConfig(new UpdateInterpDetailRequest()
                {
                    ApplicationId = ApplicationId,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Region = Region,
                    CorrespondenceLocation = CorrespondenceLocation,

                    Data = new InterpDetailData()
                    {
                        Outline =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Outline),
                                CultureInfo.InvariantCulture),
                        Category =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Category),
                                CultureInfo.InvariantCulture),
                        SubCategory =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                                CultureInfo.InvariantCulture),
                        AdmitInterp =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.InterpId),
                                CultureInfo.InvariantCulture),
                        LineOfBusiness = LineOfBusiness.Professional,
                        CurrentStatus = InterpStatus.Draft,
                        EmployeeNumber = Regex.Replace(membership.UserId, "[^0-9]", string.Empty).ToInt16(),
                        EmployeeRegion = membership.RegionCode.ToString().FromString<Plan>(),
                        ConfiguredSteps = new ConfiguredSteps()
                        {
                            ConditionalSteps = conditionalSteps.Count() > 0 ? conditionalSteps.ToArray() : null,
                            ExceptionSteps = exceptionSteps.Count() > 0 ? exceptionSteps.ToArray() : null,
                            UnconditionalSteps = unconditionalSteps.Count() > 0 ? unconditionalSteps.ToArray() : null
                        }
                    }
                });

                switch (response.Status)
                {
                    case ResponseStatus.Failure:
                        this.InterpMessage = "Unable to update Interp - " + response.Errors[0].Message;
                        break;
                    case ResponseStatus.Success:
                        this.UpdateInterp = 0;
                        this.InterpMessage = "Interp successfully saved.";
                        break;
                    case ResponseStatus.Rejected:
                        this.InterpMessage = "Unable to update Interp - " + response.Errors[0].Prop + ' ' + response.Errors[0].Message;
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                this.InterpMessage = ex.Message;
            }
        }

        /// <summary>
        /// Method to Update interp narrative
        /// </summary>
        /// <param name="interpId">interp id number</param>
        /// <param name="lineData">line data</param>
        public void UpdateInterpNarrative(string interpId, List<string> lineData)
        {
            try
            {
                this.InterpMessage = string.Empty;
                this.UpdateNarrative = 1;
                var response = ServiceClient.UpdateInterpNarrative(new UpdateInterpRequest()
                {
                    ApplicationId = ApplicationId,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Region = Region,
                    CorrespondenceLocation = CorrespondenceLocation,
                    Data = new UpdateInterpNarrativeData
                    {
                        Outline =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Outline),
                                CultureInfo.InvariantCulture),
                        Category =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Category),
                                CultureInfo.InvariantCulture),
                        SubCategory =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.Subcategory),
                                CultureInfo.InvariantCulture),
                        AdmitInterp =
                            short.Parse(
                                this.GetInterpSection(interpId, InterpIdSection.InterpId),
                                CultureInfo.InvariantCulture),
                        LineOfBusiness = LineOfBusiness.Professional,
                        Status = Status.Maintenance,
                        NarrativeLines = lineData.ToArray()
                    }
                });

                switch (response.Status)
                {
                    case ResponseStatus.Failure:
                        this.InterpMessage = "Unable to update Interp pseudocode - " + response.Errors[0].Message;
                        break;
                    case ResponseStatus.Success:
                        this.UpdateNarrative = 0;
                        this.InterpMessage = "Interp pseudocode successfully saved.";
                        break;
                    case ResponseStatus.Rejected:
                        this.InterpMessage = "Unable to update Interp pseudocode - " + response.Errors[0].Prop + ' ' + response.Errors[0].Message;
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                this.InterpMessage = ex.Message;
            }
        }

        /// <summary>
        /// Delete Interp object
        /// </summary>
        /// <param name="interpId">Interp id</param>
        public void DeleteInterp(string interpId)
        {
            try
            {
                this.InterpMessage = string.Empty;
                this.DeleteStatus = 1;
                var response = ServiceClient.DeleteInterp(new DeleteCipInterpRequest()
                {
                    ApplicationId = ApplicationId,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Region = Region,
                    CorrespondenceLocation = CorrespondenceLocation,

                    Data = new DeleteCipInterpData()
                    {
                        Outline = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Outline), CultureInfo.InvariantCulture),
                        Category = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Category), CultureInfo.InvariantCulture),
                        SubCategory = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Subcategory), CultureInfo.InvariantCulture),
                        AdmitInterp = short.Parse(this.GetInterpSection(interpId, InterpIdSection.InterpId), CultureInfo.InvariantCulture),
                        LineOfBusiness = LineOfBusiness.Professional
                    }
                });

                switch (response.Status)
                {
                    case ResponseStatus.Failure:
                        this.InterpMessage = "Unable to delete Interp - " + response.Errors[0].Message;
                        break;
                    case ResponseStatus.Success:
                        this.DeleteStatus = 0;
                        this.InterpMessage = "Interp draft successfully deleted.";
                        break;
                    case ResponseStatus.Rejected:
                        this.InterpMessage = "Unable to delete Interp - " + response.Errors[0].Prop + ' ' + response.Errors[0].Message;
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                this.InterpMessage = ex.Message;
            }
        }

        /// <summary>
        /// Update Interp Status object
        /// </summary>
        /// <param name="interpId">Interp id</param>
        /// <param name="currentStatus">Current status</param>
        /// <param name="targetStatus">Target status</param>
        public void UpdateInterpStatus(string interpId, string currentStatus, string targetStatus)
        {
            try
            {
                this.InterpMessage = string.Empty;
                this.UpdateStatusStatus = 1;
                var response = ServiceClient.UpdateInterpStatus(new StatusChangeRequest()
                {
                    ApplicationId = ApplicationId,
                    UserId = UserId,
                    UnisysUsercode = UnisysUsercode,
                    Region = Region,
                    CorrespondenceLocation = CorrespondenceLocation,

                    Data = new StatusData()
                    {
                        Outline = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Outline), CultureInfo.InvariantCulture),
                        Category = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Category), CultureInfo.InvariantCulture),
                        SubCategory = short.Parse(this.GetInterpSection(interpId, InterpIdSection.Subcategory), CultureInfo.InvariantCulture),
                        AdmitInterp = short.Parse(this.GetInterpSection(interpId, InterpIdSection.InterpId), CultureInfo.InvariantCulture),
                        LineOfBusiness = LineOfBusiness.Professional,
                        CurrentStatus = currentStatus.FromString<InterpStatus>(),
                        TargetStatus = targetStatus.FromString<InterpStatus>()
                    }
                });

                switch (response.Status)
                {
                    case ResponseStatus.Failure:
                        this.InterpMessage = "Unable to update Interp status - " + response.Errors[0].Message;
                        break;
                    case ResponseStatus.Success:
                        this.UpdateStatusStatus = 0;
                        this.InterpMessage = "Interp status updated successfully.";
                        break;
                    case ResponseStatus.Rejected:
                        this.InterpMessage = "Unable to update Interp status - " + response.Errors[0].Prop + ' ' + response.Errors[0].Message;
                        break;
                    default:
                        break;
                }
            }
            catch (SoapException ex)
            {
                this.InterpMessage = ex.Message;
            }
        }

        /// <summary>
        /// Gets the BlueBridgeUser information if not already populated;
        /// </summary>
        private static void GetMembership()
        {
            if (membership == null)
            {
                membership = new Membership();
                Helpers.Utility.ConsoleLogger(membership);
            }
        }

        /// <summary>
        /// Method to build Conditional Steps
        /// </summary>
        /// <param name="interp">interp type object</param>
        /// <returns>conditional steps</returns>
        private static List<ConditionalStep> BuildConditionalSteps(List<InterpJsonData> interp)
        {
            List<ConditionalStep> conditionSteps = new List<ConditionalStep>();
            ConditionalStep configCondition = new ConditionalStep();
            foreach (InterpJsonData item in interp)
            {
                if (item.ConditionData != null)
                {
                    List<Service.Condition> conditions = new List<Service.Condition>();

                    foreach (JsonCondition condition in item.ConditionData.Conditions)
                    {
                        RecordValueType parmType = (RecordValueType)condition.CompareValue.Id;
                        List<NumericValueWithThru> numericParam = new List<NumericValueWithThru>();
                        List<DecimalValueWithThru> decimalParam = new List<DecimalValueWithThru>();
                        List<AlphaValueWithThru> alphaParam = new List<AlphaValueWithThru>();
                        switch (parmType)
                        {
                            case RecordValueType.Numeric:
                                numericParam = BuildConditionalNumericParameters(condition.CompareValue.Value);
                                break;
                            case RecordValueType.Decimal:
                                decimalParam = BuildConditionalDecimalParameters(condition.CompareValue.Value);
                                break;
                            default:
                                alphaParam = BuildConditionalAlphaParameters(condition.CompareValue.Value);
                                break;
                        }

                        Service.Condition conCondition = new Service.Condition
                        {
                            AlphaParameters = alphaParam.Count() > 0 ? alphaParam.ToArray() : null,
                            DecimalParameters = decimalParam.Count() > 0 ? decimalParam.ToArray() : null,
                            NumericParameters = numericParam.Count() > 0 ? numericParam.ToArray() : null,
                            FieldNumber = condition.FieldName.Id,
                            FieldType = (ConfigInterp.Contracts.DataContracts.FieldType)condition.FieldType.Id,
                            ParameterType = parmType,
                            Operation = (ConditionOperation)condition.ConditionType.Id,
                            CompareType = (ConfigInterp.Contracts.DataContracts.CompareType)condition.CompareType.Id
                            ////Qualifier is not mapped 
                            ////Qualifier = ? 
                        };

                        conditions.Add(conCondition);
                    }

                    List<Service.StepAction> falseActions = new List<Service.StepAction>();
                    List<Service.StepAction> trueActions = new List<Service.StepAction>();
                    if (item.ConditionData.Actions != null)
                    {
                        foreach (var actions in item.ConditionData.Actions)
                        {
                            if (actions.Result.Id == 7)
                            {
                                trueActions.Add(BuildAction(actions));
                            }
                            else
                            {
                                falseActions.Add(BuildAction(actions));
                            }
                        }
                    }

                    configCondition.Index = item.Step.ToInt16();
                    configCondition.Conditions = conditions.ToArray();
                    configCondition.TrueActions = trueActions.Count() > 0 ? trueActions.ToArray() : null;
                    configCondition.FalseActions = falseActions.Count() > 0 ? falseActions.ToArray() : null;
                    conditionSteps.Add(configCondition);
                }
            }

            return conditionSteps;
        }

        /// <summary>
        /// Method to Build Exception Data
        /// </summary>
        /// <param name="interp">interp type object</param>
        /// <returns>exceptions list</returns>
        private static List<ExceptionStep> BuildExceptionData(List<InterpJsonData> interp)
        {
            List<Service.ExceptionStep> exceptions = new List<Service.ExceptionStep>();
            foreach (InterpJsonData item in interp)
            {
                if (item.ExceptionData != null)
                {
                    exceptions.Add(new ExceptionStep
                    {
                        Index = item.Step.ToInt16(),
                        ExceptionId = item.ExceptionData.Id.ToInt16()
                    });
                }
            }

            return exceptions;
        }

        /// <summary>
        /// Method to build Unconditional Steps
        /// </summary>
        /// <param name="interp">interp type object</param>
        /// <returns>unconditional steps</returns>
        private static List<UnconditionalStep> BuildUnConditionalSteps(List<InterpJsonData> interp)
        {
            List<UnconditionalStep> unconditionalSteps = new List<UnconditionalStep>();

            foreach (InterpJsonData item in interp)
            {
                if (item.ActionData != null)
                {
                    unconditionalSteps.Add(new UnconditionalStep
                    {
                        Action = BuildAction(item.ActionData),
                        Index = item.Step.ToInt16()
                    });
                }
            }

            return unconditionalSteps;
        }

        /// <summary>
        /// Method to build Action 
        /// </summary>
        /// <param name="action">action type object</param>
        /// <returns>step action</returns>
        private static StepAction BuildAction(JsonActionStep action)
        {
            StepAction stepAction = new StepAction();
            List<NumericValue> numericValues = new List<NumericValue>();
            List<DecimalValue> decimalValues = new List<DecimalValue>();
            List<AlphaValue> alphaValues = new List<AlphaValue>();
            if (action != null)
            {
                stepAction.ActionId = action.ActionName != null ? action.ActionName.Id.ToInt16() : "0".ToInt16();

                for (int i = 1; i < 6; i++)
                {
                    JsonDataDetail details = (JsonDataDetail)action.GetType().GetProperty("Parameter" + i).GetValue(action);
                    switch ((RecordValueType)details.Id)
                    {
                        case RecordValueType.Alpha:
                            alphaValues.Add(new AlphaValue { Value = details.Value });
                            break;
                        case RecordValueType.Numeric:
                            numericValues.Add(new NumericValue { Value = details.Value.Replace("-", string.Empty).ToInt32() });
                            break;
                        case RecordValueType.Decimal:
                            decimalValues.Add(new DecimalValue { Value = details.Value.ToDecimal() });
                            break;
                        default:
                            break;
                    }
                }

                stepAction.DecimalParameters = decimalValues.Count > 0 ? decimalValues.ToArray() : null;
                stepAction.AlphaParameters = alphaValues.Count > 0 ? alphaValues.ToArray() : null;
                stepAction.NumericParameters = numericValues.Count > 0 ? numericValues.ToArray() : null;
            }

            return stepAction;
        }

        /// <summary>
        /// Method to build conditional alpha parameters
        /// </summary>
        /// <param name="value">condition type object</param>
        /// <returns>alpha values</returns>
        private static List<AlphaValueWithThru> BuildConditionalAlphaParameters(string value)
        {
            List<AlphaValueWithThru> alphaValues = new List<AlphaValueWithThru>();
            List<string> values = value.Split(',').ToList();
            foreach (string item in values)
            {
                string[] parts = item.Trim().Split('-');
                if (parts.Length == 1)
                {
                    alphaValues.Add(new AlphaValueWithThru { Value = parts[0].Trim(), ValueThru = string.Empty });
                }
                else
                {
                    alphaValues.Add(new AlphaValueWithThru { Value = parts[0].Trim(), ValueThru = parts[1].Trim() });
                }
            }

            return alphaValues;
        }

        /// <summary>
        /// Method to build conditional decimal parameters
        /// </summary>
        /// <param name="value">condition type object</param>
        /// <returns>decimal values</returns>
        private static List<DecimalValueWithThru> BuildConditionalDecimalParameters(string value)
        {
            List<DecimalValueWithThru> decimalValues = new List<DecimalValueWithThru>();
            List<string> values = value.Split(',').ToList();
            foreach (string item in values)
            {
                string[] parts = item.Trim().Split('-');
                if (parts.Length == 1)
                {
                    decimalValues.Add(new DecimalValueWithThru { Value = parts[0].ToDecimal(), ValueThru = 0 });
                }
                else
                {
                    decimalValues.Add(new DecimalValueWithThru { Value = parts[0].ToDecimal(), ValueThru = parts[1].ToDecimal() });
                }
            }

            return decimalValues;
        }

        /// <summary>
        /// Method to build conditional numeric parameters
        /// </summary>
        /// <param name="value">condition type object</param>
        /// <returns>numeric values</returns>
        private static List<NumericValueWithThru> BuildConditionalNumericParameters(string value)
        {
            List<NumericValueWithThru> numericValues = new List<NumericValueWithThru>();
            List<string> values = value.Split(',').ToList();
            foreach (string item in values)
            {
                string[] parts = item.Trim().Split('-');
                if (parts.Length == 1)
                {
                    numericValues.Add(new NumericValueWithThru { Value = parts[0].ToInt32(), ValueThru = 0 });
                }
                else
                {
                    numericValues.Add(new NumericValueWithThru { Value = parts[0].ToInt32(), ValueThru = parts[1].ToInt32() });
                }
            }

            return numericValues;
        }

        /// <summary>
        /// Verify Interp
        /// </summary>
        /// <param name="outline">outline value</param>
        /// <param name="category">category value</param>
        /// <param name="subcategory">subcategory value</param>
        /// <param name="interpId">interp id value</param>
        private void VerifyInterp(string outline, string category, string subcategory, string interpId)
        {
            try
            {
                if (interpId.Length == 4)
                {
                    var response = ServiceClient.InquireInterpNarrative(new InquireInterpRequest()
                    {
                        ApplicationId = ApplicationId,
                        UserId = UserId,
                        UnisysUsercode = UnisysUsercode,
                        Region = Region,
                        CorrespondenceLocation = CorrespondenceLocation,

                        Data = new InquireInterpNarrativeData()
                        {
                            Outline = short.Parse(outline, CultureInfo.InvariantCulture),
                            Category = short.Parse(category, CultureInfo.InvariantCulture),
                            SubCategory = short.Parse(subcategory, CultureInfo.InvariantCulture),
                            AdmitInterp = short.Parse(interpId, CultureInfo.InvariantCulture),
                            LineOfBusiness = LineOfBusiness.Professional,
                            Status = Status.None
                        }
                    });

                    Helpers.Utility.ConsoleLogger("VerifyInterp:InquireInterpNarrative Response: ", response);

                    this.InterpMessage = string.Empty;
                    this.ViewInterp = 0;
                    this.CreateNewInterp = 0;
                    if (response.Status == ResponseStatus.Success)
                    {
                        this.ViewInterp = 0;
                        this.CreateNewInterp = 1;
                        this.InterpMessage = "Interp available for configuration";
                    }
                    else
                    {
                        this.ViewInterp = 1;
                        this.CreateNewInterp = 0;
                        if (response.FailureReason == OperationResult.AlreadyExists)
                        {
                            this.InterpMessage = "Interp already exists.";
                        }
                        else
                        {
                            this.InterpMessage = "Interp is not configurable";
                        }
                    }
                }
            }
            catch (SoapException ex)
            {
                this.InterpError = "Yes";
                this.InterpErrorText = ex.Message;
            }
        }
    }
}