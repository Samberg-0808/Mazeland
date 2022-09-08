using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNumberBox : MonoBehaviour
{
    public GameObject NumberBox;
    public float xMin, xMax, yMin, yMax;
    public float randomX, randomY;
    public float timeBetweenCreation;
    public RectTransform Canvas;
    private float createTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > createTime)
        {
            Creation();
            createTime = Time.time + timeBetweenCreation;
        }
    }

    void Creation()
    {
        randomX = Random.Range(xMin, xMax);
        randomY = Random.Range(yMin, yMax);

        Instantiate(NumberBox, transform.position + new Vector3(randomX, randomY, 0), transform.rotation, Canvas);
    }
}
