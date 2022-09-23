using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGenerator : MonoBehaviour
{
    private int i = 0;

    public GameObject[] coins;

    public GameObject[] enemies;
    
    List<Vector3> CoinVectors = new List<Vector3> ();

    List<Vector3> EnemyVectors = new List<Vector3> ();
    
    public sendToGoogle sc = new sendToGoogle();

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i % 200 == 0) {
            spawnCoins();
        }

        if (i % 400 == 0) {
            spawnEnemies();
        }
    }

    private void Awake() {
        long _sessionID = System.DateTime.Now.Ticks;

        sc.Send();
    }

    void spawnCoins() {
        int r = Random.Range(0, coins.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Instantiate(coins[r], randomPoint, transform.rotation);

        
 
    }

    void spawnEnemies() {
        int r = Random.Range(0, enemies.Length);

        Vector2 center = new Vector2(1.07f, 0.58f);

        Vector2 randomPoint = center + Random.insideUnitCircle * 4f;

        Instantiate(enemies[r], randomPoint, transform.rotation);
    }
}
