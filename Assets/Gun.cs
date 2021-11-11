using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Vector3 pos;
    public Transform player;
    public Transform banana;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        pos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - banana.position).normalized;
        Debug.Log("x: " + pos.x + " | " + "y: " + pos.y + " | " + "z: " + pos.z);
        if(pos.z > -0.995f && pos.z < 0.995f)
        {
            float rot_z = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        }
        else
        {

        }

    }
}
