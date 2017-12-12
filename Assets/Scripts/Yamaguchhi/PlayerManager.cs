using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        switch (collider.gameObject.tag)
        {
            case "Hujitsubo":
                Hujitsubo(collider.gameObject.transform);
                break;
            case "Goal":
                myRigidbody.velocity = Vector2.zero;
                SceneManager.LoadScene("Result");
                break;
            case "Enemy":
                SceneManager.LoadScene("GameOver");
                break;
            default:
                break;
        }        
    }
    /// <summary>
    /// ふじつぼ処理
    /// </summary>
    /// <param name="pos"></param>
    void Hujitsubo(Transform pos)
    {
        isAction = true;
        myRigidbody.velocity = Vector2.zero;
        transform.position = pos.position;
    }
    //-------------------------------------
}
