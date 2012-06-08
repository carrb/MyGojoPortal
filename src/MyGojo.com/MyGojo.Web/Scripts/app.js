/*  app.js 
   
    Author:     ScottWade.net@live.com / sc0ttwad3@gmail.com
    Date:       06/07/2012 - Big AZURE announcemets today in history!  #meetAzure http://www.meetwindowsazure.com
    Rev:        0.1

    Notes:
        The Application Composition Root
        Using Object Literals for Namespacing (with some nesting)
 
 */

(function (window) {
    'use strict';

    // Your starting point. Enjoy the ride!
    /* Start execution unconcerned with DOM ready-state  */
    jQuery(function ($) {
    
        /* Namespace for this application */
        var myGojo = myGojo || {};

        var myGojoConfig = {
            language: "english",
            defaults: {
                enableGeoLocation: true
            }
        };


    });
    

    /* jQuery DOM ready event - occurs after ... */
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



})(window);

/*
<script src="http://yandex.st/highlightjs/6.1/highlight.min.js"></script>
    <script src="epiceditor.js"></script>
    <script>
      
      try{
        hljs.initHighlightingOnLoad(); 
      } catch(e){
        document.body.className += " " + 'offline-mode';
        console.log('Code highlighting will be disabled because yandex.st isn\'t loading or there is an error in the linked script.')
      }

      var examples = [document.getElementById('example-1')];

      var ee1 = new EpicEditor(examples[0]);
      ee1.options({
        file:{
          defaultContent:"#EpicEditor\nThis is some default content. Go ahead, _change me_. "
        }
        , focusOnLoad:true
      })
      .load();
    </script>
*/












