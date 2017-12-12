using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urchin : EnemyBase
{

    private float activeTimer;

    private int status;

    Animator urchinAnimation;
    public GameObject urchinActive;
    public BoxCollider2D collider;
    //ウニのサイズ・座標
    Vector2 ActiveColliderOffset = new Vector2(-0.51f, 0.56f);
    Vector2 ActiveColliderSize = new Vector2(7.846f, 7.86f);

    Vector2 DefalutColliderOffset = new Vector2(1.81f, 0.22f);
    Vector2 DefalutColliderSize = new Vector2(5.58f, 5.16f);
    void Start()
    {
        urchinAnimation = GetComponent<Animator>();
        activeTimer = 0.0f;
        status = 0;
    }

    void Update()
    {
        switch (status)
        {
            case 0:
                activeTimer += Time.deltaTime;
                if (activeTimer >= 2.0f)
                {
                    urchinAnimation.SetBool("ActiveFlg", true);
                    urchinActive.SetActiveRecursively(true);
                    status = 1;
                    collider.offset = ActiveColliderOffset;
                    collider.size = ActiveColliderSize;
                }
                break;
            case 1:
                activeTimer -= Time.deltaTime;
                if (activeTimer <= 0.0f)
                {
                    urchinAnimation.SetBool("ActiveFlg", false);
                    urchinActive.SetActiveRecursively(false);
                    status = 0;
                    collider.offset = DefalutColliderOffset;
                    collider.size = DefalutColliderSize;
                }
                break;

        }
    }
}
