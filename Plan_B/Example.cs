using System;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    enum GameEnums
    {
        Hello,
    }
    private void Start()
    {
        //init
        GlobalEvent.Init();
        
        //dispatch string
        GlobalEvent.AddEvent(GameEnums.Hello,Say_Hello_A);
        GlobalEvent.DispatchEvent(GameEnums.Hello,"Hello!");
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
        
        //dispathc class
        GlobalEvent.AddEvent(GameEnums.Hello,Say_Hello_B);
        GlobalEvent.DispatchEvent(GameEnums.Hello,EventData.New(new Dictionary<string,object>
        {
            {"pos",Vector2.zero},
            {"id",120}
        }));
        
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_B);
        
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);

    }

    private void Say_Hello_B(string o)
    {
        Debug.Log("=====hello b====");
        EventData ed = EventData.New(o);
        Debug.Log(ed.id);
        Debug.Log(ed.pos);
    }

    private void Say_Hello_A(string o)
    {
        Debug.Log("=====hello a====");
        Debug.Log(o);
    }
}