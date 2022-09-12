using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerGenerator : MonoBehaviour
{
    private const int V = 0;
    private int i = 0;

    public GameObject[] spheres;

    public GameObject[] bonus;

    public GameObject[] Enemy;

    public GameObject[] Plants;
    List<Vector3> vectors = new List<Vector3> ();

    List<Vector3> vectorsenamy = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i % 100 == 0) {
            spawnObjects();
            Debug.Log(i);
        }

        if (i % 1000 == 0) {
            spawnBonus();
        }

        if (i % 300 == 0)
        {
            spawnEnemy();
        }
    }


    void spawnObjects() {
        int io = Random.Range(0, spheres.Length);


        Vector3 p3 = new Vector3(-4.92f, -0.18f, 0.0376f);

        Vector3 p2 = new Vector3(-4.92f, 1.44f, 0.0376f);

        Vector3 p1 = new Vector3(-4.92f, 3f, 0.0376f);

        Vector3 p4 = new Vector3(-4.92f, -1.73f, 0.0376f);

        Vector3 p5 = new Vector3(-4.92f, -3.26f, 0.0376f);

        vectors = new List<Vector3>();
        if (Plants[0] != null)
        {
            vectors.Add(p1);
        }
        if (Plants[1] != null)
        {
            vectors.Add(p2);
        }
        if (Plants[2] != null)
        {
            vectors.Add(p3);
        }
        if (Plants[3] != null)
        {
            vectors.Add(p4);
        }
        if (Plants[4] != null)
        {
            vectors.Add(p5);
        }

        //vectors.Add(p1);
        //vectors.Add(p2);
        //vectors.Add(p3);
        //vectors.Add(p4);
        //vectors.Add(p5);

        int jo = Random.Range(0, vectors.Count);

        GameObject clone;

        clone = (GameObject) Instantiate(spheres[io], vectors[jo], transform.rotation);

        clone.GetComponent<Rigidbody2D> ().velocity = 5 * transform.localScale.x * clone.transform.right;
 
    }

    void spawnBonus() {

        Vector3 a = new Vector3(0f, -0.72f, 0f);

        Instantiate(bonus[0], a, transform.rotation);

    }

    void spawnEnemy()
    {
        int ie = Random.Range(0, Enemy.Length);


        Vector3 e1 = new Vector3(10f, -0.18f, 0.0376f);

        Vector3 e2 = new Vector3(10f, 1.44f, 0.0376f);

        Vector3 e3 = new Vector3(10f, 3f, 0.0376f);

        Vector3 e4 = new Vector3(10f, -1.73f, 0.0376f);

        Vector3 e5 = new Vector3(10f, -3.26f, 0.0376f);

        vectorsenamy.Add(e1);
        vectorsenamy.Add(e2);
        vectorsenamy.Add(e3);
        vectorsenamy.Add(e4);
        vectorsenamy.Add(e5);

        int je = Random.Range(0, vectorsenamy.Count);

        GameObject enemyclone;

        enemyclone = (GameObject)Instantiate(Enemy[ie], vectorsenamy[je], transform.rotation);

        enemyclone.GetComponent<Rigidbody2D>().velocity = 2 * transform.localScale.x * enemyclone.transform.right * -1;

    }
}
