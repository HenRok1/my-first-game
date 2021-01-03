using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    
    public float positionOfPatrol;
    public Transform point;
    bool moveingRight;
    private Animator anim;

    public int health = 2;
    Transform player;
    
    public GameObject bullet;
    public Transform FairAIPoint;

    public float stoppingDistance;

    bool Chill = false;
    bool Angry = false;
    bool GoBack = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;        
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, point.position) < positionOfPatrol && Angry == false)
        {
            Chill = true;
        }
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            Angry = true;
            Chill = false;
            GoBack = false;
        }
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            Angry = false;
            GoBack = true;
        }
        if(Chill == true)
        {
            Chills();
        }        
        else if(Angry == true)
        {
            Angrys();
            
        }
        else if(GoBack == true)
        {
            GoBacks();
        }
        if(transform.position.x < point.position.x - positionOfPatrol && Chill == true) {
            Flip();
        }
        else if(transform.position.x > point.position.x + positionOfPatrol && Chill == true){
            Flip();
        }
    }
    void FixedUpdate(){
        if(Angry == true){
            Shoot();
        }

    }
    void Chills(){
        if(transform.position.x > point.position.x + positionOfPatrol){
            moveingRight = false;
        }
        else if(transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;             
        }
        if(moveingRight){
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Angrys(){
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        speed = 8;
        if(Angry == true && moveingRight == true){
            Flip();
        }
        
    }
    void GoBacks(){
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        if(GoBack == true && moveingRight == false){
            Flip();
        }
    }
    void Flip(){
        moveingRight = !moveingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void TakeDamage(int damage){
       health -= damage;
       if(health <= 0){
           Die();
       }
    }    
    void Die(){
        Destroy(gameObject);
    }
    void Shoot()
    {
        Instantiate(bullet, FairAIPoint.position, FairAIPoint.rotation); 
    }
}
