/* config.js 
 *
 * Set the require.js configuration for the application
 */

require.config({
    
    // initialize application with the 'main' application file
    deps: ["main"],

    paths: {
        // javascript folders
        modules: "../app/modules",
        templates: "../app/templates",
        libs: "../assets/js/libs",
        plugins: "../assets/js/plugins",

        // libraries
        jquery: "../assets/js/libs/jquery-1.8b1",
        underscore: "../assets/js/libs/underscore",
        backbone: "../assets/js/libs/backbone",
        badebug: "../assets/js/libs/ba-debug",
        modernizr: "../assets/js/libs/modernizr"
    }


});