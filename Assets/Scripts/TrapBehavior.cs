using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -5)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.GetComponent<Collider2D>());
    }
}
