using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Threading;
using TMPro;

public class DestroyOnCollision_lv8 : MonoBehaviour
{
    // Start is called before the first frame updat

    public Text MyscoreText;
    public GameObject point;
    public static event Action OnPlayerScore;
    public Text Timer;
    public int ScoreNum;

    //public HideMask hidemask;

    public TextMeshPro PlayerText;

    public float TimeLeft;

    public GameObject[] enemy;
    public GameObject[] coins;

    private long _sessionID;
    private Scene scene;
    public static event Action NextLevel;
    public ProgressBar progressBar;
    public Dictionary<string, int> levelScoreTarget = new Dictionary<string, int>
    {
        ["Tutorial"] = 1000,
        ["Level1"] = 40,
        ["Level2"] = 60,
        ["Level3"] = 60,
        ["Level4"] = 60,
        ["Level8"] = 40
    };

    // **** data code ****
    public int enemyKilled;
    public int pointGained;
    public int itemGained;
    private Stopwatch stopwatch = new Stopwatch();
    // ********

    public EnemyStatus enemyStatus;
    public GameObject floatingpoints;
    public HealthSystem life;
    public PlayerControl speed;

    public AudioSource gainSound;
    public AudioSource hitSound;
    public spawnerGenerator_lv8 sg;

    public CameraShake cameraShake;
    public GameObject Immune_item;
    public SpriteRenderer spriteRenderer;
    public Color c;

    public SendToGoogle sc = new SendToGoogle();

    

    private bool death_flag = true;
    private void Awake()
    {
        _sessionID = System.DateTime.Now.Ticks;

    }

    
    void Start()
    {
        // **** data code ****
        enemyKilled = 0;
        pointGained = 0;
        itemGained = 0;
        stopwatch.Start();
        // ********

        scene = SceneManager.GetActiveScene();
        UnityEngine.Debug.Log(scene.name);
        ScoreNum = 0;
        MyscoreText.text = "Score " + ScoreNum;
        PlayerText.text = ScoreNum.ToString();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        c = spriteRenderer.material.color;
        Physics2D.IgnoreLayerCollision(8, 9, false); // reset IgnoreCollision
    }

