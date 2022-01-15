using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using TMPro;

public class ConnectionScript : MonoBehaviour
{
    WebSocket ws;
    //public GameObject spawns;
    public GameObject gameObjectToSpawn;
    public GameObject myPlayerTextName;
    public GameObject myPlayer;
    public Camera mainCamera;
    private GameObject clone;

    // A thread-safe Queue (first in first out)
    private readonly ConcurrentQueue<Action> _actions = new ConcurrentQueue<Action>();

    private void Start()
    {
        ws = new WebSocket("ws://" + CrossSceneInformation.IP + ":8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            string data = System.Text.Encoding.UTF8.GetString(e.RawData);
            data = data.Trim();
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + data);

            _actions.Enqueue(() => ShowUsers(data));
        };

        SetNickname(CrossSceneInformation.Nickname);
    }

    private void Update()
    {
        // Work the dispatched actions on the Unity main thread
        while (_actions.Count > 0)
        {
            bool v = _actions.TryDequeue(out Action action);
            if (v)
            {
                action?.Invoke();
            }
        }
    }

    private void ShowUsers(string messageFromServer)
    {
        Message json = JsonConvert.DeserializeObject<Message>(messageFromServer);

        foreach (User user in json.Payload)
        {
            GameObject userFound = GameObject.Find(user.Name);
            if (userFound)
            {
                userFound.transform.position = new Vector3(user.Location.X, user.Location.Y, user.Location.Z);
            }
            else
            {
                if (user.Name.Equals(CrossSceneInformation.Nickname)){
                    //myPlayerTextName.text = user.Name;
                    myPlayerTextName.GetComponent<TMP_Text>().text = user.Name;
                } else
                {
                    Creator(user);
                }
            }
        }
    }

    public void Creator(User user)
    {
        Vector3 newPosition = new Vector3(user.Location.X, user.Location.Y, user.Location.Z);
        GameObject o = Instantiate(gameObjectToSpawn, newPosition, Quaternion.identity);
        o.name = user.Name;
        o.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = user.Name;
        o.transform.GetChild(3).GetComponent<Canvas>().worldCamera = mainCamera;
        //GameObject textName = o.gameObject.transform.F.Find("TextName");
        //((TMP_Text)textName).text = user.Name;
        //CrossSceneInformation.Users.Add(o);
    }

    private void SetNickname(string nickname)
    {
        if (ws == null)
        {
            return;
        }

        string newUser = "{\"Event\":\"set_nickname\",\"Payload\":{\"Name\":\"" + nickname + "\",\"Location\":{\"X\":1,\"Y\":1,\"Z\":1}}}";
        ws.Send(newUser);
    }

    public void SetUserChangedPosition()
    {
        if (ws == null)
        {
            return;
        }

        string newMovement = "{\"Event\":\"set_user_changed_position\",\"Payload\":{\"Name\":\"" + CrossSceneInformation.Nickname + 
            "\",\"Location\":{\"X\":" + myPlayer.transform.position.x.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture) + 
            ",\"Y\":" + myPlayer.transform.position.y.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture) +
            ",\"Z\":" + myPlayer.transform.position.z.ToString("0.0000", System.Globalization.CultureInfo.InvariantCulture) + "}}}";
        ws.Send(newMovement);
    }
}


