using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBase : MonoBehaviour {

    public int EnemyType;
    public int EnemyHp;
    public int EnemyAttac;
    public float EnemySpeed;
    public float EnemyPositionX;
    public float EnemyPositionY;      

    /// <summary>
    /// 敵移動
    /// </summary>
    public virtual void EnemyMove()
    {
        
    }
}
