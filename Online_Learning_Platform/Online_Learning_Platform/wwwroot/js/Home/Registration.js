function Register() {

    var name = $("#Name").val();
    var email = $("#Email").val();
    var password = $("#Password").val();
    var confirmPassword = $("#ConfirmPassword").val();

    var alphabetRegex = /^[A-Za-z]+$/;
    var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (name == "") {
        swal("Please Enter Name");
    }
    else if (!alphabetRegex.test(name)) {
        swal("Please Use Alphabets");
    }
    else if (email == "") {
        swal("Please Enter Email");
    }
    else if (!emailRegex.test(email)) {
        swal("Please Enter Proper Email Address");
    }
    else if (email.includes("syaser327@outlook.com")) {
        swal("Email Already Exists", "Please use a different email.", "error");
    }
    else if (password == "" && password.length <= 10) {
        swal("Please Enter Password of 10 Characters");
    }
    else if (confirmPassword == "" && confirmPassword.length <= 10) {
        swal("Please Enter Confirm Password of 10 Characters");
    }
    else if (password != confirmPassword) {
        swal("Passwords Dont Match");
    }
    else {
        // Create a JavaScript object representing the registration model
        var Registration = {
            Name: name,
            Email: email,
            Password: password,
        };

        // Check if the email exists on the server
        $.ajax({
            type: "POST",
            url: "/HomeApi/CheckEmailExists?Email="+email,
            contentType: "application/json",
            dataType: "json",
            success: function (emailExists) {
                if (emailExists) {
                    // Email exists, show an error message
                    swal("Email Already Exists", "Please use a different email.", "error");
                } else {
                    // Email doesn't exist, proceed with registration
                    $.ajax({
                        type: "POST",
                        url: "/HomeApi/Registration",
                        data: JSON.stringify(Registration),
                        contentType: "application/json",
                        dataType: "json",
                       
                       
                    });
                    swal("Registered Successfully!", "Redirecting", "success");
                    setTimeout(function () {
                        // Redirect to another page after 3 seconds
                        window.location.href = '/Home/Index'; // Replace with your desired URL
                    }, 2000); 
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle error here
                console.error("Error:", textStatus, errorThrown);
            }
        });



    }


    
}
