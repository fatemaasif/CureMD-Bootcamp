$(document).ready(function () {
    // Function to fetch and display the student data
    function fetchStudentsData() {
        $.ajax({
            url: "/api/Student", 
            type: "GET",
            dataType: "json",
            success: function (data) {
                displayStudents(data);
            },
            error: function (xhr, status, error) {
                console.log("Error occurred while fetching student data: " + error);
            }
        });
    }

    // Function to display the student data in the list format
    function displayStudents(students) {
        var studentList = $("#studentList");
        studentList.empty();

        if (students.length == 0) {
            studentList.append("<li>No students found.</li>");
            return;
        }

        students.forEach(function (student) {
            //display each student as Fn Ln - Age: xx, Course: abc
            var listItem = $("<li>").text(student.firstName + " " + student.lastName + " - Age: " + student.age + ", Course: " + student.course);
            studentList.append(listItem);
        });
    }

    // Function to implement IntelliSense-style search
    $("#searchInput").on("input", function () {
        var searchTerm = $(this).val().toLowerCase();
        var studentList = $("#studentList li");

        studentList.each(function () {
            var studentName = $(this).text().toLowerCase();

            if (studentName.includes(searchTerm)) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
    });

    // Fetch and display the student data on page load
    fetchStudentsData();
});
