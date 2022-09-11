using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text MyscoreText;

    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum; 
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Circle") {
            Destroy(collision.gameObject);
        }
        // if (collision.gameObject.tag == "Bonus") {
        //     Destroy(collision.gameObject);
        //     script.movementSpeed *=2;
        // }
    }
    // Update is called once per frame
}
