
/*
var Currency = require('currency');
var conversionRateCanadian = 0.91;

Currency = new Currency(conversionRateCanadian);

console.log('Currency class instantiated with current conv. rate.');

console.log("50 Canadian dollars: $" + Currency.canadianToUS(50));
console.log("30 US dollars: Can$" + Currency.USToCanadian(30));
*/



var http = require('http');
var Url = require('url');

var items = [];
console.log('items array is empty; creating httpServer on 8080...');


http.createServer(function(req, res) {
    switch(req.method) {
        case 'POST':
            var item = '';
            req.setEncoding('utf8');

            req.on('data', function(chunk) {
                item += chunk;
            });

            req.on('end', function() {
                items.push(item);
                res.writeHead(200, { 'Content-Type': 'text/html' });
                res.end('OK\n');
            });

            break;


        case 'GET':
            var body = items.map(function(item, i) {
                return i + ': ' + item;
            }).join('\n');

            res.writeHead(200, {
                'Content-Length': Buffer.byteLength(body),
                'Content-Type': 'text/plain; charset="utf-8"'
            });

            res.end(body);
            break;


        case 'DELETE':
            var path = Url.parse(req.url).pathname;
            var i = parseInt(path.slice(1), 10);

            if(isNaN(i)) {
                res.statusCode = 400;
                res.end('Invalid item id');
            } else if(!items[i]) {
                res.statusCode = 404;
                res.end('Item at id: ' + i + 'not found');
            } else {
                items.splice(i, 1);
                res.end('OK\n');
            }

            break;

    }

}).listen(8080);

/*

    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.end('Hello, world!');
}).listen(process.env.PORT || 8080);

*/