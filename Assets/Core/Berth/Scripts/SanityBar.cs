using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;
    [SerializeField] private int health; 
    public float t = 10f;
    private bool gameOver;
    public bool pauseOn;

    void Start()
    {
        gameOver= false;
        slider.maxValue = t;
        slider.value = t;
    }

    private void Update()
    {
        Timer();
    }
    public void Timer()
    {
    
      float time = t - Time.time;
        
            if (time <= 0)
            {
                gameOver = true;
                SceneManager.LoadScene ("GameOver");
            }

            if(gameOver == false)
            {
                slider.value = time;
            }
    }
}
