/* app.js 

   ember.js - Documentation:  http://emberjs.com/documentation/

   * Bindings
   * Computed Properties
   * Auto-updating templates

   This client-side architecture allows for less boilerplate code (using ember.js),
     structures/organizes your code (MVC), improves testability, eliminates callback
     spaghetti, and supplies built-int support for state management.

   All data the application needs is downloaded initially behind the scenes, so that round
     trips to the server (either through a full page refresh, or even an ajax request) are
     eliminated and the user never (or not often) needs to load a new page, thus the UI
     is extremely quick in responding to user interaction.

   Another advantage of this architecture is using standard REST APIs, and back-end
     developers can focus on building fast, reliable, and secure server APIs, and are
     decoupled from the front-end experts.

 */




// Create Ember application namespace
var App = Em.Application.create();

// Create model/class and generate an instance
App.Person = Em.Object.extend({
    id: 0,
    name: ""
});

var person = App.Person.create();
person.name = "Scott Wade";


// Create controller
//
// Conventions:
//      content - controller field which references the data it controls
//                in others word its model
//
App.userController = Ember.Object.create({
    content: person,

    // example function to just change the name displayed
    // using setter
    changeModel: function() {
        this.content.set('name', 'Roger Doger');
    }
});


// Create a view
//
// Setup a binding so that if controller specified's model field ever changes
//   then this view will be updated.
//
// Note:  the nameBinding -- ember will drop the Binding from the end, and it
//        must match the {{name}} field in the view template.
App.MyView = Em.View.extend({
  nameBinding: 'App.userController.content.name'
});

// Bind the button click event
function btnTest_OnClick() {
    App.userController.changeModel();
}



