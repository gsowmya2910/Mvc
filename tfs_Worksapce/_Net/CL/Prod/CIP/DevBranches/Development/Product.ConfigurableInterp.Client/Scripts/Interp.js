
$(function () {

    newInterpFunctionCall();

    editInterpFunctionCall();

});

//Function for deleting an Interp
var deleteInterp = function (interpId) {
    $("#modalBlockingSpinner").removeClass("hidden");

    var options = {
        url: $("#dvSitePath").html() + 'Interp/DeleteInterp',
        type: 'POST',
        data: { interpId: interpId }
    };

    $.ajax(options).done(function (data) {
        if (data.DeleteStatus === 0) {
            clearDelete();
            showToast.success(data.InterpMessage);
            window.setTimeout(function () {
                $("#lnkInterpConfiguratorHome")[0].click();
            }, 2000);
        }
        else {
            $("#modalBlockingSpinner").addClass("hidden");
            $("#deleteInterpMessage").text(data.InterpMessage);
            $("#deleteInterpErrorRow").removeClass("hidden");
        }
    })
    .fail(function (data) {
        clearDelete();
    });
};

var clearDelete = function () {
    $("#deleteInterpMessage").text('');
    $("#deleteInterpErrorRow").addClass("hidden");
    $("#deleteInterpModal").modal('hide');
};


//Function for updating the status of an Interp
var setTargetStatusMsg = function (element) {
    $("#newInterpStatus").val($(element).data('interp-status'));
    $("#targetStatusAction").text($(element).text());
};

var updateInterpStatus = function (interpId, currentStatus) {
    $("#modalBlockingSpinner").removeClass("hidden");
    var targetStatus = $("#newInterpStatus").val();

    var options = {
        url: $("#dvSitePath").html() + 'Interp/UpdateInterpStatus',
        type: 'POST',
        data: {
            interpId: interpId,
            currentStatus: currentStatus,
            targetStatus: targetStatus
        }
    };

    $.ajax(options).done(function (data) {
        if (data.UpdateStatus === 0) {
            clearStatus();
            showToast.success(data.InterpMessage);
            window.setTimeout(function () {
                window.location.href = $("#dvSitePath").html() + 'Interp/ViewInterp?InterpQueryId=' + interpId;
            }, 2000);
        }
        else {
            $("#modalBlockingSpinner").addClass("hidden");
            $("#updateInterpStatusMessage").text(data.InterpMessage);
            $("#updateInterpStatusErrorRow").removeClass("hidden");
        }
    })
    .fail(function (data) {
        clearStatus();
    });
};

var clearStatus = function () {
    $("#updateInterpStatusMessage").text('');
    $("#updateInterpStatusErrorRow").addClass("hidden");
    $("#updateInterpStatusModal").modal('hide');
};

//Passive and error message notifications
showToast = function (message) {
    showToast.success(message);
};
showToast.success = function (message) {
    $.toaster({ priority: 'success', title: '', message: message });
};
showToast.warning = function (message) {
    $.toaster({ priority: 'warning', title: '', message: message });
};
showToast.info = function (message) {
    $.toaster({ priority: 'info', title: '', message: message });
};
showToast.danger = function (message) {
    $.toaster({ priority: 'danger', title: '', message: message });
};
