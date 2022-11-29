using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement_lv18 : MonoBehaviour
{
    // Start is called before the first frame update
    public float position_change_rate = 1.0f;
    // TODO - can move enemy_level to a new 'Enemy.cs' script
    public int enemy_level = 1;

    private int time_count = 0;
    private int x_sign = 1;
    private int y_sign = 1;

    private int freeze_modifier = 1;

    // private Vector3 player_pos;
    // private Vector3 diff;

    void Start()
    {

        time_count = 0;
        // player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyOnCollision_lv18.enemyfreeze)
        {
            freeze_modifier = 0;
        }
        else
        {
            freeze_modifier = 1;
        }
        if (time_count == 1000){
            y_sign *= Random.Range(0,2)*2-1;
        }
        else if (time_count == 2000){
            x_sign *= Random.Range(0,2)*2-1;
            time_count = 0;
        }
        
          
        var x_rnd = Random.value;
        var y_rnd = Random.value;

        transform.position += new Vector3(x_rnd * x_sign, y_rnd * y_sign, 0) * Time.deltaTime * position_change_rate * freeze_modifier;

        time_count ++;

        // if (this.gameObject.name.IndexOf('(') != -1)
        // {
        //     player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //     diff = new Vector3(player_pos.x - transform.position.x, player_pos.y - transform.position.y, 0);
        //     diff.Normalize();
        //     transform.position += diff * Time.deltaTime * position_change_rate;
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rob")
        {
            Vector3 position_change = (collision.gameObject.transform.position - transform.position);
            position_change.Normalize();
            transform.position += position_change;
        }
    }

}

