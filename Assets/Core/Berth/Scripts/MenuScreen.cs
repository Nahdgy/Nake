using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
   [SerializeField] public Animator animator;
   [SerializeField] public string levelToLoad;
    public bool canInterract = true;

    public void Fade()
    {
        canInterract= false;
        GameObject.Find("Play").GetComponent<Button>().enabled= false;
        SceneManager.LoadScene("Final");
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
