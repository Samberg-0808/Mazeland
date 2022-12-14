using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnerGenerator_lv4 : MonoBehaviour
{
    private int i = 0;

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
    public Scene scene;



    List<Vector2> CoinVectors = new List<Vector2>();

    List<Vector2> EnemyVectors = new List<Vector2>();

    List<Vector2> itemVectors = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        // **** data code ****
        totalEnemy = 0;
        totalCoins = 0;
        totalItems = 0;
        // ********

        scene = SceneManager.GetActiveScene();

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

            if (i % 1000 == 0 & scene.name == "Level3")
            {
                spawnItems();

                // **** data code ****
                totalItems++;
                // ********
            }
        }
    }


    public void spawnCoins()
    {
        int r = Random.Range(0, coins.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);
        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;
        if (scene.name == "Level3")
        {
            randomPoint = center + Random.insideUnitCircle * 50f;

        }
        Instantiate(coins[r], randomPoint, transform.rotation);



    }





    public void spawnEnemies()
    {
        int r = Random.Range(0, enemies.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);
        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;
        if (scene.name == "Level3")
        {
            randomPoint = center + Random.insideUnitCircle * 50f;

        }
        Instantiate(enemies[r], randomPoint, transform.rotation);
    }



    void spawnItems()
    {
        int r = Random.Range(0, items.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;
        if (scene.name == "Level3")
        {
            randomPoint = center + Random.insideUnitCircle * 50f;

        }
        Instantiate(items[r], randomPoint, transform.rotation);



    }
}