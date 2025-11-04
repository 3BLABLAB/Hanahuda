using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huda : MonoBehaviour
{
    private Image image;
    private SpriteRenderer SpriteRenderer;
    private Sprite[] HudaSprites;
    // { get; private set; } は、このクラスの外部からは変更できないが、参照はできるという意味
    public int Tsuki { get; private set; }
    public int Order { get; private set; }
    private void Awake()
    {
        //image = GetComponent<Image>();
        SpriteRenderer = GetComponent<SpriteRenderer>();    
    }
    public void Initialize(int Tsuki, int Order, Sprite[] spritesArray)
    {
        this.Tsuki = Tsuki;
        this.Order = Order;
        this.HudaSprites = spritesArray;
        Visualise();
    }

    public void Visualise()
    {
        int index = 4 * this.Tsuki + this.Order;
        Debug.Log(index);
        if (SpriteRenderer != null && HudaSprites != null && index >= 0 && index < HudaSprites.Length)
        {
            this.SpriteRenderer.sprite = HudaSprites[index];
        }
        else
        {
            // エラーの詳細をログに出す
            if (SpriteRenderer == null) Debug.LogError("SpriteRenderer が null です。");
            if (HudaSprites == null) Debug.LogError("HudaSprites 配列が null です。");
            if (index < 0 || index >= HudaSprites.Length) Debug.LogError($"インデックス {index} が配列の範囲外です (Size: {HudaSprites.Length})。");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
