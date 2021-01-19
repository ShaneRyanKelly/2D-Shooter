using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Vector2 velo;
    public Collider2D playerCollider;
    public Rigidbody2D bulletBody;
    Vector2 fixedSpeed = new Vector2();
    
    private void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log("bulletHit");
        Collider2D bulletCollider = gameObject.GetComponent<Collider2D>();
        Collider2D otherCollider = other.gameObject.GetComponent<Collider2D>();
        Rigidbody2D otherBody = other.gameObject.GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "Player"){
            Physics2D.IgnoreCollision(bulletCollider, otherCollider, true);
        }  
        if (other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //velo = velo * bulletSpeed * Time.fixedDeltaTime;
        //Debug.Log("bullet velocity: " + velo.x + ", " + velo.y);
        fixedSpeed =  velo * bulletSpeed;
        bulletBody.velocity = fixedSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletBody.velocity = fixedSpeed;
    }
}
