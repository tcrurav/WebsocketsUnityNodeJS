require('dotenv').config();
const WebSocket = require('ws');
let server = require('http').createServer();
let app = require('./http_server');

// If you want just a WebSocket without http server
// const wss = new WebSocket.Server({ port: 8080 }, () => {
//   console.log('server started')
// })

// Create web socket server on top of a regular http server
let wss = new WebSocket.Server({
  server: server
});

// Also mount the app here
server.on('request', app);

wss.on('connection', function connection(ws) {
  ws.on('message', (data) => {
    console.log('data received: ' + data.toString('utf-8'));
    ws.send(data);
  })
})

// If you want just a WebSocket without http server
// wss.on('listening', () => {
//   console.log('listening on 8080')
// })

server.listen(process.env.PORT, function () {
  console.log(`http/ws server listening on ${process.env.PORT}`);
});