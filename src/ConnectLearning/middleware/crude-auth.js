module.exports = function(req, res, next) {
    var authorization = req.headers.authorization;

    if(!authorization)
        return next(new Error('Unauthorized'));

    var parts = authorization.split(' '),
        scheme = parts[0],
        authorization = new Buffer(parts[1], 'base64').toString().split(':'),
        user = authorization[0],
        pass = authorization[1];

        if ('wades' == user && '68gunsh1p' == pass) {
            // allow the next piece of middleware to execute
            next();    
        } else {
            next(new Error('Unauthorized'));
        }
};