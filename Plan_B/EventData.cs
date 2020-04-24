using UnityEngine;

[System.Serializable]
public class EventData
{
    public int id = 0;
    public int hp = 0;
    public int mp = 0;
    public int camp = 0;
    public Vector2 pos;
    public bool ismove = false;

    public EventData(object o)
    {
        string js = string.Empty;
        js = JsonUtility.ToJson(o);
        JsonUtility.FromJsonOverwrite(js, this);
    }

    public static EventData New(object o)
    {
        return new EventData(o);
    }
}
