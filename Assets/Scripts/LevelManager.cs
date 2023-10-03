using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void Start()
    {
        Screen.SetResolution(500, 800, FullScreenMode.Windowed);
        //SceneManager.LoadScene("Menu");
    }
    public void playGame()
    {
        SceneManager.LoadScene("Level_1");

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void goBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void levelSelect()
    {
        SceneManager.LoadScene("Level_Select");
    }

    public void selectLevelIndex(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
