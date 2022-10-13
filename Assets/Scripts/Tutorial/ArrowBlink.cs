using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ArrowBlink: MonoBehaviour
{
    public Color startColor = Color.magenta;
    public Color endColor = Color.yellow;
    [Range(0,10)]
    public float speed = 1;
    Image imgComp;
    public GameObject Arrow0to3;

    void Start()
    {
        StartCoroutine(OriginalShowAndHide(2.0f));
    }
    void Awake()
    {
        imgComp = GetComponent<Image>();
    }
   
    void Update()
    {
        imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
    
    IEnumerator OriginalShowAndHide(float delay)
    {
        Arrow0to3.SetActive(true);
        yield return new WaitForSeconds(delay);
        Arrow0to3.SetActive(false);
    }
    
    
}