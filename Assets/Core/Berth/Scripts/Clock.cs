using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Animator Animation;
    [SerializeField] bool trente = false, quinze = false;
    public GameObject little, big;
    // Start is called before the first frame update
    void Start()
    {
        Animation = GetComponent<Animator>();
        Animation.speed = 0;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.T))
       {
                Animation.speed = 1;
       } else if (Input.GetKeyUp(KeyCode.T))
       {
            Animation.speed = 0;
       }
        Validation();
    }

    private void OnTriggerEnter(Collider other)
    {
       // if (other.little.CompareTag ("Quinze"))
        {
            Debug.Log("collide 15");
            quinze = true;
        }
        if (other.gameObject.CompareTag("Trente"))
        {
            Debug.Log("collide 30");
            trente = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Quinze"))
        {
            Debug.Log("out 15");
            quinze = false;
        }
        if (other.gameObject.CompareTag("Trente"))
        {
            Debug.Log("out 30");
            trente = false;
        }

    }
    private void Validation()
    {
        if(quinze == true && trente == true) 
        {
            Debug.Log("Good");
        }
    }
}
