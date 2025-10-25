using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahudaPosition : MonoBehaviour
{
    private LineRenderer lineRenderer;

    //�傫������l(>1.0)�ɂ���Ƙc�ɂȂ�
    float width = 0.15f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3 pos = transform.position;
        Renderer renderer = GetComponent<Renderer>();
        //Vector3 scale = renderer.bounds.extents;
        Vector3 scale = transform.localScale;

        // ���_�̐���ݒ�
        lineRenderer.positionCount = 4;

        // ���_�̍��W��ݒ�
        Vector3[] corners = new Vector3[4];
        corners[0] = pos + new Vector3(-scale.x / 2, -scale.y / 2, 0); // ����
        corners[1] = pos + new Vector3(scale.x / 2, -scale.y / 2, 0);  // �E��
        corners[2] = pos + new Vector3(scale.x / 2, scale.y / 2, 0);   // �E��
        corners[3] = pos + new Vector3(-scale.x / 2, scale.y / 2, 0);  // ����
        lineRenderer.SetPositions(corners);
        //Debug.Log(corners[1]);
        //Debug.Log(pos);

        // ���[�v��L���ɂ��Ďl�p�`�����
        lineRenderer.loop = true;

        // ���̑�����ݒ�
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
