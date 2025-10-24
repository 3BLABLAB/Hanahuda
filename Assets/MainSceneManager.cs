using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class MainSceneManager : MonoBehaviour
{
    //�ԎD�̃J�[�h���`
    //���Ԃ�https://hanafudazukan.hatenablog.com/���Q��
    //������9��(�e)�͐Z�Ƌe�����ւ���
    private bool[,] Bahuda_Appeared = new bool[12, 4];
    public bool[,] A_Mochihuda =new bool[12, 4], B_Mochihuda=new bool [12, 4];
    //��D�F12�������A�d���̉\������
    //�ꂩ����������List
    List<List <Huda>>[] Bahuda=new List<List<Huda>>[12];
    private List<Huda>[] A_Tehuda = new List<Huda>[8];
    private List<Huda>[] B_Tehuda = new List<Huda>[8];

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɌŒ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<string> Role_Check(bool Is_A=true)
    {
        //������������append�����z��
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
    //�܌��A�l���A�O�����`�F�b�N����(�r��)
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
            if (A_Mochihuda[2, 0] && A_Mochihuda[8, 1])
            {
                return "HanamiDeIppai";
            }
        }
        else
        {
            if (B_Mochihuda[2, 0] && B_Mochihuda[8, 1])
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
            if (A_Mochihuda[5, 0] && A_Mochihuda[6, 0] && A_Mochihuda[9, 0])
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

    private string Tan(bool Is_A)
    {
        int count = 0;
        if (Is_A)
        {
            if (A_Mochihuda[0, 1]) count++;
            if (A_Mochihuda[1, 1]) count++;
            if (A_Mochihuda[2, 1]) count++;
            if (A_Mochihuda[3, 1]) count++;
            if (A_Mochihuda[4, 1]) count++;
            if (A_Mochihuda[5, 1]) count++;
            if (A_Mochihuda[6, 1]) count++;
            if (A_Mochihuda[8, 1]) count++;
            if (A_Mochihuda[9, 1]) count++;
            if (A_Mochihuda[10, 2]) count++;
            if (count >= 5)
            {
                return "Tan" + (char)(count - 4);
            }
        }
        else
        {
            if (B_Mochihuda[0, 1]) count++;
            if (B_Mochihuda[1, 1]) count++;
            if (B_Mochihuda[2, 1]) count++;
            if (B_Mochihuda[3, 1]) count++;
            if (B_Mochihuda[4, 1]) count++;
            if (B_Mochihuda[5, 1]) count++;
            if (B_Mochihuda[6, 1]) count++;
            if (B_Mochihuda[8, 1]) count++;
            if (B_Mochihuda[9, 1]) count++;
            if (B_Mochihuda[10, 2]) count++;
            if (count >= 5)
            {
                return "Tan" + (char)(count - 4);
            }
        }
        return "";
    }
    private string Kasu(bool Is_A)
    {
        int count = 0;
        if (Is_A)
        {
            for (int i = 0; i < 10; i++)
            {
                //1-10���܂ł̓J�X�̈ʒu������
                for (int j = 2; j < 4; j++)
                {
                    if (A_Mochihuda[i, j]) count++;
                }
            }
            if (A_Mochihuda[10, 3]) count++;
            //12��
            for (int j = 1; j < 4; j++)
            {
                if (A_Mochihuda[11, j]) count++;
            }
            if (count >= 10)
            {
                return "Kasu" + (char)(count - 9);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                //1-10���܂ł̓J�X�̈ʒu������
                for (int j = 2; j < 4; j++)
                {
                    if (B_Mochihuda[i, j]) count++;
                }
            }
            if (B_Mochihuda[10, 3]) count++;
            //12��
            for (int j = 1; j < 4; j++)
            {
                if (B_Mochihuda[11, j]) count++;
            }
            if (count >= 10)
            {
                return "Kasu" + (char)(count - 9);
            }
        }
        return "";
    }

}