    void Update()
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }



        // Return the current Active Scene to get the name of the current scene
        scene = SceneManager.GetActiveScene();
        if (ScoreNum >= levelScoreTarget[scene.name])
        {
            ScoreNum = 0;

            // **** data code ****
            stopwatch.Stop();
            long levelTime = stopwatch.ElapsedMilliseconds;
            levelTime = levelTime / 1000;
            long currLevel = 7;
            sc.Send(_sessionID, currLevel, levelTime, -1, life.life);
            sc.enemySend(sg.totalEnemy, enemyKilled, sg.totalCoins, pointGained, sg.totalItems, itemGained);
            // ********



            //Display the next level menu
            NextLevel?.Invoke();
            point.SetActive(false);
        }

        progressBar.setProgressBar(ScoreNum, levelScoreTarget[scene.name]);

        enemy = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject child in enemy)
        {
            if (child.gameObject.tag == "Enemy")
            {
                child.gameObject.GetComponent<EnemyStatus>().updateColor(ScoreNum);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.name == "Circle")
        {
            life.TakeDamage();
            hitSound.Play();
            Vector3 position_change = (collision.gameObject.transform.position - transform.position);
            position_change.Normalize();
            transform.position += position_change;
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }

        if (collision.gameObject.tag == "Coin")
        {

            if (collision.gameObject.name == "coin-1(Clone)")
            {
                ScoreNum += 1;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+1";
            }
            else if (collision.gameObject.name == "coin-2(Clone)")
            {
                ScoreNum += 2;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+2";
            }
            else if (collision.gameObject.name == "coin-3(Clone)")
            {
                ScoreNum += 3;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+3";
            }
            else if (collision.gameObject.name == "coin-4(Clone)")
            {
                ScoreNum += 5;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+5";
            }
            else if (collision.gameObject.name == "coin-5(Clone)")
            {
                ScoreNum += 10;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+10";
            }
            Destroy(collision.gameObject);

            // **** data code ****
            pointGained++;
            // ********

            sg.currentCoins--;
            MyscoreText.text = "Score: " + ScoreNum;
            PlayerText.text = ScoreNum.ToString();
            gainSound.Play();
        }

        if (collision.gameObject.tag == "Enemy")
        {
            int enemy_level = collision.gameObject.GetComponent<EnemyMovement_lv8>().enemy_level;
            if (ScoreNum % enemy_level == 0 && ScoreNum != 0)
            {
                ScoreNum += enemy_level;
                MyscoreText.text = "Score: " + ScoreNum;
                PlayerText.text = ScoreNum.ToString();
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+" + enemy_level;
                gainSound.Play();
                Destroy(collision.gameObject);
                sg.currentEnemies--;

                // **** data code ****
                enemyKilled++;
                // ********
            }
            else
            {
                /* TODO - consider following improvements for collision
                   - camera shake when collision happens
                   - smoother collision effect by overriding player update()
                   - a very short invincibility period right after collision
                */
                // Add camera shake
                StartCoroutine(cameraShake.Shake(.15f, .4f));

                // Add short invincibility period
                StartCoroutine("IgnoreCollision");

                transform.position += transform.position - collision.gameObject.transform.position;
                life.TakeDamage();
                hitSound.Play();
            }

        }

        if (collision.gameObject.tag == "Item")
        {

            if (collision.gameObject.name == "heart-item(Clone)")
            {
                life.Heal();
            }
            if (collision.gameObject.name == "speed-item(Clone)")
            {
                speed.Speed();
            }
            if (collision.gameObject.name == "bomb-item(Clone)")
            {
                coins = FindObjectsOfType(typeof(GameObject)) as GameObject[];
                foreach (GameObject coin in coins)
                {
                    if (coin.gameObject.tag == "Coin" && coin.gameObject.name.IndexOf('(') != -1)
                    {
                        Destroy(coin);
                        ScoreNum += 1;
                        GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                        points.transform.GetComponent<TextMesh>().text = "+1"; ScoreNum += 1;
                        pointGained++;
                        MyscoreText.text = "Score: " + ScoreNum;
                        PlayerText.text = ScoreNum.ToString();
                        sg.currentCoins--;
                    }
                    if (coin.gameObject.tag == "Enemy" && coin.gameObject.name.IndexOf('(') != -1)
                    {
                        Destroy(coin);
                        ScoreNum += 1;
                        GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                        points.transform.GetComponent<TextMesh>().text = "+1";
                        pointGained++;
                        MyscoreText.text = "Score: " + ScoreNum;
                        PlayerText.text = ScoreNum.ToString();
                        sg.currentEnemies--;
                    }
                }
            }
            Destroy(collision.gameObject);

            // **** data code ****
            itemGained++;
            // ********

            gainSound.Play();
        }

        if (life.IsDead() & this.death_flag)
        {
            //hidemask.DisableMask();
            OnPlayerScore?.Invoke();

            // **** data code ****
            int level = 7;
            sc.Send(_sessionID, -1, -1, level, -1);
            sc.enemySend(-1, -1, -1, -1, -1, -1);
            // ********

            this.death_flag = false;
        }

        // Add collison immune item
        if (collision.gameObject.tag == "Immune")
        {
            Destroy(collision.gameObject);
            gainSound.Play();
            StartCoroutine("IgnoreCollision");
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        if (minutes == 0 & seconds == 0) {
            OnPlayerScore?.Invoke();
        }
    }


    // Temporarily ignore collision for 3 seconds
    IEnumerator IgnoreCollision() {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < 6; i++) {
            c.a = 0.5f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.25f);
            c.a = 1f;
            spriteRenderer.material.color = c;
            yield return new WaitForSeconds(0.25f);
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}