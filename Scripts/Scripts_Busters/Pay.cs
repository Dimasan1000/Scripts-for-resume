using UnityEngine;

public class Pay : MonoBehaviour
{
    [SerializeField] private Seve_Parametres _reInitTasks;
    [SerializeField] private Counter _coins;
    [SerializeField] private GameObject _contentTasks;
    public void PayTasks()
    {
        if (_coins._countCoin >= 500)
        {
            for (int i = _contentTasks.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(_contentTasks.transform.GetChild(i).gameObject);
            }
            _coins._countCoin -= 500;
            _reInitTasks.LoadFromFile(true);
            _coins._coinsToMenu.text = _coins._coins.text = _coins._countCoin.ToString();
        }

    }

}
