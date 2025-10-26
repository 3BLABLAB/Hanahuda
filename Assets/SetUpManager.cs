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

    // 1. �C���X�y�N�^���琶���������v���n�u��ݒ�
    [Header("��������v���n�u")]
    public GameObject TehudaPrefab;
    public GameObject BahudaPrefab;//TODO

    // 2. �C���X�y�N�^������W�E��]�E�T�C�Y���w��
    [Header("�g�����X�t�H�[���ݒ�")]
    private Vector3[] spawnPositionsOfTehudaA = new Vector3[8];
    private Vector3[] spawnPositionsOfTehudaB = new Vector3[8];
    public Vector3[] spawnPositionsOfBahuda = new Vector3[12];

    // (X, Y, Z) �̊p�x�i�I�C���[�p�j�Ŏw��
    public Vector3 spawnRotation = new Vector3(0, 0, 0);

    //�X�P�[��
    //�C���X�y�N�^�[�̒l���D�悳���
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
        //Awake()�ő������Ə����������\������
        Bahuda_Appeared = mainSceneManager.Bahuda_Appeared;
        Bahuda = mainSceneManager.Bahuda;
        A_Tehuda = mainSceneManager.A_Tehuda;
        B_Tehuda = mainSceneManager.B_Tehuda;
        // �v���n�u���ݒ肳��Ă��邩�m�F
        if (TehudaPrefab == null)
        {
            Debug.LogError("Object Prefab ���ݒ肳��Ă��܂���I");
            return;
        }

        //��D��ݒ�
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

            // ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(
                BahudaPrefab,
                spawnPositionsOfBahuda[mo],
                Quaternion.Euler(spawnRotation)// Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            );
            // ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = BahudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or);
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

        //A�̎�D��ݒ�
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
            // ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaA[i],
                Quaternion.Euler(spawnRotation)// Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            );
            // ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = TehudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or);
            A_Tehuda[i] = BahudaComponent;
        }
        //B�̎�D��ݒ�
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
            // ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfTehudaB[i],
                Quaternion.Euler(spawnRotation)// Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            );
            // ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = TehudaSpawnScale;

            Huda BahudaComponent = newObject.GetComponent<Huda>();
            BahudaComponent.Initialize(mo, or);
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
