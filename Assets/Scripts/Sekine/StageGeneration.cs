////////////////////////////////////
//製作者　関根明良
//クラス　ステージ生成クラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageGeneration : MonoBehaviour
{
	[SerializeField]
	Transform stageObjectsParent;

	[SerializeField]
	List<GameObject> stageObjects = new List<GameObject>();

	List<string[]> csvData = new List<string[]>();

	void Start()
	{

		Debug.Log(ReadPlayerPref.GetStringKey("1-1"));
		TextAsset csv = Resources.Load(ReadPlayerPref.GetStringKey(ReadPlayerPref.GetStringKey("PlayingStage"))) as TextAsset;
		StringReader reader = new StringReader(csv.text);

		while (reader.Peek() > -1)
		{
			string line = reader.ReadLine();
			csvData.Add(line.Split(','));
		}

		for (int i = 0; i < csvData.Count; i++)
		{
			for (int j = 0; j < csvData[i].Length; j++)
			{
				if (int.Parse(csvData[i][j]) != 0)
					Instantiate(stageObjects[int.Parse(csvData[i][j])-1], stageObjectsParent).transform.localPosition = new Vector3(j * 1.28f, -i * 1.28f, 0.0f);
			}
		}
	}
}