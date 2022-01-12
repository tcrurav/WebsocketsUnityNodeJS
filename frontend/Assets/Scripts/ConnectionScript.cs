using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
public class ConnectionScript : MonoBehaviour
{
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            string data = System.Text.Encoding.UTF8.GetString(e.RawData);
            data = data.Trim();
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + data);
        };
    }
    private void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //string newUser = @"{ 
            //    'event': 'set_nickname', 
            //    'msg': { 
            //        'name': 'pepon', 
            //        'position': {
            //            'x': 1,
            //            'y': 1
            //        }
            //    }
            //}";
             
            string newUser = "{\"event\":\"set_nickname\",\"msg\":{\"name\":\"pepon\",\"position\":{\"x\":1,\"y\":1}}}";

            //var newUser = JsonConvert.SerializeObject(new {
            //    event: "set_nickname", 
            //    msg: {
            //        name: 'pepon', 
            //        position: {
            //            x: 1,
            //            y: 1
            //        }
            //    }
            // });
            ws.Send(newUser);
        }
    }
}


