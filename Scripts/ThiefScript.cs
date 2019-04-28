using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefScript : MonoBehaviour
{
    public Sprite scaredSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The Stealing Script is in PlayerController
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Scream Area")
        {
            GetComponent<SpriteRenderer>().sprite = scaredSprite;
        }
    }
}
