/* config.js 
 *
 * Set the require.js configuration for the application
 */

require.config({

  // Initialize the application with the main application file
  deps: ["main"],

  paths: {

    // JavaScript folders

    // ~/Scripts/app/ - this config
    collections: "collections",
    models: "models",
    modules: "modules",
    templates: "templates",
    views: "views",

    // ~/Scripts/
    libs: "../libs",
    plugins: "../plugins",
    jquery: "../jquery-1.8b1",
    underscore: "../underscore",
    backbone: "../backbone",
    badebug: "../ba-debug",
    modernizr: "../modernizr",
  
    // ~/Scripts/test  
    mocha: "../test/mocha/mocha",
    chai: "../test/chai/chai",
    sinon: "../test/sinon/sinon",

    // Shim Plugin
    use: "../plugins/require/use"
  },

  use: {
    backbone: {
      deps: ["use!underscore", "jquery"],
      attach: "Backbone"
    },

    underscore: {
      attach: "_"
    }
  }
});
