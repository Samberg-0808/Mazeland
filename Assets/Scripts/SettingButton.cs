using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public bool Paused = false;
    public GameObject PauseCanvas;
    //button color 78CEFF
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Unpause()
    {
        Time.timeScale = 1;
        Paused = false;
        PauseCanvas.SetActive(false);
    }


    public void Pause()
    {
        Time.timeScale = 0;
        Paused = true;
        PauseCanvas.SetActive(true);
    }

    public void MuteButton()
    {

    }

    public void MenuButton()
    {
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
