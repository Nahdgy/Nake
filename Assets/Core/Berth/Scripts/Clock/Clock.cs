using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Animator Animation;
    [SerializeField]
    private Six six;
    [SerializeField]
    private Three three;
    
    void Start()
    {
        Animation = GetComponent<Animator>();
        Animation.speed = 0;
    }

    void Update()
    {
        ClockControl();
        Validation();
    }

    private void Validation()
    {
        if(three.IsOkSmall && six.IsOkTall && Input.GetKey(KeyCode.K)) 
        {
            Debug.Log("Good");
        }
    }

    void ClockControl()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Animation.speed = 1;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            Animation.speed = 0;
        }
    }
}