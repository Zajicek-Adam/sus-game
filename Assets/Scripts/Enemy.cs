using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float range;
    public GameObject bean;
    public Transform firePoint;
    private bool shouldShoot = false;
    private float firerate = 2.5f;
    private Vector3 pos; // Position in the camera viewport
    private Vector3 originalPosition; // Position before subtracting the Range
    private float startingY;
    private Vector3 bulletVelocity = Vector3.zero;
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
        originalPosition = transform.position;
        if (pos.z > 0 && pos.x > 0 && pos.y > 0) // Is in viewport
        {
            Attack();
        }
        Turn();
    }
    void Attack()
    {
        if(transform.position.x - player.position.x > 0 && player.position.x - transform.position.x < 8)
        {
            range = 8f;
        }
        else if(transform.position.x - player.position.x < 0 && transform.position.x - player.position.x < 8)
        {
            range = -8f;
        }
        if (Mathf.Abs(transform.position.x - player.position.x) < 8)
        {
            shouldShoot = true;
        }
        else
        {
            shouldShoot = false;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x + range, startingY, player.position.z), ref velocity, 0.25f, 150f * Time.fixedDeltaTime);
            shouldShoot = true;
        }

        if (shouldShoot)
        {
            firerate -= Time.deltaTime;
            Vector2 offset = new Vector2(Random.Range(0f,1f), Random.Range(0f, 1f));
            if (firerate <= 0)
            {
                firerate = 2.5f;
                GameObject instantiatedBean;
                instantiatedBean = Instantiate(bean);
                instantiatedBean.transform.position = firePoint.position;
                instantiatedBean.SetActive(true);
                instantiatedBean.GetComponent<Rigidbody2D>().velocity = (player.position - instantiatedBean.transform.position).normalized * 400f * Time.fixedDeltaTime;
            }
        }
    }
    void Turn()
    {
        if (player.position.x - originalPosition.x < 0)
        {
            transform.rotation = new Quaternion(0, 180f, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0f, 0, 0);
        }
    }
}
