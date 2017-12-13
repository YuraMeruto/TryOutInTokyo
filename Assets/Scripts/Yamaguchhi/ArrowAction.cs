using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAction : MonoBehaviour {
    /**********************************
     * クラス変数
     * *******************************/


    /***********************************
     * クラス関数
     * **********************************/

    void Update()
    {
        //矢印の回転    
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rot = (vec - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, rot);
    }
    //---------------------------------------------------
    
}
