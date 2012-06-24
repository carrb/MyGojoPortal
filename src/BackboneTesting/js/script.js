/* Author:

*/

var Photo = Backbone.Model.extend({
    defaults: {
        src: 'placeholder.jpg',    // commented out to test validatoin on instanti
        title: 'an image placeholder',
        coordinates: [0, 0]
    },

    initialize: function() {
        debug.log('Photo model has been initialized');

        this.on("change:src", function() {
            var src = this.get("src");
            debug.log("[src] updated to... " + src);
        });

        this.on("change:title", function() {
            var title = this.get("title");
            debug.log("[title] has been updated to... " + title);
        });

        this.on("error", function(model, error) {
            debug.log(error);
        });
    },


    validate: function(attribs) {
        if(attribs.src === undefined) {
            return "You must specify a src for the image!";
        }
    },

    changeSrc: function(source) {
        this.set({ src: source });
    },
    setTitle: function(newTitle) {
        this.set({ title: newTitle });
    }
});

var somePhoto = new Photo();
somePhoto.set({ title: "On the beach" });
somePhoto.changeSrc("magic.jpg");   // triggers "change:src" and logs an update to console.
somePhoto.setTitle("Fishing at the sea")

debug.log(somePhoto.toJSON());


var PhotoSearch = Backbone.View.extend({
    el: $('#results'),

    render: function(event) {
        var compiled_template = _.template($("results-template").html());
        this.$el.html(compiled_template(this.model.toJSON()));
        return this; // to enable chaining...
    },

    events: {
        "submit #searchForm": "search",
        "click .reset": "reset",
        "click .advanced": "switchContext"        
    },

    search: function(event){
        // execute when a form #searchForm has been submitted
    },
    reset: function(event){
        // executed when an element with class "reset" has been clicked.
    },
    switchContext: function(event){
        // executed when an element with class "advanced" has been clicked
    }



});






