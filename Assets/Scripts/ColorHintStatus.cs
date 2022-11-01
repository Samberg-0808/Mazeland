using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHintStatus : MonoBehaviour
{
    GameObject[] enemy;
    public Button btn;
    public Text txt;

    public void changeStatus() {

        bool status = true;
        enemy = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        print("change color hint status");
        foreach (GameObject child in enemy)
        {
            if (child.gameObject.tag == "Enemy")
            {
                child.gameObject.GetComponent<EnemyStatus>().updateStatus();
                
                // Text text = transform.Find("HintStatusOff").GetComponent<Text>(); 
                // if (status) {
                //     status = false;
                //     if (child.gameObject.GetComponent<EnemyStatus>().mutable) {
                //         text.text= "off"; 
                //     } else {
                //         text.text = "on";
                //     }
                // }
            }
        }
    }
    
    
}
