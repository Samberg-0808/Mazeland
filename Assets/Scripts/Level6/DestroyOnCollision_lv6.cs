using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Threading;
using TMPro;

public class DestroyOnCollision_lv6 : MonoBehaviour
{
    // Start is called before the first frame updat

    public Text MyscoreText;
    public GameObject point;
    public static event Action OnPlayerScore;
    public Text Timer;
    
    public int ScoreNum;

    public TextMeshPro PlayerText;


    public float TimeLeft;

    public GameObject[] enemy;

    private long _sessionID;
    private Scene scene;
    public static event Action NextLevel;
    public ProgressBar progressBar;
    public Dictionary<string, int> levelScoreTarget = new Dictionary<string, int>
    {
        ["Tutorial"] = 1000,
        ["Level1"] = 40,
        ["Level2"] = 100,
        ["Level3"] = 150,
        ["Level6"] = 100
    };

    public EnemyStatus enemyStatus;

    public int enemyKilled;
    public GameObject floatingpoints;
    public HealthSystem life;
    public PlayerControl speed;

    public AudioSource gainSound;
    public AudioSource hitSound;
    // public spawnerGenerator sg;

    public CameraShake cameraShake;
    public GameObject Enemy;
    public GameObject Player;
    public GameObject Immune_item;
    public SpriteRenderer spriteRenderer;
    public Color c;

    public SendToGoogle sc = new SendToGoogle();

    private Stopwatch stopwatch = new Stopwatch();

    private bool death_flag = true;
    private void Awake()
    {
        _sessionID = System.DateTime.Now.Ticks;

    }

    
    void Start()
    {
        enemyKilled = 0;
        scene = SceneManager.GetActiveScene();
        UnityEngine.Debug.Log(scene.name);
        ScoreNum = 0;
        MyscoreText.text = "Score: " + ScoreNum;
        PlayerText.text = ScoreNum.ToString();

        

        Enemy = GameObject.FindWithTag("Enemy");
        Player = GameObject.FindWithTag("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        c = spriteRenderer.material.color;

        stopwatch.Start();
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
            stopwatch.Stop();
            long levelTime = stopwatch.ElapsedMilliseconds;
            levelTime = levelTime / 1000;

            //sc.Send(_sessionID, levelTime, -1, -1);


            // if (scene.name == "Level1")
            // {

            //     sc.Send(_sessionID, levelTime, -1, -1, -1, life.life);
            //     sc.enemySend(sg.totalEnemy, enemyKilled, -1, -1, -1, -1);
            // }
            // else if (scene.name == "Level2")
            // {
            //     UnityEngine.Debug.Log(levelTime);
            //     sc.Send(_sessionID, -1, levelTime, -1, -1, life.life);
            //     sc.enemySend(-1, -1, sg.totalEnemy, enemyKilled, -1, -1);
            // }
            // else if (scene.name == "Level3")
            // {
            //     UnityEngine.Debug.Log(levelTime);
            //     sc.Send(_sessionID, -1, -1, levelTime, -1, life.life);
            //     sc.enemySend(-1, -1, -1, -1, sg.totalEnemy, enemyKilled);
            // }

            //OnPlayerScore?.Invoke();
            //Display the next level menu
            NextLevel?.Invoke();
            point.SetActive(false);
        }

        // progressBar.setProgressBar(ScoreNum, levelScoreTarget[scene.name]);

        // UnityEngine.Debug.Log("enemy");
        foreach (GameObject child in enemy)
        {
            // UnityEngine.Debug.Log("sss");
            if (child != null && child.gameObject.tag == "Enemy")
            {
                if (ScoreNum > 0)
                {
                    child.gameObject.GetComponent<EnemyStatus>().updateColor(ScoreNum);
                }
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
            //OnPlayerScore?.Invoke();
            //point.SetActive(false);
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
            else if (collision.gameObject.name == "coin-100(Clone)")
            {
                ScoreNum += 100;
                GameObject points = Instantiate(floatingpoints, transform.position, Quaternion.identity) as GameObject;
                points.transform.GetComponent<TextMesh>().text = "+100";
            }
            Destroy(collision.gameObject);
            // sg.currentCoins--;
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
                // sg.currentEnemies--;
                enemyKilled++;
            }
            else
            {
                /* TODO - consider following improvements for collision
                   - camera shake when collision happens
                   - smoother collision effect by overriding player update()
                   - a very short invincibility period right after collision
                */
                // Add camera shake (duration, magnitude)
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
            Destroy(collision.gameObject);
            enemyKilled++;
            gainSound.Play();
        }

        if (life.IsDead() & this.death_flag)
        {
            OnPlayerScore?.Invoke();
            int level;
            if (scene.name == "Level1")
            {
                level = 1;
                sc.Send(_sessionID, -1, -1, -1, level, -1);
                sc.enemySend(-1, -1, -1, -1, -1, -1);
            }
            else if (scene.name == "Level2")
            {
                level = 2;
                sc.Send(_sessionID, -1, -1, -1, level, -1);
                sc.enemySend(-1, -1, -1, -1, -1, -1);
            }
            else if (scene.name == "Level3")
            {
                level = 3;
                sc.Send(_sessionID, -1, -1, -1, level, -1);
                sc.enemySend(-1, -1, -1, -1, -1, -1);
            }
            this.death_flag = false;
        }

        // Add collison immune item
        if (collision.gameObject.tag == "immune")
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
    }


    // Temporarily ignore collision for 3 seconds
    IEnumerator IgnoreCollision() {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(8, 11, true);
        c.a = 0.5f;
        spriteRenderer.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        Physics2D.IgnoreLayerCollision(8, 11, false);
        c.a = 1f;
        spriteRenderer.material.color = c;
    }
}
