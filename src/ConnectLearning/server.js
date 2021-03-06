/**
 * Created with JetBrains WebStorm.
 * User: wades
 * Date: 7/20/12
 * Time: 12:58 PM
 * To change this template use File | Settings | File Templates.
 */

/**
 * MODULE DEPENDENCIES
 * -------------------------------------------------------------------------------------------------
 * include any modules you will use through out the file
 **/

var http = require('http');
var connect = require('connect');
var nconf = require('nconf');
var route = require('./middleware/connect-router');


/**
 * CONFIGURATION
 * -------------------------------------------------------------------------------------------------
 * load configuration settings from ENV, then settings.json.  Contains keys for OAuth logins. See
 * settings.example.json.
 **/
nconf.env().file({file: 'settings.json'});

/**
 * -------------------------------------------------------------------------------------------------
 * set up view engine (jade), css preprocessor (less), and any custom middleware (errorHandler)
 **/


/**
 * LOGGING
 * -------------------------------------------------------------------------------------------------
 * set up custom middleware (logging)
 **/
function logger(req, res, next) {
    console.log('%s %s', req.method, req.url);
    next();
}



/**
* ERROR MANAGEMENT
* -------------------------------------------------------------------------------------------------
* error management - instead of using standard express / connect error management, we are going
* to show a custom 404 / 500 error using jade and the middleware errorHandler (see ./middleware/errorHandler.js)
**/
var errorOptions = { dumpExceptions: true, showStack: true }



/**
 * ROUTING
 * -------------------------------------------------------------------------------------------------
 * include a route file for each major area of functionality in the site
 **/


/**
 * RUN
 * -------------------------------------------------------------------------------------------------
 * this starts up the server on the given port
 **/
var app = connect()
    .use(logger)
    //.use(require('./middleware/errorHandler')(errorOptions))
    //.use(require('./middleware/locals'))
    .use('/admin', require('./middleware/crude-auth'))
    .use('/admin', require('./middleware/crude-admin'))

    //.use(routeThis(require('./routes/user')))
    //.use(routeThis(require('./routes/admin')))
    .listen(3000);


    
    //.use(echoHello);

//http.createServer(app).listen(3000);