function PasswordRecovery() {
    var Email = $("#Email").val();

    var emailRegex = /^[\w\.-]+@[\w\.-]+\.\w+$/;

    if (Email == null) {
        swal("Please Enter Email");
    }
    else if (emailRegex.test(Email) == false) {
        swal("Please Enter Proper Email");
    }
    else {
        $.ajax({
            type: "POST",
            url: "/HomeApi/CheckEmailExists?Email=" + Email,
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                if (data == false) {
                    swal("Invalid Email","This Email ID Doesnt Exists","warning");
                }
                else {

                    $.ajax({
                        type: "POST",
                        url: "/HomeApi/RecoverPassword?Email=" + Email,
                        contentType: "application/json",
                        dataType: "json",
                    });
                    swal("Check Mail", "Recovery Password Sent Over Mail", "info");
                    setTimeout(function () {
                        window.location.href = '/Home/Index';
                    }, 1500);
                }
            },

        });
    }


}