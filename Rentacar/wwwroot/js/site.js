﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
            console.log("message about to sent");
            $.ajax({

                url: "/Reservation/FindAvailableCars",
                method: "GET",
                data: {
                    "ReservationBegin": reservationBegin,
                    "ReservationEnd": reservationEnd
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
});
