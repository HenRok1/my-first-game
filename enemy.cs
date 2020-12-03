using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int helth = 2;

    public void TakeDamage(int damage){
        helth -=damage;
        if (helth <=0){
            Die();
        }
    }
    void Die(){

        Destroy(gameObject);
    }
}
