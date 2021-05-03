using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController: MonoBehaviour
{
    public double speed = 20.0;
    public double limit = 30.0;
    public Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        double x = Input.GetAxis("Horizontal") * speed;
        double z = Input.GetAxis("Vertical") * speed;
        if (Input.anyKey)
        {
            double theta = -(Math.PI - Math.Atan2(x, z)) * (180 / Math.PI);
            rigid.rotation = Quaternion.AngleAxis((float)theta, Vector3.up);
        }
        if (rigid.velocity.magnitude >= limit)
        {
            x = 0;
            z = 0;
        }
        rigid.AddForce((float)x, 0, (float)z);
    }
}
