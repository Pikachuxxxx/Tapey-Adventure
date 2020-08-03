using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMovement2D : MonoBehaviour
{
    private Rigidbody2D _playerRB;
    private float InputX;
    private float InputY;

    private float jumpTimeCounter;
    private bool isJumping;

    // Use these variable to the check if the player is grounded or not
    [Header("Player Grounded check")]
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Space]
    [Header("Locomotion Settings")]
    public float speed = 5f;
    public float jumpForce = 20f;
    public float jumpTime = 0.25f;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerRB.gravityScale = 4f;
    }

    void Update()
    {
        // Getting the Input
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");

        //Flip the player based on the Input
        if (InputX > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if(InputX < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);


        // Check wether the player is grounded or not
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        // If the player is grounded enable him to jump 
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _playerRB.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
         }

        // Enabling the player mario like jump
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                _playerRB.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
                isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            isJumping = false;
    }

    private void FixedUpdate()
    {
        // Moving the player in X-axis using the InputX every phyiscs cycle
        _playerRB.velocity = new Vector2(InputX * speed, _playerRB.velocity.y);  
    }

}
