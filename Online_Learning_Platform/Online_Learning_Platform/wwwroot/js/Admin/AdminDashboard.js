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

function Test() {
    if (sessionStorage.getItem('Email') == null || sessionStorage.getItem('Email') == "" || sessionStorage.getItem('Email').length <= 0) {
        window.location.href = '/Home/Index';
        //console.log(sessionStorage.getItem('AdminID'));
        return false;
    }
}



//Fetch Employee Data and store in textboxes
function EmployeeDetail() {

    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable tbody");

    var index = 0;

    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/UserApi/FetchBookingDetails')
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



                var itemInputName = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.user.replace(/"/g, ""));

                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputName);



                var itemInputCourse = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.course.replace(/"/g, ""));

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputCourse);



                var itemInputinstructor = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.instructor.replace(/"/g, ""));

                var itemColumn4 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputinstructor);



                newRow.append(itemColumn1, itemColumn2, itemColumn3, itemColumn4);
                $("#menuTable tbody").append(newRow);



            });
       

        })
        .catch(error => {
            console.error('Error:', error);
        });
}


let callCount = 0;
//Fetch Employee Data and store in textboxes
function CourseDetail() {

    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable1 tbody");
    var index = 0;
    callCount++;

    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/AdminApi/FetchCourses')
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



                var itemInputName = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.instructor.replace(/"/g, ""));

                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputName);



                var itemInputCourse = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.courseName.replace(/"/g, ""));

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputCourse);



                var itemInputinstructor = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", getTodaysDate());

                var itemColumn4 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputinstructor);



                newRow.append(itemColumn1, itemColumn2, itemColumn3, itemColumn4);
                $("#menuTable1 tbody").append(newRow);
              


            });

        })
        .catch(error => {
            console.error('Error:', error);
        });
}


function getTodaysDate() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0'); // Day
    var mm = String(today.getMonth() + 1).padStart(2, '0'); // Month (0-based, so we add 1)
    var yyyy = today.getFullYear(); // Year

    return mm + '/' + dd + '/' + yyyy; // Format the date as MM/DD/YYYY
}

