using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    //爆破エフェクト
    public GameObject explosion;

    //Bullet
    public GameObject bulletPrefab;

    //敵機の移動
    float offset;

    void Start()
    {
        offset = Random.Range(0, 2f * Mathf.PI);
        //攻撃
        InvokeRepeating("Shot", 2f, 1f);
    }

    void Shot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    //接触判定があった場合(collisonには接触したオブジェクトの情報が入っている)
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //playerと敵が接触した時
        if (collision.CompareTag("Player") == true)
        {
            //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
            Instantiate(explosion, collision.transform.position, transform.rotation);
        }
        else if (collision.CompareTag("EnemyBullet") == true)
        {
            return;// この関数に関してはここで、実行を終える
        }
        else if(collision.CompareTag("Finish")== true)
        {
            return;
        }

        //破壊する時に爆破エフェクト生成（生成したいもの、場所、回転）
        Instantiate(explosion, transform.position, transform.rotation);
        //enemyの機体を破壊
        Destroy(gameObject);
        //collisionはぶつかった相手の情報が入っている。この場合は弾
        Destroy(collision.gameObject);

        
    }
    // Update is called once per frame
    void Update()
    {
        //真下に移動する
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount * 0.01f + offset) * 0.005f, Time.deltaTime, 0);

        //撃った弾のy軸が-3以下の位置にいったら破壊＊＊＊＊＊＊＊＊＊＊＊＊今回追加
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
