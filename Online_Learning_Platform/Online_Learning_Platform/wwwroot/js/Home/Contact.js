function ContactUs() {

    var Fullname = $("#Fullname").val();
    var Email = $("#Email").val();
    var Message = $("#Message").val();


    var alphabetRegex = /^[A-Za-z\s]+$/;
    var emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (Fullname == "") {
        swal("Please Enter Name");
    }
    else if (!alphabetRegex.test(Fullname)) {
        swal("Please Use Alphabets");
    }
    else if (Email == "") {
        swal("Please Enter Email");
    }
    else if (!emailRegex.test(Email)) {
        swal("Please Enter Proper Email Address");
    }
    else if (Message == "") {
        swal("Please Enter Name");
    }
    else {
        // Create a JavaScript object representing the registration model
        var Contact = {
            Fullname: Fullname,
            Email: Email,
            Message: Message,
        };


        // Send an AJAX POST request to the server
        $.ajax({
            type: "POST",
            url: "/HomeApi/Contacts",
            data: JSON.stringify(Contact),
            contentType: "application/json",
            dataType: "json",
           
        });

        swal("Thank You!", "For Contacting Us", "success");

        // Redirect to another page after 2 seconds
        setTimeout(function () {
            window.location.href = '/Home/Index'; // Replace with your desired URL
        }, 2000);
    }

}