//----------------------------------------------------------------
// <copyright file="InterpController.cs" company="CoreLink">
//     Copyright © CoreLink 2013. All rights reserved.
// </copyright>
//---------------------------------------------------------------- 
namespace Product.ConfigurableInterp.Client.Controllers
{
    #region references
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    using Models;
    using ServiceCode;

    #endregion references
    /// <summary>
    /// Interp Controller class
    /// </summary>
    public class InterpController : Controller
    {
        /// <summary>
        /// Gets Interp Id from Form values for view interp
        /// </summary>
        public string ViewInterpId
        {
            get
            {
                return this.GetRequestQueryStringValue("InterpQueryId");
            }
        }

        /// <summary>
        /// Gets Interp Id from Query string values
        /// </summary>
        public string InterpId
        {
            get
            {
                return this.GetRequestQueryStringValue("InterpQueryId");
            }
        }

        /// <summary>
        /// Gets Action Type from Query string values
        /// </summary>
        public string ActionType
        {
            get
            {
                return this.GetRequestQueryStringValue("Type");   

            }
        }

        /// <summary>
        /// Gets Step Number from Query string values
        /// </summary>
        public int StepNo
        {
            get
            {
                return Request.QueryString.HasKeys() ? int.Parse(Request.QueryString["StepNo"], CultureInfo.InvariantCulture) : 1;
            }
        }

        /// <summary>
        /// Gets CRI Mock Interp Model Object
        /// </summary>
        public Interp ViewInterpModel
        {
            get
            {
                return CriInterpClientData.GetInterpDetails(this.ViewInterpId);
            }
        }

        /// <summary>Controller Code for Error View</summary>
        /// <returns>Action Result</returns>
        public ActionResult Error()
        {
            return View();
        }

        /// <summary>Controller Code for Index View</summary>
        /// <remarks>
        /// Passing the Dashboard model into the View.
        /// </remarks>        
        /// <returns>Action Result</returns>
        public ActionResult Index()
        {
            try
            {
                ViewBag.Version = " v" + Assembly.GetExecutingAssembly().GetName().Version;
                ViewBag.PageTitle = "   Dashboard";
            }
            catch (EndpointNotFoundException)
            {
            }

            return this.View(CriInterpClientData.DashboardModel);
        }

        /// <summary>Get Interp Section Values from the services</summary>
        /// <remarks>
        /// Using the services provided by the corelink team,
        /// get values for outline, category, Sub Category and Interp
        /// </remarks>        
        /// <returns>Action result</returns>
        public ActionResult InterpSections()
        {
            var interpId = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToString() : string.Empty;
            Helpers.Utility.ConsoleLogger("Got into the InterpSections with: " + interpId);
            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(
                    new
                    {
                        Outline_Number = string.Empty,
                        Outline_Description = string.Empty,
                        Category_Number = string.Empty,
                        Category_Description = string.Empty,
                        SubCategory_Number = string.Empty,
                        SubCategory_Description = string.Empty,
                        InterpId_Number = string.Empty,
                        Level_Description = string.Empty,
                        InterpEror = "No",
                        InterpErrorText = string.Empty,
                        CreateNewInterp = 0,
                        ViewInterp = 0,
                        InterpMessage = string.Empty
                    },
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                var client = new InterpClientData();
                Models.InterpSections interp = new InterpSections(client, interpId, true);

                var jsonReturn = this.Json(
                    new
                    {
                        Outline_Number = interp.OutlineNumber,
                        Outline_Description = interp.OutlineDescription,
                        Category_Number = interp.CategoryNumber,
                        Category_Description = interp.CategoryDescription,
                        SubCategory_Number = interp.SubcategoryNumber,
                        SubCategory_Description = interp.SubcategoryDescription,
                        InterpId_Number = interp.InterpIdNumber,
                        Level_Description = interp.LevelDisplay,
                        InterpEror = client.InterpError,
                        InterpErrorText = client.InterpErrorText,
                        CreateNewInterp = client.CreateNewInterp,
                        ViewInterp = client.ViewInterp,
                        InterpMessage = client.InterpMessage
                    },
                    JsonRequestBehavior.AllowGet);
                Helpers.Utility.ConsoleLogger("InterpSections return value: ", jsonReturn);
                return jsonReturn;
            }
        }

