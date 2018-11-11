using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    // Use this for initialization
    public float MoveRange = 10;
    float InitPos;
    int state = 0;
    public float speed = 10f;
    void Start()
    {
        InitPos = this.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == 0)
        {
            this.transform.Translate(Time.deltaTime * speed * Vector2.left);
            if (this.transform.position.x - InitPos < -10)
            {
                state = 1;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            this.transform.Translate(Time.deltaTime * speed * Vector2.right);
            if (this.transform.position.x > InitPos)
            {
                state = 0;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
