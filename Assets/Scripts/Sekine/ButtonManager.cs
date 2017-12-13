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
	[SerializeField]
	GameObject panel;

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
	public void ToGameScene()
	{
		SceneManager.LoadScene("Game");
	}

	public void SwitchPanel(string stageName)
	{
		panel.SetActive(!panel.activeSelf);

		ReadPlayerPref.SetStringKey("PlayingStage", stageName);
	}
}
