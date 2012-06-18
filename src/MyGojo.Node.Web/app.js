/* app.js */

var application_root = __dirname,
    express = require("express"),
    path = require("path"),
    mongoose = require("mongoose");

var app = express.createServer();
app.configure(function() {
    // the bodyParser middleware parses JSON request bodies
    app.use(express.bodyParser());
    app.use(express.methodOverride());
    app.use(app.router);
    app.use(express.static(path.join(application_root, "public")));
    app.use(express.errorHandler({
        dumpExceptions: true,
        showStack: true 
    }));
    
    app.set("views", path.join(application_root, "views"));
    app.set("view engine", "jade")
});

/* routing */
app.get("/", function(req, res){
    res.send("Hello from MyGojo.Node.Web!");
});

app.get("/announcement", function(req, res) {
    res.render("announcement", {title: "First Sample Announcement"});
});

app.get("/api/announcements", function(req, res) {
    return Announcement.find(function(err, announcements) {
        return res.send(announcements);
    });
});



mongoose.connect("mongodb://localhost:27017/MyGojoNode?safe=true");

var Announcement = mongoose.model("Announcement", new mongoose.Schema({
    title: String,
    content: String,
    isVisible: Boolean,
    isEditable: Boolean,
    priority: Number
}));





/*
var http = require('http');

http.createServer(function (req, res) {
    
    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.end('Hello, world!');
    
}).listen(process.env.PORT || 8080);
*/