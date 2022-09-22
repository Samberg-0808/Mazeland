using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float position_change_rate = 2f;
    private int time_count = 0;
    private int x_sign = 1;
    private int y_sign = 1;
    void Start()
    {
        time_count = 0;
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

          
        var x_rnd = Random.value;
        var y_rnd = Random.value;

        transform.position += new Vector3(x_rnd * x_sign, y_rnd * y_sign, 0) * Time.deltaTime * position_change_rate;

        time_count ++;
    }
}
