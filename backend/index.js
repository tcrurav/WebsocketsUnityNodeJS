require('dotenv').config();
const WebSocket = require('ws');
let server = require('http').createServer();
let app = require('./http_server');

// If you want just a WebSocket without http server
// const wss = new WebSocket.Server({ port: 8080 }, () => {
//   console.log('server started')
// })

let users = [{
  name: "pepe",
  position: {
    x: 0,
    y: 0
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

    switch (message.event) {
      case "set_nickname":
        console.log("set_nickname")
        setNickname(message.msg);
        break;
      case "set_user_changed_position":
        console.log("set_user_changed_position")
        userChangedPosition(message.msg);
        break;
    }
  });
});

userChangedPosition = function (msg) {
  for (let i = 0; i < users.length; i++) {
    if (user.name == msg.name) {
      users[i].position.x = msg.position.x;
      users[i].position.y = msg.position.y;
      wss.broadcast({
        event: "user_changed_position",
        msg: users
      });
      return;
    }
  }
};

setNickname = function (user) {
  console.log(user)
  console.log(JSON.stringify(user))
  users.push(user);
  console.log("setNickname")
  console.log(users)
  wss.broadcast({
    event: "new_user",
    msg: users
  });
};

wss.broadcast = function broadcast(msg) {
  wss.clients.forEach(function each(client) {
    client.send(msg);
  });
};

// If you want just a WebSocket without http server
// wss.on('listening', () => {
//   console.log('listening on 8080')
// })

server.listen(process.env.PORT, function () {
  console.log(`http/ws server listening on ${process.env.PORT}`);
});