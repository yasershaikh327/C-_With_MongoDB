
    function FetchAllCourses() {
        fetch('/AdminApi/FetchCourses')
            .then(response => response.json())
            .then(data => {
                var jsonArray = data;
                var index = 0;

                // Function to generate HTML for a course item
                function createCourseCard(course) {
                    return `
                    <div class="col-sm">
                        <div class="card" style="width: 18rem;">
                            <div class="card-body">
                                <h3 class="card-title">${course.courseName}</h3>
                                <div id="para">
                                    <p class="card-text">${course.descsription}</p>
                                </div>
                                <button type="button" class="btn btn-primary" data-course-id="${course.id}">More Details</button>
                            </div>
                        </div>
                    </div>
                `;
                }

                // Select the element with the id "coursesBox"
                var parentContainer = document.getElementById('coursesBox');

                // Event listener for the "More Details" buttons
                parentContainer.addEventListener('click', function (event) {
                    if (event.target.matches('button[data-course-id]')) {
                        // Get the course ID from the button's data attribute
                        var courseId = event.target.getAttribute('data-course-id');

                        // Redirect to another page with the course ID
                        window.location.href = '/User/CourseDetails';
                        sessionStorage.setItem('courseId', courseId);
                    }
                });

                // Iterate over the array containing the JSON data
                jsonArray.forEach(course => {
                    var courseHTML = createCourseCard(course);
                    // Append the generated HTML to the parent container
                    parentContainer.innerHTML += courseHTML;
                    index++;
                });
            })
            .catch(error => {
                console.error('Error:', error);
            });
    }







//Fetch All Courses
function FetchAllCourses2() {
    fetch('/AdminApi/FetchCourses')
        .then(response => response.json())
        .then(data => {
            var jsonArray = data;
            var index = 0;

            // Function to generate HTML for a course item
            function createCourseCard(course) {
                return `
    <div class="col-lg-3 col-md-4 col-sm-6" id=YY>
                    <div class="card" style="width: 100%;">
                        <div class="card-body">
                            <h3 class="card-title" id="titles">${course.courseName}</h3>
                       
                            <div id="para">
                                <p class="card-text">
                                  ${course.descsription}
                                </p>

                            </div>
                             <button type="button" class="btn btn-primary" data-course-id="${course.id}">More Details</button>
                        </div>
                    </div>
                    <br>
                </div>
                `;
            }

            // Select the element with the id "coursesBox"
            var parentContainer = document.getElementById('coursesBox2');

            // Event listener for the "More Details" buttons
            parentContainer.addEventListener('click', function (event) {
                if (event.target.matches('button[data-course-id]')) {
                    // Get the course ID from the button's data attribute
                    var courseId = event.target.getAttribute('data-course-id');

                    // Redirect to another page with the course ID
                    window.location.href = '/User/CourseDetails';
                    sessionStorage.setItem('courseId', courseId);
                }
            });

            // Iterate over the array containing the JSON data
            jsonArray.forEach(course => {
                var courseHTML = createCourseCard(course);
                // Append the generated HTML to the parent container
                parentContainer.innerHTML += courseHTML;
                index++;
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
}


//Search Courses
function SearchCourses() {

    var searchInput = document.getElementById('searchbar');
    // const listItems = document.querySelectorAll('.grid-container .grid-item');
    const listItems = document.querySelectorAll('#YY');
    var count;
    searchInput.addEventListener('keyup', function () {
        const searchTerm = searchInput.value.toLowerCase();
        listItems.forEach(function (item) {
            const text = item.textContent.toLowerCase();
            if (text.includes(searchTerm)) {
                item.style.display = 'block';
            } else {
                item.style.display = 'none';
            }
        });
    });
}

function myFunction(x) {
    x.classList.toggle("change");

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
