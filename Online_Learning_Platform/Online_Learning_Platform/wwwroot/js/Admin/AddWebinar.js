function AddWebinar() {
    var WebinarName = $("#WebinarName").val();
    var WebinarDescription = $("#WebinarDescription").val();

    if (WebinarName == "") {
        swal("Please Enter Webinar Name ");
    }
    else if (WebinarDescription == "") {
        swal("Please Enter Description ");
    }
    else {


        //Add Webinar
        var Webinar = {
            WebinarName: WebinarName,
            WebinarDescription: WebinarDescription,
            
        };

        $.ajax({
            type: "POST",
            url: "/AdminApi/AddWebinar",
            data: JSON.stringify(Webinar),
            contentType: "application/json",
            dataType: "json",


        });


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