using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
using Unity.VisualScripting;

public class MainSceneManager : MonoBehaviour
{
    SetUpManager SetUpManager;
    //花札のカードを定義
    //順番はhttps://hanafudazukan.hatenablog.com/を参照
    //ただし9月(菊)は青短と菊を入れ替える
    public bool[,] Bahuda_Appeared = new bool[12, 4];
    public bool[,] A_Mochihuda =new bool[12, 4], B_Mochihuda=new bool [12, 4];
    //場札：12か月分、重複の可能性あり
    //一か月あたり一つのList
    public List<Huda>[] Bahuda=new List<Huda>[12];
    public Huda[] A_Tehuda = new Huda[8];
    public Huda[] B_Tehuda = new Huda[8];
    public bool Is_A = true;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートを60に固定
        //場札を初期化
        for (int i = 0; i < Bahuda.Length; i++) Bahuda[i] = new List<Huda>();
        SetUpManager =GetComponent<SetUpManager>();
        SetUpManager.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

