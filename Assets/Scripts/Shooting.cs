﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    PhotonView view;
    //public CircleCollider2D circleCollider;

    public float firePower;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    IEnumerator HandleFire()
    {
        Debug.Log("Waited");
        yield return new WaitForSeconds(0.5f);
    }
    void Shoot()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(-firePoint.right * firePower * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}
