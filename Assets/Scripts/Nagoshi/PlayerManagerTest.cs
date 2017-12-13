using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagerTest : MonoBehaviour {

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
    private PlayerControlerTest playerControlerScript;
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
                Hujitsubo(collider.gameObject.transform);
                playerControlerScript.SePlay(2);
                break;
            case "Goal":
                myRigidbody.velocity = Vector2.zero;
                SceneManager.LoadScene("Result");
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
                //audio.clip = clip[1];
                //audio.Play();
                break;
        }
        myRigidbody.simulated = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Hujitsubo")
        {
            flow.isFlow = true;
            hujiAnim.speed /= 1.5f;
            anim.SetBool("IsPlayer", true);
        }
    }

    /// <summary>
    /// ふじつぼ処理
    /// </summary>
    /// <param name="pos">ふじつぼのTransform</param>
    void Hujitsubo(Transform pos)
    {
        //audio.clip = clip[0];
        //audio.Play();
        hujiAnim = pos.gameObject.GetComponent<Animator>();
        hujiAnim.speed *= 1.5f;

        anim.SetBool("IsPlayer", false);
        flow.isFlow = false;
        isAction = true;
        myRigidbody.velocity = Vector2.zero;
        myRigidbody.simulated = false;
        transform.rotation = Quaternion.identity;
        transform.position = pos.position;
    }
    //-------------------------------------


}
