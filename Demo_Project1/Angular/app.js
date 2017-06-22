var app = angular
	.module("myModule", [])
	.controller("myController", function ($scope, $http) {
		$http.post('QuestionService.asmx/GetAllQuestions')
			.then(function (response) {
				$scope.questions = response.data;
			});
	});