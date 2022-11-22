using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class spawnerGenerator_lv16 : MonoBehaviour
{
    private int i = 0;

    public GameObject[] coins;

    public GameObject[] enemies;

    public GameObject[] items;

    public GameObject[] immune_items;

    public GameObject boss;
    public TextMeshPro bossText;

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
    //copy paste start
    public Vector3 player_pos;
    //copy paste end



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

            if ((i+400) % 750 == 0)
            {
                spawnItems();

                // **** data code ****
                totalItems++;
                // ********
            }
        }
        //copy paste start
        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //copy paste end
    }


    public void spawnCoins()
    {
        int r = Random.Range(0, coins.Length);

        Vector2 center = new Vector2(2.2f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Instantiate(coins[r], randomPoint, transform.rotation);



    }



    public void spawnEnemies()
    {
        int r = Random.Range(0, enemies.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Vector3 posChange = player_pos;
        posChange.Normalize();
        EnemyMovement_lv16 enemy_script = boss.GetComponent<EnemyMovement_lv16>();
        
        Vector2 minionSpawnPoint = boss.transform.position + posChange*2;

      //  Instantiate(enemies[r], randomPoint, transform.rotation);
        if (Vector2.Distance(player_pos, randomPoint) > 1.0f)
        {
            Instantiate(enemies[r], minionSpawnPoint, transform.rotation);
            // enemy_script.enemy_level -= 1;
            // bossText.text = enemy_script.enemy_level.ToString();
        }
    }

  

    void spawnItems()
    {
        int r = Random.Range(0, items.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Instantiate(items[r], randomPoint, transform.rotation);

    }

    public void spawnImmuneItems() {
        int r = Random.Range(0, items.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Instantiate(immune_items[r], randomPoint, transform.rotation);
    }
}
