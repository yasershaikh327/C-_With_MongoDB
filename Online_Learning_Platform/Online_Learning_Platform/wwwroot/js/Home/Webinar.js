//Webinars
function FetchAllWebinars() {
    fetch('/AdminApi/FetchWebinar')
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
            <h3 class="card-title">${course.webinarName}</h5>
            <div id="para"><p class="card-text">${course.webinarDescription}</p></div>
          
            </div>
        </div>
        </div>
      `;
            }

            // Select the element with the id "coursesBox"
            var parentContainer = document.getElementById('coursesBox2');

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
    ;

}