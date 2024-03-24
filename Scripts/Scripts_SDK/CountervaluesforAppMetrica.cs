using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountervaluesforAppMetrica : MonoBehaviour
{
    public int _countHits;
    public int _countRewive;
    public int _countDoubleBuster;

    public void CounterforAppMetrica(int count)
    {
        switch (count)
        {
            case 0:
                _countHits++;
                break;
            case 1:
                _countRewive++;
                break;
            case 2:
                _countDoubleBuster++;
                break;
        }
    } 



}
