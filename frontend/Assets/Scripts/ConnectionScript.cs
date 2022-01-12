using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

//public class ConnectionScript : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
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
            ws.Send("Hello");
        }
    }
}


