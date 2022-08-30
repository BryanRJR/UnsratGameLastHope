using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
