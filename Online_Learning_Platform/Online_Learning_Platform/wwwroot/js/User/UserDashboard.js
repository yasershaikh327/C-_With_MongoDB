function CheckifSessionisNull() {
    var employeeID = sessionStorage.getItem('EmployeeID');
    if (employeeID === null) {
        var body = document.body;
        document.body.style.backgroundColor = "black";
        document.body.style.opacity = "0.5";
        document.body.style.pointerEvents = "none";

        swal.opacity = 0.5;

        swal("Please Sign In");
        setTimeout(function () {
            // Redirect to another page after 3 seconds
            window.location.href = '/Home/Login';
        }, 2000);
    }
    else {
        FetchBookedCourses();
    }
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


//Fetch Booked Courses
function FetchBookedCourses() {


    //Fetch User Details:
    fetch('/AdminApi/GetUsers')
        .then(response => response.json())
        .then(data2 => {
            var jsonArray2 = data2;
            // Assuming your data is an array of users
            // Find the user with the given userId
            var user = jsonArray2.find(user => user.id === parseInt(sessionStorage.getItem("EmployeeID")));
       


    // Get the element where you want to display the textbox
            var tableBody = $("#menuTable3 #tableBody1");
    var index = 0;
  

    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/UserApi/FetchUserBookingDetails?Email='+user.email)
        .then(response => response.json())
        .then(data => {

            // Store the JSON data in an array
            var jsonArray = data;

            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
                index++;

                var newRow = $("<tr>");
                var itemInputSrNo = $("<input>")
                    .attr("type", "text")
                    .attr("value", index)
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true);

                var itemColumn1 = $("<td>")
                    .css("width", "10%")
                    .append(itemInputSrNo);

                var itemInputInstrcutor = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.instructor.replace(/"/g, ""));


                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputInstrcutor);

                var itemInputCourse = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.course.replace(/"/g, ""));

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputCourse);



                var itemInputDateAdded = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", getTodaysDate());

                var itemColumn4 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputDateAdded);



                newRow.append(itemColumn1, itemColumn2, itemColumn3, itemColumn4);
                $("#menuTable3 tbody").append(newRow);



            });

        })
        .catch(error => {
            console.error('Error:', error);
        });
    });
}

function getTodaysDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0'); // Day
    var mm = String(today.getMonth() + 1).padStart(2, '0'); // Month (0-based, so we add 1)
    var yyyy = today.getFullYear(); // Year

    return mm + '/' + dd + '/' + yyyy; // Format the date as MM/DD/YYYY
}

