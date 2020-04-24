using System;
using System.Collections.Generic;

/// <summary>
/// Author Sagic @ email:isagic@gmail.com time:2020/02/19 10:40:08
/// </summary>
public class GlobalEvent
{
    /// <summary>
    /// 事件代理
    /// </summary>
    /// <param name="args"></param>
    public delegate void ItemEvent(List<string> args = null);

    /// <summary>
    /// 所有的事件
    /// </summary>
    private static Dictionary<Enum, List<ItemEvent>> dels = null;

    /// <summary>
    /// 提高存在感
    /// GlobalEvent.Init() to init.
    /// </summary>
    public static void Init()
    {
        dels = new Dictionary<Enum, List<ItemEvent>>();
    }

    /// <summary>
    /// 添加事件（必须要移除
    /// Add a Event (Must be removed
    /// </summary>
    /// <param name="em"></param>
    /// <param name="callback"></param>
    public static void AddEvent(Enum em, ItemEvent callback)
    {
        if (dels.ContainsKey(em))
        {
            List<ItemEvent> ld = dels[em];
            if (ld != null)
            {
                ld.Add(callback);
            }
            else
            {
                ld = new List<ItemEvent>();
                ld.Add(callback);
            }
        }
        else
        {
            dels.Add(em, new List<ItemEvent> {callback});
        }
    }

    /// <summary>
    /// 分发事件
    /// Dispatch event
    /// </summary>
    /// <param name="em"></param>
    /// <param name="str"></param>
    public static void DispatchEvent(Enum em, params string[] str)
    {
        if (dels.ContainsKey(em))
        {
            List<ItemEvent> ld = dels[em];
            if (ld != null) ld.ForEach(x => x(new List<string>(str)));
        }
    }

    /// <summary>
    /// 移除事件（必须与添加对应可以移除多次
    /// Remove event (Allow multiple removals
    /// </summary>
    /// <param name="em"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent(Enum em, ItemEvent callback)
    {
        if (dels.ContainsKey(em))
        {
            List<ItemEvent> ld = dels[em];
            if (ld != null)
            {
                if (ld.Count > 0)
                    ld.Remove(callback);
                else
                    dels.Remove(em);
                //Debug.Log("=====removeEvent==="+em+"==="+ld.Count);
            }
        }
    }
}