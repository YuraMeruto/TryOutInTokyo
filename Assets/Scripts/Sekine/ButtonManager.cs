////////////////////////////////////
//製作者　関根明良
//クラス　ボタン処理クラス
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
	/// <summary>
	/// シーン遷移
	/// </summary>
	public void SceneTransition(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	/// <summary>
	/// メインシーンへの遷移
	/// </summary>
	/// <param name="stageNum">遷移先のステージ番号</param>
	public void ToGameScene(int stageNum)
	{
		SceneManager.LoadScene("Game");
	}
}
