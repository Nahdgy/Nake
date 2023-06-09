using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaudron : MonoBehaviour
{
    [SerializeField] private bool FioleOne, FioleTwo, FioleThree, FioleFour;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CorrectOrder()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fiole1")
        {
            FioleOne = true;
        }

        if (collision.gameObject.name == "Fiole2")
    }
}
