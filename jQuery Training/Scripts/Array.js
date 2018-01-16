//Array.js
var student = function(id, name, address, date){
	this.Id = id;
	this.name = name;
	this.address = address;
	this.dob = date;
}//Class for the student....

var Collection = function(){
	var data = load();
	//save();
	function save(){
		localStorage.setItem("data", JSON.stringify(data));
	}
	function load(){
		var json = localStorage.getItem("data");
		data = JSON.parse(json);
		for (var i = 0; i < data.length; i++) {
			var dt = data[i].dob;//in the form of string
			data[i].dob = new Date(dt);//Convert to actual date...
		}
	}
	/*data.push(new student(111, 'Phaniraj', 'Bangalore', new Date("02/22/1977")))
	data.push(new student(112, 'Banu Prakash', 'Bangalore', new Date("12/30/1967")))
	data.push(new student(113, 'Vinod', 'Shimoga', new Date("04/12/1974")))*/
	
	this.allRecords = function(){
		load();
		return data;
	}

	this.register = function(student){
		data.push(student);
		save();
	}

	this.find = function(name){
		load();
		var subset =[];
		for(s in data){
			if(data[s].name.includes(name))
				subset.push(data[s]);
		}
		return subset;
	}

	this.update = function(student){
		for (var i = 0; i < data.length; i++) {
			if(data[i].Id == student.Id){
				data[i].name = student.name;
				data[i].address = student.address;
				data[i].dob = student.dob;
				return;//exit the function...
			}
		}
	}
}

