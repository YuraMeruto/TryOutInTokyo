using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OFade : MonoBehaviour
{
    private bool fadeFlg;
    private float alfa = 0.0f;
    float red, green, blue;

    //public float fadeSpeed = 0.f;

    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fadeFlg = true;
        }
        if(fadeFlg)
        {
            FadePanel();
        }
    }
    public void FadePanel()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += Time.deltaTime;
    }
}
