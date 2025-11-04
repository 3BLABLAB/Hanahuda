using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpManager : MonoBehaviour
{
    private MainSceneManager mainSceneManager;
    private Huda Huda;
    private bool[,] Bahuda_Appeared = new bool[12, 4];
    public List<Huda>[] Bahuda ;
    public Huda[] A_Tehuda ;
    public Huda[] B_Tehuda;

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

    private void Awake()
    {
        mainSceneManager = GetComponent<MainSceneManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    public void SetUp()
    {
        //Awake()で代入すると順序がずれる可能性あり
        Bahuda_Appeared = mainSceneManager.Bahuda_Appeared;
        Bahuda = mainSceneManager.Bahuda;
        A_Tehuda = mainSceneManager.A_Tehuda;
        B_Tehuda = mainSceneManager.B_Tehuda;
        Sprite[] spritesToPass = mainSceneManager.HudaSprites;
        // プレハブが設定されているか確認
        if (TehudaPrefab == null)
        {
            Debug.LogError("Object Prefab が設定されていません！");
            return;
        }

        //場札を設定
        while(true)  
        {
            int NewBahudaNum,mo,or ;
            do
            {
                NewBahudaNum = UnityEngine.Random.Range(0, 48);//0-47
                mo = NewBahudaNum / 4;
                or = NewBahudaNum % 4;
            } while (Bahuda_Appeared[mo, or]);
            Bahuda_Appeared[mo, or] = true;

            // 座標と回転を指定してオブジェクトを生成
            GameObject newObject = Instantiate(
                BahudaPrefab,
                spawnPositionsOfBahuda[mo],
                Quaternion.Euler(spawnRotation)// Vector3 の回転（オイラー角）を Quaternion に変換
            );
            // 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = BahudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or, spritesToPass);
            Bahuda[mo].Add(BahudaComponent);

            int nonEmptyMonthCount = 0;
            {
                for (int i = 0; i < Bahuda.Length; i++)
                {
                    if (Bahuda[i] != null && Bahuda[i].Count > 0)
                    {
                        nonEmptyMonthCount++;
                    }
                }
            }
            if (nonEmptyMonthCount >= 8) break;
        }

        //Aの手札を設定
        for (int i = 0; i < 8; i++)
        {
            int NewBahudaNum, mo, or;
            do
            {
                NewBahudaNum = UnityEngine.Random.Range(0, 48);//0-47
                mo = NewBahudaNum / 4;
                or = NewBahudaNum % 4;
            } while (Bahuda_Appeared[mo, or]);
            Bahuda_Appeared[mo, or] = true;

            spawnPositionsOfTehudaA[i] = new Vector3(
                -4f + (1.2f * i), -7.0f, -2f
            );
            // 座標と回転を指定してオブジェクトを生成
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaA[i],
                Quaternion.Euler(spawnRotation)// Vector3 の回転（オイラー角）を Quaternion に変換
            );
            // 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = TehudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or, spritesToPass);
            A_Tehuda[i] = BahudaComponent;
        }
        //Bの手札を設定
        for (int i = 0; i < 8; i++)
        {
            int NewBahudaNum, mo, or;
            do
            {
                NewBahudaNum = UnityEngine.Random.Range(0, 48);//0-47
                mo = NewBahudaNum / 4;
                or = NewBahudaNum % 4;
            } while (Bahuda_Appeared[mo, or]);
            Bahuda_Appeared[mo, or] = true;
            spawnPositionsOfTehudaB[i] = new Vector3(
                -4f + (1.2f * i), 7.0f, -2f
            );
            // 座標と回転を指定してオブジェクトを生成
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaB[i],
                Quaternion.Euler(spawnRotation)// Vector3 の回転（オイラー角）を Quaternion に変換
            );
            // 生成したオブジェクトのサイズ（スケール）を指定
            newObject.transform.localScale = TehudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or, spritesToPass);
            B_Tehuda[i] = BahudaComponent;
        }

        //Debug.Log("Bahuda");
        //Debug.Log("A_Tehuda");
        //Debug.Log("B_Tehuda");
        //foreach(List<Huda> tmp in Bahuda)
        //{
        //    foreach(Huda h in tmp) Debug.Log($"Tsuki: {h.Tsuki}, Order: {h.Order}");
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
