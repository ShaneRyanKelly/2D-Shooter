using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
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

    void OnCollisionEnter(Collision collisionInfo)
    {
        //playerBody.isKinematic = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMove = new Vector2();
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
