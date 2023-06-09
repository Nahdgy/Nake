using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fioles : MonoBehaviour
{

    [SerializeField] GameObject[] Flasks;

    private void Update()
    {
        CheckOrder();
    }

    private void CheckOrder()
    {
        for (int i = 0; i < Flasks.Length; ++i)
        {
            if (i != 0) return;
            if (i != 1) return;
            if (i != 2) return;
            if (i != 3) return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckOrder();
    }

}
