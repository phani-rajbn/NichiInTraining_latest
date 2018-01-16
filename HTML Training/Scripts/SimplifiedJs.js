//Helper function for getting the element by id....
function get(input){
	return document.getElementById(input);
}

function $click(input, fn){
	document.getElementById(input).addEventListener('click', fn);
}

function $(input, event, fun){
	document.getElementById(input).addEventListener(event, fun);
}
