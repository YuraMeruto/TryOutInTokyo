using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    /***********************************************
     * クラス変数
     * ********************************************/
    private Vector2 playerVec; //飛ばす角度
    private float power; // 飛ばす力
    [SerializeField, Tooltip("飛ばす力の最大値")]
    private float maxPower = 500.0f;
    [SerializeField, Tooltip("飛ばす力の最小値")]
    private float minPower = 200.0f;
    private Vector2 clickPosDown, clickPosUp; //ドラッグしたポジション  
    private float pullDistance; // ドラッグした距離
    private GameObject arrow; // 矢印
    [SerializeField, Tooltip("SEを鳴らすAudio")]
    private AudioSource audio;
    [SerializeField]
    private AudioClip[] clip;
    private Slider meter;
    [SerializeField, Tooltip("PlayerMangerTestのスクリプト")]
    PlayerManager playermanagerScript;
    [SerializeField, Tooltip("プレイヤーPlayerFlowのAnimator")]
    PlayerFlow flow;
    [SerializeField, Tooltip("タップした時に泳ぐ力")]
    private float swimPower = 100000.0f;
    /***********************************************
     * クラス関数
     * ********************************************/
    void Start()
    {
        arrow = transform.Find("Arrow").gameObject;
        meter = GameObject.Find("Canvas/Meter").GetComponent<Slider>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playermanagerScript.IsAction)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //タッチした場所のポジション
                clickPosDown = Input.mousePosition;
                arrow.SetActive(true);
                SePlay(0);
            }

            if (Input.GetMouseButtonUp(0))
            {
                //離した場所のポジション
                clickPosUp = Input.mousePosition;
                arrow.SetActive(false);

                if (clickPosDown == clickPosUp)
                {
                    //指を離した場所が同じ場所なら処理抜ける
                    return;
                }

                //飛ばす方向の計算
                playerVec = clickPosDown - clickPosUp;
                playerVec.Normalize();
                //ドラッグした距離の計算
                pullDistance = (clickPosDown - clickPosUp).magnitude;

                power = pullDistance * 3.0f;
                Debug.Log(power);

                if (power >= maxPower)
                {
                    power = maxPower;
                }
                else if (power < minPower)
                {
                    return;
                }
                //飛ばす処理
                playermanagerScript.MyRigidbody.AddForce(playerVec * power);
                playermanagerScript.IsAction = false;
                SePlay(1);             
            }
            
        }
        //タップしたときに少し前へ進む
        if (flow.isFlow)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //playermanagerScript.MyRigidbody.AddForce(transform);
            }

        }
        meter.value = transform.position.x;
    }

    public void SePlay(int number)
    {
        audio.clip = clip[number];
        audio.Play();
    }
}
