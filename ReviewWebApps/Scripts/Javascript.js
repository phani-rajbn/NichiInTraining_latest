//function is a group of statements that are supposed to be executed very frequently in the App. U could invoke these statements as a single call. The function is  invoked only if U call the function in the main program....
function getData(){
	//creating an object  called emp with attributes empID, empName and empAddress...
	var emp ={
		empID:123, 
		empName:'SampleName',
		empAddress:'SampleAddress'
	}
	return emp;//returning the object...
}
//////////////////////////////////////////////////////////////////////////
//global function will get the message of the day...
function getMessage(){
	var today = new Date();//Gets the system date and time...
	var hr = today.getHours();//Get the Hour factor of the DateTime object.
	var message = '';
	if(hr < 12)
		message ="Good Morning";
	else if((hr >= 12) && (hr < 16))
		message = "Good Afternoon";
	else if((hr >= 16) && (hr < 21))
		message = "Good Evening";
	else
		message ="Good Night";
	return message;
}
//Basic requirement of using JS inside an HTML page is generate Dynamic content by manipulating the DOM elements using certain logic required for the Application...
//////////////////////////////////////////////////////////////////////////
//Calc Component which has even history in it....
//class to represent a single calculation
var operation = function(v1, v2, operand, result){
	this.Value1 = v1;
	this.Value2 = v2;
	this.operand = operand;
	this.result = result;
	this.time = getTime();
}
//////////////////////////////////////////////////////////////////////////
//This function delays the script for a certain period of time....
function wait(ms){
   var start = new Date().getTime();
   var end = start;
   while(end < start + ms) {
     end = new Date().getTime();
  }
}
//////////////////////////////////////////////////////////////////////////
//This function gets the time as hh:mm:ss format...
function getTime(){
			var date = new Date();
			var hh = date.getHours();
			var mm = date.getMinutes();
			var ss = date.getSeconds();
			return hh +" : " +mm + " : " + ss;
}
//////////////////////////////////////////////////////////////////////////
//The calc class does the mathematical calculation....
var calc = function(){
	var history = [];
	function addToHistory(op){
		if(history.length == 5)
			history.splice(0, 1);
		history.push(op);
		//Adds the item to the bottom of the list...
	}
    this.addFn = function(v1, v2){
    	var res = v1 + v2
    	var op = new operation(v1, v2, "+", res);
    	addToHistory(op);
    	return res;
    }
    this.subFn = function(v1, v2){
    	var res = v1 - v2
    	var op = new operation(v1, v2, "-", res);
    	addToHistory(op);
    	return res;
    }
    this.mulFn = function(v1, v2){
    	var res = v1 * v2
    	var op = new operation(v1, v2, "*", res);
    	addToHistory(op);
    	return res;
    }
    this.divFn = function(v1, v2){
    	if(v2 == 0)
    		throw "Division by zero is not allowed"
    	else{
	    	var res = v1 / v2
	    	var op = new operation(v1, v2, "/", res);
	    	addToHistory(op);
	    	return res;
    	}
    }
    this.getHistory = function(){
    	return history.reverse();
    }
}
//////////////////////////////////////////////////////////////////////////
//Exception handling and throwing in Javascript....
function handleException(){
	try{
		console.log(123/0);
		throw "Error in the function"//what U throw is what U catch...
	}catch(err){
		console.log("catch:" + err)
	}finally{
		console.log("finally:clean up")
	}
}

//////////////////////////////////////////////////////////////////////////
var book = function(id, title, cost){
			this.id = id;
			this.title = title;
			this.price = cost;
		}//book object...

var bookStore = function(){
	var store = [];
	load();
	function load(){
		var data = localStorage.getItem('data');//get
		if(data == null){
			//check whether data is available
			store = [];//if not available reset to []
		}else{
			store = JSON.parse(data);
		}
	}
	function save(){
		localStorage.setItem('data', JSON.stringify(store));
	}
	this.addBook = function(bk){
		store.push(bk);
		save();
	}

	this.search = function(title){
		var tempList = [];
		for(var i =0; i <store.length; i++){
			if(store[i].title.includes(title))
				tempList.push(store[i])
		}
		return tempList;
	}
	this.getAllBooks = function(){
		return store;
	}
}