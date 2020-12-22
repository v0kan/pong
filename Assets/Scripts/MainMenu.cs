using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlaySingleplayer()
    {
        SceneManager.LoadScene("VSBOT");
    }
    
    public void PlayMultiplayer()
    {
        SceneManager.LoadScene("VSPLAYER");
    }

    public void QuitGame()
    {
        Debug.Log(("QUIT!"));
        Application.Quit();
    }
}
