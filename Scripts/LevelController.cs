using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject nextLevelMenu;

    private void OnEnable() {
        DestroyOnCollision.NextLevel += EnableNextLevelMenu;
    }

    private void OnDisable() {
        DestroyOnCollision.NextLevel -= EnableNextLevelMenu;
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
}
