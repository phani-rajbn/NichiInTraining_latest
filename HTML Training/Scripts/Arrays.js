//Arrays.js
//What is an Array? An Array is a collection of similar types of data which is represented as a single unit...
//A unit could be a combination of different data types which is called as object...
var emp = function(id, name, address){
	this.empID = id;
	this.empName = name;
	this.empAddress = address;
}//created a class in JS by a name called emp...
//internally a class is a collection of fields. They are stored as elements of a dictionary...
var emp1 = new emp(123, 'Phaniraj', 'Bangalore');
//alert(emp1.empName);
var emp2 = new emp(124, 'Ananth', 'Mysore');
//alert(emp2.empName);
var emp3 = new emp(125, 'Somnath', 'Mysore');
//alert(emp3.empName);

var collection = [];//Syntax of array in JS...
collection.push(emp1);//push adds the element to the bottom of the collection...
collection.push(emp2);
collection.push(emp3);
//alert(collection.length)
var id = prompt("Enter the ID to delete");
for (var i = 0; i < collection.length; i++) {
	if(collection[i].empID == id){
		collection.splice(i, 1);
	}
}
alert(collection.length)