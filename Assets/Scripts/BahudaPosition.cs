using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BahudaPosition : MonoBehaviour
{
    private LineRenderer lineRenderer;

    //大きすぎる値(>1.0)にすると歪になる
    float width = 0.15f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Vector3 pos = transform.position;
        Renderer renderer = GetComponent<Renderer>();
        //Vector3 scale = renderer.bounds.extents;
        Vector3 scale = transform.localScale;

        // 頂点の数を設定
        lineRenderer.positionCount = 4;

        // 頂点の座標を設定
        Vector3[] corners = new Vector3[4];
        corners[0] = pos + new Vector3(-scale.x / 2, -scale.y / 2, 0); // 左下
        corners[1] = pos + new Vector3(scale.x / 2, -scale.y / 2, 0);  // 右下
        corners[2] = pos + new Vector3(scale.x / 2, scale.y / 2, 0);   // 右上
        corners[3] = pos + new Vector3(-scale.x / 2, scale.y / 2, 0);  // 左上
        lineRenderer.SetPositions(corners);
        //Debug.Log(corners[1]);
        //Debug.Log(pos);

        // ループを有効にして四角形を閉じる
        lineRenderer.loop = true;

        // 線の太さを設定
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }
}
