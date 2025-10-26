using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huda : MonoBehaviour
{

    private MainSceneManager mainSceneManager;
    // { get; private set; } は、このクラスの外部からは変更できないが、参照はできるという意味
    public int Tsuki { get; private set; }
    public int Order { get; private set; }
    private bool[,] Bahuda_Appeared = new bool[12, 4];
    public void Initialize(int Tsuki, int Order)
    {
        this.Tsuki = Tsuki;
        this.Order = Order;
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
