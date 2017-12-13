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
    private Vector2 direction;
    [SerializeField,Tooltip("プレイヤーのAnimator")]
    private Animator anim;
    private Animator hujiAnim;
    private PlayerFlow flow;
    private GameObject gameOverPanel;

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
    void Start()
    {
        if (Instance != null) return;
        else
        {

            Instance = this;
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        flow = GetComponent<PlayerFlow>();

        gameOverPanel = GameObject.Find("Canvas/GameOver");
        gameOverPanel.SetActive(false);
        
        direction = gameObject.transform.localScale;
        direction.x *= -1;
        gameObject.transform.localScale = direction;
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
                //SceneManager.LoadScene("GameOver");
                gameOverPanel.SetActive(true);
                break;
            default:
                break;
        }
		myRigidbody.simulated = true;
    }

	private void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Hujitsubo")
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
