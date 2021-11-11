using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    private Vector3 pos;
    private float startingY;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        startingY = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        pos = cam.WorldToViewportPoint(transform.position);
        if(pos.z > 0) // Is in viewport
        {
            Attack();
            Turn();
        }
    }
    void Attack()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, startingY, player.position.z), ref velocity, 0.25f, 150f * Time.fixedDeltaTime);
    }
    void Turn()
    {
        if(player.position.x - transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0, 180f, 0, 0);
        }
    }
}
