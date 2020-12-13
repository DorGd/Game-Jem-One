using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject beamPrefab;
    public float beamForce = 10;
    private Rigidbody2D _rbPlayer;
    // Update is called once per frame
    private void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        _rbPlayer.transform.DOShakePosition(0.1f, 0.1f, 1); // recoil
        rb.AddForce(firePoint.up * beamForce, ForceMode2D.Impulse);
    }
}

