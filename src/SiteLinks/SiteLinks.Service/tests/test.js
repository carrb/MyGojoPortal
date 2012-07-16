/* test.js */
/*
 * Initial work with Node's assert for testing
 */


var assert = require('assert');
var task = require('server-with-mongo');

console.info('Connectin to Tasks DB');
var tasksDb = new task.TasksDb();

var testsStarted = 0;
var testsCompleted = 0;

console.log("Connected. Started:" + testsStarted + ", Complete:" + testsCompleted);

deleteTest();

/* delete test */
function deleteTest(db) {
    testsStarted++;
    tasksDb.delete(function() {
        tasksDb.get({'skip':0, 'limit':25}, function(err, tasks) {
            if (error) throw err;

            assert.equal(tasks.length, 0, 'Failure: there should be no tasks after deleting all of them.');
            console.log('taks.length = ' + tasks.length);
            testsCompleted++;
            cb();
        });
    });
}

