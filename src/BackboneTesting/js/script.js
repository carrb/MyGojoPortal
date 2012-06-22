/* Author:

*/

var Photo = Backbone.Model.extend({
    defaults: {
        src: 'placeholder.jpg',
        title: 'an image placeholder',
        coordinates: [0,0]
    },
    initialize: function(){
        console.log('this model has been initialized');

        this.on("change:src", function() {
            var src = this.get("src");
            console.log('Image source updated to ' + src);
        });
    },
    changeSrc: function(source) {
        this.set({src:source});
    }
});

var somePhoto = new Photo({
    src: "test.jpg",
    title: "testing"
});

somePhoto.changeSrc("magic.jpg");   // triggers "change:src" and logs an update to console.


console.log(somePhoto.toJSON());






