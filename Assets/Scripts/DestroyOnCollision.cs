using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame updat

    public PlayerControl script;
    public Text MyscoreText;

    public Text Timer;
    private int ScoreNum;

    public float TimeLeft;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum; 
    }

    void Update() {
        if (TimeLeft > 0){
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Circle") {

            if (collision.gameObject.name == "Circle1(Clone)") {
                ScoreNum +=1;
            }
            else if (collision.gameObject.name == "Circle2(Clone)") {
                ScoreNum +=5;
            }
            else if (collision.gameObject.name == "Circle3(Clone)") {
                ScoreNum +=10;
            }
            else if (collision.gameObject.name == "Circle4(Clone)") {
                ScoreNum +=20;
            }
            else if (collision.gameObject.name == "Circle5(Clone)") {
                ScoreNum +=50;
            }
            Destroy(collision.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
        if (collision.gameObject.tag == "Bonus") {
            Destroy(collision.gameObject);
            script.movementSpeed *=2;
        }
    }

    void updateTimer(float currentTime) {
        currentTime +=1;

        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