        /// <summary>Get Field Names Values from the services</summary>
        /// <remarks>
        /// Using the services provided by the corelink team,
        /// get values for Field Names
        /// </remarks>      
        /// <param name="compareTypeId">Compare Type</param>
        /// <param name="elementId">Element ID</param>
        /// <param name="fieldNameIdContainer">Field Name</param>
        /// <param name="compareDropDown">Compare ID</param>
        /// <returns>Action result</returns>
        public ActionResult FieldTypes(string compareTypeId, string elementId, string fieldNameIdContainer, string compareDropDown)
        {
            var fieldTypeSelectList = new List<SelectListItem>();
            var fieldType = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 1;
            var fieldNameResponse = InterpClientData.GetFieldnames(fieldType, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
            var result = string.Empty;

            if (fieldNameResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
            {
                foreach (var item in fieldNameResponse.Descriptions)
                {
                    if (result.Length > 0)
                    {
                        fieldTypeSelectList.Add(new SelectListItem() { Text = item.FieldDescription, Value = item.FieldId });
                    }
                    else
                    {
                        result = item.FieldId + " = " + item.FieldDescription;
                    }
                }

                ViewBag.FieldTypeList = fieldTypeSelectList;
                ViewBag.CompareToValues = compareTypeId;
                ViewBag.ElementId = elementId;
                ViewBag.ContainerId = compareTypeId;
                ViewBag.CompareDropDown = compareDropDown;
            }

            return PartialView("_fieldTypes");
        }

        /// <summary>Get Compare types Values from the services</summary>
        /// <remarks>
        /// Using the services provided by the corelink team,
        /// get values for Compare types
        /// </remarks>        
        /// <param name="elementId">Element ID</param>
        /// <returns>Action result</returns>
        public ActionResult CompareTypes(string elementId)
        {
            var compareTypeList = new List<SelectListItem>();

            var fieldName = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 1;
            var compareTypeResponse = InterpClientData.GetCompareTypes(fieldName, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
            var result = string.Empty;
            if (compareTypeResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
            {
                foreach (var item in compareTypeResponse.Descriptions)
                {
                    if (result.Length > 0)
                    {
                        compareTypeList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                    else
                    {
                        compareTypeList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                }

                ViewBag.CompareTypeList = compareTypeList;
                ViewBag.ElementId = elementId;
            }

            return PartialView("_compareTypeDropdown");
        }

        /// <summary>Get Action names Values from the services</summary>
        /// <remarks>
        /// Using the services provided by the corelink team,
        /// get values for Action names populates dynamic DropDown list
        /// </remarks>        
        /// <returns>Action result</returns>
        public ActionResult ActionNames()
        {
            var actionType = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 1;
            var actionResponse = InterpClientData.GetActions(actionType, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
            var result = string.Empty;
            if (actionResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
            {
                var fieldNameSelectList = new List<SelectListItem>();

                foreach (var item in actionResponse.Descriptions)
                {
                    if (result.Length > 0)
                    {
                        fieldNameSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                    else
                    {
                        fieldNameSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                }

                ViewBag.ActionNameList = fieldNameSelectList;
            }

            return PartialView("_ActionName");
        }

        /// <summary>
        /// Gets action helper text and values
        /// </summary>
        /// <param name="actionId">action id</param>
        /// <returns>object or properties</returns>
        public JsonResult GetActionFormatHintDescription(int actionId)
        {
            var actionFormatHint = InterpClientData.GetActionParameterDescriptionValidationInfo(actionId);
            return Json(actionFormatHint, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets actions
        /// </summary>
        /// <returns>list of actions</returns>
        public JsonResult ActionNamesJson()
        {
            var actionType = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 1;
            var actionResponse = InterpClientData.GetActions(actionType, ConfigInterp.Contracts.DataContracts.LineOfBusiness.Professional);
            var result = string.Empty;
            var fieldNameSelectList = new List<SelectListItem>();
            if (actionResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success)
            {
                foreach (var item in actionResponse.Descriptions)
                {
                    if (result.Length > 0)
                    {
                        fieldNameSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                    else
                    {
                        fieldNameSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TypeId.ToString() });
                    }
                }
            }

            return Json(fieldNameSelectList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the field validation needed for selected condition fields
        /// </summary>
        /// <returns>Action result</returns>
        public ActionResult FieldValidation()
        {
            var fieldId = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 0;
            var typeId = this.Request.QueryString.Keys.Count > 1 ? Request.QueryString[1].ToInt32() : 0;

            if (fieldId > 0 && typeId > 0)
            {
                var fieldValidationResponse = InterpClientData.GetFieldValidationInfo(fieldId, typeId);
                if (fieldValidationResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success && fieldValidationResponse.Data != null && fieldValidationResponse.Data.Length > 0)
                {
                    var dataResponse = fieldValidationResponse.Data[0];

                    // This may have to be converted to an array if is found that the Data object actually returns more than one item.
                    FieldValidationInfoData data = new FieldValidationInfoData()
                    {
                        FormatDescription = dataResponse.FormatDescription,
                        FormatInputHintDescription = dataResponse.FormatInputHintDescription,
                        FormatInputPattern = dataResponse.FormatInputPattern,
                        FormatTypeId = dataResponse.FormatTypeId,
                        MaxSize = dataResponse.MaxSize,
                        MinSize = dataResponse.MinSize,
                        QualifierTypeNumber = dataResponse.QualifierTypeNumber,
                        ValueTypeId = dataResponse.ValueTypeId
                    };
                    return this.Json(new { data }, JsonRequestBehavior.AllowGet);
                }
            }

            return this.Json(new { DBNull.Value }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the action parameter description validation needed for selected action fields
        /// </summary>
        /// <returns>Action result</returns>
        public ActionResult ActionParameterDescriptionValidation()
        {
            var actionId = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToInt32() : 0;

            if (actionId > 0)
            {
                var actionParameterResponse = InterpClientData.GetActionParameterDescriptionValidationInfo(actionId);
                if (actionParameterResponse.Status == ConfigInterp.Contracts.DataContracts.ResponseStatus.Success && actionParameterResponse.Data != null && actionParameterResponse.Data.Length > 0)
                {
                    List<ActionParameterDescriptionValidationInfoData> dataReturn = new List<ActionParameterDescriptionValidationInfoData>();

                    foreach (var dataResponse in actionParameterResponse.Data)
                    {
                        ActionParameterDescriptionValidationInfoData data = new ActionParameterDescriptionValidationInfoData()
                        {
                            FormatDescription = dataResponse.FormatDescription,
                            FormatInputHintDescription = dataResponse.FormatInputHintDescription,
                            FormatInputPattern = dataResponse.FormatInputPattern,
                            FormatTypeId = dataResponse.FormatTypeId,
                            MaxSize = dataResponse.MaximumSize,
                            MinSize = dataResponse.MinimumSize,
                            OrderSequence = dataResponse.OrderSequence,
                            IsOptional = dataResponse.IsOptional,
                            ParameterDescription = dataResponse.ParameterDescription,
                            ParameterPseudoDescription = dataResponse.ParameterPseudoDescription,
                            ValueTypeId = dataResponse.ValueTypeId
                        };
                        dataReturn.Add(data);
                    }

                    return this.Json(new { dataReturn }, JsonRequestBehavior.AllowGet);
                }
            }

            return this.Json(new { DBNull.Value }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Save New Interp
        /// </summary>
        /// <returns>Action Result</returns>
        public ActionResult SaveNewInterp()
        {
            var interpId = this.Request.QueryString.Keys.Count > 0 ? Request.QueryString[0].ToString() : string.Empty;
            Helpers.Utility.ConsoleLogger("SaveNewInterp with: " + interpId);
            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(new { CreateNewInterp = 0, ViewInterp = 0, InterpMessage = string.Empty }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var client = new InterpClientData();
                client.SaveNewInterp(interpId);
                var retJson = this.Json(new { CreateNewInterp = client.CreateNewInterp, ViewInterp = client.ViewInterp, InterpMessage = client.InterpMessage }, JsonRequestBehavior.AllowGet);
                Helpers.Utility.ConsoleLogger("SaveNewInterp return value = ", retJson);
                return retJson;
            }
        }

        /// <summary>Controller Code for getting values in Create New Interp Partial View</summary>
        /// <remarks>
        /// Passing the Create New Interp Partial view on Dashboard button click
        /// </remarks>
        /// <returns>Action result</returns>
        [HttpGet]
        public ActionResult CreateNewInterp()
        {
            var model = new NewInterpModel();
            try
            {
                ViewBag.PageTitle = "Create New Interp";
            }
            catch (EndpointNotFoundException)
            {
            }

            return this.PartialView("_CreateNewInterp", model);
        }

        /// <summary>Controller Code for Edit View</summary>
        /// <remarks>
        /// Passing the model into the View.        
        /// </remarks>
        /// <returns>Action result</returns>
        public ActionResult EditInterp()
        {
            try
            {
                ViewBag.PageTitle = "(Edit Mode)";
            }
            catch (EndpointNotFoundException)
            {
            }

            return this.View(this.ViewInterpModel);
        }

        /// <summary>
        /// Save Interp details
        /// </summary>
        /// <param name="interpId">Interp id</param>
        /// <param name="data">Interp Json data</param>
        /// <returns>Action result</returns>
        public ActionResult SaveInterpDetails(string interpId, string data)
        {
            string responseMessage = string.Empty;

            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(new { UpdateInterp = 1, UpdateNarrative = 1, InterpMessage = "Unable to save Interp." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<InterpJsonData> steps = DeserializeInterp(data);
                var client = new InterpClientData();
                client.UpdateInterpConfig(interpId, steps);
                responseMessage = client.InterpMessage;

                List<string> lines = GeneratePseudocode(steps);
                client.UpdateInterpNarrative(interpId, lines);
                responseMessage += "<br/>" + client.InterpMessage;
                var retJson = this.Json(new { client.UpdateInterp, client.UpdateNarrative, InterpMessage = responseMessage }, JsonRequestBehavior.AllowGet);
                return retJson;
            }
        }

        /// <summary>
        /// Save Interp details
        /// </summary>
        /// <param name="interpId">Interp id</param>
        /// <param name="data">Interp Json data</param>
        /// <returns>Action result</returns>
        public ActionResult ViewPseudocode(string interpId, string data)
        {
            string responseMessage = string.Empty;
            // TODO : work in progress
            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(new { data = "Bad Request." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<InterpJsonData> steps = DeserializeInterp(data);
                List<string> lines = GeneratePseudocode(steps);
                var retJson = this.Json(new { data = lines }, JsonRequestBehavior.AllowGet);
                return retJson;
            }
        }

        /// <summary>Controller Code for adding New Actions Partial View</summary>
        /// <remarks>
        /// Passing the action id to create the id for div tag dynamically
        /// Using the model and passing it to the View to populate the Action dropdown lists
        /// </remarks>
        /// <param name="rowPosition">Row position</param>
        /// <param name="conditionType">Condition Type</param>
        /// <returns>Action Result</returns>
        public ActionResult AddConditionsActionsStep(int? rowPosition, int? conditionType)
        {
            try
            {
                ViewBag.RowOrder = rowPosition == null ? 1 : rowPosition.Value;
                ViewBag.DivActionConditionStepID = Guid.NewGuid();
                var model = new Interp();
                CriInterpClientData.CreateNewActions(model);
                CriInterpClientData.CreateNewConditions(model);
                model.ActionObject.StepNumber = this.StepNo;
                switch (this.ActionType)
                {
                    case "Conditions":
                        ViewBag.NoConditions = "hidden";
                        ViewBag.Conditions = "show";
                        ViewBag.NoActions = "show";
                        ViewBag.Actions = "hidden";
                        break;

                    case "Actions":
                        ViewBag.NoConditions = "show";
                        ViewBag.Conditions = "hidden";
                        ViewBag.NoActions = "hidden";
                        ViewBag.Actions = "show";
                        break;
                }

                if (rowPosition != null || rowPosition < 1)
                {
                    ViewBag.RowOrder = rowPosition = rowPosition + 1;
                    model.ConditionObject.SelectedConditionType = conditionType.ToString();
                    return this.PartialView("~/Views/Interp/_AddConditions.cshtml", model);
                }

                return this.PartialView("~/Views/Interp/_AddConditionsActionsStep.cshtml", model);
            }
            catch (EndpointNotFoundException)
            {
                return this.PartialView("~/Views/Interp/_AddConditionsActionsStep.cshtml");
            }
        }

        /// <summary>Controller Code for adding New Actions Partial View</summary>
        /// <remarks>
        /// Passing the action id to create the id for div tag dynamically
        /// Using the model and passing it to the View to populate the Action dropdown lists
        /// </remarks>
        /// <param name="firstException">first exception action</param>
        /// <param name="rowPosition">Row position</param>
        /// <returns>Action Result</returns>
        public ActionResult AddExceptionsStep(bool? firstException, int? rowPosition)
        {
            try
            {
                ViewBag.RowOrder = rowPosition == null ? 1 : rowPosition.Value;

                ViewBag.DivExceptionStepID = Guid.NewGuid();
                var model = new Interp();
                var exceptions = CriInterpClientData.NewExceptions.ToList();

                model.SetExceptions(exceptions);
                ViewBag.NoExceptions = "hidden";
                ViewBag.Exceptions = "show";

                if (firstException == null)
                {
                    exceptions[0].StepNumber = this.StepNo;
                    return this.PartialView("~/Views/Interp/_AddExceptionsStep.cshtml", model);
                }
                else
                {
                    exceptions[0].StepNumber = this.StepNo;
                    ViewBag.RowOrder = rowPosition = rowPosition + 1;
                    return this.PartialView("~/Views/Interp/_AddSequentialExceptionSteps.cshtml", model);
                }
            }
            catch (EndpointNotFoundException)
            {
                return this.PartialView("~/Views/Interp/_AddExceptionsStep.cshtml");
            }
        }

        /// <summary>
        /// Add action step
        /// </summary>
        /// <param name="firstAction">first action indicator</param>
        /// <param name="rowPosition">row position</param>
        /// <returns>Action Result</returns>
        public ActionResult AddActionStep(bool? firstAction, int? rowPosition)
        {
            try
            {
                ViewBag.RowOrder = rowPosition = rowPosition + 1;
                ViewBag.DivActionStepID = Guid.NewGuid();
                var model = new Interp();
                CriInterpClientData.CreateNewActions(model);
                ViewBag.NoActions = "hidden";
                ViewBag.Actions = "show";

                if (firstAction == null)
                {
                    model.ActionObject.StepNumber = this.StepNo == 0 ? 1 : this.StepNo;
                    return this.PartialView("~/Views/Interp/ActionStep.cshtml", model.ActionObject);
                }
                else
                {
                    ViewBag.RowOrder = rowPosition = rowPosition + 1;
                    return this.PartialView("~/Views/Interp/_AddSequentialAction.cshtml", model);
                }
            }
            catch (EndpointNotFoundException)
            {
                return this.PartialView("~/Views/Interp/ActionStep.cshtml");
            }
        }

        /// <summary>Controller Code for View Interp View</summary>
        /// <remarks>
        /// Passing the model into the View.
        /// </remarks>
        /// <returns>Action Result</returns>
        public ActionResult ViewInterp()
        {
            try
            {
                ViewBag.PageTitle = "Dashboard > Interp Details";
            }
            catch (EndpointNotFoundException)
            {
            }

            return this.View(this.ViewInterpModel);
        }

        /// <summary>
        /// Update Interp Status Action
        /// </summary>
        /// <param name="interpId">Interp ID</param>
        /// <param name="currentStatus">current status</param>
        /// <param name="targetStatus">target status</param>
        /// <returns>Action Result</returns>
        [HttpPost]
        public ActionResult UpdateInterpStatus(string interpId, string currentStatus, string targetStatus)
        {
            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(new { UpdateStatus = 1, InterpMessage = "Unable to update Interp status." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var client = new InterpClientData();
                client.UpdateInterpStatus(interpId, currentStatus, targetStatus);
                var retJson = this.Json(new { UpdateStatus = client.UpdateStatusStatus, InterpMessage = client.InterpMessage }, JsonRequestBehavior.AllowGet);
                return retJson;
            }
        }

        /// <summary>
        /// Delete Interp by Id
        /// </summary>
        /// <param name="interpId">Interp ID</param>
        /// <returns>Action Result</returns>
        [HttpPost]
        public ActionResult DeleteInterp(string interpId)
        {
            if (string.IsNullOrEmpty(interpId))
            {
                return this.Json(new { DeleteStatus = 1, InterpMessage = "Unable to delete Interp." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var client = new InterpClientData();
                client.DeleteInterp(interpId);
                var retJson = this.Json(new { DeleteStatus = client.DeleteStatus, InterpMessage = client.InterpMessage }, JsonRequestBehavior.AllowGet);
                return retJson;
            }
        }

        /// <summary>
        /// This will validate if the request has the desired field in it.
        /// </summary>
        /// <param name="name">The name of the field to be searched for</param>
        /// <returns>boolean return value.  True, the field name exists in the request string</returns>
        private bool CheckIfRequestFormFieldExists(string name)
        {
            if (string.IsNullOrEmpty(this.Request.Form[name]))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Retrieves the desired field name from the request string
        /// </summary>
        /// <param name="name">The field name wanted in the request</param>
        /// <returns>The value of the request field if it existed</returns>
        private string GetRequestQueryStringValue(string name)
        {
            string returnString = string.Empty;
            if (Request.QueryString.HasKeys())
            {
                returnString = Request.QueryString[name];
            }

            return returnString;
        }

        /// <summary>
        /// Deserializes the Json string into configuration steps
        /// </summary>
        /// <param name="data">json data</param>
        /// <returns>list of steps</returns>
        private List<InterpJsonData> DeserializeInterp(string data)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<InterpJsonData>>(data);
        }

        /// <summary>
        /// Deserializes the Json string into configuration steps
        /// </summary>
        /// <param name="data">json data</param>
        /// <returns>list of steps</returns>
        private List<string> GeneratePseudocode(List<InterpJsonData> data)
        {
            //TODO: take the input list and create the pseudocode per requirements document
            return new List<string>();
        }
    }
}
