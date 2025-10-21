using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class Huda
{
    public int Tsuki;
    public int Order;
}
public class Main : MonoBehaviour
{
    //花札のカードを定義
    //順番はhttps://hanafudazukan.hatenablog.com/を参照
    //ただし9月(菊)は青短と菊を入れ替える
    private bool[,] Bahuda_Appeared = new bool[12, 4];
    //private bool[,] A_Tehuda = new bool[12, 4];
    //private bool[,] B_Tehuda = new bool[12, 4];
    private bool[,] A_Mochihuda =new bool[12, 4], B_Mochihuda=new bool [12, 4];
    //場札：12か月分、重複の可能性あり
    //一か月あたり一つのList
    List<Huda>[] Bahuda=new List<Huda>[12];
    private Huda[] A_Tehuda = new Huda[8];
    private Huda[] B_Tehuda = new Huda[8];

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
            if (A_Mochihuda[0, 0]) count++;
            if (A_Mochihuda[2, 0]) count++;
            if (A_Mochihuda[7, 0]) count++;
            if (A_Mochihuda[11, 0]) count++;
            if (count == 3) return "Sanko";
            else if (count == 4)
            {
                if (A_Mochihuda[10, 0]) return "Ameshiko";
                else return "Shiko";
            }
            else if (count == 5) return "Goko";
        }
        else
        {
            if (B_Mochihuda[0, 0]) count++;
            if (B_Mochihuda[2, 0]) count++;
            if (B_Mochihuda[7, 0]) count++;
            if (B_Mochihuda[11, 0]) count++;
            if (count == 3) return "Sanko";
            else if (count == 4)
            {
                if (B_Mochihuda[10, 0]) return "Ameshiko";
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
            if (A_Mochihuda[2,0] && A_Mochihuda[7, 1])
            {
                return "HanamiDeIppai";
            }
        }
        else
        {
            if (B_Mochihuda[2,0] && B_Mochihuda[7, 1])
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
            if (A_Mochihuda[7, 0] && A_Mochihuda[8, 1])
            {
                return "TsukimiDeIppai";
            }
        }
        else
        {
            if (B_Mochihuda[7, 0] && B_Mochihuda[8, 1])
            {
                return "TsukimiDeIppai";
            }
        }
        return "";
    }

    private string Inoshikacho(bool Is_A = true)
    {
        if (Is_A)
        {
            if (A_Mochihuda[5,0] && A_Mochihuda[6, 0] && A_Mochihuda[9, 0])
            {
                return "TsukimiDeIppai";
            }
        }
        else
        {
            if (B_Mochihuda[5, 0] && B_Mochihuda[6, 0] && B_Mochihuda[9, 0])
            {
                return "TsukimiDeIppai";
            }
        }
        return "";
    }

    private string Akatan(bool Is_A = true)
    {
        if (Is_A)
        {
            if (A_Mochihuda[0, 1] && A_Mochihuda[1, 1] && A_Mochihuda[2, 1])
            {
                return "Akatan";
            }
        }
        else
        {
            if (B_Mochihuda[0, 1] && B_Mochihuda[1, 1] && B_Mochihuda[2, 1])
            {
                return "Akatan";
            }
        }
        return "";
    }

    private string Aotan(bool Is_A = true)
    {
        if (Is_A)
        {
            if (A_Mochihuda[5, 1] && A_Mochihuda[8, 1] && A_Mochihuda[9, 1])
            {
                return "Aotan";
            }
        }
        else
        {
            if (B_Mochihuda[5, 1] && B_Mochihuda[8, 1] && B_Mochihuda[9, 1])
            {
                return "Aotan";
            }
        }
        return "";
    }

    private string Tane(bool Is_A)
    {
        int count = 0;
        if (Is_A)
        {
            if (A_Mochihuda[1, 0]) count++;
            if (A_Mochihuda[3, 0]) count++;
            if (A_Mochihuda[4, 0]) count++;
            if (A_Mochihuda[5, 0]) count++;
            if (A_Mochihuda[6, 0]) count++;
            if (A_Mochihuda[7, 1]) count++;
            if (A_Mochihuda[8, 1]) count++;
            if (A_Mochihuda[9, 0]) count++;
            if (A_Mochihuda[10, 1]) count++;
            if (count >= 5)
            {
                return "Tane" + (char)(count - 4);
            }
        }
        else
        {
            if (B_Mochihuda[1, 0]) count++;
            if (B_Mochihuda[3, 0]) count++;
            if (B_Mochihuda[4, 0]) count++;
            if (B_Mochihuda[5, 0]) count++;
            if (B_Mochihuda[6, 0]) count++;
            if (B_Mochihuda[7, 1]) count++;
            if (B_Mochihuda[8, 1]) count++;
            if (B_Mochihuda[9, 0]) count++;
            if (B_Mochihuda[10, 1]) count++;
            if (count >= 5)
            {
                return "Tane" + (char)(count - 4);
            }
        }
        return "";
    }
}

