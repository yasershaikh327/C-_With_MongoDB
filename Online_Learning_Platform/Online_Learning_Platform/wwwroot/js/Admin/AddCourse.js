
//Add Course
function AddCourse() {
    var Vidoe = $("#fileInput").val();
    var Coursename = $("#CourseName").val();
    var Price = $("#Price").val();
    var Instructor = $("#Instrcutor").val();
    var Desciption = $("#Description").val();
/*
    if (CourseLogo.files.length > 0) {
        var file1 = CourseLogo.files[0].name;
    }
    else if (CourseInstc.files.length > 0) {
        var file2 = CourseInstc.files[0].name;
    }
    else if (Vidoe.files.length > 0) {
        var file3 = Vidoe.files[0].name;
    }
    else*/ if (Coursename == "") {
        swal("Please Enter Course Name ");
    }
    else if (Price == "") {
        swal("Please Enter Price ");
    }
    else if (Instructor == "") {
        swal("Please Enter Instructor ");
    }
    else if (Desciption == "") {
        swal("Please Enter Description");
    }
     else {

         //Add Course
         var Course = {
             CourseName: Coursename,
             Price: Price,
             Instructor: Instructor,
             Descsription: Desciption,
             CourseVideos: Vidoe,
        };





        //Add Details
        $.ajax({
            type: "POST",
            url: "/AdminApi/AddCourse",
            data: JSON.stringify(Course),
            contentType: "application/json",
            dataType: "json",


        });


         //Add Images and Videos:
        var form = $('#uploadForm')[0];
        var formData = new FormData(form);

        var fileName = fileInput.files[0].name; // Get the file name
        var formData = new FormData(form);
        formData.append('files', fileName);

        $.ajax({
            type: 'POST',
            url: '/AdminApi/Photos',
            data: fileName,
            processData: false, // Don't process the data
            contentType: false, // Don't set content type
        });



        swal("Courses Added Successfully");
        
    }
}


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