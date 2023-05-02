using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int health;
    public float maxHealth = 100f;
    public float minHealth = 0F;
    public PlayerMov PlayerMov;
    public float t;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver= false;
        slider.maxValue = t;
        slider.value = t;
    }

    // Update is called once per frame
    void Update()
    {
        float time = t - Time.time;
        int minutes = Mathf.FloorToInt(time/60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);   

        if (time <= 0)
        {
            gameOver = true;
        }

        if(gameOver == false)
        {
            slider.value = time;
        } 
    }
    /*void MaxHealth(int health)
    {
       slider.maxValue = health;
        slider.value = health;

        gradient.Evaluate(1f);
    }*/

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
