
var question = function(subject, question, choice1, choice2, choice3, choice4, rightAnswer){
	this.subject = subject;
	this.question = question;
	this.choice1 = choice1;
	this.choice2 = choice2;
	this.choice3 = choice3;
	this.choice4 = choice4;
	this.rightAnswer = rightAnswer;
	alert("All the details are set")
}

var bank = function(){
	var questions = [];
	load();
	function save(){
		localStorage.setItem('AllQuestions', JSON.stringify(questions));
	}
	function load(){
		if(localStorage.getItem('AllQuestions') != undefined){
			questions = JSON.parse(localStorage.getItem('AllQuestions'));
		}
	}
	this.addQuestion = function(questionInfo){
		questions.push(questionInfo);
		save();
	}
	this.findAllQuestions = function(subject){
		load();
		var list = [];
		$.each(questions, function(index, question){
			if(question.subject == subject)
				list.push(question);
		});
		return list;
	}
}

