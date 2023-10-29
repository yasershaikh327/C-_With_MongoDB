function FeedbackList() {
    fetch('/AdminApi/FetchContactDetails')
        .then(response => response.json())
        .then(data => {

            // Store the JSON data in an array
            var jsonArray = data;


            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
  

                var newRow = $("<tr>");
                var itemInputName = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.fullname.replace(/"/g, ""));

                var itemColumn1 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputName);



                var itemInputEmail = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.email.replace(/"/g, ""));

                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputEmail);



                var itemInputmessage = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.message.replace(/"/g, ""));

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputmessage);


                var itemInputReply = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .prop("required", true)
                    .attr("value", "Hi");
                   

                var itemColumn4 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputReply);

                var itemInputbutton = $("<button>")
                    .addClass("form-control form-control-lg beautiful-button") // Add the "beautiful-button" class
                    .attr("style", "background-color:red;color:white;font-weight:900")
                    .attr("value", item.email) // Pass the email value to the button
                    .attr("id", 'reply') // Pass the email value to the button
                    .text("Submit")
                    .click(function () {
                        // Store the input value in the 'replyValue' variable
                        replyValue = itemInputReply.val();
                        Send(this, item.email, replyValue); // Pass 'this', the email, and the input value to the Send function
                    });

                var itemColumn5 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputbutton);

                newRow.append(itemColumn1, itemColumn2, itemColumn3, itemColumn4, itemColumn5);
                $("#menuTable2 tbody").append(newRow);



            });


        })
        .catch(error => {
            console.error('Error:', error);
        });
}

//Reply Button
function Send(button, email,reply) {

    $.ajax({
        url: "/AdminApi/ReplyBack?email=" + email + "&reply=" + reply,
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json',

    });
    swal("Submitted Successfully", "", "success");
}




