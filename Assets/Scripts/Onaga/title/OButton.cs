using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OButton : MonoBehaviour
{
    private AudioSource touchSE;
    public OFade fade;
    private float SceneChengePoint = 1.0f;
    private float fadeWiteTime = 0.0f;
    private bool sceneFlg = false;
    public float fadeSpeed;

    void Start()
    {
        touchSE = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchSE.PlayOneShot(touchSE.clip);
            fadeSpeed = fade.fadeSpeed;
            sceneFlg = true;
        };
        if (sceneFlg)
        {
            fadeWiteTime += fadeSpeed;
            if (fadeWiteTime > SceneChengePoint)
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
