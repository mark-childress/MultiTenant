
function HomeController ($scope){
    $scope.sessions = [
        {title: 'Javascript', speaker: 'Crockford'},
        {title: 'C', speaker: 'Ritchie'},
        {title: 'Java', speaker: 'Gosling'},
        {title: 'C#', speaker: 'Hjlsberg'}
    ];
}

HomeController.$inject = ['$scope'];

module.exports = HomeController;