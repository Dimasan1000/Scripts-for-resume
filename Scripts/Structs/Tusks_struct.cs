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
    public Sprite _icon;//������
    public float value;
    public float _parametrValue;//������� ����� �������.
    public string _description1;//��������1
    public string _description2;//��������2
    public string _reward;//�������
    public bool _compleate;//�������� �������
    public bool _took;// ������ �������
    public string _enumT;
    public string _enumCur;
    public Vector2 _pos;

}