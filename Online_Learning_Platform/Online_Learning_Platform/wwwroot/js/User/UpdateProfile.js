//Update Password
function UpdateProfile() {
    var Oldpassword = document.getElementById("oldPassword").value;
    var Newpassword = document.getElementById("newPassword").value;
    var CNewpassword = document.getElementById("confirmPassword").value;
    if (Oldpassword == "" || Oldpassword == null) {
        swal("Enter Old Password");
        return false;
    }
    else if (Newpassword == "" || Newpassword == null) {
        swal("Enter New Password");
        return false;
    }
    else if (CNewpassword == "" || CNewpassword == null) {
        swal("Enter Confirm Password");
        return false;
    }
    else if (Newpassword != CNewpassword) {
        swal("Password's Doesnt Match", "", "error");
        return false;
    }
    else {
        var id = sessionStorage.getItem('EmployeeID');
        var Password = Newpassword;
        var oldPassword = Oldpassword;

        var Updatepassword = {
            Id: id,
            oldPassword: oldPassword,
            Password: Password
        };

        // Convert the object to JSON
        var jsonPayload = JSON.stringify(Updatepassword);

        // Make the AJAX call
        $.ajax({
            url: '/UserApi/UpdatePassword', // Replace with the actual controller and action URL
            type: 'POST',
            contentType: 'application/json', // Set the content type to JSON
            data: jsonPayload, // Pass the JSON payload as data
            success: function (response) {
                if (response === false || response === "false") {
                    swal("Wrong Old Password", "", "error");
                } else {
                    swal("Password Updated", "", "success");
                }
            },
            error: function (xhr, status, error) {
                swal('An error occurred while making the Ajax call:', error);
            }
        });

    }

}





//Show Name and Email
function showData() {
    var userId = sessionStorage.getItem("EmployeeID");

    fetch('/AdminApi/GetUsers')
        .then(response => response.json())
        .then(data => {
            var jsonArray = data;
            // Assuming your data is an array of courses
            // Find the course with the given courseId
            var course = jsonArray.find(course => course.id === parseInt(userId));



            document.getElementById("fullname").value = course.name;
            document.getElementById("email").value = course.email;

        });
}

//Logout
function Logout() {

    swal({
        title: "Are you sure you want to Logout?",
        text: "",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                sessionStorage.removeItem('EmployeeID');
                sessionStorage.removeItem('Email');
                window.location.href = '/Home/Index';
            } else {
                return false;
            }
        });


}