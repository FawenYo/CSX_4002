using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
