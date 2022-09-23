using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    private bool dead;

    void Start() 
    {
        life = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == true) 
        {
            Debug.Log("Game Over");
        }
    
    }


    //everytime call this method, life - 1 and update the heart icons
    public void TakeDamage() 
    {
        if(life >= 1) 
        {
            life = life - 1;
            Destroy(hearts[life].gameObject);

        }

        if (life < 1) 
        {
            dead = true;
        }
    }


    // return true if dead
    public bool IsDead()
    {
        return dead;
    }

    

       
}
