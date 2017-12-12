////////////////////////////////////
//製作者　名越大樹
//クラス　PlayerPrefを使うクラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPlayerPref : MonoBehaviour
{

    public bool GetHasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public string GetStringKey(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public int GetIntKey(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public float GetFloatKey(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }

    public void SetIntKey(string key, int value)
    {
        PlayerPrefs.SetInt(key,value);
    }

    public void SetFloatKey(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SetStringKey(string key, string value)
    {
        PlayerPrefs.SetString(key,value);
    }
}
