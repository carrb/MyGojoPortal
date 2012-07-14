/* server.js 
 *
 * Purpose is to test a static file web server
 */

var http = require('http');
var parse = require('url').parse;
var join = require('path').join;
var fs = require('fs');


/*  Ex: If requested url was "/index.html", and root path was "/var/www/example.com/public"
        use Path modules .join() method to combine these and form abs. path  */

var root = __dirname;  // defined by Node: absolute path to dir containing this script

http.createServer(function(req, res) {

    var url = parse(req.url);
    var path = join(root, url.pathname);

    fs.stat(path, function(err, stat) {
        if(err) {
            if('ENOENT' == err.code) {
                res.statusCode = 404;
                res.end('Not Found');
            } else {
                res.statusCode = 500;
                res.end('Internal Server Error');
            }
        } else {
            res.setHeader('Content-Length', stat.size);

            var stream = fs.createReadStream(path);
            stream.pipe(res);

            stream.on('error', function(err) {
                res.statusCode = 500;
                res.end('Internal Server Error');
            });
        }
    });

    //res.writeHead(200, { 'Content-Type': 'text/html' });
    //res.end('Hello, world!');

}).listen(process.env.PORT || 8080);


