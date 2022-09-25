using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverMenu; 

    private void OnEnable() {
        DestroyOnCollision.OnPlayerScore += EnableGameOverMenu;
    }

    private void OnDisable() {
        DestroyOnCollision.OnPlayerScore -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu() {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
