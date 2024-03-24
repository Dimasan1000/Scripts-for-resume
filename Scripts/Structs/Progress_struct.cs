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
    public Sprite _icon;//������
    public float _parametrValue;//������� ����� �������.
    public float value;
    public string _description1;//��������1
    public string _description2;//��������2
    public string _reward;//�������
    public bool _compleate;//�������� �������
    public bool _took;// ������ �������
    public string _enumP;
    public string _enumCur;
    public Vector2 _pos;
}
