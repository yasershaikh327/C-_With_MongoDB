
function AutoSeedData() {

    //Customer Data
    var customerData = [
        {
            Id:"481cf36a-fdb8-4911-853f-34ad26df4a2a",
            FirstName: "Alice",
            LastName: "Smith",
            DOB: "1987-01-01",
        },
        {
            Id:"1db7a052-91d5-43f0-8eeb-c852b504cd59",
            FirstName: "Bob",
            LastName: "Smith",
            DOB: "1987-01-01",
        }
    ];

    for (let i = 0; i < customerData.length; i++) {
        {
            $.ajax({
                type: "POST",
                url: "/HomeApi/AddCustomer",
                data: JSON.stringify(customerData[i]),
                contentType: "application/json",
                dataType: "json",
            });
        }
    }

    //Order Details:
    var orderData = [
        {
            customer_Id: "481cf36a-fdb8-4911-853f-34ad26df4a2a",
            itemName: "Nail Polish",
            itemPrice: 100.00,
        },
        {
            customer_Id: "481cf36a-fdb8-4911-853f-34ad26df4a2a",
            itemName: "Hair Brush",
            itemPrice: 500.00,
        },
        {
            customer_Id: "1db7a052-91d5-43f0-8eeb-c852b504cd59",
            itemName: "Shaving Cream",
            itemPrice: 90.00,
        }
    ];

    for (let j = 0; j < orderData.length; j++)
    {
        {
            $.ajax({
                type: "POST",
                url: "/HomeApi/AddOrders",
                data: JSON.stringify(orderData[j]),
                contentType: "application/json",
                dataType: "json",
            });
        }
    }


  
}

//Fetch Customer Details
function FetchCustomerDetails() {


    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable3");

    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/HomeApi/GetCustomers')
        .then(response => response.json())
        .then(data => {

            // Store the JSON data in an array
            var jsonArray = data;

            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {
      

                var newRow = $("<tr>");
                var itemcustomerID = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.id);


                var itemColumn1 = $("<td>")
                    .css("width", "20%")
                    .append(itemcustomerID);

                var itemInputCustomerName = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.firstName);

                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputCustomerName);



                var itemInputDOB = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.dob);

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputDOB);


                var itemAction = $("<a>")
                    .attr("href", "#") // Set the href attribute to the desired URL
                    .attr("data-value", item.id) // Store the value in a custom "data-value" attribute
                    .addClass("form-control form-control-lg") // Add the specified class
                    .text("View Orders") // Set the text content
                    .on("click", function () {
                        var value = $(this).data("value"); // Retrieve the value from the data-value attribute
                        FetchOrderDetails(value); // Call your function and pass the retrieved value
                    });
                   

                var itemColumn4 = $("<td>")
                    .css("width", "20%")
                    .append(itemAction);



                newRow.append(itemColumn1, itemColumn2, itemColumn3, itemColumn4);
                $("#menuTable3").append(newRow);



            });

        })
        .catch(error => {
            console.error('Error:', error);
        });
}




//Fetch Indiviual Details
//Fetch Order Details
function FetchOrderDetails(ID) {
    // Get the element where you want to display the textbox
    var tableBody = $("#menuTable4");
    tableBody.empty();


    // Perform an AJAX request to fetch the JSON data
    // Make an HTTP request to fetch the JSON data
    fetch('/HomeApi/GetOrders?Id='+ID)
        .then(response => response.json())
        .then(data => {

            // Store the JSON data in an array
            var jsonArray = data;

            // Iterate over the array containing the JSON data
            jsonArray.forEach(item => {


                var newRow = $("<tr>");
                var itemcustomerID = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.id);


                var itemColumn1 = $("<td>")
                    .css("width", "20%")
                    .append(itemcustomerID);

                var itemInputItemName = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.itemName);

                var itemColumn2 = $("<td>")
                    .css("width", "20%")
                    .append(itemInputItemName);



                var ItemInputItemPrice = $("<input>")
                    .attr("type", "text")
                    .addClass("form-control form-control-lg")
                    .attr("readonly", true)
                    .prop("required", true)
                    .attr("value", item.itemPrice);

                var itemColumn3 = $("<td>")
                    .css("width", "20%")
                    .append(ItemInputItemPrice);


                newRow.append(itemColumn1, itemColumn2, itemColumn3);
                $("#menuTable4").append(newRow);



            });

        })
        .catch(error => {
            console.error('Error:', error);
        });
}