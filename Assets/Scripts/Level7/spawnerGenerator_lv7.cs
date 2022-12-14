using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnerGenerator_lv7 : MonoBehaviour
{
    private int i = 0;
    private int locationCount = 0;
    private float randomRange = 1;

    public GameObject[] coins;

    public GameObject[] enemies;

    public GameObject[] items;

    public int CoinsControl;

    public int EnemiesControl;

    public int startGameTiming;

    // **** data code ****
    public int totalEnemy;
    public int totalCoins;
    public int totalItems;
    // ********

    public int coinsLimit;
    public int enemiesLimit;

    public int currentCoins;
    public int currentEnemies;
    public Vector3 player_pos;
    public Scene scene;



    List<Vector3> CoinVectors = new List<Vector3>();

    List<Vector3> EnemyVectors = new List<Vector3>();

    List<Vector3> itemVectors = new List<Vector3>();

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

    // Update is called once per frame
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

            if (i % 1000 == 0 & scene.name == "Level3")
            {
                spawnItems();

                // **** data code ****
                totalItems++;
                // ********

            }

            locationCount++;
            if (locationCount == 3) {
                locationCount = 0;
            }
        }
        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }


    public void spawnCoins()
    {
        int r = Random.Range(0, coins.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(6.31f, -2.6f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(-2.25f, -2.45f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);
        }
        else {
            Vector2 center = new Vector2(1.88f, 5.52f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);

        }



    }

   



    public void spawnEnemies()
    {
        int r = Random.Range(0, enemies.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(6.31f, -2.6f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            if (Vector2.Distance(player_pos, randomPoint) > 1.0f)
            {
                Instantiate(enemies[r], randomPoint, transform.rotation);
            }
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(-2.25f, -2.45f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            if (Vector2.Distance(player_pos, randomPoint) > 1.0f)
            {
                Instantiate(enemies[r], randomPoint, transform.rotation);
            }
        }
        else
        {
            Vector2 center = new Vector2(1.88f, 5.52f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            if (Vector2.Distance(player_pos, randomPoint) > 1.0f)
            {
                Instantiate(enemies[r], randomPoint, transform.rotation);
            }

        }

    }

  

    void spawnItems()
    {
        int r = Random.Range(0, items.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(6.31f, -2.6f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(-2.25f, -2.45f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);
        }
        else
        {
            Vector2 center = new Vector2(1.88f, 5.52f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);

        }

    }
}
