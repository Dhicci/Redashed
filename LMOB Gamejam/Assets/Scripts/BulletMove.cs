using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;

    public void BulletDirection(Vector2 where)
    {
        rb.velocity = where * speed;
    }
}
