using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerGenerator : MonoBehaviour
{
    private const int V = 0;
    private int i = 0;

    public GameObject[] spheres;

    public GameObject[] bonus;
    
    List<Vector3> vectors = new List<Vector3> ();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i % 200 == 0) {
            spawnObjects();
        }

        if (i % 1000 == 0) {
            spawnBonus();
        }
    }

    void spawnObjects() {
        int i = Random.Range(0, spheres.Length);


        Vector3 p1 = new Vector3(-4.92f, -0.18f, 0.0376f);

        Vector3 p2 = new Vector3(-4.92f, 1.44f, 0.0376f);

        Vector3 p3 = new Vector3(-4.92f, 3f, 0.0376f);

        Vector3 p4 = new Vector3(-4.92f, -1.73f, 0.0376f);

        Vector3 p5 = new Vector3(-4.92f, -3.26f, 0.0376f);

        vectors.Add(p1);
        vectors.Add(p2);
        vectors.Add(p3);
        vectors.Add(p4);
        vectors.Add(p5);

        int j = Random.Range(0, vectors.Count);

        GameObject clone;

        clone = (GameObject) Instantiate(spheres[i], vectors[j], transform.rotation);

        clone.GetComponent<Rigidbody2D> ().velocity = 5 * transform.localScale.x * clone.transform.right;
 
    }

    void spawnBonus() {

        Vector3 a = new Vector3(0f, -0.72f, 0f);

        Instantiate(bonus[0], a, transform.rotation);

    }
}
