using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_12 : MonoBehaviour
{
    private Transform destination;

    public bool isOne;
    public bool isTwo;
    public bool isThree;
    public bool isFour;
    public float distance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        if (isOne)
        {
            destination = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        }
        else if (isTwo)
        {
            destination = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        }
        else if (isThree) 
        {
            destination = GameObject.FindGameObjectWithTag("Portal4").GetComponent<Transform>();
        }
        else if (isFour)
        {
            destination = GameObject.FindGameObjectWithTag("Portal3").GetComponent<Transform>();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, collision.transform.position) > distance) 
        {
            collision.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
