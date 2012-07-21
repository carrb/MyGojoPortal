/* crude-logger.js 
 *
 * Basic logger with configurable printing format


exports = module.exports = function logger(format) {
    format = format || {};

    // defaults

    function setup(format) {
        var regexp = /:(\w+)/g;
    }


    return function logger(err, req, res, next) {
        var str = format.replace(regexp, function(_, property) {
            return req[property];
        });

        console.log(str);

        next();
    };
};

*/

