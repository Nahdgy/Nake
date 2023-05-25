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
    public PlayerMov PlayerMov;
    public float t = 100f;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver= false;
        slider.maxValue = t;
        slider.value = t;
    }

    // Update is called once per frame

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
