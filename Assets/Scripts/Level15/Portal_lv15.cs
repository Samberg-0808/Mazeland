using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_lv15 : MonoBehaviour
{
    private Transform destination;

    public bool isOne;
    public bool isTwo;
    public bool isThree;
    public bool isFour;
    public bool isFive;
    public bool isSix;
    public float distance = 0.2f;

    public GameObject Ring1;
    public GameObject Ring3;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal5;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isOne)
        {
            destination = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        }
        // else if (isTwo)
        // {
        //     destination = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        // }
        // else if (isThree) 
        // {
        //     destination = GameObject.FindGameObjectWithTag("Portal4").GetComponent<Transform>();
        // }
        // else if (isFour)
        // {
        //     destination = GameObject.FindGameObjectWithTag("Portal3").GetComponent<Transform>();
        // }
        else if (isFive)
        {
            destination = GameObject.FindGameObjectWithTag("Portal6").GetComponent<Transform>();
        }
        // else if (isSix)
        // {
        //     destination = GameObject.FindGameObjectWithTag("Portal5").GetComponent<Transform>();
        // }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Vector2.Distance(transform.position, collision.transform.position) > distance) 
        {
            collision.transform.position = new Vector2(destination.position.x, destination.position.y);
            if (Ring1.activeSelf)
            {
                Ring1.SetActive(false);
                portal1.SetActive(false);
                portal2.SetActive(false);
            }
            else
            {
                Ring3.SetActive(false);
                portal5.SetActive(false);
            }
        }
    }
}
