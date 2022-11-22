using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class spawnerGenerator_lv20 : MonoBehaviour
{
    private int i = 0;

    public GameObject[] coins;

    public GameObject[] enemies;

    public GameObject[] items;

    public GameObject[] immune_items;

    public int CoinsControl;

    public int EnemiesControl;

    public int startGameTiming;

    public TextMeshPro eventText;

    // **** data code ****
    public int totalEnemy;
    public int totalCoins;
    public int totalItems;
    // ********

    public int coinsLimit;
    public int enemiesLimit;

    public int currentCoins;
    public int currentEnemies;
    //copy paste start
    public Vector3 player_pos;
    //copy paste end
    public Scene scene;



    List<Vector3> CoinVectors = new List<Vector3>();

    List<Vector3> EnemyVectors = new List<Vector3>();

    List<Vector3> itemVectors = new List<Vector3>();

    List<Vector3> immuneItemVectors = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        // **** data code ****
        totalEnemy = 0;
        totalCoins = 0;
        totalItems = 0;
        // ********
        
        currentCoins = 0;
        currentEnemies = 0;
    }

    void FixedUpdate()
    {
        i++;
        if (i > startGameTiming)
        {
            if (i % CoinsControl == 0 & currentCoins < coinsLimit)
            {
                spawnCoins();
                currentCoins++;

                // **** data code ****
                totalCoins++;
                // ********
            }

            if (i % EnemiesControl == 0 & currentEnemies < enemiesLimit)
            {
                // **** data code ****
                totalEnemy++;
                // ********
                currentEnemies++;
                spawnEnemies();
            }

            if (i % 800 == 0 & scene.name == "Level3")
            {
                spawnItems();

                // **** data code ****
                totalItems++;
                // ********
            }
            if (i % 800 == 0)
            {
                int xcount = Random.Range(0, 2);
                if(xcount == 0)
                {
                    enemyspawnevent();
                }
                else
                {
                    coinspawnevent();
                }
            }
        }
        //copy paste start
        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //copy paste end
    }


    public void spawnCoins()
    {
        if (Time.timeScale == 0)
        {

        }
        else
        {
            int r = Random.Range(0, coins.Length);

            Vector2 center = new Vector2(1.07f, 0.58f);

            Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

            Instantiate(coins[r], randomPoint, transform.rotation);
        }


    }


    public void spawnEnemies()
    {
        if (Time.timeScale == 0)
        {

        }
        else
        {
            int r = Random.Range(0, enemies.Length);

            Vector2 center = new Vector2(1.07f, 0.58f);

            Vector2 randomPoint = center + Random.insideUnitCircle * 4f;
            
            //copy paste start and also delete the orignal instantiate line
            if(Vector2.Distance (player_pos, randomPoint) > 1.0f)
            {
                Instantiate(enemies[r], randomPoint, transform.rotation);
            }
        }
        //copy paste end
    }

  

    void spawnItems()
    {
        if(Time.timeScale == 0)
        {

        }
        else
        {
            int r = Random.Range(0, items.Length);

            Vector2 center = new Vector2(1.07f, 0.58f);

            Vector2 randomPoint = center + Random.insideUnitCircle * 4f;
            
            Instantiate(items[r], randomPoint, transform.rotation);
        }
    }

    public void spawnImmuneItems() 
    {
        if (Time.timeScale == 0)
        {

        }
        else
        {
            int r = Random.Range(0, items.Length);

            Vector2 center = new Vector2(1.07f, 0.58f);

            Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

            Instantiate(immune_items[r], randomPoint, transform.rotation);
        }
    }

    public void enemyspawnevent()
    {
        if (Time.timeScale == 0)
        {

        }
        else
        {
            StartCoroutine(enemyspawnCoroutine());
        }
    }

    IEnumerator enemyspawnCoroutine()
    {
        eventText.text = "Enemy Spawning Events!";
        EnemiesControl = EnemiesControl - 100;

        yield return new WaitForSeconds(8);

        EnemiesControl = EnemiesControl + 100;
        eventText.text = "";
    }

    public void coinspawnevent()
    {
        if (Time.timeScale == 0)
        {

        }
        else
        {
            StartCoroutine(coinspawnCoroutine());
        }
    }

    IEnumerator coinspawnCoroutine()
    {
        eventText.text = "Coin Spawning Events!";
        CoinsControl = CoinsControl - 150;

        yield return new WaitForSeconds(8);

        CoinsControl = CoinsControl + 150;
        eventText.text = "";
    }
}