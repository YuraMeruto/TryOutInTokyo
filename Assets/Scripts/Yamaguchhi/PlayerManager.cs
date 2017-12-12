using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    /*******************************************************
     * クラス変数
     * ****************************************************/
    private bool isAction = false;


    /******************************************************
     * プロパティ
     * ***************************************************/
     public static PlayerManager Instance
    {
        get;
        private set;
    }
    /******************************************************
     * クラス関数
     * ***************************************************/
    void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
        
    }
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        
=======
		
>>>>>>> parent of 1b92547... ふじつぼに当たっている状態でのみ動かす実装
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ActionSwitch()
    {
        isAction = true;
    }
}
