/*this chunk of code sets up a dropdown menu when mouse hovers over the navbar links \
and then hides it when mouse moves away from the link*/
const navbarlinkSEA = document.getElementById('SEA');
const dropdownmenu1 = document.querySelector('.dropdown-content1');
navbarlinkSEA.addEventListener('mouseover', () => dropdownonHover(dropdownmenu1));
navbarlinkSEA.addEventListener('mouseout', () => resetOnMouseOut(dropdownmenu1));

const navbarlinkCI = document.getElementById('CI');
const dropdownmenu2 = document.querySelector('.dropdown-content2');
navbarlinkCI.addEventListener('mouseover', () => dropdownonHover(dropdownmenu2));
navbarlinkCI.addEventListener('mouseout', () => resetOnMouseOut(dropdownmenu2));

const navbarlinkAfr = document.getElementById('Afr');
const dropdownmenu3 = document.querySelector('.dropdown-content3');
navbarlinkAfr.addEventListener('mouseover', () => dropdownonHover(dropdownmenu3));
navbarlinkAfr.addEventListener('mouseout', () => resetOnMouseOut(dropdownmenu3));

function dropdownonHover(dropdown) {
  dropdown.style.display = 'block';
  const dropdownLinks = dropdown.querySelectorAll('.dropdown-link');
  dropdownLinks.forEach(link => {
    link.addEventListener('mouseover', () => { link.style.backgroundColor = 'grey'; })
    link.addEventListener('mouseout', () => { link.style.backgroundColor = 'transparent'; });
  });
}
function resetOnMouseOut(dropdown) {
  dropdown.style.display = 'none';
}
/*switches image back and forth when button clicked*/
const imageSwitchButn = document.getElementById('imageSwitcher');
const switchingImage = document.getElementById('switchableImage');
imageSwitchButn.addEventListener('click', function () {
  if (switchingImage.getAttribute('src') == 'https://rachelgouk.com/wp-content/uploads/2021/01/portman-ritz-carlton-southeast-asian-shanghai-4.jpg') {
    switchingImage.setAttribute("src", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Phat_Thai_kung_Chang_Khien_street_stall.jpg/1200px-Phat_Thai_kung_Chang_Khien_street_stall.jpg");
  }

  else {
    switchingImage.setAttribute("src", "https://rachelgouk.com/wp-content/uploads/2021/01/portman-ritz-carlton-southeast-asian-shanghai-4.jpg");
  }
})
/*table manipulation*/
var calTable = document.getElementById('calTable');
/*adds a row to table upon button click*/
const addtablerowsbtn = document.getElementById('rowAdder');
addtablerowsbtn.addEventListener('click', function () {
  var row = calTable.insertRow(5);
  var cell1 = row.insertCell(0);
  var cell2 = row.insertCell(1);
  var cell3 = row.insertCell(2);
  var cell4 = row.insertCell(3);
  cell1.innerHTML = 'New Food Item';
  cell2.innerHTML = 'New Category';
  cell3.innerHTML = 0;
  cell4.innerHTML = '$0.00';
})
/*sorts table upon button click*/
const tableSorterCalbtn = document.getElementById('tableSorterCal');
tableSorterCalbtn.addEventListener('click', function () {
  var rows = calTable.rows;
  let switching = true;
  var i;
  while (switching) { /*while loop runs until there is no more switching to be done*/
    switching = false;
    for (i = 1; i < rows.length - 1; i++) {
      var shouldSwitch = false;
      var x = rows[i].getElementsByTagName('td')[2]; /*get data from 3rd column*/
      var y = rows[i + 1].getElementsByTagName('td')[2];
      if (Number(x.innerHTML) > Number(y.innerHTML)) {
        shouldSwitch = true;
        break;
      }
    }
    if (shouldSwitch) {
      rows[i].parentNode.insertBefore(rows[i + 1], rows[i]); /*swaps the elements of the second row with the one before it*/
      switching = true; /*switching remains true until there has been a swap*/
    }
  }

})
/*to validate form*/
function validateForm() {
  const fname = document.forms["FPQuiz"]['name'].value;
  const fage = document.forms["FPQuiz"]['age'].value;
  const fdob = document.forms["FPQuiz"]['dob'].value;
  if (fname == '' || fage == '' || fdob == '') {
    alert("All details must be filled out");
    return false; /*form not submitted if name, age or dob empty*/
  }
  if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(FPQuiz.email.value)) /*email validation*/
  {}
  else{
    alert("You have entered an invalid email address!")
    return (false)
  }
    
}