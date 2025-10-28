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
    [SerializeField]SetUpManager SetUpManager;
    [SerializeField]Role_Check Role_Check;
    //�ԎD�̃J�[�h���`
    //���Ԃ�https://hanafudazukan.hatenablog.com/���Q��
    //������9��(�e)�͐Z�Ƌe�����ւ���
    public bool[,] Bahuda_Appeared = new bool[12, 4];
    public bool[,] A_Mochihuda =new bool[12, 4], B_Mochihuda=new bool [12, 4];
    //��D�F12�������A�d���̉\������
    //�ꂩ����������List
    public List<Huda>[] Bahuda=new List<Huda>[12];
    public Huda[] A_Tehuda = new Huda[8];
    public Huda[] B_Tehuda = new Huda[8];
    public bool Is_A = true;
    public List<string> Roles = new List<string>{};
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//�t���[�����[�g��60�ɌŒ�
        //��D��������
        for (int i = 0; i < Bahuda.Length; i++) Bahuda[i] = new List<Huda>();
        //SetUpManager =GetComponent<SetUpManager>();
        SetUpManager.SetUp();
    }

    // Update is called once per frame
    void Update()
    {
        Roles = Role_Check.CheckALLRoles();
    }

}

