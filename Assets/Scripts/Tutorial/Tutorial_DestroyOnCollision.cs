using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Threading;
using TMPro;


public class Tutorial_DestroyOnCollision: MonoBehaviour
{
    public int ScoreNum;
    public Text MyscoreText;
    public TextMeshPro PlayerText;
    public GameObject point;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject[] enemy;
    public GameObject floatingpoints;
    public GameObject Enemy_3;
    public GameObject Enemy_2;
    public GameObject Arrow3to2;
    public GameObject Arrow3to3;
    public Color startColor = Color.magenta;
    public Color endColor = Color.yellow;
    [Range(0,10)]
    public float speed = 1;
    
    public Image img3to2;
    public Image img3to3;

    public TextMeshProUGUI Math0and3;
    public TextMeshProUGUI Math3and2;
    public TextMeshProUGUI Math3and3;
    public TextMeshProUGUI Math3plus3;
    public TextMeshProUGUI Math6and2;
    public TextMeshProUGUI Math6plus2;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score " + ScoreNum;
        PlayerText.text = ScoreNum.ToString();


        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
        
        //Hide Enemy and arrow
        Enemy_2.SetActive(false);
        Enemy_3.SetActive(false);
        Arrow3to2.SetActive(false);
        Arrow3to3.SetActive(false);

        //hide math formula
        Math0and3.enabled = false;
        Math3and2.enabled = false;
        Math3and3.enabled = false;
        Math3plus3.enabled = false;
        Math6and2.enabled = false;
        Math6plus2.enabled = false;
    }

    void Update()
    {
        enemy = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in enemy)
        {
            if (child.gameObject.tag == "Enemy")
            {
                if (ScoreNum > 0)
                {
                    child.gameObject.GetComponent<EnemyStatus>().updateColor(ScoreNum);
                }
            }
        }

        if (Arrow3to2.active == true)
        {
            img3to2.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            StartCoroutine(OriginalShowAndHide(Arrow3to2, 1.5f));
        }

        if (Arrow3to3.active == true)
        {
            img3to3.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            StartCoroutine(OriginalShowAndHide(Arrow3to3, 1.5f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Coin")
        {

            if (collision.gameObject.name == "1-Coin")
            {
                ScoreNum += 1;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+1";
            }
            else if (collision.gameObject.name == "2-Coin")
            {
                ScoreNum += 2;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+2";
            }
            else if (collision.gameObject.name == "3-Coin")
            {
                ScoreNum += 3;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+3";
              
                StartCoroutine(TextShowAndHide(Math0and3, 4.0f));
                StartCoroutine(ShowArrowAndEnemy(Arrow3to2, Enemy_2, 4.0f));
                // Arrow3to2.SetActive(true);
                // Enemy_2.SetActive(true);
            }

            Destroy(collision.gameObject);


            MyscoreText.text = "Score: " + ScoreNum;
            PlayerText.text = ScoreNum.ToString();
        }
        
        if (collision.gameObject.tag == "Enemy")
        {
            int enemy_level = collision.gameObject.GetComponent<EnemyMovement>().enemy_level;
            if (ScoreNum % enemy_level == 0 && ScoreNum != 0)
            {
                ScoreNum += enemy_level;
                MyscoreText.text = "Score: " + ScoreNum;
                PlayerText.text = ScoreNum.ToString();
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+" + enemy_level;
               // gainSound.Play();
                Destroy(collision.gameObject);


                if (collision.gameObject.name == "3-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math3and3, 2.5f));
                    StartCoroutine(TextDelaytoShow(Math3plus3, 2.5f, 2.5f));
                }

                if (collision.gameObject.name == "2-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math6and2, 2.5f));
                    StartCoroutine(TextDelaytoShow(Math6plus2, 2.5f, 2.5f));
                }
            }

            else
            {

                if (collision.gameObject.name == "2-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math3and2, 4.0f));
                    StartCoroutine(ShowArrowAndEnemy(Arrow3to3, Enemy_3, 4.0f));
                    
                    // Enemy_3.SetActive(true);
                    // Arrow3to3.SetActive(true);
                }

                
                transform.position += transform.position - collision.gameObject.transform.position;
             //   life.TakeDamage();
            //    hitSound.Play();

                // Add short invincibility period
                // Physics.IgnoreCollision(Player.GetComponent<Collider>(), Enemy.GetComponent<Collider>(), true);
                // StartCoroutine("GetInvulnerable");
            }

        }
    }
    
    IEnumerator OriginalShowAndHide(GameObject arrow, float delay)
    {
        arrow.SetActive(true);
        yield return new WaitForSeconds(delay);
        arrow.SetActive(false);
    }

    IEnumerator TextShowAndHide(TextMeshProUGUI mathText, float delay)
    {
        mathText.enabled = true;
        yield return new WaitForSeconds(delay);
        mathText.enabled = false;
    }

    IEnumerator ShowArrowAndEnemy(GameObject arrow, GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(true);
        enemy.SetActive(true);
    }

    IEnumerator TextDelaytoShow(TextMeshProUGUI mathText, float delay, float showTime)
    {
        yield return new WaitForSeconds(delay);
        mathText.enabled = true;
        yield return new WaitForSeconds(showTime);
        mathText.enabled = false;
    }

}