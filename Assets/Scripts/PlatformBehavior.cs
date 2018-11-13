using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{

    [SerializeField]
    public float leftBound;
    public float rightBound;
    public float speed;
    int dim = 0;
    const int LEFT = 0;
    const int RIGHT = 1;

    Rigidbody2D rigidbody;
    // Use this for initialization
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (dim == LEFT)
        {
            rigidbody.MovePosition(pos + speed * Time.deltaTime * Vector2.left);
            if (transform.localPosition.x <= leftBound)
            {
                dim = RIGHT;
            }
        }
        else
        {
            // transform.Translate(speed * Time.deltaTime * Vector3.right);
            rigidbody.MovePosition(pos + speed * Time.deltaTime * Vector2.right);
            if (transform.localPosition.x >= rightBound)
            {
                dim = LEFT;
            }

        }
    }
}
