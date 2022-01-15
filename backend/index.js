require('dotenv').config();
const WebSocket = require('ws');
let server = require('http').createServer();
let app = require('./http_server');

// If you want just a WebSocket without http server
// const wss = new WebSocket.Server({ port: 8080 }, () => {
//   console.log('server started')
// })

let users = [{
  Name: "pepe",
  Location: {
    X: 3,
    Y: 0,
    Z: 3
  }
}]

// Create web socket server on top of a regular http server
let wss = new WebSocket.Server({
  server: server
});

// Also mount the app here
server.on('request', app);

wss.on('connection', function connection(ws) {

  ws.on('message', (data) => {
    const stringMessage = data.toString('utf-8').trim();
    let message = JSON.parse(stringMessage);

    switch (message.Event) {
      case "set_nickname":
        console.log("set_nickname")
        // by the way I'm generating a random position
        message.Payload.Location.X = Math.random() * 20;
        message.Payload.Location.Y = 0;
        message.Payload.Location.Z = Math.random() * 20;
        setNickname(message.Payload);
        break;
      case "set_user_changed_position":
        console.log("set_user_changed_position")
        userChangedPosition(message.Payload);
        break;
    }
  });
});

userChangedPosition = function (msg) {
  for (let i = 0; i < users.length; i++) {
    if (users[i].Name == msg.Name) {
      users[i].Location.X = msg.Location.X;
      users[i].Location.Y = msg.Location.Y;
      users[i].Location.Z = msg.Location.Z;
      wss.broadcast({
        Event: "user_changed_position",
        Payload: users
      });
      return;
    }
  }
};

setNickname = function (user) {
  users.push(user);
  wss.broadcast({
    Event: "new_user",
    Payload: users
  });
};

wss.broadcast = function broadcast(msg) {
  wss.clients.forEach(function each(client) {
    client.send(JSON.stringify(msg));
  });
};

// If you want just a WebSocket without http server
// wss.on('listening', () => {
//   console.log('listening on 8080')
// })

server.listen(process.env.PORT, function () {
  console.log(`http/ws server listening on ${process.env.PORT}`);
});