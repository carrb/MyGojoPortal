/* app.js */

jQuery(function ($) {

    //var myGojoApp = new gojo();
    //myGojoApp.init();

});


// jQuery document ready event - occurs after ...
$(document).ready(function () {

    $('#demo').click(function () {

        console.log("Clicked jGrowl enabled button.");

        // Possible theme values:  (default, warning, danger, info, success)
        $.jGrowl("There should be a lot more information here to allow learning the application and using jGrowl for notifications.", {
            theme: "success",
            /* Possible values: default, warning, danger, info, success */
            position: "top-left"
        /* top-left top-right bottom-left bottom-right center */
        });
        

        $('#my-workspaces').tooltip({
            selector: "a[rel=tooltip]"
        });

    });


});