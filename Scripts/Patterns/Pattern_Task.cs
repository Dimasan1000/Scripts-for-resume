using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_Task : MonoBehaviour
{
    public Counter count;
    public Create_Tasks_Progress _sortTask;
    public Scrollbar _valtask;
    public Image _icon;//������
    public Image _imageCurency;
    public float val;
    public float _parametrValue;//������� ����� �������.
    public TextMeshProUGUI _description;//��������
    public TextMeshProUGUI _reward;//�������
    public bool _compleate;//�������� �������
    public bool _took;// ������ �������
    public string _enumT;
    public string _enumCur;
    public int Reward; //�������.

    public void GetReward()
    {
        AppMetrika_Metods.ClicButtonTascksAndProgr(_description.text);
        _took=true;
        switch (_enumCur)
        {
            case "Coins":
                count._countCoin += Reward;
                count._coinsToMenu.text = count._coins.text = count._countCoin.ToString();
                break;
            case "Cristal":
                count._countCristal += Reward;
                count._cristalMenu.text = count._countCristal.ToString();
                break;
        }
        _sortTask.SortTasks();
    }

}
