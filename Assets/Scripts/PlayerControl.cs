using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
<<<<<<< Updated upstream

=======
    
>>>>>>> Stashed changes
    public float movementSpeed = 3.0f;
    public bool timestop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var HorizontalMovement = Input.GetAxis("Horizontal");
        var VerticalMovement = Input.GetAxis("Vertical");
        if(HorizontalMovement > 0)
        {
            if(VerticalMovement > 0)
            {
                if(DestroyOnCollision.timefreeze == true)
                {
                    movementSpeed = 300.0f;
                }
                else
                {
                    movementSpeed = 3.0f;
                }
            }
        }
        // if (DestroyOnCollision.timefreeze == true)
        // {
            
        //     movementSpeed = 10.0f;
        //     // timestop = true;
        //     // StartCoroutine(move());
        // }

        // if (timestop == true)
        // {
        //     print ("correct my code pls");
        // }

        // IEnumerator move()
        // {
        //     yield return new WaitForSeconds(0.07f);
        //     timestop = false;
        // }

        // if (timestop == false)
        // {
        //     movementSpeed = 3.0f;
        // }


        
        
        transform.position += new Vector3(HorizontalMovement, VerticalMovement, 0) * Time.unscaledDeltaTime *  movementSpeed;
        
<<<<<<< Updated upstream
        transform.position += new Vector3(HorizontalMovement, VerticalMovement, 0) * Time.deltaTime *  movementSpeed;
        
      
=======

>>>>>>> Stashed changes
    }

    public void Speed()
    {
<<<<<<< Updated upstream
        if (movementSpeed < 6)
        {
            movementSpeed++;
        }
=======

>>>>>>> Stashed changes
    }

}
