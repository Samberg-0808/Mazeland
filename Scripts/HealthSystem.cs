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
        
    }


    //everytime call this method, life - 1 and update the heart icons
    public void TakeDamage() 
    {
        if(life >= 1) 
        {
            life = life - 1;
            Destroy(hearts[life].gameObject);
            Time.timeScale = 1;
        }

        if (life < 1) 
        {
            dead = true;
            Time.timeScale = 0;
        }
    }


    // return true if dead
    public bool IsDead()
    {
        return dead;
        Time.timeScale = 0;
    }

    

       
}
