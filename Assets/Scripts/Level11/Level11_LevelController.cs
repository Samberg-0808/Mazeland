using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level11_LevelController : MonoBehaviour
{
    public GameObject nextLevelMenu;

    private void OnEnable() {
        DestroyOnCollision_lv11.NextLevel += EnableNextLevelMenu;
    }

    private void OnDisable() {
       DestroyOnCollision_lv11.NextLevel -= EnableNextLevelMenu;
    }

    public void EnableNextLevelMenu()
    {
        Time.timeScale = 0;
        nextLevelMenu.SetActive(true);
    }

    public void StartNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
        Time.timeScale = 1;  
    }

    public void SelectLevelScene(){
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
    }

    public void StartTutorial(){
    SceneManager.LoadScene("Tutorial");
    Time.timeScale = 1;
    }
}
