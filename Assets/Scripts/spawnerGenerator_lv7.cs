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

    public int totalEnemy;

    public int coinsLimit;
    public int enemiesLimit;

    public int currentCoins;
    public int currentEnemies;
    public Scene scene;



    List<Vector3> CoinVectors = new List<Vector3>();

    List<Vector3> EnemyVectors = new List<Vector3>();

    List<Vector3> itemVectors = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        totalEnemy = 0;
        
        currentCoins = 0;
        currentEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i > startGameTiming)
        {
            if (i % CoinsControl == 0 & currentCoins < coinsLimit)
            {
                spawnCoins();
                currentCoins++;
            }

            if (i % EnemiesControl == 0 & currentEnemies < enemiesLimit)
            {
                totalEnemy++;
                currentEnemies++;
                spawnEnemies();
            }

            if (i % 1000 == 0 & scene.name == "Level3")
            {
                spawnItems();
            }

            locationCount++;
            if (locationCount == 3) {
                locationCount = 0;
            }
        }
    }


    public void spawnCoins()
    {
        int r = Random.Range(0, coins.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(1.43f, 2.22f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(6.29f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);
        }
        else {
            Vector2 center = new Vector2(-3.34f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(coins[r], randomPoint, transform.rotation);

        }



    }

   



    public void spawnEnemies()
    {
        int r = Random.Range(0, enemies.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(1.43f, 2.22f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(enemies[r], randomPoint, transform.rotation);
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(6.29f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(enemies[r], randomPoint, transform.rotation);
        }
        else
        {
            Vector2 center = new Vector2(-3.34f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(enemies[r], randomPoint, transform.rotation);

        }

    }

  

    void spawnItems()
    {
        int r = Random.Range(0, items.Length);

        if (locationCount == 0)
        {
            Vector2 center = new Vector2(1.43f, 2.22f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);
        }
        else if (locationCount == 1)
        {
            Vector2 center = new Vector2(6.29f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);
        }
        else
        {
            Vector2 center = new Vector2(-3.34f, -6.41f);

            Vector2 randomPoint = center + Random.insideUnitCircle * randomRange;

            Instantiate(items[r], randomPoint, transform.rotation);

        }

    }
}
