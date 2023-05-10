using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Failed : MonoBehaviour
{
    public Animator animator;
    private float timer = 10f;
    private int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {

    }

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
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void fadeToNextLev()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
