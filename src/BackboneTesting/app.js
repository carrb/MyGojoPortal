/* app.js */


// node dependencies
var express  = require("express"),
    path     = require("path"),
    mongoose = require("mongoose");

console.log("New instance of Express!");

// new instance of Express server
var app = module.exports = express.createServer();

// mongoose.model for any ToDo item defined by passing in schema instance
mongoose.connect("mongodb://localhost:27017/BackboneTest?safe=true");

var ToDo = mongoose.model("ToDo", new mongoose.Schema({
    text: String,
    done: Boolean,
    order: Number
}));


// configure() method - setup what need for current env. with Express server.
// Use Jad as viewing/templating engine instead of default HTML/JS
app.configure(function() {
    // bodyParser middleware parses JSON request bodies
    app.use(express.bodyParser());
    app.use(express.methodOverride());
    app.use(app.router);
    app.use(express.static(__dirname + '/public'));

    app.set('views', __dirname + '/views');
    app.set("view engine", "jade");
});

app.configure('development', function(){
  app.use(express.errorHandler({ dumpExceptions: true, showStack: true }));
});

app.configure('production', function(){
  app.use(express.errorHandler());
});


app.get("/", function(req, res) {
    res.send("Hello World");
})

app.get("/todo", function(req, res) {
    res.render("todo", { tite: "Sample Backbone Application" });
})

app.listen(3000);



