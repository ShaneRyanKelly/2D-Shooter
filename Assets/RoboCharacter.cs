using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCharacter : MonoBehaviour
{
    public Animator animator;
    public Camera mainCamera;
    public float movementSpeed;
    private bool collision;
    private Vector3 currentPosition;
    private float moveX;
    private float moveY;
    public Rigidbody2D playerBody;
    private Vector2 currentMove;
    public Bullet bullet;
    public Collider2D bulletCollider;
    public Collider2D playerCollider;
    void OnCollisionEnter(Collision collisionInfo)
    {
        //playerBody.isKinematic = true;
    }
    void Shoot(int direction)
    {
        Bullet currentBullet = Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
        switch (direction){
            case 0:
                currentBullet.velo = new Vector2(0, 1);
                break;
            case 1:
                currentBullet.velo = new Vector2(1, 0);
                break;
            case 2:
                currentBullet.velo = new Vector2(0, -1);
                break;
            case 3:
                currentBullet.velo = new Vector2(-1, 0);
                break;
            default:
                break;
        }
    }
    void Shoot (Vector2 shootDirection)
    {
        Bullet currentBullet = Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
        currentBullet.velo = shootDirection;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMove = new Vector2();
        //Physics2D.IgnoreCollision(playerCollider, bulletCollider, true);
    }

    // Update is called once per frame
    void Update() 
    {
        currentPosition = transform.position;
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        moveX = moveX * Time.fixedDeltaTime * movementSpeed;
        moveY = moveY * Time.fixedDeltaTime * movementSpeed;
        currentMove.x = moveX;
        currentMove.y = moveY;
        if (Input.GetKeyDown("up"))
        {
            Shoot(0);
        }
        else if (Input.GetKeyDown("right"))
        {
            Shoot(1);
        }
        else if (Input.GetKeyDown("down"))
        {
            Shoot(2);
        }
        else if (Input.GetKeyDown("left"))
        {
            Shoot(3);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector2 shootPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPosition = transform.position;
            RaycastHit2D shootRay = Physics2D.Raycast(playerPosition, playerPosition - shootPosition);
            playerPosition.Normalize();
            shootPosition.Normalize();
            Shoot(new Vector2(shootRay.normal.x, shootRay.normal.y));
            //Debug.Log("shoot ray: " + shootRay.normal.x + ", " + shootRay.normal.y);
            //Debug.Log("player position: " + playerPosition.x + ", " + playerPosition.y);
            //Debug.Log("mouse click: " + shootPosition.x + ", " + shootPosition.y);
        }
    }
    void FixedUpdate()
    {
        currentMove.Normalize();
        playerBody.velocity = currentMove * movementSpeed;
        //transform.position += new Vector3(currentMove.x, currentMove.y, 0.0f);
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        //mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
    }
}
