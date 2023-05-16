using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Animator Animation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void turnClockHand()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Animation.StopPlayback();
        } else if (Input.GetKeyUp(KeyCode.T))
        {
            //Animation.Stop();
        }
    }
}
