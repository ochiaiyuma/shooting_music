using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        //上に動かす
        transform.position += new Vector3(0, 3f, 0) * Time.deltaTime;

        //撃った弾のy軸が3以上の位置にいったら破壊＊＊＊＊＊＊＊＊＊＊＊＊今回追加
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }
}
