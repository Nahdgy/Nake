
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            FadeToLevel(1);
        }
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

    public void Quit()
    {
        Debug.Log("left");
        Application.Quit();
    }

}
