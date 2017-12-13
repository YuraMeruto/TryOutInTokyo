using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OButton : MonoBehaviour
{
    private float sceneChange = 0.0f;
    private bool sceneFlg = false;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sceneFlg = true;
        };
        if (sceneFlg)
        {
            sceneChange += Time.deltaTime;
            if (sceneChange > 1.0f)
            {
                OnClick();
            }

        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
