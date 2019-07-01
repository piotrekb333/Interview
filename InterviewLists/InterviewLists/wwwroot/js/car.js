var saveModel = '';
function LoadData() {
    $.ajax({
        type: 'GET',
        url: '/Car/GetAllTable',
        success: function (result) {
            $('#table-result').html(result);
            $(".delete-car").click(function () {
                DeleteCar($(this).attr('data-id'));
            });
            $(".edit-car").click(function () {
                LoadCar($(this).attr('data-id'));
            });
        }
    });
}

function LoadCarModels(id) {
    $("#CarModel").html('');
    $.ajax({
        type: 'GET',
        url: '/Car/GetCarModels/' + id,
        success: function (response) {
            response.forEach(function (entry) {
                $("#CarModel").append(new Option(entry.title, entry.id));
            });

        }
    });
}

function LoadEditCarModels(id) {
    $("#EditCarModel").html('');
    $.ajax({
        type: 'GET',
        url: '/Car/GetCarModels/' + id,
        success: function (response) {
            response.forEach(function (entry) {
                $("#EditCarModel").append(new Option(entry.title, entry.id));
            });
            if (saveModel !== '') {
                $("#EditCarModel").val(saveModel);
                saveModel = '';
            }
        }
    });
}

function LoadCar(id) {
    $.ajax({
        type: 'GET',
        url: '/Car/GetCarById/' + id,
        success: function (response) {
            $("#EditCarId").val(response.id);
            $("#EditCarMake").val(response.carMakeId);
            saveModel = response.carModelId;
            $("#EditCarMake").change();
            $("#EditCarPrice").val(response.price);
            $("#EditCarDate").val(response.dateOfProduction);
            $('#EditCarDate').datepicker("setDate", new Date(response.dateOfProduction));
            $("#EditCarCountry").val(response.country);
            $("#editCarModal").modal('show');
        }
    });
}

function SaveCar() {
    if (!$("#add-car-form").valid()) {
        return;
    }
    var data = {
        CarMakeId: $("#CarMake").val(),
        CarModelId: $("#CarModel").val(),
        Price: $("#CarPrice").val(),
        DateOfProduction: $("#CarDate").val(),
        Country: $("#CarCountry").val()
    };
    $.ajax({
        type: 'POST',
        url: '/Car/Create',
        data: data,
        success: function () {
            $("#addEmployeeModal").modal('hide');
            $("#CarMake").val('');
            $("#CarModel").val('');
            $("#CarPrice").val('');
            $("#CarDate").val('');
            $("#CarCountry").val('');
            LoadData();
        }
    });
}

function UpdateCar() {
    if (!$("#edit-car-form").valid()) {
        return;
    }
    var data = {
        CarMakeId: $("#EditCarMake").val(),
        CarModelId: $("#EditCarModel").val(),
        Price: $("#EditCarPrice").val(),
        DateOfProduction: $("#EditCarDate").val(),
        Country: $("#EditCarCountry").val(),
        Id: $("#EditCarId").val()
    };
    $.ajax({
        type: 'PUT',
        url: '/Car/Update',
        data: data,
        success: function () {
            $("#editCarModal").modal('hide');
            $("#EditCarMake").val('');
            $("#EditCarModel").val('');
            $("#EditCarPrice").val('');
            $("#EditCarDate").val('');
            $("#EditCarCountry").val('');
            $("#EditCarId").val('');
            LoadData();
        }
    });
}


function DeleteCar(id) {
    $.ajax({
        type: 'DELETE',
        url: '/Car/Delete/' + id,
        success: function (result) {
            LoadData();
        }
    });
}

$(document).ready(function () {
    LoadData();
    $("#CarMake").change(function () {
        LoadCarModels($(this).val());
    });
    $("#EditCarMake").change(function () {
        LoadEditCarModels($(this).val());
    });
    $("#btn-add-car").click(function () {
        SaveCar();
    });
    $("#btn-update-car").click(function () {
        UpdateCar();
    });
});