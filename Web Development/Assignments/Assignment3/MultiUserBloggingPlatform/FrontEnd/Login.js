$(document).ready(function () {
    $("#loginbtn").click(function (e) {
        e.preventDefault(); // Prevent the default form submission

        // Get form data
        var username = $("#username").val();
        var password = $("#password").val();

        if (username == "" || password == "") {
            alert("Please fill in all the required fields.");
            return;
        }

        var userdata = {
            "Username": username,
            "Password": password
        };

        $.ajax({
            type: "GET",
            url: "/api/Users/" + username + "/" + password,
            contentType: "application/json",
            success: function (response) {
                // Login successful
                alert("Login successful!");
                window.location.href = 'HomePage.html';
            },
            error: function (xhr, status, error) {
                // Login failed
                var errorMessage = xhr.responseText;
                alert(errorMessage);
            }
        });
    });
});
