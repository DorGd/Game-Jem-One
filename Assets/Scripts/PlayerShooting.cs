using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject beamPrefab;
    public float beamForce = 10;
    public float recoil = 40f;
    private Rigidbody2D _rb;
    // Update is called once per frame
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        _rb.AddForce(firePoint.up * -recoil, ForceMode2D.Force);
        GameObject beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = beam.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * beamForce, ForceMode2D.Impulse);
    }
}

