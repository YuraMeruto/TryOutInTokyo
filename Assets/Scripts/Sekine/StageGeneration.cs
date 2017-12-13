////////////////////////////////////
//製作者　関根明良
//クラス　ステージ生成クラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class StageGeneration : MonoBehaviour
{
	public GameObject mainCamera;

	[HideInInspector]
	public Transform stageObjectsParent;

	[HideInInspector]
	public List<GameObject> stageObjects;

	List<string[]> csvData = new List<string[]>();

	void Start()
	{
		TextAsset csv = Resources.Load("CSV/" + ReadPlayerPref.GetStringKey(ReadPlayerPref.GetStringKey("PlayingStage"))) as TextAsset;
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
				{
					Instantiate(stageObjects[int.Parse(csvData[i][j]) - 1], stageObjectsParent).transform.localPosition = new Vector3(j * 1.28f, -i * 1.28f, 0.0f);
				}
				
			}
		}
	}

	#if UNITY_EDITOR

	[CustomEditor(typeof(StageGeneration))]
	public class StageGenerationEditor : Editor
	{

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			StageGeneration stageGeneration = target as StageGeneration;

			stageGeneration.stageObjectsParent = EditorGUILayout.ObjectField("ステージの親オブジェクト", stageGeneration.stageObjectsParent, typeof(Transform), true) as Transform;

			List<GameObject> list = stageGeneration.stageObjects;

			for (int i = 0; i < list.Count; i++)
				list[i] = EditorGUILayout.ObjectField("ステージ画像 " + (i + 1), list[i], typeof(GameObject), true) as GameObject;

			GameObject add = EditorGUILayout.ObjectField("追加画像", null, typeof(GameObject), true) as GameObject;

			if (add != null)
				list.Add(add);

			if (GUILayout.Button("1つ消す", GUILayout.Width(100)))
			{
				list.RemoveAt(list.Count-1);
			}

			if (GUILayout.Button("保存", GUILayout.Width(100)))
				EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
		}
	}

	#endif
}