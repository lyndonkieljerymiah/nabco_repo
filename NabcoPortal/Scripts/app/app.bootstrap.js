/**
 * Application Bootstrap
 * All Initialization and configuration 
 * will be configured here
 */


var app = angular.module('MainApp', ['ngAnimate', 'ngSanitize', 'ui.bootstrap']);
app.service('ajaxService',
        function () {
            this.postForm = function (data, action, controller, success, fail) {
                var serverPost = "http://localhost:50305/api/" + controller + "/" + action;
                $.ajax({
                    type: 'POST',
                    url: serverPost,
                    data: data,
                    success: function (data) {
                        success(data);
                    }
                });
            }
        });

