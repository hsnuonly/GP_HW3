using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform player;
    public float buttom;
    // Use this for initialization
    Vector3 offset;
    void Start()
    {
        offset = this.transform.position - player.transform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = player.transform.position + offset;
        temp.y = Mathf.Max(buttom, temp.y);
        // temp.x = player.position.x;
        // this.transform.position = temp;

        this.transform.position = temp;
    }
}
