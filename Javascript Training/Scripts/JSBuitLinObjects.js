//JS has certain ready to use objects for our day to day activities: DateTime, Math, String, Number and Boolean operations. 
function DateTimeOperations() {
	var date = new Date();
	document.write(date +"<br/>");
	document.write("The Year is " + date.getFullYear() +"<br/>");
	document.write("The Month is " + (parseInt(date.getMonth()) + 1) +"<br/>");
	document.write("The Date of the Month is " + date.getDate() +"<br/>");
	document.write("The Day of the Week is " + (parseInt(date.getDay()) + 1) +"<br/>");//Tuesday is 2, index starts with 0.
	var dob = parseInt(prompt("Enter the Year of birth"));
	var age = date.getFullYear() - dob;
	document.write("The Current age is " + age);

}
function getTime(){
	var today = new Date()
	var time  = "" + today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
	return time; 
}