using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    private float timer = 10f;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = gameObject.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0f && view.IsMine)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!view.IsMine)
            return;
        if (col.gameObject.CompareTag("Player"))
        {
            return;
        }
        PhotonNetwork.Destroy(gameObject);

    }
}
