using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private RoboCharacter playerCharacter;
    public float moveRate;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            //Destroy(other.gameObject);
            //Instantiate(new RoboCharacter(), new Vector3(0,0,0), new Quaternion(0,0,0,0));
        }  
    }
    void Move(){
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = playerCharacter.transform.position;
        RaycastHit2D moveRay = Physics2D.Raycast(enemyPosition, enemyPosition - playerPosition);
        Vector2 moveVector = new Vector2(moveRay.normal.x, moveRay.normal.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = moveVector * moveRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = FindObjectOfType<RoboCharacter>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
}
