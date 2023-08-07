$(document).ready(function () {
    // Function to fetch and display the student data
    function fetchStudentsData() {
        $.ajax({
            url: "/Student",
            type: "GET",
            dataType: "json",
            success: function (data) {
                studentDataList = data;
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

    //function to get single student data
    function displayStudent(data) {
        $("#searchedStudentdata").html("<p>Name: " + data.firstName+" "+data.lastName + "</p><p>Age: " + data.age + ", Course: "+data.course+ "</p>");
    }

    // Click event handler for the search button
    $("#searchButton").click(function (e) {
        e.preventDefault(); // Prevent the default form submission behavior
        var search = $("#searchInput").val();
        if (search === "") {
            alert("Please enter correct name in the search bar");
            return;
        }
        var userID = getStudentID(search);
        getStudentData(userID); // Call the function to get student data with the given search parameter (ID or name)
    });

    //function to obtain ID of single student
    function getStudentID(searchInput) {
        for (var i = 0; i < studentDataList.length; i++) {
            var student = {
                fname: studentDataList[i].firstName,
                lname: studentDataList[i].lastName,
                studentID: studentDataList[i].ID
            };
            if (student.fname.toLowerCase().includes(searchInput) || student.lname.toLowerCase().includes(searchInput)) {
                return student.studentID;
            }
        }
    }

    // Function to get single student data
    function getStudentData(ID) {
        $.ajax({
            url: '/Student/' + ID,
            type: 'GET',
            success: function (data) {
                console.log('Student data retrieved successfully:', data);
                displayStudent(data);
            },
            error: function (error) {
                console.error('Error getting student data:', error);
            }
        });
    }

    // Fetch and display the student data on page load
    fetchStudentsData();
});
var studentDataList;