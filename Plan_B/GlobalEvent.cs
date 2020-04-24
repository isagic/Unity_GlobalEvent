using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可发送形式类与字符串
/// </summary>
public class GlobalEvent
{
    public delegate void fun(string o);
    private static Dictionary<Enum, fun> dels = null;
    
    /// <summary>
    /// 提高存在感
    /// GlobalEvent.Init() to init.
    /// </summary>
    public static void Init()
    {
        dels = new Dictionary<Enum, fun>();
    }

    public static void AddEvent(Enum name,fun f)
    {
        if (dels.ContainsKey(name))
            dels[name] += f;
        else
            dels.Add(name, f);
    }

    public static void RemoveEvent(Enum name,fun f)
    {
        if (dels.ContainsKey(name))
        {
            dels[name] -= f;
            if (dels[name] == null) dels.Remove(name);
        }
    }

    public static void DispatchEvent(Enum name,object o = null)
    {
        if (dels.ContainsKey(name))
        {
            string str = string.Empty;
            if (o != null)
            {
                if (o.GetType().ToString() == "System.String")
                    str = o.ToString();
                else
                    str = JsonUtility.ToJson(o);
            }
            if (dels[name] != null) dels[name](str);
        }
    }
}
