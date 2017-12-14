using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    /*******************************************************
     * クラス変数
     * ****************************************************/
    private bool isAction = false;
    [SerializeField, Tooltip("プレイヤーのRigidBody2D")]
    private Rigidbody2D myRigidbody;
    private Vector2 direction;
    [SerializeField, Tooltip("プレイヤーのAnimator")]
    private Animator anim;
    private Animator hujiAnim;
    [SerializeField, Tooltip("プレイヤーPlayerFlowのAnimator")]
    private PlayerFlow flow;
    private GameObject gameOverPanel;
    private GameObject loadManager;
    [SerializeField, Tooltip("PlayerControlerのスクリプト")]
    private PlayerController playerControlerScript;
    [SerializeField]
    private GameObject hujitsuboBack;
    /******************************************************
     * プロパティ
     * ***************************************************/

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
    void Start()
    {
        loadManager = GameObject.Find("Manager/LoadManager");

    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Wall":
                playerControlerScript.SePlay(3);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        switch (collider.gameObject.tag)
        {

            case "Hujitsubo":
            case "HujitsuboReverse":
                Hujitsubo(collider.gameObject.transform,collider.gameObject.tag);
                playerControlerScript.SePlay(2);
                break;
            case "Goal":
                myRigidbody.velocity = Vector2.zero;
                SceneManager.LoadScene("GameClear");
                break;
            case "Enemy":
                switch (collider.gameObject.name)
                {
                    case "Fish":
                        playerControlerScript.SePlay(5);
                        break;
                    case "Urchin":
                        playerControlerScript.SePlay(4);
                        break;
                }
                loadManager.GetComponent<StageGeneration>().ShowPanel();
                break;
            default:
                break;
        }
        myRigidbody.simulated = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Hujitsubo"||collider.gameObject.tag == "HujitsuboReverse")
        {
            hujitsuboBack.SetActive(false);
            flow.isFlow = true;
            anim.SetBool("IsPlayer", true);
            collider.gameObject.GetComponent<Animator>().SetBool("IsHujitsubo", false);
            transform.parent = null;
        }
    }

    /// <summary>
    /// ふじつぼ処理
    /// </summary>
    /// <param name="pos">ふじつぼのTransform</param>
    void Hujitsubo(Transform pos,string tag)
    {
        hujitsuboBack.SetActive(true);
        pos.gameObject.GetComponent<Animator>().SetBool("IsHujitsubo", true);
        anim.SetBool("IsPlayer", false);
        flow.isFlow = false;
        Debug.Log(flow.isFlow);
        isAction = true;
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.simulated = false;
        transform.rotation = Quaternion.identity;
        //transform.parent = pos;
        //transform.position = new Vector2(pos.position.x,);
        Transform playerSpot = pos.Find("PlayerSpot");
        transform.position = playerSpot.position;
        if(tag == "HujitsuboReverse")
        {
            transform.rotation = playerSpot.rotation;
        }
    }
    //-------------------------------------


}