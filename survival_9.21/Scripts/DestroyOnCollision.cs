using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DestroyOnCollision : MonoBehaviour
{
    // Start is called before the first frame updat

    public Text MyscoreText;
    public  GameObject point;
    public static event Action OnPlayerScore;
    public Text Timer;
    private int ScoreNum;

    public float TimeLeft;

    public GameObject[] enemy;

    public ProgressBar progressBar;
    public GameObject floatingpoints;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score " + ScoreNum; 
    }

    void Update() {
        if (TimeLeft > 0){
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }

        if(ScoreNum >= 50) {
            OnPlayerScore?.Invoke();
            point.SetActive(false);
        }

        progressBar.setProgressBar(ScoreNum);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        

        if (collision.gameObject.name == "Circle") {
            OnPlayerScore?.Invoke();
            point.SetActive(false);
        }
        if (ScoreNum == 0 & collision.gameObject.tag == "Enemy") {
            point.SetActive(false);
            OnPlayerScore?.Invoke();
        }

        if (collision.gameObject.tag == "Coin") {
            if (collision.gameObject.name == "coin-1(Clone)") {
                ScoreNum +=1;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+1";
            }
            else if (collision.gameObject.name == "coin-2(Clone)") {
                ScoreNum +=2;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+2";
            }
            else if (collision.gameObject.name == "coin-3(Clone)") {
                ScoreNum +=3;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+3";
            }
            else if (collision.gameObject.name == "coin-4(Clone)") {
                ScoreNum +=5;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+5";
            }
            else if (collision.gameObject.name == "coin-5(Clone)") {
                ScoreNum +=10;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+10";
            }
            Destroy(collision.gameObject);
            MyscoreText.text = "Score: " + ScoreNum;
        }

        if (collision.gameObject.name == "Enemy-1(Clone)") {
            ScoreNum +=1;
            MyscoreText.text = "Score: " + ScoreNum;
            Destroy(collision.gameObject);
            GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
            points.transform.GetComponent<TextMesh>().text = "+1";
        }

        if (collision.gameObject.name == "Enemy-2(Clone)") {
            if (ScoreNum % 2 == 0) {
                ScoreNum +=2;
                MyscoreText.text = "Score: " + ScoreNum;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+2";
            } 
            else {
                Vector3 temp = new Vector3(0f,0f,0f);
                Instantiate(enemy[(ScoreNum%2)-1], temp, transform.rotation);
                ScoreNum -= 2;
                MyscoreText.text = "Score: " + ScoreNum;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "-2";
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Enemy-3(Clone)") {
            if (ScoreNum % 3 == 0) {
                ScoreNum +=3;
                MyscoreText.text = "Score: " + ScoreNum;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+3";
            } 
            else {
                Vector3 temp = new Vector3(2f,2f,0f);
                Instantiate(enemy[(ScoreNum%3)-1], temp, transform.rotation);
                ScoreNum -= 3;
                MyscoreText.text = "Score: " + ScoreNum;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "-3";
            }
            Destroy(collision.gameObject);
        }

        if (ScoreNum < 0) {
            ScoreNum = 0;
            Debug.Log("Game Over");
            OnPlayerScore?.Invoke();
        }
    }

    void updateTimer(float currentTime) {
        currentTime +=1;

        float minutes = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
