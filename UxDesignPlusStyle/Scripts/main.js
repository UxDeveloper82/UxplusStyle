//Budget Controller

var budgetController = (function () {
  

})();

var UIController = (function () {



})();

// GLobal App Controller
var controller = (function (budgetCtrl, UICtrl) {

    document.querySelector('.add__btn').addEventListener('click', function () {
        console.log('button was click');
    });
})(budgetController, UIController);