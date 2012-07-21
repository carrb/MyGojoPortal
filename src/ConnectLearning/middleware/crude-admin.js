/* crude-admin.js */

module.exports = function(req, res, next) {
    switch(req.url) {
        case '/':
            res.end('try /users');
            break;

        case '/users':
            res.setHeader('Content-Type', 'application/json');
            res.end(JSON.stringify(['wades', 'admsw', 'testuser']));
            break;
    }
};