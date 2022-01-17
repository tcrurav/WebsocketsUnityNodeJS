# Unity (frontend) and NodeJs (backend) Example using Websockets
This project is just a project example to learn how to use Websockets with Unity (frontend) and NodeJS (backend).

You can play in this project in a network simply giving the IP of the server, and entering your avatar name: 
![screenshots](https://github.com/tcrurav/WebsocketsUnityNodeJS/blob/master/screenshots/screenshot-01.png)

After clicking on "Start" you can start playing. In every screen you can see the other players moving around:
![screenshots](https://github.com/tcrurav/WebsocketsUnityNodeJS/blob/master/screenshots/screenshot-02.png)

## Getting Started

Download links:

From Github: https://github.com/tcrurav/v.git

## Prerequisites

You need a working environment with:
* [Git](https://git-scm.com) - You can install it from https://git-scm.com/downloads.
* [Unity](https://unity.com) - One unified platform with flexible solutions for you to build, manage, and grow your game.
* [Node.js](https://nodejs.org) - Install node.js from https://nodejs.org/es/download/. It's advisable to install the LTS version.

## General Installation instructions

The best option to start with this project is cloning it in your PC:

```
git clone https://github.com/tcrurav/WebsocketsUnityNodeJS.git
```

This project contains 2 different parts:
* Frontend
* Backend

You need a node.js working environment. The LTS is recommended: https://nodejs.org/es/

Once you have cloned the project install all dependencies.

```
cd WebsocketsUnityNodeJS/backend
npm install

* For your backend part:
You need a WebsocketsUnityNodeJS/backend/.env file with the IP where you run your NodeJS backend:

```
PORT=localhost
```

Finally to start enjoying this project.

```
cd WebsocketsUnityNodeJS/backend
node index.js
```

* For your frontend part:
You have to build the project from Unity. After that you can run the .exe file.

Enjoy!!!


## Built With

* [Visual Studio Code](https://code.visualstudio.com/) - The Editor used in this project
* [Node.js](https://nodejs.org/) - Node.js® is a JavaScript runtime built on Chrome's V8 JavaScript engine.
* [express](https://expressjs.com/) - Fast, unopinionated, minimalist web framework for Node.js.
* [ws](https://www.npmjs.com/package/ws) - ws is a simple to use, blazing fast, and thoroughly tested WebSocket client and server implementation.
* [dotenv](https://www.npmjs.com/package/dotenv) - Dotenv is a zero-dependency module that loads environment variables from a .env file into process.env. Storing configuration in the environment separate from code is based on The Twelve-Factor App methodology.

## Acknowledgments

* https://medium.com/unity-nodejs/websocket-client-server-unity-nodejs-e33604c6a006. A basic Websockets tutorial to start with Unity and nodeJS.
* https://www.techiediaries.com/ionic/ionic-5-jwt-authentication-node-expressjs/. Excellent tutorial as a basis for learning the Authentication basics needed for this project.
* https://www.youtube.com/watch?v=76Lh0UApjNI. How to use mixamo Characters in Unity.
* https://gist.github.com/PurpleBooth/109311bb0361f32d87a2. A very complete template for README.md files.
* https://www.theserverside.com/video/Follow-these-git-commit-message-guidelines. Guidelines to write properly git commit messages.