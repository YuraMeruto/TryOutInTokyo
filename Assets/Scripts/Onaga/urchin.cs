using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urchin : EnemyBase {

    private float activeTimer;

    private int status;

    public GameObject urchinActive;

    // Use this for initialization
    void Start () {
        activeTimer = 0.0f;
        status = 0;
    }

    // Update is called once per frame
    void Update() {
      switch (status)
        {
            case 0:
                activeTimer += Time.deltaTime;
                if (activeTimer >= 2.0f)
                {
                    urchinActive.SetActiveRecursively(true);
                    status = 1;
                }
                break;
            case 1:
                activeTimer -= Time.deltaTime;
                if (activeTimer <= 0.0f)
                {
                    urchinActive.SetActiveRecursively(false);

                    status = 0;
                }
                break;

        }
    }
}
