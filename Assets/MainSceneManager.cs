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
    public bool[,] Bahuda_Appeared = new bool[12, 4];
    public bool[,] A_Mochihuda =new bool[12, 4], B_Mochihuda=new bool [12, 4];
    //��D�F12�������A�d���̉\������
    //�ꂩ����������List
    List<List <Huda>>[] Bahuda=new List<List<Huda>>[12];
    private List<Huda>[] A_Tehuda = new List<Huda>[8];
    private List<Huda>[] B_Tehuda = new List<Huda>[8];
    public bool Is_A = true;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɌŒ�

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

