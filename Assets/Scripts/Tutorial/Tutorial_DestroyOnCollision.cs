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
    public static event Action OnPlayerScore;

    public AudioSource gainSound;
    public AudioSource hitSound;

    public GameObject point;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject[] enemy;
    public GameObject floatingpoints;
    public GameObject Enemy_3;
    public GameObject Enemy_2;
    public GameObject Enemy_4;
    public GameObject Enemy_5;
    public GameObject Arrow3to2;
    public GameObject Arrow3to3;
    public GameObject Coin3;
    public Color startColor = Color.magenta;
    public Color endColor = Color.yellow;
    [Range(0,10)]
    public float speed = 1;
    // public HealthSystem life;
    // private bool death_flag = true;
    
    public Image img3to2;
    public Image img3to3;

    public TextMeshProUGUI Math0and3;
    public TextMeshProUGUI Math3and2;
    public TextMeshProUGUI Math3and3;

    public TextMeshProUGUI Math6and2;
    public TextMeshProUGUI Math8and4;   
    public TextMeshProUGUI Math12and3;
    public TextMeshProUGUI Math12and5;
    public TextMeshProUGUI Math15and5;

    public TextMeshProUGUI DivisibleText;
    public TextMeshProUGUI DivisibleText1;
    public TextMeshProUGUI DivisibleText2;

    public GameObject RestartTutorial;
    private Scene scene;
    public ProgressBar progressBar;
    public Dictionary<string, int> levelScoreTarget = new Dictionary<string, int>
    {
        ["GameTutorial"] = 20
    };

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
        Enemy_4.SetActive(false);
        Enemy_5.SetActive(false);
        Arrow3to2.SetActive(false);
        Arrow3to3.SetActive(false);

        Coin3.SetActive(false);
        RestartTutorial.SetActive(false);

        //hide math formula
        Math0and3.enabled = false;
        Math3and2.enabled = false;
        Math3and3.enabled = false;        
        Math6and2.enabled = false;
        Math8and4.enabled = false;
        Math12and3.enabled = false;
        Math12and5.enabled = false;
        Math15and5.enabled = false;      

        DivisibleText.enabled = false;
        DivisibleText1.enabled = false;
        DivisibleText2.enabled = false;
        
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        progressBar.setProgressBar(ScoreNum, levelScoreTarget[scene.name]);

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
                StartCoroutine(ShowArrowAndEnemy(Arrow3to2, Enemy_2, 2.0f));
            }
            else if (collision.gameObject.name == "3-Coin-1")
            {
                ScoreNum += 3;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+3";
                StartCoroutine(TextShowAndHide(Math12and3, 2.5f));
            }
            
            Destroy(collision.gameObject);

            MyscoreText.text = "Score: " + ScoreNum;
            PlayerText.text = ScoreNum.ToString();

            gainSound.Play();
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
                gainSound.Play();
                Destroy(collision.gameObject);


                if (collision.gameObject.name == "3-Enemy")
                {
                    StartCoroutine(TextDelaytoShow(Math3and3, 2.5f, 2.5f));
                    StartCoroutine(TextShowAndHide(DivisibleText, 1.3f));
                }

                if (collision.gameObject.name == "2-Enemy")
                {
                    StartCoroutine(TextShowAndHide(DivisibleText1, 1.3f));
                    StartCoroutine(TextDelaytoShow(Math6and2, 2.5f, 2.5f));
                    Enemy_4.SetActive(true);
                }

                if (collision.gameObject.name == "4-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math8and4, 2.5f));
                    Enemy_5.SetActive(true);
                    Coin3.SetActive(true);
                }

                if (collision.gameObject.name == "5-Enemy")
                {
                    StartCoroutine(TextShowAndHide(DivisibleText2, 1.3f));
                    StartCoroutine(TextDelaytoShow(Math15and5, 2.5f, 2.5f));
                    StartCoroutine(ShowRestart(RestartTutorial, 4.0f));
                }

            }

            else
            {
                if (collision.gameObject.name == "2-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math3and2, 4.0f));
                    StartCoroutine(ShowArrowAndEnemy(Arrow3to3, Enemy_3, 0.5f));
                }

                if (collision.gameObject.name == "5-Enemy")
                {
                    StartCoroutine(TextShowAndHide(Math12and5, 4.0f));
                }
                
                transform.position += transform.position - collision.gameObject.transform.position;
                // life.TakeDamage();
                hitSound.Play();

                // Add short invincibility period
                // Physics.IgnoreCollision(Player.GetComponent<Collider>(), Enemy.GetComponent<Collider>(), true);
                // StartCoroutine("GetInvulnerable");
            }
        }
        
        // if (life.IsDead() & this.death_flag)
        // {
        //     OnPlayerScore?.Invoke();
        // }
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


    IEnumerator ShowRestart(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(true);
    }
}