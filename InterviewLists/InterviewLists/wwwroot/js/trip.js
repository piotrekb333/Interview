var saveModel = '';
function LoadData() {
    $.ajax({
        type: 'GET',
        url: '/Trip/GetAllTable',
        success: function (result) {
            $('#table-result').html(result);
            $(".delete-trip").click(function () {
                DeleteTrip($(this).attr('data-id'));
            });
            $(".edit-trip").click(function () {
                LoadTrip($(this).attr('data-id'));
            });
        }
    });
}


function LoadTrip(id) {
    $.ajax({
        type: 'GET',
        url: '/Trip/GetTripById/' + id,
        success: function (response) {
            $("#EditTripPrice").val(response.price);
            $("#EditTripDateFrom").datepicker("setDate", new Date(response.dateStart));
            $('#EditTripDateTo').datepicker("setDate", new Date(response.dateEnd));
            $("#EditTripCountry").val(response.country);
            $("#EditTripId").val(response.id);
            $("#editTripModal").modal('show');
        }
    });
}

function SaveTrip() {
    var data = {
        Price: $("#TripPrice").val(),
        DateStart: $("#TripDateFrom").val(),
        DateEnd: $("#TripDateTo").val(),
        Country: $("#TripCountry").val()
    };
    $.ajax({
        type: 'POST',
        url: '/Trip/Create',
        data: data,
        success: function () {
            $("#addEmployeeModal").modal('hide');
            $("#TripPrice").val('');
            $("#TripDateFrom").val('');
            $("#TripDateTo").val('');
            $("#TripCountry").val('');

            LoadData();
        }
    });
}

function UpdateTrip() {
    var data = {
        Price: $("#EditTripPrice").val(),
        DateStart: $("#EditTripDateFrom").val(),
        DateEnd: $("#EditTripDateTo").val(),
        Country: $("#EditTripCountry").val(),
        Id: $("#EditTripId").val()
    };
    $.ajax({
        type: 'PUT',
        url: '/Trip/Update',
        data: data,
        success: function () {
            $("#editTripModal").modal('hide');
            $("#EditTripPrice").val('');
            $("#EditTripDateFrom").val('');
            $("#EditTripDateTo").val('');
            $("#EditTripCountry").val('');
            $("#EditTripId").val('');
            LoadData();
        }
    });
}


function DeleteTrip(id) {
    $.ajax({
        type: 'DELETE',
        url: '/Trip/Delete/' + id,
        success: function (result) {
            LoadData();
        }
    });
}

$(document).ready(function () {
    LoadData();
    $("#btn-add-trip").click(function () {
        SaveTrip();
    });
    $("#btn-update-trip").click(function () {
        UpdateTrip();
    });
});