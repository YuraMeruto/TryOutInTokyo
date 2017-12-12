//////////////////////////////////////
//製作者　名越大樹
//クラス　Resourcesからデータを取得するスクリプト
//////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReourcesRead : MonoBehaviour
{
    [SerializeField]
    string file;
    void Start()
    {
        ReadTextData(file);
    }
    public string ReadCSVData(string file)
    {
        TextAsset readdata = Resources.Load(file) as TextAsset;
        StringReader reader = new StringReader(readdata.text);
        string data = reader.ReadToEnd();
        return data;
    }

    public string ReadTextData(string file)
    {
        TextAsset readdata = Resources.Load(file) as TextAsset;
        Debug.Log(readdata.text);
        return readdata.text;
    }
}
