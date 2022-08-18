using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalEvent {
    public delegate void ItemEvent(List<object> o = null);

    private static Dictionary<Enum, List<ItemEvent>> di = null;

    /// <summary>
    /// 提高存在感
    /// </summary>
    public static void Init() {
        di = new Dictionary<Enum, List<ItemEvent>>();
    }

    /// <summary>
    /// 添加事件（必须要移除
    /// </summary>
    /// <param name="em"></param>
    /// <param name="callback"></param>
    public static void AddEvent(Enum em, ItemEvent callback) {
        // Debug.Log($"----add:{em}");
        if (di.ContainsKey(em))
        {
            List<ItemEvent> ld = di[em];
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
            di.Add(em, new List<ItemEvent> { callback });
        }
    }

    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="em"></param>
    /// <param name="str"></param>
    public static void DispatchEvent(Enum em, params object[] str) {
        try
        {
            if (di.ContainsKey(em))
            {
                List<ItemEvent> ld = di[em];
                if (ld != null)
                {
                    // Debug.Log(em +"=="+ld.Count);
                    ld.ToList().ForEach(x => { x(new List<object>(str)); });
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    /// <summary>
    /// 移除事件（必须与添加对应可以移除多次
    /// </summary>
    /// <param name="em"></param>
    /// <param name="callback"></param>
    public static void RemoveEvent(Enum em, ItemEvent callback) {
        if (di != null && di.ContainsKey(em))
        {
            List<ItemEvent> ld = di[em];
            if (ld != null)
            {
                if (ld.Count > 0)
                    ld.Remove(callback);
                else
                    di.Remove(em);
                // Debug.Log("=====removeEvent===" + em + "===" + ld.Count);
            }
        }
    }
}