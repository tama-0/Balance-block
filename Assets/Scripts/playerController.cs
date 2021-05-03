using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController: MonoBehaviour
{
    public float speed = 15.0f;
    public float limit = 10.0f;
    public Rigidbody rigid;

    Vector2 SquareToCircle(Vector2 input)
    {
        Vector2 output;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2.0f);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2.0f);
        return output;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float rad = Vector2.Angle(Vector2.right, new Vector2(x,z)) * Mathf.Deg2Rad;
        float r = Mathf.Sqrt(x * x + z * z) * (0.7071f + 0.2928f * Mathf.Abs(Mathf.Cos(2 * rad)));
        if (Input.anyKey)
        {
            double theta = -(Mathf.PI - Mathf.Atan2(x, z)) * (180 / Mathf.PI);
            rigid.rotation = Quaternion.AngleAxis((float)theta, Vector3.up);
        }
        x = r * Mathf.Cos(rad) * speed;
        z = z >= 0 ? r * Mathf.Sin(rad) * speed : -r * Mathf.Sin(rad) * speed;
        if (r*speed > limit)
        {
            x = Mathf.Cos(rad) * limit;
            z = z >= 0 ? Mathf.Sin(rad) * limit : -Mathf.Sin(rad) * limit;
        }
        rigid.AddForce(x, 0, z);
    }
}
