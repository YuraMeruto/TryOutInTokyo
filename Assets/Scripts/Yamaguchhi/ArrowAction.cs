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
        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            Debug.Log("a");
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rot = (vec - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, rot);
        }else if(Input.mousePosition.x >= Camera.main.WorldToScreenPoint(transform.position).x)
        {
            Debug.Log("b::"+"mouse:"+Input.mousePosition.x+" player:"+transform.position.x);
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rot = (-vec - new Vector2(transform.position.x, transform.position.y)).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, rot);
        }
        
        

    }
    //---------------------------------------------------
    
}
