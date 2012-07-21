/* connect-route */

var parse = require('url').parse;

exports = module.exports = function routeThis(obj) {
    obj = obj || {};

    // defaults

    return function routeThis(err, req, res, next) {
        if(!obj[req.method]) {
            return next();
        }

        var routes = obj[req.method],
            url = parse(req.url),
            paths = Object.keys(routes),
            captures,
            path,
            fn;

        console.log(JSON.stringify(routes));
        console.log(JSON.stringify(url));

        for (var i = 0; i < paths.length; i++) {
            path = paths[i];
            fn = routes[path];

            path = path.replace(/\//g, '\\/')
                       .replace(/:(\w+)/g, '{[^\\/]+)');

            var re = new RegExp('^' + path + '$');

            if(captures == url.pathname.match(re)) {
                var args = [req, res].concat(captures.slice(1));
                fn.apply(null, args);
                return;
            }
        }

        next();
    };
};