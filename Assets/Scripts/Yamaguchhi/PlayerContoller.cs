using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    /***********************************************
     * クラス変数
     * ********************************************/
    private Rigidbody2D myRigidbody;
    private Vector2 playerVec;
    private Vector2 clickPosDown, clickPosUp;
    private float power = 1000.0f;
    private bool isAction = false;
    private GameObject arrow;

    /***********************************************
     * クラス関数
     * ********************************************/
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        arrow = transform.Find("Arrow").gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            //タッチした場所のポジション
            clickPosDown = Input.mousePosition;
            Debug.Log("Down:" + clickPosDown);
            arrow.SetActive(true);
            
            
        }

        
        

        if (Input.GetMouseButtonUp(0))
        {
            //離した場所のポジション
            clickPosUp = Input.mousePosition;
            Debug.Log("Up:" + clickPosUp);
            arrow.SetActive(false);

            if(clickPosDown == clickPosUp)
            {
                //指を離した場所が同じ場所なら処理抜ける
                return;
            }

            
            

            //飛ばす方向の計算
            playerVec = clickPosDown - clickPosUp;       
            playerVec.Normalize();
            myRigidbody.AddForce(playerVec * power);
        }
	}
    //-------------------------------------------
}
