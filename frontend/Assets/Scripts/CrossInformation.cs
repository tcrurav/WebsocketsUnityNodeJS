using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneInformation
{
    public static string Nickname { get; set; }
    public static string IP { get; set; }
}

public class Message
{
    public string Event { get; set; }
    public List<User> Payload { get; set; }
}

public class User
{
    public string Name { get; set; }
    public Position Location { get; set; }
}

public class Position
{
    public float X  { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}
