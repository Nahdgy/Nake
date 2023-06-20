using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaudron : MonoBehaviour
{
    [SerializeField] private bool FioleOne, FioleTwo, FioleThree, FioleFour;
    [SerializeField] GameObject fou;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Fiole1")
        {
            FioleOne = true;
            Destroy(collision.gameObject);
        }
     
        if (collision.gameObject.name == "Fiole2" && FioleOne == true)
        { 
            FioleTwo = true;
            Destroy(collision.gameObject);
        } 
    
        if (collision.gameObject.name == "Fiole3" && FioleTwo == true)
        {
            FioleThree = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Fiole4" && FioleThree == true)
        {
            FioleFour = true;
            Destroy(collision.gameObject);
        }
    }

    private void Resolved()
    {
        if (FioleOne == true &&  FioleTwo == true && FioleThree == true && FioleFour == true) 
        {
           fou.SetActive(true);
        }
    }

    private void Update()
    {
        Resolved();
    }
}
