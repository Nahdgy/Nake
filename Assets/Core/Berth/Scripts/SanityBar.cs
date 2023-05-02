using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image[] fill;
    public int health;
    public int maxHealth;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // health = characterInteraction.Health;
      //  maxHealth = characterInteraction.maxHealth;

        for (int i = 0; i < fill.Length; i++)
        {
            if (i < maxHealth)
            {
                fill[i].enabled = true;
            }
            else
            {
                fill[i].enabled = false;
            }
        }
    }

    void MaxHealth(int health)
    {
       slider.maxValue = health;
        slider.value = health;

        gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        //fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
