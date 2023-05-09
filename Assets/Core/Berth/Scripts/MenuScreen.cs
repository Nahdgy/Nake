
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    
    public void Fade()
    {
       FadeToLevel(1);
        Debug.Log("fade");
    }

    public Animator animator;
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("left");
        Application.Quit();
    }
}
