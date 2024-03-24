using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateSegments : MonoBehaviour
{
    [SerializeField] private Counter _oxygen;
    [SerializeField] private LerpBoosters _culbits;
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private GameObject _tube;
    Queue<GameObject> _segmentsQueue = new Queue<GameObject>();
    private int _pos = 0;
    [SerializeField] private Vector3 temp;
    public Create_Coins_Ox_Health _craateSegm;
    public bool _flagCreate = false;


    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            _segmentsQueue.Enqueue(_craateSegm.CreatePines(_tube, temp));
            temp.z += 20;
        }
    }

    void Update()
    {
        if (_craateSegm._coutCreatePines < _craateSegm._collections._pine.Count-1)
        {
            if (_craateSegm._collections._pine[_craateSegm._coutCreatePines].Distanse < _playerBody.transform.position.z)
            {
                _craateSegm._coutCreatePines++;
            }
        }
        if (_pos != Convert.ToInt32(_playerBody.transform.position.z))
        {
            _pos = Convert.ToInt32(_playerBody.transform.position.z);
            _oxygen.OxigenReduction(_pos + 10);
            if (_pos % 20 == 0)
            {
                _culbits.OnButtonCulbit();
            }

            if (_pos != 0 && _pos % 20 > 0 && _pos % 20 < 5 && _flagCreate == false)
            {
                _segmentsQueue.Enqueue(_craateSegm.CreatePines(_tube, temp));
                temp.z += 20;
                _flagCreate = true;
            }
            if (_pos != 0 && _pos % 20 > 6 && _flagCreate == true)
            {
                _flagCreate = false;
            }
        }
        if (_playerBody.transform.position.z - _segmentsQueue.Peek().transform.position.z > 40)
        {

            GameObject destroy = _segmentsQueue.Dequeue();
            Destroy(destroy);
        }
    }
}
