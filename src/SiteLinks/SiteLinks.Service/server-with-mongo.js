
var argv = require('optimist').argv;
var mongoose = require('mongoose');


var command = argv.command;
var taskProject = argv.project;
var taskDescription = argv.desc;


var db = mongoose.connect('mongodb://localhost/tasks');

var Schema = mongoose.Schema;
var Tasks = new Schema({
    project: String,
    description: String
});

var tasksModel = mongoose.model('Task', Tasks);



switch(command) {
    case 'list':
        listTasks();
        break;

    case 'add':
        addTask(taskProject, taskDescription);
        break;

    default:
        console.log('Usage: ' + process.argv[0] + '--command list|add --project [taskProject] --desc [taskDescription]');
}


function addTask(taskProject, taskDescription) {
    var task = new tasksModel();
    task.project = taskProject;
    task.description = taskDescription;

    task.save(function(err) {
        if(err) throw err;
        console.log('Task saved!');
    });
}

function listTasks() {
    tasksModel.find({}, function(err, docs) {
        if(err) throw err;

        docs.forEach(function(doc) {
            //console.log(typeof doc + ": " + doc + "\n");
        });

        //docs.forEach


    });
}



/*
function getTasks(file, cb) {
    path.exists(file, function(exists) {
        var tasks = [];

        if(exists) {
            fs.readFile(file, 'utf8', function(err, datum) {
                if(err) throw err;
                var data = datum.toString();
                var tasks = JSON.parse(data);
                cb(tasks);
            });
        } else {
            cb([]);
        }
    });
}

function listTasks(file) {
    getTasks(file, function(tasks) {
        for(var i in tasks) {
            console.log(tasks[i]);
        }
    });
}


function storeTasks(file, tasks) {
    fs.writeFile(file, JSON.stringify(tasks), 'utf8', function(err) {
        if (err) throw err;
        console.log('Saved.');
    });
}



*/