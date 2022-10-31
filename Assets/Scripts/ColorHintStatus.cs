using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHintStatus : MonoBehaviour
{
    GameObject[] enemy;
    
    void Start() 
    {
        enemy = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }

    public void changeStatus() {

        print("change color hint status");
        foreach (GameObject child in enemy)
        {
            if (child.gameObject.tag == "Enemy")
            {
                child.gameObject.GetComponent<EnemyStatus>().updateStatus();
            }
        }
    }
    
    
}
