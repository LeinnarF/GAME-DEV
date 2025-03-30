using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScence : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void GoToTutorial()
    {
        SceneManager.LoadScene("1. Tutorials");
    }
}
