using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlat : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name.Equals ("Henry"))
        {
            Invoke("DropPlatform", 1.2f);
            Destroy(gameObject, 2f);
        }
    }
    void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
