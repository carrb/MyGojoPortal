/* bookshelf.js */

/*  When book was a regular object and not a constructor module:
 *
 *
define([
    'modules/book'
], function(book) {
    return {
        listBook: function() {
            alert(book.title);
        }
    };
});

 */

define(['models/book'], function(Book) {
    var books = [
        new Book('Naked Lunch', 'Grove Press'),
        new Book('A Tale of Two Cities', 'Chapman & Hall')
     ];

    return {
        // new function listBooks() dealing with multiple books
        listBooks: function() {
            books.forEach(function(book) {
                debug.log(book.title);
            });
        }
    };
});

