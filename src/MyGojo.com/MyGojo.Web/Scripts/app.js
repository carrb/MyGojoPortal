/*  app.js 
   
    Author:     ScottWade.net@live.com / sc0ttwad3@gmail.com
    Date:       06/07/2012 - Big AZURE announcemets today in history!  #meetAzure http://www.meetwindowsazure.com
    Rev:        0.1
*/

MyGojoApp = (function ($) {
    // Initialization
    init = function () {
        console.info("MyGojoApp: object instantiated and initialized!");
    },

    // Methods
    logStatus = function () {
        console.info("logStatus called.");
    };

    return {
        init: init,
        logStatus: logStatus

        //init: function () {
        //    var view = new View();
        //    $("#some-div").html(view.render().el);
        //}
    };
})(jQuery);


$(document).ready(function () {
    MyGojoApp.init();
    
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

