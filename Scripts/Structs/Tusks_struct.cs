using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Tusks_struct
{
    public StructTusk[] StrTusk;
    public float[] _pos_yT;
}

[System.Serializable]
public struct StructTusk
{
    public Scrollbar _valtask;
    public float _valueScrollbar;
    public Sprite _icon;//иконка
    public float value;
    public float _parametrValue;//сколько нужно набрать.
    public string _description1;//описание1
    public string _description2;//описание2
    public string _reward;//награда
    public bool _compleate;//выполнил задание
    public bool _took;// забрал награду
    public string _enumT;
    public string _enumCur;
    public Vector2 _pos;

}