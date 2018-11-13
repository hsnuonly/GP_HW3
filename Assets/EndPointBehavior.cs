using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPointBehavior : MonoBehaviour
{
    public GameObject mask;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        mask.SetActive(true);
        Destroy(this.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Stage2");
    }
}
