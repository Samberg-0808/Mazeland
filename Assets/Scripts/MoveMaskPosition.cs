using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMaskPosition : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        // get the object position
        Vector2 pos = gameObject.transform.position;  
        //convert game object position 
        Vector2 viewportPoint = Camera.main.WorldToViewportPoint(pos);  
        
        // set MIN and MAX Anchor values to the same position as ViewportPoint
        rectTransform.anchorMin = viewportPoint;  
        rectTransform.anchorMax = viewportPoint; 
    }
}
