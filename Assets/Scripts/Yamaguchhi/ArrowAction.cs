using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAction : MonoBehaviour {
	/**********************************
     * クラス変数
     * *******************************/
	static Vector2 before;

	/***********************************
     * クラス関数
     * **********************************/
	private void Start()
	{
		before = Input.mousePosition;
	}

	void Update()
	{
		//矢印の回転
		Vector2 now = Input.mousePosition;
		float rot = Mathf.Atan2(now.y - before.y, now.x - before.x);

		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot*Mathf.Rad2Deg-90.0f);
	}
    //---------------------------------------------------
    
}
