using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class PlayerShip : MonoBehaviour
{
    //弾を発射するオブジェクトの位置を取得
    public Transform firePoint;

    public GameObject explosion;

    //弾をオブジェクトとして取得
    public GameObject bulletPrefab;

    //リトライボタン:シーンの再読み込み
    [SerializeField] GameObject LastPanel = default;

    public static int count;
    int frame;

    void Start()
    {
        frame = 0;
        count = 10;
    }

    // 一定時間(0.02s)ごとに実行される関数
    void Update()
    {
        Move();

        frame++; // フレームをカウント

        //Zキーを押しているときかつ10フレームごと
        if (Input.GetKey(KeyCode.Space) && frame % count == 0)
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); // プレイヤーの位置に弾を生成します
        }

    }

    //移動の処理
    void Move()
    {
        //横軸の値を返す
        float x = Input.GetAxisRaw("Horizontal");

        //縦軸の値を返す
        float y = Input.GetAxisRaw("Vertical");

        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        //移動できる範囲をMathf.Clampで範囲指定して制御
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -7.2f, 7.2f),
            Mathf.Clamp(nextPosition.y, -4.5f, 4.5f),
            nextPosition.z
            );
        //現在位置にnextPositionを＋
        transform.position = nextPosition;
    }

    

    //爆発
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") == true)
        {
            // 爆破エフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            // 自分を破壊
            Destroy(gameObject);
            // 弾を破壊
            Destroy(collision.gameObject);

            LastPanel.SetActive(true);
        }else if(collision.CompareTag("Finish") == true)
        {
            // 爆破エフェクト
            Instantiate(explosion, transform.position, transform.rotation);
            // 自分を破壊
            Destroy(gameObject);
            // 弾を破壊
            Destroy(collision.gameObject);

            LastPanel.SetActive(true);
        }
    }
}