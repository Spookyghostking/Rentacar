// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("#CarManufacturerSelect").on("change", function (e) {
        $("#CarModelSelect").html("<option value=\"0\">Select Model</option>");
        $.ajax({
            url: "/CarModelAdmin/GetManufacturerModels",
            method: "GET",
            data: {
                "id": e.target.value
            },
            success: function (data) {
                console.log(data);
                data.forEach((model) => {
                    $("#CarModelSelect").append(`<option value="${model.id}">${model.name}</option>`);
                });
            }
        });
        $("#CarModelSelect").prop("disabled", false);
    });

    $(document).on("click", function (e) {
        if (e.target.id == "findAvailableCars") {
            //console.log("button.ispressed = true")
            var reservationBegin = $("#ReservationBegin").val();
            var reservationEnd = $("#ReservationEnd").val();
            var carTypeID = $("#carTypeFilter").val();
            console.log(carTypeID);
            $.ajax({

                url: "/Reservation/FindAvailableCars",
                method: "GET",
                data: {
                    "ReservationBegin": reservationBegin,
                    "ReservationEnd": reservationEnd,
                    "CarTypeID": carTypeID
                },
                success: function (data) {
                    console.log(data);
                    $("#availableCarsContainer").html(data);
                }
            });
        } else if ($(e.target).hasClass("reservationCreateCarSelect")) {
            var carID = $(e.target).val();
            $("#carIDHiddenInput").val(carID);
            $("form").submit();
        }
    });

    $(document).on("click", ".car-details", function () {
        $(".modal-title").html("Car details");
        $("#modalConfirm").html("Choose");
        $("#modalConfirm").val(this.value);
        $("#modalConfirm").attr("class", "btn btn-primary reservationCreateCarSelect");
        $.ajax({
            url: "/Reservation/CarDetailsModal",
            method: "GET",
            data: {
                ID: parseInt(this.value)
            },
            success: function (data) {
                $("#modalBody").html(data);
            }
        });
    });
});
