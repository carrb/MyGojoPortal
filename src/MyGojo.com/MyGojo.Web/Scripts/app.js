/*  app.js 
   
    Author:     ScottWade.net@live.com / sc0ttwad3@gmail.com
    Date:       06/07/2012 - Big AZURE announcemets today in history!  #meetAzure http://www.meetwindowsazure.com
    Rev:        0.1

    Notes:
        The Application Composition Root
        Using Object Literals for Namespacing (with some nesting)
 
 */


MyGojoApp = (function (Backbone, $) {

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

})(Backbone, jQuery);



$(function () {
    MyGojoApp.init();

    $('.carousel').carousel();
    
    $('#demobtn').click(function () {
        console.log("Clicked jGrowl enabled button.");
    
        // Possible theme values:  (default, warning, danger, info, success)
        $.jGrowl("There should be a lot more information here to allow learning the application and using jGrowl for notifications.", {
            theme: "success",
            /* Possible values: default, warning, danger, info, success */
            position: "top-left"
            /* top-left top-right bottom-left bottom-right center */
        });
    });

    // Tooltips with Url for Workspaces
    $('#my-workspaces').tooltip({
        selector: "a[rel=tooltip]"
    });
    
    // Testing EpicEditor
    var editorWindow = $('#editor-window');
    var editor = new EpicEditor(editorWindow);
    
    editor.options({
        file: {
            name: 'editorForContent',
            defaultContent: 'Write text in here!'
        },
        /*
        themes: {
            editor: '/css/epiceditor/editor-custom.css',
            preview: '/css/epiceditor/preview-custom.css'
        },
        */
        focusOnLoad: true,
        shortcuts: {
            preview: 77
        }
    }).load();
});


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