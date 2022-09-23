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
    public HealthSystem life;

    public AudioSource gainSound;
    public AudioSource hitSound;
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
            life.TakeDamage();
            hitSound.Play();
            Vector3 position_change = (collision.gameObject.transform.position - transform.position);
            position_change.Normalize();
            transform.position += position_change;
            //OnPlayerScore?.Invoke();
            //point.SetActive(false);
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
            gainSound.Play();
        }

        if (collision.gameObject.tag == "Enemy") {
            int enemy_level = collision.gameObject.GetComponent<EnemyMovement>().enemy_level;
            if (ScoreNum % enemy_level == 0) {
                ScoreNum +=enemy_level;
                MyscoreText.text = "Score: " + ScoreNum;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+"+enemy_level;
                gainSound.Play();
                Destroy(collision.gameObject);
            } 
            else {
                /* TODO - consider following improvements for collision
                   - camera shake when collision happens
                   - smoother collision effect by overriding player update()
                   - a very short invincibility period right after collision
                */
                transform.position += transform.position - collision.gameObject.transform.position;
                life.TakeDamage();
                hitSound.Play();
                //Vector3 temp = new Vector3(0f,0f,0f);
                //Instantiate(enemy[(ScoreNum%2)-1], temp, transform.rotation);
                //ScoreNum -= 2;
                //MyscoreText.text = "Score: " + ScoreNum;
                //GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                //points.transform.GetComponent<TextMesh>().text = "-2";
            }
            
        }

        if (ScoreNum < 0) {
            ScoreNum = 0;
            Debug.Log("Game Over");
            OnPlayerScore?.Invoke();
        }

        if (life.IsDead()) 
        { 
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
