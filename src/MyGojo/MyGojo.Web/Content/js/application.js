/* application.js */
/*
    Resources for Backbone.js/Underscore.js - http://elegantcode.com/2012/01/23/resources-for-getting-started-with-backbone-js/
    More: http://lostechies.com/derickbailey/2012/02/06/3-stages-of-a-backbone-applications-startup/


    Main entry point for the application which defines the namespace of the application
    All module references must point to a single shared object:
        A reusable function will be created that can retrieve the shared object reference when called
        This function will create the shared object and through memoization "remember" it internally in connection with a key
        Create a closure around the module's objects to prevent tampering
        Create a private scope for the module where module-specific data can be defined
 */



// jQuery ready event - occures after all code has been downloaded and evaluated and is ready to be initialized.
// Application Composition Root - where application is initialized.
jQuery(function($) {

});


// jQuery document ready event - occurs after ...
$(document).ready(function () {
    
    $('#demo').click(function () {
        // Possible theme values:  (default, warning, danger, info, success)
        $.jGrowl("There should be a lot more information here to allow learning more information about more information regarding the application and using jGrowl for notifications.", {
            theme: "warning"
        });
    });


});