/*****************************************
 * 
 * Handle consuming data
 * 
 *****************************************/
var DataManager = function() {

	/*
	 * For Posting
	 */
	function formPost(data, action, controller, sucess, fail)
	{
		var serverPost = "http://localhost:50305/api/" + controller + "/" + action;

		$.ajax({
			type: 'POST',
			url: serverPost,
			data: data,
			success: function (data)
			{
				sucess(data);
			}
		});

	}

	return {
		formPost: formPost
	};

}();


