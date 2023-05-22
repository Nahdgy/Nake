
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
   [SerializeField] public Animator animator;
   [SerializeField] public string levelToLoad;
    private float timer = 5f;
    public bool canInterract = true;
    [SerializeField] AnimationBehavior animBehavior;

    private void Start()
    {
        inIt();
    }

    public void inIt()
    {
        animBehavior.FadeIn();
    }
    public void Fade()
    {
        canInterract= false;
        Timer();
        Debug.Log("fade");
        GameObject.Find("Play").GetComponent<Button>().enabled= false;
    }

    public void Timer()
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

    public void Quit()
    {
        Debug.Log("left");
        Application.Quit();
    }
}
