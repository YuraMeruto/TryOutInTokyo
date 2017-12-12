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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ActionSwitch()
    {
        isAction = true;
    }
}
