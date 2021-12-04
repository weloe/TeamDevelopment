using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW2Cmera : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public float speed;
    void Start()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speed);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= player.position.y)
        {
            transform.position = new Vector3(player.position.x, 0, -10f);
        }

    }
}
