using System;
using System.Collections.Generic;
using UnityEngine;

public class Example:MonoBehaviour
{
    enum GameEnums
    {
        Hello,
    }
    private void Start()
    {
        GlobalEvent.Init();
        
        GlobalEvent.AddEvent(GameEnums.Hello,Say_Hello_A);
        
        GlobalEvent.DispatchEvent(GameEnums.Hello,"1","2","3","4");
        
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
        GlobalEvent.RemoveEvent(GameEnums.Hello,Say_Hello_A);
    }

    private void Say_Hello_A(List<string> args)
    {
        Debug.Log("======say hello a====");
        Debug.Log(args[0]);
    }
}