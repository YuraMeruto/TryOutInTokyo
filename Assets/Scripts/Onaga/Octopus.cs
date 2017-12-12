using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : EnemyBase {

	// Use this for initialization
	void Start () {
        base.enemySpeed = 0.5f;
        base.enemyPositionX = transform.position.x;
        base.enemyPositionY = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
