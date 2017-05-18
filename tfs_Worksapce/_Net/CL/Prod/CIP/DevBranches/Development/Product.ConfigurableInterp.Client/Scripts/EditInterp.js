var conditionOperations = function () {
    $(document).on('click', '.delcondition', function (e) {
        $(this).closest(".ui-state-default").remove();
        //addNewException()
        setFormChanged();
    });

    $(document).on('click', '.movecondition', function (e) {
        $("#conditions").sortable({
            revert: true
        });

        $(this).closest(".condition-item").draggable({
            connectToSortable: "#sortable",
            helper: "clone",
            revert: "invalid"
        });

        $("ul, li").disableSelection();
        setFormChanged();
    });
};

var actionOperations = function () {
    $(document).on('click', '.delaction', function (e) {
        $(this).closest(".ui-state-default").remove();
        setFormChanged();
    });

    $(document).on('click', '.moveaction', function (e) {
        $("#actions").sortable({
            revert: true
        });

        $(this).closest(".action-item").draggable({
            connectToSortable: "#sortable",
            helper: "clone",
            revert: "invalid"
        });

        $("ul, li").disableSelection();
        setFormChanged();
    });
};

var exceptionOperation = function () {
    $(document).on('click', '.delexception', function (e) {
        $(this).closest(".ui-state-default").remove();
        setFormChanged();
    });

    $(document).on('click', '.moveexception', function (e) {

        $("#exceptions").sortable({
            revert: true
        });

        $(this).closest(".exception-item").draggable({
            connectToSortable: "#sortable",
            helper: "clone",
            revert: "invalid"
        });

        $("ul, li").disableSelection();
        setFormChanged();
    });
};

var GetQueryStringParams = function (sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] === sParam) {
            return sParameterName[1];
        }
    }
};

var StepNumber = 0;

function btnAddAction() {
    showProgress();
    $.ajax({
        data: {
            InterpQueryId: GetQueryStringParams("InterpQueryId"),
            StepNo: ++StepNumber
        },
        url: 'AddActionStep'
    }).success(function (partialView) {
        $('#add_steps').append(partialView);
        hideProgress();
        setFormChanged();
    });
}

function GetValidationType(thiselement, FieldName, CompareTypeInputField) {
    if ($('#' + CompareTypeInputField).is(':visible')) {

        $('#' + CompareTypeInputField).nextUntil('.InterpEditTextBox').attr("onfocusout", "ValidateValues();");
    }
}

function ValidateValues() {
    alert('Validation On the way');
}

function fieldNameChange(element, replacementContainer, InputSelectorCompareValues, keywordvalue) {
    setFormChanged();
    if ($("#" + keywordvalue).val() !== "5") {

        var data = { fieldName: $(element).val(), elementId: InputSelectorCompareValues };

        DynamicSelectList(element, replacementContainer, 'CompareTypes', data);
    }
}

function GetActionNames(element, replacementContainer) {
    var data = { FieldTypes: $(element).val() };

    DynamicSelectList(element, replacementContainer, 'Fieldnames', data);
}

function onStepActionTypeChange(element) {
    var result = $(element).closest(".divActionParams").children().find(".ddlStepResult").val();
    if (result === "") {
        alert("Please select result");
        return;
    }

    showProgress();
    $.ajax({
        data: {
            actionType: $(element).val()
        },
        url: 'ActionNamesJson'
    }).success(function (result) {
        $(element).closest(".divActionParams").children().find(".ddlStepActionName").empty();
        $.each(result,
            function (idx, val) {
                $(element).closest(".divActionParams").children().find(".ddlStepActionName")
                    .append($('<option>', { value: val.Value, text: val.Text }));
            });
        $(element).closest(".divActionParams").children().find(".ddlStepActionName").trigger('change');
        hideProgress();
        setFormChanged();
    });
}

