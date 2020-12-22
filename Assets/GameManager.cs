using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsPaused = false;
    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (GameIsPaused && Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }
}
