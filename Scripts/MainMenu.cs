using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Levels;
    public GameObject Menu;

    public void StartGame(int id) {
        SceneManager.LoadScene(id);
    }

    public void ShowLevels() {
        Menu.SetActive(false);
        Levels.SetActive(true);
    }

    public void BackToMainMenu() {
        Levels.SetActive(false);
        Menu.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
