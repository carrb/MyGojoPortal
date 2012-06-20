﻿/*  app.js 
   
    Author:     ScottWade.net@live.com / sc0ttwad3@gmail.com
    Date:       06/07/2012 - Big AZURE announcemets today in history!  #meetAzure http://www.meetwindowsazure.com
    Rev:        0.1
*/

MyGojoApp = (function ($) {
    // Initialization
    init = function () {
        console.info("MyGojoApp: object instantiated and initialized!");
    },
    
    // Private Fields
    this.listSiteLinks = [];

    // Methods
    logStatus = function () {
        console.info("logStatus called.");
    };

    loadWorkspaces = function() {
        debug.log("Loading workspaces...");

        var jqxhr = $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: "{}",
            url: "api/SiteLinks" + '?' + Math.round(new Date().getTime()),

            beforeSend: function(xhr) {
                debug.log("beforeSend...");
                debug.log(xhr);
            }
        }).done(function(data) {
            debug.log("done.");            


            var siteLinks = $.parseJSON(jqxhr.responseText);
            
            for (var index in siteLinks) {
                if (siteLinks.hasOwnProperty(index)) {
                    // <li><a href="@item.Url" rel="tooltip" data-original-title="@item.Url">@item.Title</a></li>
                    listSiteLinks.push("<li><a href=" + siteLinks[index].Url + "rel=\"tooltip\" data-original-title=" + siteLinks[index].url + ">" + siteLinks[index].title + "</a></li>");
                }
            }

            debug.log(listSiteLinks);

            $("#my-workspaces-list", {
                html: listSiteLinks.join('')
            }).appendTo("#my-workspaces-list");


        }).fail(function(data) {
            debug.log("fail.");
        }).always(function(data) {
            debug.log("always.");
        }).complete(function(data) {
            debug.log("complete.");
        });
        
        


        /*
        $.getJSON("api/SiteLinks" + '?' + Math.round(new Date().getTime()), function (data) {
            // on success - 'data' contains the list of SiteLinks
            $.each(data, function (key, val) {
                // format the text to display
                var str = "<a href=\"val.Url\" rel=\"tooltip\" data-original-title=\"val.Url\">" + val.Title + "</a>";

                // add list item for the SiteLink
                $('<li/>', { html: str }).appendTo($('#my-workspaces-list'));
            });
        });
        */
    
    };

    return {
        init: init,
        logStatus: logStatus,
        loadWorkspaces: loadWorkspaces

        //init: function () {
        //    var view = new View();
        //    $("#some-div").html(view.render().el);
        //}
    };
})(jQuery);


$(document).ready(function () {
    $("body").queryLoader2();

    MyGojoApp.init();
    MyGojoApp.loadWorkspaces();
    
    
    $('#demobtn').click(function () {
        debug.log("Clicked jGrowl enabled button.");
    
        // Possible theme values:  (default, warning, danger, info, success)
        $.jGrowl("There should be a lot more information here to allow learning the application and using jGrowl for notifications.", {
            theme: "success",
            /* Possible values: default, warning, danger, info, success */
            position: "center"
            /* top-left top-right bottom-left bottom-right center */
        });
        
        
        
       
    });
    
    $('#redactor-content').redactor();

    // Tooltips with Url for Workspaces
    //$('#my-workspaces').tooltip({
    //    selector: "a[rel=tooltip]"
    //});
    
    
});

