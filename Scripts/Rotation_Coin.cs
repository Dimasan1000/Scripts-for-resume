using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Coin : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1));
    }
}