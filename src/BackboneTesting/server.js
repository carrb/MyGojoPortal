/* server.js */

/* ===== Dependencies ===== */
// node dependencies
var express  = require("express"),
    path     = require("path"),
    mongoose = require("mongoose");

console.log("New instance of Express!");


/* ===== Application Server and MongoDB Connection ===== */
// new instance of Express server
var app = module.exports = express.createServer();

// mongoose.model for any ToDo item defined by passing in schema instance
mongoose.connect("mongodb://localhost:27017/BackboneTest?safe=true");

var ToDo = mongoose.model("ToDo", new mongoose.Schema({
    text: String,
    done: Boolean,
    order: Number
}));



/* ===== Configuration ===== */
// configure() method - setup what need for current env. with Express server.
// Use Jade as viewing/templating engine instead of default HTML/JS
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



/* ===== Routing ===== */
// routing
app.get("/", function(req, res) {
    res.send("Hello World");
})

app.get("/todo", function(req, res) {
    res.render("todo", { tite: "MongoDB backed ToDo Application" });
})


// routing API
app.get("/api/todos", function(req, res) {
    return ToDo.find(function(err, todos) {
        return res.send(todos);
    });
});

app.get("/api/todos/:id", function(req, res) {
    return ToDo.findById(req.params.id, function(err, todo) {
        if (!err) {
            return res.send(todo);
        }
    })
})


app.put('/api/todos/:id', function(req, res){
  return Todo.findById(req.params.id, function(err, todo) {
    todo.text = req.body.text;
    todo.done = req.body.done;
    todo.order = req.body.order;
    return todo.save(function(err) {
      if (!err) {
        console.log("updated");
      }
      return res.send(todo);
    });
  });
});

app.post('/api/todos', function(req, res){
  var todo;
  todo = new Todo({
    text: req.body.text,
    done: req.body.done,
    order: req.body.order
  });
  todo.save(function(err) {
    if (!err) {
      return console.log("created");
    }
  });
  return res.send(todo);
});

app.delete('/api/todos/:id', function(req, res){
  return Todo.findById(req.params.id, function(err, todo) {
    return todo.remove(function(err) {
      if (!err) {
        console.log("removed");
        return res.send('')
      }
    });
  });
});



/* ===== Startup ===== */
// Start application server listening for requests
app.listen(3000);



