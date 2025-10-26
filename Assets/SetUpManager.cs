using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpManager : MonoBehaviour
{
    // 1. インスペクタから生成したいプレハブを設定
    [Header("生成するプレハブ")]
    public GameObject TehudaPrefab;
    public GameObject BahudaPrefab;//TODO

    // 2. インスペクタから座標・回転・サイズを指定
    [Header("トランスフォーム設定")]
    private Vector3[] spawnPositionsOfTehudaA = new Vector3[8];
    private Vector3[] spawnPositionsOfTehudaB = new Vector3[8];
    public Vector3[] spawnPositionsOfBahuda = new Vector3[12];

    // (X, Y, Z) の角度（オイラー角）で指定
    public Vector3 spawnRotation = new Vector3(0, 0, 0);

    //スケール
    //インスペクターの値が優先される
    public Vector3 TehudaSpawnScale = new Vector3(1, 1, 1);
    public Vector3 BahudaSpawnScale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        // プレハブが設定されているか確認
        if (TehudaPrefab == null )
        {
            Debug.LogError("Object Prefab が設定されていません！");
            return;
        }

        //場札を表示
        foreach (Vector3 pos in spawnPositionsOfBahuda)
        {
            // 1. 座標と回転を指定してオブジェクトを生成
            //    Vector3 の回転（オイラー角）を Quaternion に変換
            GameObject newObject = Instantiate(
                BahudaPrefab,
                pos,
                Quaternion.Euler(spawnRotation)
            );

            // 2. 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = BahudaSpawnScale;
        }
        //Aの手札を表示
        for (int i=0;i<8;i++)
        {
            spawnPositionsOfTehudaA[i] =new Vector3 (
                -4f + (1.2f * i),-7.0f,-2f
            );
            // 1. 座標と回転を指定してオブジェクトを生成
            //    Vector3 の回転（オイラー角）を Quaternion に変換
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaA[i],
                Quaternion.Euler(spawnRotation)
            );

            // 2. 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = TehudaSpawnScale;
        }
        //Bの手札を表示
        for (int i = 0; i < 8; i++)
        {
            spawnPositionsOfTehudaB[i] = new Vector3(
                -4f + (1.2f * i), 7.0f, -2f
            );
            // 1. 座標と回転を指定してオブジェクトを生成
            //    Vector3 の回転（オイラー角）を Quaternion に変換
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaB[i],
                Quaternion.Euler(spawnRotation)
            );

            // 2. 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = TehudaSpawnScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
