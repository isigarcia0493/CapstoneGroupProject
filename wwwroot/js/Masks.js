'use strict'

$(document).ready(function () {
    $("#ZipCode").inputmask("99999");
    $("#PhoneNumber").inputmask("(999)-999-9999");
    $("#UnitPrice").inputmask("99.99");
    $("#Payment_CardNumber").inputmask("9999-9999-9999-9999");
    $("#Payment_ExpitarionDate").inputmask("99/99");
    $("#Payment_SecurityCode").inputmask("999");
})