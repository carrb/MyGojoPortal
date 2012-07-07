/* books.js */

/*
 *  When passing a function into define() instead of an object, 
 *      the function will get executed by RequireJS and whatever 
 *      is returned from the function then becomes the module. 
 *
 *  Regular object version

        define({
            title: "Naked Lunch",
            publisher: "Grove Press"
        });
 */

 /* Constructor Module version -- similar to a class */

define(function() {
    var Book = function(title, publisher) {
        this.title = title;
        this.publisher = publisher;
    };
    return Book;
});