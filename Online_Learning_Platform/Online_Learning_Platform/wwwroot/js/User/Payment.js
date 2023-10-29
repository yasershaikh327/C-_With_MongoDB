function Payments() {
    // Validation
    var CardHolderName = $("#CardHolderName").val();
    var CardNumber = $("#CardNumber").val();
    var CVV = $("#CVV").val();
    var Month = $("#Month").val();
    var Year = $("#Year").val();
    var integerRegex = /^[0-9]+$/;

    if (CardHolderName === "") {
        swal("Please Enter Name");
    }
    else if (!integerRegex.test(CardNumber) || CardNumber.length !== 16) {
        swal("Please Enter 16 Digit Card Number");
    }
    else if (!integerRegex.test(CVV) || CVV.length !== 3) {
        swal("Please Enter 3 Digit CVV Number");
    }
    else if (!integerRegex.test(Month) || (Month > 12 || Month < 1)) {
        swal("Please Enter Month From 1 - 12");
    }
    else if (!integerRegex.test(Year)) {
        swal("Please Enter Year");
    }
    else if (parseInt(Year) < parseInt(getCurrentYear()) && parseInt(Month) === parseInt(getCurrentMonth())) {
        swal("Card is Expired");
    }
    else {
        var courseId = sessionStorage.getItem("CourseId");
        var userId = sessionStorage.getItem("EmployeeID");

        // Fetch Course Data
        fetch('/AdminApi/FetchCourses')
            .then(response => response.json())
            .then(data1 => {
                var jsonArray1 = data1;
                // Assuming your data is an array of courses
                // Find the course with the given courseId
                var course = jsonArray1.find(course => course.id === parseInt(courseId));

                sessionStorage.setItem("CourseId", courseId);

                // Fetch User Data
                fetch('/AdminApi/GetUsers')
                    .then(response => response.json())
                    .then(data2 => {
                        var jsonArray2 = data2;
                        // Assuming your data is an array of users
                        // Find the user with the given userId
                        var user = jsonArray2.find(user => user.id === parseInt(userId));

                        if (course && user) {
                            var CourseBook = {
                                User: user.name,
                                Email: user.email,
                                Course: course.courseName,
                                Instructor: course.instructor,
                            };



                            //Check if course is booked:
                            $.ajax({
                                type: "POST",
                                url: "/UserApi/BookCourse",
                                data: JSON.stringify(CourseBook),
                                contentType: "application/json",
                                dataType: "json",
                                success: function (response) {
                                    if (response === false || response === "false") {
                                        swal("Course Already Purchased", "", "warning");
                                    } else {
                                        setTimeout(function () {
                                            window.location.href = '/User/UserDashboard'; // Replace 'https://example.com' with your desired URL
                                        }, 1500);
                                        swal("Thank You for Choosing Us", "Redirecting To Dashboard", "success");
                                    }
                                },
                                
                            });
                        } 
                    });
               
            });
    }
}


// Get Current Year
function getCurrentYear() {
    const currentDate = new Date();
    const currentYear = currentDate.getFullYear();
    return currentYear;
}

// Get Current Month
function getCurrentMonth() {
    const currentDate = new Date();
    const currentMonthIndex = currentDate.getMonth();
    const currentMonth = currentMonthIndex + 1; // Add 1 to make it one-based
    return currentMonth;
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