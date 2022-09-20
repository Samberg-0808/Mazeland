using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleShrink : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circle;
    public float growRate = -1f;

    // Update is called once per frame
    void Update()
    {
        circle.transform.localScale  += new Vector3(0.1f, .1f, .1f) * growRate * Time.deltaTime;
    }
}
