

function FetchMoreCourseDetails() {
    var courseId = sessionStorage.getItem('courseId');
    
    fetch('/AdminApi/FetchCourses')
        .then(response => response.json())
        .then(data => {
            var jsonArray = data;
            // Assuming your data is an array of courses
            // Find the course with the given courseId
            var course = jsonArray.find(course => course.id === parseInt(courseId));

            sessionStorage.setItem("CourseId", courseId);

            if (course) {
                // You can now access the details of the course
           
               //Prof Details
                document.getElementById("profName").innerText = course.instructor;
                document.getElementById("profEmail").innerText = course.instructor;

                //Course Details
                document.getElementById("courseNameDisplay").innerText = course.courseName;
                document.getElementById("DescriptionToDisplay").innerText = course.descsription;
                document.getElementById("courseNameDisplay1").innerText = course.courseName;
                document.getElementById("DescriptionToDisplay1").innerText = course.descsription;
                document.getElementById("prices").innerText = course.price;


                //Video Details:
                // Get a reference to the video element using its ID
                var videoElement = document.getElementById('myVideo');
                const filename = course.courseVideos.replace(/^.*[\\\/]/, '');
    
                videoElement.src = "/CourseVideos/" + filename;

                // You can also set other attributes and properties, such as controls, poster, etc.
                // For example:
                videoElement.controls = true;
                videoElement.poster = 'video_poster.jpg';

                // To start playing the video, you can call the play() method
                videoElement.play();



            } else {
                console.log('Course not found');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
}


//Buy Course
function BuyCourse() {
    var courseId = sessionStorage.getItem("CourseId");
    var userId = sessionStorage.getItem("EmployeeID");

    if (userId == null) {
        swal("Please Log In", "Redirecting to Login Page", "info"); // Changed "Please Login In" to "Please Log In"
        setTimeout(function () {
            window.location.href = '/Home/Login';
        }, 1500);
    }
    else {
        fetch('/AdminApi/FetchCourses')
            .then(response => response.json())
            .then(data => {
                var jsonArray = data;
                // Assuming your data is an array of courses
                // Find the course with the given courseId
                var course = jsonArray.find(course => course.id === parseInt(courseId));

                // Fetch User Data
                fetch('/AdminApi/GetUsers')
                    .then(response => response.json())
                    .then(data2 => {
                        var jsonArray2 = data2;
                        // Assuming your data is an array of users
                        // Find the user with the given userId
                        var user = jsonArray2.find(user => user.id === parseInt(userId));

                        var CourseBook = {
                            User: 'user.name',
                            Email: user.email,
                            Course: course.courseName,
                            Instructor: 'course.instructor',
                        };



                        // Check if the course is booked
                        $.ajax({
                            type: "POST",
                            url: "/UserApi/CheckIfCourseIsBooked",
                            data: JSON.stringify(CourseBook),
                            contentType: "application/json",
                            dataType: "json",
                            success: function (response) {
                                if (response === false || response === "false") {
                                    swal("Course Already Purchased", "", "warning");
                                } else {
                                    swal("Redirecting to Payment Page", "Please do not press the back button or refresh the page", "warning"); // Updated the message
                                    setTimeout(function () {
                                        window.location.href = '/User/Payment';
                                    }, 1500);
                                }
                            },
                        });
                    });

               
            });
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