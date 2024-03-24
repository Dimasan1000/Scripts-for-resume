using UnityEngine;


[System.Serializable]
public struct Struct_Busters
{
    //постоянные бустеры.
    public int _coin_2x;
    public int _healthFour;
}
[System.Serializable]
public struct Struct_BustersLimit 
{ 
    //временные бустеры
    public int _unlimitLives;
    public int _oxyUnlimit;
}
[System.Serializable]
public struct Boosterss
{
    public Struct_Busters UnTime;
    public Struct_BustersLimit _time;
}

