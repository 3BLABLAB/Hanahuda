using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class Main : MonoBehaviour
{
    //花札のカードを定義
    //順番はhttps://hanafudazukan.hatenablog.com/を参照
    private bool[,] Bahuda = new bool[12, 4];
    private bool[,] A_Tehuda = new bool[12, 4];
    private bool[,] B_Tehuda = new bool[12, 4];

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレームレートを60に固定
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<string> Role_Check(bool Is_A=true)
    {
        //成立した役がappendされる配列
        List<string> Roles=new List<string> { };
        Roles.Add(Goko(Is_A));
        Roles.Add(HanamiDeIppai(Is_A));
        Roles.Add(TsukimiDeIppai(Is_A));
        Roles.Add(Inoshikacho(Is_A));
        Roles.Add(Akatan(Is_A));
        Roles.Add(Aotan(Is_A));
        Roles.Add(Tane(Is_A));
        Roles.Add(Tan(Is_A));
        Roles.Add(Kasu(Is_A));
        return Roles;
    }

    //五光、四光、三光をチェックする(排他)
    private string Goko(bool Is_A = true)
    {
        int count = 0;

        if (Is_A)
        {
            if (A_Tehuda[0, 0]) count++;
            if (A_Tehuda[2, 0]) count++;
            if (A_Tehuda[7, 0]) count++;
            if (A_Tehuda[11, 0]) count++;
            if (count == 3) return "Sanko";
            else if (count == 4)
            {
                if (A_Tehuda[10, 0]) return "Ameshiko";
                else return "Shiko";
            }
            else if (count == 5) return "Goko";
        }
        else
        {
            if (B_Tehuda[0, 0]) count++;
            if (B_Tehuda[2, 0]) count++;
            if (B_Tehuda[7, 0]) count++;
            if (B_Tehuda[11, 0]) count++;
            if (count == 3) return "Sanko";
            else if (count == 4)
            {
                if (B_Tehuda[10, 0]) return "Ameshiko";
                else return "Shiko";
            }
            else if (count == 5) return "Goko";
        }
        return "";
    }
    private string HanamiDeIppai(bool Is_A = true)
    {
        if (Is_A)
        {
            if (A_Tehuda[2,0] && A_Tehuda[7, 1])
            {
                return "HanamiDeIppai";
            }
        }
        else
        {
            if (B_Tehuda[2,0] && B_Tehuda[7, 1])
            {
                return "HanamiDeIppai";
            }
        }
        return "";
    }
    private string TsukimiDeIppai(bool Is_A = true)
    {
        if (Is_A)
        {
            if (A_Tehuda[7, 0] && A_Tehuda[8, 1])
            {
                return "TsukimiDeIppai";
            }
        }
        else
        {
            if (B_Tehuda[7, 0] && B_Tehuda[8, 1])
            {
                return "TsukimiDeIppai";
            }
        }
        return "";
    }

}

