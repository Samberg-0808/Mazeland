using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tips_lv20 : MonoBehaviour
{
    public int time_count = 100;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // for (int i = 0; i < time_count; i++) {
        //     transform.position = transform.position - new Vector3((float)0.5, (float)0.5, 0);
        //     time_count--;
        // }
        
    }
}