function OnStepActionNameChange(element) {
    var step = element.parentNode.id.substr(element.parentNode.id.indexOf("_") + 1, 1);
    var selectedActionName = $(element).children("option").filter(":selected").text();
    $(element).closest(".Action").children().find(".divLabelParam").attr('hidden', true);

    $.ajax({
        data: {
            ActionId: $(element).val()
        },
        url: 'GetActionFormatHintDescription'
    }).success(function (result) {

        if (result.Data.length > 0) {
            $.each(result.Data, function (ind, val) {
                var diveleid = "#divParamLabel_" + (ind + 1) + "_" + step;
                $(diveleid).attr('hidden', false);
                $(diveleid).find("label").text(selectedActionName + "-" + (ind + 1));
                $(diveleid).find("input").attr("placeholder", val.FormatInputHintDescription);
                $(diveleid).find("span").attr("hidden", true);
                $(diveleid).find("input").attr("regex", val.FormatInputPattern);
                $(diveleid).find("span").attr("hidden", true);
                $(diveleid).find("input").mask(val.FormatInputHintDescription.replace(/#/g, "9"), { placeholder: val.FormatInputHintDescription });
                $(diveleid).find("input").attr('valueType', val.ValueTypeId);
            });
        }
        setFormChanged();
    });
}

function validateStepTextbox(element) {
    var regex = $(element).attr('regex');
    var minimum = $(element).attr('minimum');
    var maximum = $(element).attr('maximum');
    var errmsg = $(element).attr('data-err-msg');
    $(element).closest(".divLabelParam").find("span").attr("hidden", new RegExp(regex).test($(element).val()));
    $(element).closest(".divLabelParam").find("span").innerHTML = errmsg;
}

function fieldTypeChange(element, replacementContainer, CompareTypecontainerId, ElementId, CompareDropDown) {
    var KeyWordText = $(element).val();

    var data = { fieldType: $(element).val(), compareTypeId: CompareTypecontainerId, elementId: ElementId, compareDropDown: CompareDropDown };

    if (KeyWordText === "5") {
        $('#SelectedCompareType' + ElementId + ' option').each(function () {

            $(this).remove();

        });

        $('#SelectedCompareType' + ElementId).prop("disabled", true);

        $('#SelectedCompareType' + ElementId).append('<option value="1" selected="selected">Is True</option>');
    }
    else {
        $('#SelectedCompareType' + ElementId).prop("disabled", false);
    }

    DynamicSelectList(element, replacementContainer, 'FieldTypes', data);
    setFormChanged();
}

function DynamicSelectList(element, replacement, url, data) {
    showProgress();
    $.ajax({
        data: data,
        url: url
    }).success(function (partialView) {

        $("#" + replacement).html(partialView);

        $(".slctComboBox").select2({
            width: "100%"
        }
         );

        $('.slctComboBoxCompare').select2({
            width: "100%"
        });

        hideProgress();
    });
}

var operationManagement = function () {

    $("#btn_addconditions").on('click', function () {
        showProgress();
        $.ajax({
            data: {
                InterpQueryId: GetQueryStringParams("InterpQueryId"),
                Type: "Conditions",
                StepNo: ++StepNumber
            },
            url: 'AddConditionsActionsStep'
        }).success(function (partialView) {
            $('#add_steps').append(partialView);
            $('.slctComboBox').select2();
            $('.slctComboBoxCompare')
                .select2({
                    width: "style"
                });
            hideProgress();
            setFormChanged();
        });
    });

    $("#btn_addexceptions").on('click', function () {
        showProgress();
        $.ajax({
            data: {
                InterpQueryId: GetQueryStringParams("InterpQueryId"),
                Type: "Exceptions",
                StepNo: ++StepNumber,
                CurrentDateTime: new Date()
            },
            url: 'AddExceptionsStep'

        }).success(function (partialView) {
            $('#add_steps').append(partialView);
            $('.slctComboBox').select2();
            hideProgress();
            setFormChanged();
        });
    });
};

var spinnerVisible = false;
var formChanged = false;

function setFormChanged() {
    formChanged = true;
    $("#btnEditInterp_Save").prop("disabled", false);
}

function showProgress() {
    if (!spinnerVisible) {
        $("#modalBlockingSpinner").removeClass("hidden");
        $("#btn_addexceptions").prop("disabled", true);
        $("#btn_addactions").prop("disabled", true);
        $("#btn_addconditions").prop("disabled", true);
        spinnerVisible = true;
    }
}

function hideProgress() {
    if (spinnerVisible) {
        $("#btn_addexceptions").prop("disabled", false);
        $("#btn_addactions").prop("disabled", false);
        $("#btn_addconditions").prop("disabled", false);
        $("#modalBlockingSpinner").addClass("hidden");
        spinnerVisible = false;
    }
}

var cancelClick = function () {
    $('#tb_interpno').val('');
};

var successFunc = function (redirect) {
    window.location = redirect;
};

var createClick = function () {
    $('#myModal1').modal('hide');
    $.ajax({
        type: "POST",
        url: '@Url.Action("EditInterp", "Interp")',
        dataType: "html",
        success: successFunc,
        error: errorFunc
    });
};

var openPseudo = function (interpId) {
    var data = buildInterpData();
    var options = {
        url: $("#dvSitePath").html() + 'Interp/ViewPseudocode',
        type: 'POST',
        data: { interpId: interpId, data: data }
    };

    $.ajax(options).done(function (data) {
        if (data.data !== null) {
            alert("I should display stuff!");
        }
        else {
            alert("unable to generage pseudocode");
        }
    })
   .fail(function () {
   });
};


var buildInterpData = function () {
    var data = [];
    $("#add_steps").children(".InterpStep").each(function () {
        var conditionData = null;
        var actionData = null;
        var exception = null;
        var errorInd = false; //TODO: set to true if step has a validation error on it.
        var result, actionType, actionName, parameter1, parameter2, parameter3, parameter4, parameter5;

        var stepNumber = $(this).attr('stepcontainer');
        var stepType = $(this).attr('class').split(' ')[1];

        if (stepType === "StepException") {
            $(this).find("#SelectedException").each(function () {
                exception = {
                    "Id": $(this).val() === "" ? "0" : $(this).val(),
                    "Value": $(this).find('option:selected').text()
                };
            });
        }

        if (stepType === "StepCondition") {
            var conditionType, fieldType, fieldName, compareType, compareValue;
            conditionData = [];
            conditionList = [];

            $(this).find(".container").each(function () {
                $(this).find("#SelectedConditionType").each(function () {
                    conditionType = {
                        "Id": $(this).val() === "" ? "0" : $(this).val(),
                        "Value": $(this).find('option:selected').text()
                    };
                });

                $(this).find("#SelectedFieldType").each(function () {
                    fieldType = {
                        "Id": $(this).val() === "" ? "0" : $(this).val(),
                        "Value": $(this).find('option:selected').text()
                    };
                });

                $(this).find("#FieldName").each(function () {
                    fieldName = {
                        "Id": $(this).val() === "" ? "0" : $(this).val(),
                        "Value": $(this).find('option:selected').text()
                    };
                });

                $(this).find('.slctComboBoxCompare').each(function () {
                    compareType = {
                        "Id": $(this).val() === "" ? "0" : $(this).val(),
                        "Value": $(this).find('option:selected').text()
                    };
                });

                $(this).find("#CompareValues").each(function () {
                    compareValue = {
                        "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                        "Value": $(this).val()
                        //TODO: Figure out where the validation is being done and update the attributes as appropriate.
                    };
                });

                var condition = { "ConditionType": conditionType, "FieldType": fieldType, "FieldName": fieldName, "CompareType": compareType, "CompareValue": compareValue };
                conditionList.push(condition);
            });

            //TODO: if there are actions under a conditon need to add them to this object - similar to "StepAction"
            //Can't complete until UI is built to know field ID's and such
            var actionList = null;
            //var action = { "Result": result, "ActionType": actionType, "ActionName": actionName, "Parameter1": parameter1, "Parameter2": parameter2, "Parameter3": parameter3, "Parameter4": parameter4, "Parameter5": parameter5 };
            //actionList.push(action);

            conditionData = { "Conditions": conditionList, "Actions": actionList };
        }

        if (stepType === "StepAction") {
            actionData = [];
            $(this).find("[name='SelectedResult']").each(function () {
                result = {
                    "Id": $(this).val() === "" ? "0" : $(this).val(),
                    "Value": $(this).find('option:selected').text()
                };
            });

            $(this).find("[name='SelectedActionType']").each(function () {
                actionType = {
                    "Id": $(this).val() === "" ? "0" : $(this).val(),
                    "Value": $(this).find('option:selected').text()
                };
            });

            $(this).find("[name='SelectedActionName']").each(function () {
                actionName = {
                    "Id": $(this).val() === "" ? "0" : $(this).val(),
                    "Value": $(this).find('option:selected').text()
                };
            });

            $(this).find("#Parameter1").each(function () {
                parameter1 = {
                    "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                    "Value": $(this).val()
                };
            });

            $(this).find("#Parameter2").each(function () {
                parameter2 = {
                    "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                    "Value": $(this).val()
                };
            });

            $(this).find("#Parameter3").each(function () {
                parameter3 = {
                    "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                    "Value": $(this).val()
                };
            });

            $(this).find("#Parameter4").each(function () {
                parameter4 = {
                    "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                    "Value": $(this).val()
                };
            });

            $(this).find("#Parameter5").each(function () {
                parameter5 = {
                    "Id": $(this).attr('valueType') === "" ? "0" : $(this).attr('valueType'), //This is the value type to identify Alpha, Numeric or Decimal.
                    "Value": $(this).val()
                };
            });

            actionData = {
                "Result": result, "ActionType": actionType, "ActionName": actionName, "Parameter1": parameter1, "Parameter2": parameter2, "Parameter3": parameter3, "Parameter4": parameter4, "Parameter5": parameter5
            };
        }

        data.push({ "Step": stepNumber, "StepInError": errorInd, "ExceptionData": exception, "ConditionData": conditionData, "ActionData": actionData });
    });

    return JSON.stringify(data);
};

var saveClick = function (interpId, action) {
    var data = buildInterpData();

    var options = {
        url: $("#dvSitePath").html() + 'Interp/SaveInterpDetails',
        type: 'POST',
        data: { interpId: interpId, data: data }
    };

    showProgress();
    $.ajax(options).done(function (data) {
        if (data.UpdateInterp === 0 && data.UpdateNarrative === 0) {
            showToast.success(data.InterpMessage);
            if (action === "0") {
                hideProgress();
                //The Save button was clicked, clear any errors
            }
            else {
                //Done button was clicked, go back to view mode
                window.location.href = $("#dvSitePath").html() + 'Interp/ViewInterp?InterpQueryId=' + interpId;
            }
        }
        else {
            //Either Configuration, Narrative or Both didn't save
            hideProgress();
            $('#doneModal').modal('hide');

            jQuery("#dialog-confirm-text").html(data.InterpMessage);
            $("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 450,
                modal: true,
                title: "Error",
                buttons: {
                    "Close": function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    })
    .fail(function (data) {
        hideProgress();
        $('#doneModal').modal('hide');
    });
};

var doneClick = function (data) {
    if (formChanged) {
        $('#doneModal').modal('show');
    }
    else {
        showProgress();
        window.location.href = $("#dvSitePath").html() + 'Interp/ViewInterp?InterpQueryId=' + data;
    };
};

var dismissClick = function (data) {
    showProgress();
    window.location.href = $("#dvSitePath").html() + 'Interp/ViewInterp?InterpQueryId=' + data;
};

var editClick = function (data) {
    showProgress();
    window.location.href = $("#dvSitePath").html() + 'Interp/EditInterp?InterpQueryId=' +data;
 };

var buttonOperationsForEditInterp = function () {
    $("#btnCreate").click(createClick);
    $("#btnCancel").click(cancelClick);
    };

//Function for adding New Condition Step
function addNewCondition(divId) {
    $("#divEmptyCondition").hide();

    showProgress();
    $.ajax({
                data: {
                    InterpQueryId: GetQueryStringParams("InterpQueryId"),
                    Type: "Conditions",
                    StepNo: ++StepNumber
                },
                url: 'AddConditionsActionsStep'

            }).success(function(partialView) {
        $('#add_steps').append(partialView);
        hideProgress();
        setFormChanged();
            });

    $("#" +divId + "_Conditions").removeClass("hidden").addClass("show");
    $("#" +divId + "_Condition_Links").removeClass("hidden").addClass("show");
    }

//Function for adding New Action Step
var addNewAction = function (noActionId, actionId) {
    $("#" +noActionId).removeClass("show").addClass("hidden");
    $("#" +actionId).removeClass("hidden").addClass("show");
    setFormChanged();
    };

//Function for adding New 'Or If' Condition 
//Function for adding New 'And If' Condition
var addOrIfCondition = function (divid, counterFieldid, conditiontype, step) {
    showProgress();
    $.ajax({
                data: {
                    InterpQueryId: GetQueryStringParams("InterpQueryId"),
                    rowPosition: counterFieldid,
                    StepNo: step,
                    ConditionType: conditiontype
                },
                url: 'AddConditionsActionsStep'

            }).success(function(partialView) {
        $(partialView).insertBefore("#" +divid);
        $('.slctComboBox').select2();
        $('.slctComboBoxCompare')
            .select2({
                        width: "style"
                    });
        hideProgress();
        setFormChanged();
            });
    };

//Common Method for adding 'And If' Condition and 'Or If' Condition
var addanycondition = function (divid, counterFieldid, moveFieldId, deleteFieldId, conditiontype) {

    var intCounter = $("#" + counterFieldid).val();
    var originaldivid = divid;
    var originalmoveid = moveFieldId;
    var originaldeleteid = deleteFieldId;

    intCounter++;
    $("#" +counterFieldid).val(intCounter);

    divid = newDivId(divid, intCounter);
    moveFieldId = newDivId(moveFieldId, intCounter);
    deleteFieldId = newDivId(deleteFieldId, intCounter);
    var appendnewcondition = $("#" + originaldivid).html();

    appendnewcondition = appendnewcondition.replace(originaldivid, divid);
    appendnewcondition = appendnewcondition.replace(originalmoveid, moveFieldId);
    appendnewcondition = appendnewcondition.replace(originaldeleteid, deleteFieldId);

    $(appendnewcondition).insertAfter('#' +originaldivid);
    setFormChanged();
    };

//Function for adding New 'Tru' Action
var addTrueAction = function (divid, counterFieldid, moveFieldId, deleteFieldId, resulttype) {
    addanyaction(divid, counterFieldid, moveFieldId, deleteFieldId, resulttype);
    };

//Function for adding New 'False' Action
var addFalseAction = function (divid, counterFieldid, moveFieldId, deleteFieldId, resulttype) {
    addanyaction(divid, counterFieldid, moveFieldId, deleteFieldId, resulttype);
    };

//Common Method for adding 'True' Condition and 'False' Condition
var addanyaction = function (divid, counterFieldid, moveFieldId, deleteFieldId, resulttype) {

    var originaldivid = divid;
    var originalmoveid = moveFieldId;
    var originaldeleteid = deleteFieldId;
    var intCounter = $("#" + counterFieldid).val();

    intCounter++;
    $("#" +counterFieldid).val(intCounter);

    divid = newDivId(divid, intCounter);
    moveFieldId = newDivId(moveFieldId, intCounter);
    deleteFieldId = newDivId(deleteFieldId, intCounter);
    var appendnewaction = $("#" + originaldivid).html();

    appendnewaction = appendnewaction.replace(originaldivid, divid);
    appendnewaction = appendnewaction.replace(originalmoveid, moveFieldId);
    appendnewaction = appendnewaction.replace(originaldeleteid, deleteFieldId);
    $(appendnewaction).insertAfter('#' +originaldivid);
    setFormChanged();
    };

//Function for adding New Exception within current exception step
var addNewException = function (data, StepNumber) {

    $.ajax({
                data: {
                    InterpQueryId: GetQueryStringParams("InterpQueryId"),
                    Type: "Exceptions",
                    StepNo: StepNumber,
                    FirstException: false,
                    RowPosition: null
                },
                url: 'AddExceptionsStep'

            }).success(function(partialView) {

        $("</br>").insertBefore(data);
        $(partialView).insertBefore("#" +data);
        $('.slctComboBox').select2();
        setFormChanged();
            });
    };

//Function for deleting a Step Containing Actions and Conditions
var deleteInterpStep = function (stepid, divid, deleteFieldId) {
    var stepName = getStepName(stepid);
    jQuery("#dialog-confirm-text").text("Are you sure you want to delete \"" + stepName + "\"?");

    $("#dialog-confirm").dialog({
                resizable: false,
                height: "auto",
                width: 450,
                modal: true,
                buttons: {
                    "Delete": function () {
                        $(this).dialog("close");
                        //deleteReorderSteps(stepid, stepName);
                        $('#' +stepid).remove();
                        StepNumber--;
                        reorderEventHandler(stepName);
                        setFormChanged();
                    },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
            });
    };

//Function to parse out the step name of the current stepid.
var getStepName = function (stepid) {
    var headingDiv = document.getElementById("head-" + stepid);
    var stepDiv = headingDiv.innerHTML;
    var stepName = stepDiv.split("\n")[1].trim();
    return stepName;
    };

//Function for copying a Step Containing Actions and Conditions
var copyActionsConditionsStep = function (divid, deleteFieldId) {
    //alert('This function is for next phase')
    //setFormChanged();
};

//Function for Copying a Step Containing Exceptions
var copyExceptionStep = function (divid, deleteFieldId) {
    //alert('This function is for next phase')
    //setFormChanged();
};

//Function for Deleting an Action
var deleteAction = function (divid) {
    setFormChanged();
    };

//Function for Deleting an Condition
var deleteCondition = function (data, RowPosition) {
    setFormChanged();
    if (RowPosition === "1" || RowPosition === "100") {
        return false;
        }
    else {

        $("#" +data).slideUp('slow', function () {
            $("#" +data).remove();
        });
        }
    };

//Function for Deleting an Exception row from within an Exception step
var deleteExceptionRow = function (rowDivId) {
    setFormChanged();
    var containerLength = $("#" + rowDivId).closest(".InterpContent").children('.container').length;

    if (containerLength === 1) {
    }
    else {

        $("#" +rowDivId).slideUp("slow", function () {
            $("#" +rowDivId).next().remove();
            $("#" +rowDivId).remove();
        });

        //Traverse and find the exception rows container 
        var RowStep = 0;
        var GetContainer = $("#" + rowDivId).closest(".InterpContent").children('.container').each(function() {
            $(this).attr("roworder", RowStep +1);
        });
        }
    };

//Reordering the Steps
$(document).ready(function() {

    $("#add_steps").sortable({
                cursor: 'move',
                opacity: 0.8,
                placeholder: "ui-state-highlight",
                handle: "#btnStep_MoveStep",
                helper: function (e, div) {
                    var $originals = div.parent();
                    var $helper = div.clone();

                    $helper.parent()
                        .each(function(index) {
                            // Set helper cell sizes to match the original sizes
                            $(this).width($originals.eq(index).width());
                        });
                    return $helper;
                },
                stop: function (e, div) {
                    reorderEventHandler();
                }
            });
    $("#add_steps").disableSelection();
    });

var editInterpFunctionCall = function () {

    buttonOperationsForEditInterp();
    operationManagement();
    conditionOperations();
    actionOperations();
    exceptionOperation();
    };

var reorderEventHandler = function (deletedStepName) {
    var allIds = $("#add_steps").sortable("toArray");
    var changedSteps = [];
    var changes;
    var oldStepName;
    var newStepName;
    var i;

    for (i = 0; i < allIds.length; ++i) {
        if (allIds[i].length > 0) {
            newStepName = "Step " +(i +1);

            var headingDiv = document.getElementById("head-" + allIds[i]);
            var oldStepDiv = headingDiv.innerHTML;

            // Need to parse the "Step #" out of the rest of the HTML code which they are separated by line breaks
            oldStepName = headingDiv.innerHTML.split("\n")[1].trim();

            if (!(oldStepName === newStepName)) {
                headingDiv.innerHTML = oldStepDiv.replace(oldStepName, newStepName);
                changes = {
                    "OldStep": oldStepName,
                    "NewStep": newStepName
                    };
                changedSteps.push(changes);
                $(headingDiv).parent().attr('stepcontainer', i +1);
            }
        }
        }

    if (changedSteps.length > 0) {
        var actionTypeIndex = 0;
        $('[id="SelectedActionType"]').each(function() {

            var parentDiv = $(this).closest("div.InterpStep");
            var headingDiv = document.getElementById("head-" + parentDiv.attr("id"));
            var currentStep = headingDiv.innerHTML.split("\n")[1].trim();

            if ($(this).find('option:selected').text().toUpperCase() === "FLOW") {
                var actionNameIndex = 0;
                $('[id="SelectedActionName"]').each(function() {
                    if(actionNameIndex === actionTypeIndex &&
                        $(this).find('option:selected').text().toUpperCase().match("^GO TO STEP")) {
                        //Correct ActionType and Correct ActionName found, so now check the first Parameter fields for this step 
                        var paramValue = $('[id="Parameter1"]')[actionTypeIndex].value;

                        var changeIndex;
                        for (changeIndex = 0; changeIndex < changedSteps.length; changeIndex++) {
                            changes = changedSteps[changeIndex];
                            if (changes.OldStep === paramValue) {
                                $('[id="Parameter1"]')[actionTypeIndex].value = changes.NewStep;
                                showToast.info("The " +currentStep + " \"Go To\" value of " + changes.OldStep + " has been updated to go to " + changes.NewStep);
                            } else if (!deletedStepName.isEmptyObject &&
                                deletedStepName === paramValue) {
                                $('[id="Parameter1"]')[actionTypeIndex].value = "";
                                showToast.info("The " +currentStep + " \"Go To\" value is now empty.");
                            }
                        }
                    }
                });
            }
            ++actionTypeIndex;
        });
        }
    };

var actionTypeChange = function (actionType) {

    var _data = typeof $("#" +actionType).val() === 'string' ? $("#" + actionType).val(): '';
    var options = {
                url: $("#dvSitePath").html() + 'Interp/ActionNames',
                form: 'get',
                data: _data
            };

    $.ajax(options).done(function(data) {
        var $select = $("#" + actionType).next("#SelectedActionName");
        setFormChanged();
        });
    };