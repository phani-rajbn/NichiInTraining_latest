//This demo is used to apply arrays in the HTML Page....
var emp = function(id, name, address){
	//JS does not have class keyword(It is available only from ES6). A function itself will return an object....
	this.empID = id;
	this.empName = name;
	this.empAddress = address;
	this.isRemoved = false;
}

var collection  = [];//Create an Array....
collection.push(new emp(123, 'Phaniraj','Bangalore'));
collection.push(new emp(124, 'Banu Prakash','Mysore'));
collection.push(new emp(125, 'Vinod Kumar','Shimoga'));
collection[2].isRemoved = true;

function addEmployee(empObj){
	collection.push(empObj);
	alert("Employee added successfully")
}

function deleteEmp(empID){
	for (var i = 0; i < collection.length; i++) {
		if(collection[i].empID == empID){
			//collection.splice(i, 1);
			collection[i].isRemoved = true;
			alert("Employee deleted");
			return;
		}
	}
}

function updateEmp(empObj){
	for (var i = 0; i < collection.length; i++) {
		if(collection[i].empID == empObj.empID){
			collection[i].empName = empObj.empName;
			collection[i].empAddress = empObj.empAddress;
			alert("Employee updated");
		}
	}	
}

function getAllRecords(){
	return collection;
}