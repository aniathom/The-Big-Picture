using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henry : MonoBehaviour
{
    Rigidbody rb;
    float dirx, moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if(Input.GetButtonDown("Jump") && rb.velocity.y == 0) {
            rb.AddForce(Vector2.up * 400f);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirx, rb.velocity.y);
    }
}
