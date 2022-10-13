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
    public Color startColor = Color.magenta;
    public Color endColor = Color.yellow;
    [Range(0,10)]
    public float speed = 1;
    
    public Image img3to2;
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score " + ScoreNum;
        PlayerText.text = ScoreNum.ToString();


        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
        
        //Hide Enemy 2 and 3
        Enemy_2.SetActive(false);
        Enemy_3.SetActive(false);
        Arrow3to2.SetActive(false);
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

/*
        if (collision.gameObject.name == "Circle")
        {
          //  life.TakeDamage();
          //  hitSound.Play();
            Vector3 position_change = (collision.gameObject.transform.position - transform.position);
            position_change.Normalize();
            transform.position += position_change;
           // StartCoroutine(cameraShake.Shake(.15f, .4f));
            //OnPlayerScore?.Invoke();
            //point.SetActive(false);
        }
     */ 

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
                Arrow3to2.SetActive(true);
                Enemy_2.SetActive(true);
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

            }

            else
            {

                if (collision.gameObject.name == "2-Enemy")
                {
                    Enemy_3.SetActive(true);
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
    
    

}