using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour
{

    // Use this for initialization
    public Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            collider.transform.position = target.transform.position - ((Vector3)collider.offset);
        }
    }
}
