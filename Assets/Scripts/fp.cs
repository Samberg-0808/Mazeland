using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "floatingpoints(Clone)")
        {
            StartCoroutine("Free"); 
        }
    }
    IEnumerator Free()
    {

        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }
}
