using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urchin : EnemyBase {

    private float activeTimer;

    private int status;

    public GameObject urchinActive;
    public BoxCollider2D collider;

    void Start () {
        activeTimer = 0.0f;
        status = 0;
    }

    void Update() {
      switch (status)
        {
            case 0:
                activeTimer += Time.deltaTime;
                if (activeTimer >= 2.0f)
                {
                    urchinActive.SetActiveRecursively(true);
                    status = 1;
                    collider.size = new Vector2(0.2f, 0.2f);
                }
                break;
            case 1:
                activeTimer -= Time.deltaTime;
                if (activeTimer <= 0.0f)
                {
                    urchinActive.SetActiveRecursively(false);
                    status = 0;
                    collider.size = new Vector2(0.16f, 0.16f);
                }
                break;

        }
    }
}
