using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPlatformBehavior : MonoBehaviour
{

    public float lowerBound;
    public float upperBound;
    public float speed;

    int dim = 0;
    const int DOWN = 0;
    const int UP = 1;

    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = this.transform.position;
        if (dim == DOWN)
        {
            // rigidbody.MovePosition(pos + Time.deltaTime * speed * Vector2.down);
            this.transform.Translate(Time.deltaTime * speed * Vector3.down);
            if (this.transform.localPosition.y <= lowerBound)
            {
                dim = UP;
            }
        }
        else
        {
            // rigidbody.MovePosition(pos + Time.deltaTime * speed * Vector2.up);
            this.transform.Translate(Time.deltaTime * speed * Vector3.up);
            if (this.transform.localPosition.y >= upperBound)
            {
                dim = DOWN;
            }
        }
    }
}
