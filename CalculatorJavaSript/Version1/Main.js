const express = require('express');
const fs = require('fs');
const url = require('url');
const http = require('http');
const calculator = require('./Program.js');
const EventEmitter = require('events');

async function main() {
    const port = 8080;
    const app = express();
    const eventEmitter = new EventEmitter();
    const server = http.createServer(app);

    app.get('/', (req, res) => {
        var q = url.parse(req.url, true);

        var input = q.input;
        var option = q.choice;

        fs.readFile('Index.html', function (err, data) {
            if (err) {
                res.writeHead(404, { 'Content-Type': 'text/html' });
                return console.error(err);
            }
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.write(data);
            return res.end();
        });
    });

    //console.log("CPU architecture: " + os.arch());
    //console.log("Free memory: " + os.freemem());
    //console.log("Total memory: " + os.totalmem());
    //console.log("Used memory: " + (os.totalmem() - os.freemem()));
    //console.log('List of network Interfaces: ' + os.networkInterfaces());
    //console.log('OS default directory for temp files : ' + os.tmpdir());
    //console.log("Endianness of system: " + os.endianness());
    //console.log("Hostname: " + os.hostname());
    //console.log("Operating system name: " + os.type());

    eventEmitter.addListener("choose operation", (choice) => {
    });

    server.listen(port, () => console.log(`Server running at http://localhost:${port}/`));
}

main();