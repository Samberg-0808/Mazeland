using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Circle")
        {

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Plant")
        {
            Destroy(collision.gameObject);
        }

    }
}
