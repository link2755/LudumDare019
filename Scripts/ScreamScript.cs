using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamScript : MonoBehaviour
{
    public bool active = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bandido" && active == true)
        {
            Debug.Log("WAKE ME UP");
            other.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().ladraoAssustado;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bandido" && active == true)
        {
            Debug.Log("inside");
            other.GetComponent<SpriteRenderer>().sprite = player.GetComponent<PlayerController>().ladraoAssustado;
        }
    }
}
