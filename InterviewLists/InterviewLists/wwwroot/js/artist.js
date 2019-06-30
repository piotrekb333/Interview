function LoadData() {
    $.ajax({
        type: 'GET',
        url: '/Artist/GetAllTable',
        success: function (result) {
            $('#table-result').html(result);
            $(".delete-artist").click(function () {
                DeleteArtist($(this).attr('data-id'));
            });
            $(".edit-artist").click(function () {
                LoadArtist($(this).attr('data-id'));
            });
        }
    });
}


function LoadArtist(id) {
    $.ajax({
        type: 'GET',
        url: '/Artist/GetArtistById/' + id,
        success: function (response) {
            $("#EditArtistFirstName").val(response.firstName);
            $("#EditArtistLastName").val(response.lastName);

            $("#EditArtistBirthday").datepicker("setDate", new Date(response.birthday));
            $("#EditArtistCountry").val(response.country);
            $("#EditArtistId").val(response.id);
            $("#editArtistModal").modal('show');
        }
    });
}

function SaveArtist() {
    var data = {
        FirstName: $("#ArtistFirstName").val(),
        LastName: $("#ArtistLastName").val(),
        Birthday: $("#ArtistBirthday").val(),
        Country: $("#ArtistCountry").val()
    };
    $.ajax({
        type: 'POST',
        url: '/Artist/Create',
        data: data,
        success: function () {
            $("#addEmployeeModal").modal('hide');
            $("#ArtistFirstName").val('');
            $("#ArtistLastName").val('');
            $("#ArtistBirthday").val('');
            $("#ArtistCountry").val('');

            LoadData();
        }
    });
}

function UpdateArtist() {
    var data = {
        FirstName: $("#EditArtistFirstName").val(),
        LastName: $("#EditArtistLastName").val(),
        Birthday: $("#EditArtistBirthday").val(),
        Country: $("#EditArtistCountry").val(),
        Id: $("#EditArtistId").val()
    };
    $.ajax({
        type: 'PUT',
        url: '/Artist/Update',
        data: data,
        success: function () {
            $("#editArtistModal").modal('hide');
            $("#EditArtistFirstName").val('');
            $("#EditArtistLastName").val('');
            $("#EditArtistBirthday").val('');
            $("#EditArtistCountry").val('');
            $("#EditArtistId").val('');
            LoadData();
        }
    });
}


function DeleteArtist(id) {
    $.ajax({
        type: 'DELETE',
        url: '/Artist/Delete/' + id,
        success: function (result) {
            LoadData();
        }
    });
}

$(document).ready(function () {
    LoadData();
    $("#btn-add-artist").click(function () {
        SaveArtist();
    });
    $("#btn-update-artist").click(function () {
        UpdateArtist();
    });
});