/* config.js 
 *
 * Set the require.js configuration for the application
 */

require.config({
    
    // initialize application with the 'main' application file
    deps: ["main"],

    paths: {

        // javascript folders
        modules:    "../app/modules",
        templates:  "../app/templates",
        text:       "../assets/js/libs/require/text",
        libs:       "../assets/js/libs",
        plugins:    "../assets/js/plugins",

        // libraries
        jquery:     "../assets/js/libs/jquery-1.8b1",
        underscore: "../assets/js/libs/underscore",
        backbone:   "../assets/js/libs/backbone",
        badebug:    "../assets/js/libs/ba-debug",
        modernizr:  "../assets/js/libs/modernizr",

        // Shim Plugin
        use:        "../assets/js/libs/require/use"
    },


    // You must define a configuration for each incompatible script you wish to include.
    // The string property used in attach will resolve to window[stringProp] Functions are evaluated
    // in the scope of the window and passed all dependencies as arguments.
    //
    // See: https://github.com/jrburke/requirejs/wiki/Upgrading-to-RequireJS-2.0#wiki-moduleconfig
     use: {
         underscore: {
             attach: "_"
         },

         // To require a module you simply use the require function as usual, except prefix the script name
         // with use!, the ! tells the loader its a plugin.
         backbone: {
             // These script deps should be loadedd before loading backbone.js
             deps: ["use!underscore", "jquery"],
             attach: "Backbone"
         }
     }

});