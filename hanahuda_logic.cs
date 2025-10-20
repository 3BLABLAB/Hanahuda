using System;
bool[,] A_Mochihuda[12,4], B_Mochihuda[12,4], Bahuda_Appeared[12,4];
Huda[] Bahuda[8], A_Tehuda[8], B_Tehuda;

public class Huda{
    public int Tsuki;
    public int Order;
} 

int main (){
    return 0;
}

//場札を取得可能か
//左上から右上、右下、左下
bool[8] Check_Obtainable(bool Is_A=true){
    bool[8] Obtainable=new bool[8];
    foreach(Huda index in Bahuda){
        int tmp=index.Tsuki;
        for(int i=0;i<4;i++){
            //取得可能か
            if(Is_A){
                if(A_Tehuda[tmp][i]){
                    Obtainable[i]=true;
                }
            }
            else{
                if(B_Tehuda[tmp][i]){
                    Obtainable[i]=true;
                }
            }
            
        }
    }
    return Obtainable;
}

//山札から一枚場札に追加
void Yamahuda_Draw(bool Is_A=true, int Bahuda_Index){
    Random ran= new Random();
    //1月-12月　各4枚
    int New_Bahuda,mo,or;
    do{
        New_Bahuda=ran.Next(0,48);//0-47
        mo=New_Bahuda/4;
        or=New_Bahuda%4;
    }while(Bahuda_Appeared[mo,or])

    //山札を一枚引く動作


    //場札に登録
    Bahuda[Bahuda_Index].Tshuki=mo;
    Bahuda[Bahuda_Index].Order=or;
    //出現済み
    Bahuda_Appeared[mo,or]=true;
}

//場札を取る
void Bahuda_Draw(bool Is_A=true, int Bahuda_Index, Huda Pair_Tehuda){
    Huda New_Mochihuda = Bahuda[Bahuda_Index];
    if(Is_A){
        A_Mochihuda[New_Mochihuda.Tsuki,New_Mochihuda.Order]=true;
        A_Mochihuda[Pair_Tehuda.Tsuki, Pair_Tehuda.Order]=true;
        int index=A_Tehuda.IndexOf(Pair_Tehuda);
        if(index != -1)A_Tehuda[index]=null;
    }
}