using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleShrink : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circle;
    public float growRate = -1f;
    public bool freezed = false;

    // Update is called once per frame
    void Update()
    {
        if (freezed == false)
        {
            circle.transform.localScale  += new Vector3(0.1f, .1f, .1f) * growRate * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Game Over");
        }

    }

    public void Freeze()
    {
        freezed = true;
        StartCoroutine(FreezeIEnumerator());
    }

    public IEnumerator FreezeIEnumerator()
    {
        yield return new WaitForSeconds(5.0f);
        freezed = false;
    }
}
