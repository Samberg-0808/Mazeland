using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement_lv18 : MonoBehaviour
{
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
