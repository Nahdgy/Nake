using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Failed : MonoBehaviour
{
    public Animator animator;
    private float timer = 15f;
    private AnimationBehavior AnimationBehavior;

    private void Start()
    {
        AnimationBehavior.Failed();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            FadeToLevel(1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        AnimationBehavior.FadeIn();
    }
}
