using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private PlayerController2D playerController;
    public Collider2D playerCollider;
    public Collider2D self;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(self,playerCollider);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("A");
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Wall"))
        {
            playerController.isGrounded = true;
            playerController.spaceTime = 0.25f;
        }
    }
    void OnCollisionExit2D()
    {
        playerController.isGrounded = false;
    }
}
