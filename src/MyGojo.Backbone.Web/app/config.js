// Set the require.js configuration for your application.
require.config({
  // Initialize the application with the main application file
  deps: ["main"],

  paths: {
    // JavaScript folders
    libs: "../assets/js/libs",
    plugins: "../assets/js/plugins",

    // Libraries
    jquery: "../assets/js/libs/jquery-1.8b1",
    underscore: "../assets/js/libs/underscore",
    backbone: "../assets/js/libs/backbone",
    mocha: "../test/mocha/mocha",
    chai: "../test/chai/chai",
    sinon: "../test/sinon/sinon",

    // Shim Plugin
    use: "../assets/js/plugins/use"
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
