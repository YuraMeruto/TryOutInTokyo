using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCtrl : MonoBehaviour {

    // 魚の移動方向
    Vector3 direction = Vector3.left;

    // 魚の移動速度
    float moveSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // 削除
        if (transform.position.x < -10) Destroy(gameObject);
	}
}
