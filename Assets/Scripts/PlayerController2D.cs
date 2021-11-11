using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Animator myAnimator;
    public bool isGrounded = true;
    private bool canAdd;
    [SerializeField]
  //  private float jumpModifier;
  //  private float calculatedModifier;
  //  private float lastDurationInSpace;
    public float additionalForce;
    public float spaceTime;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        HandleMovement(horizontal, vertical);
        /*   if (myRigidbody.velocity.x > 0)
           {
               myAnimator.SetBool("isRunningRight", true);
               myAnimator.SetBool("isRunningLeft", false);
           } 
           if (myRigidbody.velocity.x < 0)
           {
               myAnimator.SetBool("isRunningLeft", true);
               myAnimator.SetBool("isRunningRight", false);
           }
           if (myRigidbody.velocity.x == 0)
           {
               myAnimator.SetBool("hasStoppedLeft", true);
               myAnimator.SetBool("hasStoppedRight", true);
           }*/
        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Jump(horizontal);
        }
        if (Input.GetKey(KeyCode.Space) && myRigidbody.velocity.y > 0)
        {
            spaceTime -= Time.fixedDeltaTime;
            if (spaceTime < 0f)
            {
                canAdd = false;
                AdditionalJump();
            }
            if (spaceTime < 0.15f && spaceTime > 0f)
            {
                canAdd = true;
                AdditionalJump();
            }
        }
    }
    private void HandleMovement(float horizontal, float vertical)
    {
        myRigidbody.velocity = new Vector2(horizontal * movementSpeed * Time.fixedDeltaTime, myRigidbody.velocity.y);
        /*  if(myRigidbody.velocity.x > 0)
          {
              myAnimator.SetBool("isRunningRight", true);
              myAnimator.SetBool("isRunningLeft", false);
              myAnimator.SetBool("hasStoppedLeft", false);
              myAnimator.SetBool("hasStoppedRight", false);
          }
          if(myRigidbody.velocity.x < 0)
          {
              myAnimator.SetBool("hasStoppedLeft", false);
              myAnimator.SetBool("hasStoppedRight", false);
              myAnimator.SetBool("isRunningLeft", true);
              myAnimator.SetBool("isRunningRight", false);
          }
          if(myRigidbody.velocity.x == 0)
          {
              myAnimator.SetBool("hasStoppedLeft", true);
              myAnimator.SetBool("hasStoppedRight", true);
              myAnimator.SetBool("isRunningRight", false);
              myAnimator.SetBool("isRunningLeft", false);
          }*/

    }
    private void Jump(float horizontal)
    {
        myRigidbody.velocity = new Vector2(horizontal * Time.fixedDeltaTime, jumpForce * Time.fixedDeltaTime/* * jumpModifier*/);
    }
    private void AdditionalJump()
    {
        if (canAdd)
        {
            Debug.Log("Added velocity");
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce * additionalForce);
        }
        else
        {
            Debug.Log("Didnt add velocity");
        }
    }
}


