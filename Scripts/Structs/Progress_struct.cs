using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Progress_struct
{
    public StructProgress[] _strProgr;
    public float[] _pos_yPr;
}

[System.Serializable]
public struct StructProgress
{
    public Scrollbar _valtask;
    public float _valueScrollbar;
    public Sprite _icon;//иконка
    public float _parametrValue;//сколько нужно набрать.
    public float value;
    public string _description1;//описание1
    public string _description2;//описание2
    public string _reward;//награда
    public bool _compleate;//выполнил задание
    public bool _took;// забрал награду
    public string _enumP;
    public string _enumCur;
    public Vector2 _pos;
}
