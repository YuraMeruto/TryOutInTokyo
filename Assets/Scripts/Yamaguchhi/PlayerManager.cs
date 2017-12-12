using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    /*******************************************************
     * クラス変数
     * ****************************************************/
    private bool isAction = false;
    private Rigidbody2D myRigidbody;

    /******************************************************
     * プロパティ
     * ***************************************************/
     public static PlayerManager Instance
    {
        get;
        private set;
    }

    public bool IsAction
    {
        get { return isAction; }
        set { isAction = value; }
    }
    public Rigidbody2D MyRigidbody
    {
        get { return myRigidbody; }
    }
    /******************************************************
     * クラス関数
     * ***************************************************/
    void Awake()
    {
        if (Instance != null) return;
        else Instance = this;

        myRigidbody = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
        isAction = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D collider)
    {
        
        switch (collider.gameObject.tag)
        {
            case "Hujitsubo":
                Hujitsubo(collider.gameObject.transform);
                break;
            default:
                break;
        }        
    }

    void Hujitsubo(Transform pos)
    {
        Debug.Log("aaaaaa");
        isAction = true;
        myRigidbody.velocity = Vector2.zero;
        transform.position = pos.position;
    }
}
