using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Failed : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }
}
