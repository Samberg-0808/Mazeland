using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level8_UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverMenu; 

    private void OnEnable() {
        DestroyOnCollision_lv8.OnPlayerScore += EnableGameOverMenu;
    }

    private void OnDisable() {
        DestroyOnCollision_lv8.OnPlayerScore -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void ReloadMainScene(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}