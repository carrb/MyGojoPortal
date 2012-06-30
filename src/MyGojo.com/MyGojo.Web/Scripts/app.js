/*  app.js 
   
    Author:     ScottWade.net@live.com / sc0ttwad3@gmail.com
    Date:       06/07/2012 - Big AZURE announcemets today in history!  #meetAzure http://www.meetwindowsazure.com
    Rev:        0.1
*/


// Create Ember application namespace
var MyGojoApp = Em.Application.create();




/* Legacy unstructured code line by line in document ready function!  */

$(document).ready(function () {
    $("body").queryLoader2();

    $('#demobtn').click(function () {
        debug.log("Clicked jGrowl enabled button.");
    
        // Possible theme values:  (default, warning, danger, info, success)
        $.jGrowl("There should be a lot more information here to allow learning the application and using jGrowl for notifications.", {
            theme: "success",
            /* Possible values: default, warning, danger, info, success */
            position: "top-left"
            /* top-left top-right bottom-left bottom-right center */
        });
    });
    
    $('#redactor-content').redactor();

    // Tooltips with Url for Workspaces
    //$('#my-workspaces').tooltip({
    //    selector: "a[rel=tooltip]"
    //});
    
    
});

