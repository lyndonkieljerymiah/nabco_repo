/*********************************
 * Item Dialog Controller
 * 
 * 
 ******************************/
app.controller('ItemDialogController', function ($uibModal, $scope)
{

    var $ctrl = this;
    var parentElem = angular.element($('.modal-demo'));

    //open edit/create item
    $ctrl.open = function (path) {

        $scope.item = {};
        $uibModal.open(
        {
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: path,
            appendTo: parentElem,
            controller: 'ModalInstanceCtrl',
            controllerAs: '$ctrl',
            resolve: null

        });
    }

    //open detail form
    $ctrl.openDetail = function (path)
    {
        $uibModal.open(
       {
           ariaLabelledBy: 'modal-title',
           ariaDescribedBy: 'modal-body',
           templateUrl: path,
           appendTo: parentElem,
           controller: 'ModalInstanceCtrl',
           controllerAs: '$ctrl'
       });
    }
});



/*******************************
 * 
 * Modal Instance Controller
 * 
 *******************************/
app.controller('ModalInstanceCtrl',
    function ($uibModalInstance, $scope, ajaxService)
    {
        var $ctrl = this;
        $ctrl.ok = function ()
        {
            var uriUpdate = $("#frmItemEntry").data("action");
            console.log(uriUpdate);
            //console.log($scope.item);
            //execute post here to save item
            ajaxService.postForm($scope.item,
               uriUpdate,
               function (data)
               {
                    $uibModalInstance.dismiss({ value: 'cancel' });
                    window.location.replace("http://localhost:50305/item");
                });
        }

        $ctrl.cancel = function() {
            $uibModalInstance.dismiss({ $value: 'cancel' });
        }

    });