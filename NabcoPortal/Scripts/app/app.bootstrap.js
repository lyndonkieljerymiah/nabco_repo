/**
 * Application Bootstrap
 * All Initialization and configuration 
 * will be configured here
 */


var app = angular.module('MainApp', ['ngAnimate', 'ngSanitize', 'ui.bootstrap']);
app.service('ajaxService',
        function () {
            this.postForm = function (data,url,success, fail) {
                var serverPost = url;   
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

