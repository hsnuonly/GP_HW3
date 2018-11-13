using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPointBehavior : MonoBehaviour
{

    // Use this for initialization
    public int index;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Player") return;
        if (RecordManager.index < this.index)
        {
            RecordManager.LastRecord = this.transform.position;
            RecordManager.index = this.index;
        }
        Destroy(this.gameObject);
    }
}
