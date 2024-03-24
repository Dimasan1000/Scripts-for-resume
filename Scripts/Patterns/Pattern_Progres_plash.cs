using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pattern_Progres_plash : MonoBehaviour
{
    public Counter count;
    public Create_Tasks_Progress _sortProgress;
    public Scrollbar _valProgres;
    public float _parametrValue;//сколько нужно набрать.
    public float val;
    public TextMeshProUGUI _description;//описание
    public TextMeshProUGUI _reward;//награда
    public Image _icon;//иконка
    public Image _imageCurency;
    public bool _compleate;//выполнил задание
    public bool _took;// забрал награду
    public string _enumP;
    public string _enumCur;
    public int Reward; //награда.

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
