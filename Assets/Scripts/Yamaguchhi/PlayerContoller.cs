using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    /***********************************************
     * クラス変数
     * ********************************************/
    private Vector2 playerVec;    
    private Vector2 clickPosDown, clickPosUp;
    private float power = 10.0f;
    private float pullDistance;
    private GameObject arrow;
    

    /***********************************************
     * クラス関数
     * ********************************************/
    void Awake()
    {
        arrow = transform.Find("Arrow").gameObject;
        //test
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
                //飛ばす処理
                PlayerManager.Instance.MyRigidbody.AddForce(playerVec * power * pullDistance);
                PlayerManager.Instance.IsAction = false;
            }
        
        }
	}
    
}
