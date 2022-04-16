using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviour
{
    private Vector3 pos;
    private Transform player;

    PhotonView _view;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent;
        _view = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_view.IsMine)
        {
            transform.position = player.position;
            pos = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            if (pos.z > -0.995f && pos.z < 0.995f)
            {
                float rot_z = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
            }
            else
            {

            }
        }
    }
}
