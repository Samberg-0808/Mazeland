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
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Circle2(Clone)") {
                ScoreNum +=2;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Circle3(Clone)") {
                ScoreNum +=3;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Circle4(Clone)") {
                ScoreNum +=5;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name == "Circle5(Clone)") {
                ScoreNum +=7;
                Destroy(collision.gameObject);
            }
            //Destroy(collision.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
        if (collision.gameObject.tag == "Bonus") {
            Destroy(collision.gameObject);
            script.movementSpeed += 2;
        }
        if (collision.gameObject.tag == "enamy")
        {
            if (collision.gameObject.name == "enamy 1(Clone)")
            {
                if (ScoreNum % 1 == 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    ScoreNum -= 1;
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.name == "enamy 2(Clone)")
            {
                if (ScoreNum % 2 == 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    ScoreNum -= 2;
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.name == "enamy 3(Clone)")
            {
                if (ScoreNum % 3 == 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    ScoreNum -= 3;
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.name == "enamy 5(Clone)")
            {
                if (ScoreNum % 5 == 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    ScoreNum -= 5;
                    Destroy(collision.gameObject);
                }
            }
            else if (collision.gameObject.name == "enamy 7(Clone)")
            {
                if (ScoreNum % 7 == 0)
                {
                    Destroy(collision.gameObject);
                }
                else
                {
                    ScoreNum -= 7;
                    Destroy(collision.gameObject);
                }
            }
            //Destroy(collision.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }
    }

    void updateTimer(float currentTime) {
        currentTime +=1;

        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
