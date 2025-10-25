using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huda : MonoBehaviour
{

    private MainSceneManager mainSceneManager;
    private int Tsuki;
    private int Order;
    private bool[,] Bahuda_Appeared = new bool[12, 4];
    public int get()
    {
        int New_Huda_Num;
        int mo, or;
        do
        {
            New_Huda_Num = UnityEngine.Random.Range(0, 48);//0-47
            mo = New_Huda_Num / 4;
            or = New_Huda_Num % 4;
        } while (Bahuda_Appeared[mo, or]);
        return New_Huda_Num;
    }
    private void Awake()
    {
        mainSceneManager = GetComponent<MainSceneManager>();
        Bahuda_Appeared = mainSceneManager.Bahuda_Appeared;
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
