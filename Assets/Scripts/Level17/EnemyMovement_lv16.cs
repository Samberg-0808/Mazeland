using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement_lv16 : MonoBehaviour
{
    // Start is called before the first frame update
    public float position_change_rate = 0.2f;
    // TODO - can move enemy_level to a new 'Enemy.cs' script
    public int enemy_level = 1;

    public bool idle = false;
    private int time_count = 0;
    private int x_sign = 1;
    private int y_sign = 1;
    private Vector3 player_pos;
    private Vector3 diff;

    void Start()
    {
        time_count = 0;
        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (time_count == 50){
            x_sign = x_sign * 1;
            y_sign = y_sign * -1;
        }
        else if (time_count == 100){
            x_sign = x_sign * -1;
            y_sign = y_sign * 1;
            time_count = 0;
        }

        if (idle) {
            var x_rnd = Random.value;
            var y_rnd = Random.value;
            transform.position += new Vector3(x_rnd * x_sign, y_rnd * y_sign, 0) * Time.deltaTime * position_change_rate;
        }
        else {
            player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            diff = new Vector3 (player_pos.x -transform.position.x  ,  player_pos.y - transform.position.y , 0);
            diff.Normalize();
            transform.position += diff * Time.deltaTime * position_change_rate;
        }

        time_count ++;
        
    }
}