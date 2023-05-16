using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] Animator Animation;
    

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Time"))
        {

        }
    }

}
