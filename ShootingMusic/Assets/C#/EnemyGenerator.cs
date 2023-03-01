using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //enemyPrefabというGemaobjectがあることを記述
    public GameObject enemyPrefab;

    //ゲーム起動時に動く処理
    void Start()
    {
        //繰り返し関数を実行する(Spawnを２秒後に0.5秒刻みで実行)
        //InvokeRepeating("Spawn", 1.5f, 0.8f);//ここを音楽と連動させて起こす
    }

    //生成する
    public void Spawn()
    {
        //生成位置（x軸）をランダムにしたい
        Vector3 spawnPosition = new Vector3(
            Random.Range(-6.0f, 6.0f),//生成する範囲は、生成ポイントを移動させてx軸を調べた数値を使おう
            5.0f,//transform.position.y,
            transform.position.z
            );

        //（引数）をオブジェクト化する
        Instantiate(enemyPrefab,//生成するもの
            spawnPosition,//生成する場所(今回はアタッチしているオブジェクトからになる)
            transform.rotation//生成時の向き
            );
    }
}
