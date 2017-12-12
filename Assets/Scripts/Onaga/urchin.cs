using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urchin : EnemyBase {

    private float ActiveTimer;

    public GameObject urchinActive;

    int status;

    // Use this for initialization
    void Start () {
        ActiveTimer = 0.0f;
        status = 0;
    }

    // Update is called once per frame
    void Update() {
      switch (status)
        {
            case 0:
                ActiveTimer += Time.deltaTime;
                if (ActiveTimer >= 2.0f)
                {
                    urchinActive.SetActiveRecursively(true);
                    status = 1;
                }
                break;
            case 1:
                ActiveTimer -= Time.deltaTime;
                if (ActiveTimer <= 0.0f)
                {
                    urchinActive.SetActiveRecursively(false);

                    status = 0;
                }
                break;

        }
    }
}
