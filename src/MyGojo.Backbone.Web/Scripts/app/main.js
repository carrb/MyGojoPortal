require([
  "models/bookshelf",

// Libs

  "badebug",
  "jquery",
  "use!backbone",

// Modules
  "modules/example"
],

function(bookshelf, $, Backbone) {

    bookshelf.listBooks();

});
