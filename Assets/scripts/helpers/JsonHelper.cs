﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class JsonHelper2
 {
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }

    public static String[] CreateUsernameArrayFromJSON(string jsonString)
    {
        jsonString = "{\"Items\":" + jsonString + "}";
        return JsonHelper2.FromJson<String>(jsonString);
    }

    public static Item[] CreateItemArrayFromJSON(string jsonString)
    {
        jsonString = "{\"Items\":" + jsonString + "}";
        return JsonHelper2.FromJson<Item>(jsonString);
    }
}
