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
    [SerializeField] private GameObject dizzy;
    public float t;
    private bool gameOver;
    PlayerCam cam;
    // public bool pauseOn;

    private void Awake()
    {
        t = 120f;
    }

    void Start()
    {
        gameOver= false;
        slider.maxValue = t;
        slider.value = t;
    }

    private void Update()
    {
        Timer();
        GettingDizzy();
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

    private void OnLevelWasLoaded(int level)
    {
        if (level ==  0)
        {
            slider.value = 120;
            slider.maxValue = 120;
        }
    }

    void GettingDizzy()
    {
        if (slider.value <= 55) 
        {
            dizzy.SetActive(true);
        } else
        {
            dizzy.SetActive (false);
        }
    }
}
