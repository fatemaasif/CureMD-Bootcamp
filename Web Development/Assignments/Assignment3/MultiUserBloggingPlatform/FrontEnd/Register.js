$(document).ready(function () {
    // Register button click event handler
    $("#registerButton").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        // Get form data
        var email = $("#emailInput").val();
        var username = $("#usernameInput").val();
        var password = $("#passwordInput").val();

        if (email == "" || username == "" || password == "") {
            alert("Please fill in all the required fields.");
            return; // Stop form submission if any field is empty
        }

        // Create the data object to be sent to the server
        var data = {
            "Email": email,
            "Username": username,
            "PassWd": password
        };

        // Make an AJAX POST request to the server to register the user
        $.ajax({
            type: "POST",
            url: "/api/Users", 
            data: JSON.stringify(data),
            contentType: "application/json",
            success: function (response) {
                // Registration successful
                alert("Registration successful!");
                window.location.href = 'HomePage.html';
            },
            error: function (xhr, status, error) {
                // Registration failed
                var errorMessage = xhr.responseText;
                alert(errorMessage);
            }
        });
    });
});