using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

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
	
	private Slider meter;
    

    /***********************************************
     * クラス関数
     * ********************************************/
    void Awake()
    {
        arrow = transform.Find("Arrow").gameObject;

		meter = GameObject.Find("Canvas/Meter").GetComponent<Slider>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerManager.Instance.IsAction)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //タッチした場所のポジション
                clickPosDown = Input.mousePosition;
                arrow.SetActive(true);

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

                if(power >= maxPower)
                {
                    power = maxPower;
                }else if(power < minPower)
                {
                    return;
                }
                Debug.Log(power);
                //飛ばす処理
                PlayerManager.Instance.MyRigidbody.AddForce(playerVec * power);
                PlayerManager.Instance.IsAction = false;
            }
        
        }

		meter.value = transform.position.x;
	}
    
}
