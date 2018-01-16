var emp = function(id, name, address){
	this.empID = id;
	this.empName = name;
	this.empAddress = address;
}
//Repository object....
var collection = function(){
	var collection = JSON.parse(localStorage.getItem("myData"));

	this.addEmployee = function(empObj){
		collection.push(empObj);
		var jsonData = JSON.stringify(collection);
		localStorage.setItem("myData", jsonData);
	}

	this.getEmployees = function(){
		var jsonData = localStorage.getItem("myData");
		collection = JSON.parse(jsonData);
		return collection;
	}

	this.findRecord = function(id){
		var jsonData = localStorage.getItem("myData");
		collection = JSON.parse(jsonData);
		for (var i = 0; i < collection.length; i++) {
			if(collection[i].empID == id){
				return collection[i];
			}
		}	
	}
}