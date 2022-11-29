using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public float movementSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalMovement = Input.GetAxis("Horizontal");
        var VerticalMovement = Input.GetAxis("Vertical");

        
        transform.position += new Vector3(HorizontalMovement, VerticalMovement, 0) * Time.deltaTime *  movementSpeed;
        
    }

    public void Speed()
    {
        if (movementSpeed < 6)
        {
            movementSpeed++;
        }
    }
}
