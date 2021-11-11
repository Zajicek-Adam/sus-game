using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{ 
    public Rigidbody2D myRigidbody;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;

    private float buttonHoldTime;

    public bool jumpPressed;
    public bool jumpHeld;
    public bool isJumping;

    public int maxJumps;
    public float originalGravity;
    public int jumpsLeft;

    public float maxButtonHoldTime;
    public float maxJumpSpeed;
    public float maxFallSpeed;
    public float fallSpeed;
    public float holdForce;
    public float additionalForce;
    public float gravityMultipler;

    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.GetComponent<Rigidbody2D>();
        originalGravity = myRigidbody.gravityScale;
        jumpsLeft = maxJumps;
        buttonHoldTime = maxButtonHoldTime;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            jumpPressed = true;
        }
        else
        {
            jumpPressed = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jumpHeld = true;
        }
        else
        {
            jumpHeld = false;
        }
        CheckForJump();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = myRigidbody.velocity.y;
        IsJumping();
        HandleMovement(horizontal, vertical);
    }
    private void HandleMovement(float horizontal, float vertical)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed * Time.fixedDeltaTime, myRigidbody.velocity.y);
    }
    private void CheckForJump()
    {
        if (jumpPressed)
        {
            if (!isGrounded && jumpsLeft == maxJumps)
            {
                isJumping = false;
                return;
            }
            jumpsLeft--;
            if (jumpsLeft >= 0)
            {
                isJumping = true;
                myRigidbody.gravityScale = originalGravity;
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
                buttonHoldTime = maxButtonHoldTime;
                return;
            }
        }
    }
    private void IsJumping()
    {
        if (isJumping)
        {
            myRigidbody.AddForce(Vector2.up * jumpForce);
            AdditionalJump();
        }
        if (myRigidbody.velocity.y > maxJumpSpeed)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, maxJumpSpeed);
        }
        Falling();
    }
    private void AdditionalJump()
    {
        if (jumpHeld)
        {
            buttonHoldTime -= Time.deltaTime;
            if (buttonHoldTime <= 0)
            {
                buttonHoldTime = 0;
                isJumping = false;
            }
            else
                myRigidbody.AddForce(Vector2.up * holdForce);
        }
        else
        {
            isJumping = false;
        }
    }
    private void Falling()
    {
        if (!isJumping && myRigidbody.velocity.y < fallSpeed)
        {
            myRigidbody.gravityScale = gravityMultipler;
        }
        if (myRigidbody.velocity.y < maxFallSpeed)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, maxFallSpeed);
        }
    }
}


