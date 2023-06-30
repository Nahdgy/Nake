using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fill;
    [SerializeField] private int health;
    [SerializeField] private GameObject dizzy;
    public float t = 120f;
    private bool gameOver;
    public bool startCounting = false;

    void Start()
    {
       gameOver = false;
       slider.value = 120f;
    }

    private void Update()
    {
        Timer();
        GettingDizzy();
    }
    public void Timer()
    {
        if (startCounting == true)
        {
            float time = t - Time.time;

            if (time <= 0)
            {
                gameOver = true;
                SceneManager.LoadScene("GameOver");
                t = 120f;
                startCounting = false;
            }

            if (gameOver == false)
            {
                slider.value = time;
            }
        }
    }

   private void OnLevelWasLoaded(int level)
    {
        if (level ==  1)
        {
            startCounting = true;   
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
