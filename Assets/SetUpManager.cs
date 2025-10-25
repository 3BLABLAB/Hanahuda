using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpManager : MonoBehaviour
{
    // 1. �C���X�y�N�^���琶���������v���n�u��ݒ�
    [Header("��������v���n�u")]
    public GameObject TehudaPrefab;
    public GameObject BahudaPrefab;//TODO

    // 2. �C���X�y�N�^������W�E��]�E�T�C�Y���w��
    [Header("�g�����X�t�H�[���ݒ�")]
    public Vector3[] spawnPositionsOfA = new Vector3[8];
    public Vector3[] spawnPositionsOfB = new Vector3[8];
    public Vector3[] spawnPositionsOfBahuda = new Vector3[12];

    // (X, Y, Z) �̊p�x�i�I�C���[�p�j�Ŏw��
    public Vector3 spawnRotation = new Vector3(0, 0, 0);

    //�X�P�[��
    //�C���X�y�N�^�[�̒l���D�悳���
    public Vector3 TehudaSpawnScale = new Vector3(1, 1, 1);
    public Vector3 BahudaSpawnScale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        // �v���n�u���ݒ肳��Ă��邩�m�F
        if (TehudaPrefab == null )
        {
            Debug.LogError("Object Prefab ���ݒ肳��Ă��܂���I");
            return;
        }

        //��D��\��
        foreach (Vector3 pos in spawnPositionsOfBahuda)
        {
            // 1. ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            //    Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            GameObject newObject = Instantiate(
                BahudaPrefab,
                pos,
                Quaternion.Euler(spawnRotation)
            );

            // 2. ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = BahudaSpawnScale;
        }
        //A�̎�D��\��
        for (int i=0;i<8;i++)
        {
            spawnPositionsOfA[i] =new Vector3 (
                -4f + (1.2f * i),-7.0f,0.0f
            );
            // 1. ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            //    Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfA[i],
                Quaternion.Euler(spawnRotation)
            );

            // 2. ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = TehudaSpawnScale;
        }
        //B�̎�D��\��
        for (int i = 0; i < 8; i++)
        {
            spawnPositionsOfB[i] = new Vector3(
                -4f + (1.2f * i), 7.0f, 0.0f
            );
            // 1. ���W�Ɖ�]���w�肵�ăI�u�W�F�N�g�𐶐�
            //    Vector3 �̉�]�i�I�C���[�p�j�� Quaternion �ɕϊ�
            GameObject newObject = Instantiate(
                TehudaPrefab,
                spawnPositionsOfB[i],
                Quaternion.Euler(spawnRotation)
            );

            // 2. ���������I�u�W�F�N�g�̃T�C�Y�i�X�P�[���j���w��
            newObject.transform.localScale = TehudaSpawnScale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
