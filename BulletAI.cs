using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float speedBullet = 5f;
    public int damage = 1;
    public float lifeTime = 2;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.right * speedBullet;
    }
    void Update(){
        transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
        lifeTime = lifeTime - Time.deltaTime;
        
        if(lifeTime <= 0){
            Destroy(gameObject);
    }
}

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerCon player = hitInfo.GetComponent<PlayerCon>();
        if (player != null){
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }


}
