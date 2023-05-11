using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Failed : MonoBehaviour
{
    public Animator animator;
    private float timer = 15f;

    // Update is called once per frame
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
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
