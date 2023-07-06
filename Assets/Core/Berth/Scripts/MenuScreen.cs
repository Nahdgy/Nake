using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public bool canInterract = true;

    public void Fade()
    {
        canInterract = false;
        SceneManager.LoadScene("BeginingCutscene");
    }

    public void Quit()
    {
        Debug.Log("left");
        Application.Quit();
    }

}
