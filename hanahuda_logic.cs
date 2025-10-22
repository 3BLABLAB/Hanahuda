using System;
bool[,] A_Mochihuda[12,4], B_Mochihuda[12,4], Bahuda_Appeared[12,4];
Huda[]  A_Tehuda[8], B_Tehuda[8];
//場札：最大12箇所、それぞれ重複の可能性あり
List<Huda>[] Bahuda = new List<Huda>[12];
//場札に札を追加する処理
//month=card.Tsuki 
//baHuda[month].Add(card)
//x月の札が何枚あるか
//List<Huda> targetList=baHuda[month]
//targetList.Count
//1月の場札を取る
//baHuda[0].Clear()

public class Huda{
    public int Tsuki;
    public int Order;
} 

int main (){
    return 0;
}

//場札を取得可能か
//左上から右上、右下、左下
List<bool>[12] Check_Obtainable(bool Is_A=true){
    List<bool>[12] Obtainable=new List<bool>[12];
    foreach(Huda[] Index_Bahuda in Bahuda){
        int tmp=Index_Bahuda[0].Tsuki;
        for(int i=0;i<4;i++){
            //取得可能か
            if(Is_A){
                if(A_Tehuda[tmp][i]){
                    Obtainable[i]=true;
                    break;
                }
            }
            else{
                if(B_Tehuda[tmp][i]){
                    Obtainable[i]=true;
                    break;
                }
            }
            
        }
    }
    return Obtainable;
}

int Yamahuda_Draw_Check(){
    int t=0;
    foreach(List<Huda> MonthList in Bahuda){
        if(MonthList.Count()) t++;
    }
    return t;
}
//山札から一枚場札に追加
void Yamahuda_Draw(bool Is_A=true){
    while(Yamahuda_Draw_Check() < 8) {
        Random ran= new Random();
        //1月-12月　各4枚
        int New_Bahuda_num,mo,or;
        do{
            New_Bahuda_num=ran.Next(0,48);//0-47
            mo=New_Bahuda/4;
            or=New_Bahuda%4;
        }while(Bahuda_Appeared[mo,or])

        //山札を一枚引く動作


        //場札に登録
        Huda New_Bahuda=new Huda {mo,or};
        Bahuda[mo].Add(New_Bahuda);
        //出現済み
        Bahuda_Appeared[mo,or]=true;
    }
    return;
}
    

//場札から取る
void Bahuda_Draw(bool Is_A=true, int Bahuda_Index, Huda Pair_Tehuda){
    Huda[] New_Mochihuda_Index = Bahuda[Bahuda_Index];
    if(Is_A){
        foreach(Huda New_Mochihuda in New_Mochihuda_Index){
            A_Mochihuda[New_Mochihuda.Tsuki,New_Mochihuda.Order]=true;
        }
        Bahuda[Bahuda_Index].Clear();
        A_Mochihuda[Pair_Tehuda.Tsuki, Pair_Tehuda.Order]=true;
        int index=A_Tehuda.IndexOf(Pair_Tehuda);
        if(index != -1)A_Tehuda[index]=null;
    }
}