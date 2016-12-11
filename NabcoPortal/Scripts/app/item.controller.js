/*********************************
 * Item Dialog Controller
 * 
 * 
 ******************************/
app.controller('ItemDialogController', function ($uibModal, $scope)
{

    var $ctrl = this;
    var parentElem = angular.element($('.modal-demo'));

    function openModal(path)
    {
        
        var opt =
            {
                ariaLabelledBy: 'modal-title',
                ariaDescribedBy: 'modal-body',
                templateUrl: path,
                appendTo: parentElem,
                controller: 'ModalInstanceCtrl',
                controllerAs: '$ctrl',
                resolve: null
            };
        $uibModal.open(opt);
    }

    //open edit/create item
    $ctrl.open = function (path) {
        $scope.item = {};
        openModal(path);
    }

    //open detail form
    $ctrl.openDetail = function (path) {
        openModal(path);
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
            
            //console.log($scope.item);
            //execute post here to save item
            ajaxService.postForm($("#frmItemEntry").serialize(),
               uriUpdate,
               function (data)
               {
                    $uibModalInstance.dismiss({ value: 'cancel' });
                });
        }

        $ctrl.cancel = function() {
            $uibModalInstance.dismiss({ $value: 'cancel' });
        }

    });