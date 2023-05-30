using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fioles : MonoBehaviour
{

    [SerializeField] int[] Flasks = { 0, 1, 2, 3};

    private void Update()
    {
        CheckOrder();
    }

    private void CheckOrder()
    {
        for (int i = 0; i < Flasks.Length; ++i)
        {
            if (Flasks[i] != 0) return;
            if (Flasks[i] != 1) return;
            if (Flasks[i] != 2) return;
            if (Flasks[i] != 3) return;
        }
    }

}
