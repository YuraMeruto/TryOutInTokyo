using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCtrl : EnemyBase {

    // 管理用座標
    Vector2 pos;

    // 魚の移動方向
    Vector3 direction = Vector3.left;

    // 移動速度初期値
    float moveInitializeSpeed = 0.5f;

    [SerializeField, Tooltip("敵のスケール")]
    private float enemyScale = 0.8f;

	// Use this for initialization
	void Start () {
        // 初期値
        enemyPositionX = transform.position.x;
        enemyPositionY = transform.position.y;

        // サイズ変更
        transform.localScale = new Vector3(enemyScale,enemyScale);

        // 速度設定
        enemySpeed = moveInitializeSpeed;
    }

    // Update is called once per frame
    void Update () {
        EnemyMove();

        // 削除
        if (transform.position.x < -10) Destroy(gameObject);
	}

    public override void EnemyMove()
    {
        // 移動処理
        transform.position = pos;

        // 編集
        enemyPositionX -= enemySpeed * Time.deltaTime;
        pos = new Vector2(enemyPositionX, enemyPositionY);
    }
}
