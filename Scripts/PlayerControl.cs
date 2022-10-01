using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public float movementSpeed = 3.0f;
    public TextMeshPro PlayerText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerText.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalMovement = Input.GetAxis("Horizontal");
        var VerticalMovement = Input.GetAxis("Vertical");

        
        transform.position += new Vector3(HorizontalMovement, VerticalMovement, 0) * Time.deltaTime *  movementSpeed;
        
      
    }

}
