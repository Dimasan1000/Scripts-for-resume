using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_Progres_plash : MonoBehaviour
{
    public Counter count;
    public Create_Tasks_Progress _sortProgress;
    public Scrollbar _valProgres;
    public float _parametrValue;//������� ����� �������.
    public float val;
    public TextMeshProUGUI _description;//��������
    public TextMeshProUGUI _reward;//�������
    public Image _icon;//������
    public Image _imageCurency;
    public bool _compleate;//�������� �������
    public bool _took;// ������ �������
    public string _enumP;
    public string _enumCur;
    public int Reward; //�������.

    public void GetReward()
    {
        AppMetrika_Metods.ClicButtonTascksAndProgr(_description.text);
        _took = true;
        switch (_enumCur)
        {
            case "Coins":
                count._countCoin += Reward;
                count._coinsToMenu.text = count._coins.text = count._countCoin.ToString();
                break;
            case "Cristal":
                count._countCristal += Reward;
                count._cristalMenu.text=count._countCristal.ToString();
                break;
        }
        _sortProgress.SortProgress();
    }
}
