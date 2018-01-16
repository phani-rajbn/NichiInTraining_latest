//Loops.js
//Loops are used to iterate the piece of code for a certain period, no of Times or until a condition is satisfied...
//for loop, while loop, do-while loop and for-in loop...
function forLoopDemo() {
	//for loop iterates to a specific no of times. It will be used only if U know the exact no of times the iteration should happen...
	var times = parseInt(prompt("Enter the no of times U want to iterate"));
	for (var i = 1; i <= times; i++) {
		document.write("The loop beep no {" + i +"}<br/>");
		//while U work with Arrays, index always starts with 0. So make sure that UR max limit is always less than the length of the Array.	
	}
}

function whileLoopDemo(){
	//Use while loop for infinite no of times or until a boolean condition is satisfied to true...In this case, the condition is tested first and then if true goes into the loop...
	var maxTimes = parseInt(prompt("Enter the max Times"));
	var iterator =0;
	while(maxTimes != iterator){
		document.write("while loop no " + iterator +"<br>");
		iterator++;
	}
}

//Works similar to while loop except the loop executes atleast once. The condition is tested after the loop is executed. So U could execute the block atleast once before the condition is evaluated to true. 
function dowhileLoopDemo() {
	var result = "yes";
	do{
		document.write("Atleast once");
		result = prompt("Do U want to continue?");
	}while(result =="yes");
}

//In JS, every object is a collection of its fields and methods. To iterate thro all the fields of the object, U could use for..in..U can use for..in on a collection like an object, Array and U dont have to know the length of the collection and the iteration will always be within the bounds of the collection. for..in works only in a forward only manner and read only manner..
function forinLoopDemo() {
	var emp = {empId:123, empName:"Phaniraj", empAddress:"Bangalore"};
	for(field in emp){
		document.write(field +":" + emp[field] +"<br/>");
	}//field is the key which represents the field of the class. it is not a keyword. Accessing the values of the members would be thro this key which acts like a index...

	var elements =['Apple','Mango','Orange'];
	for(item in elements){
		document.write(elements[item]);
	}
}














