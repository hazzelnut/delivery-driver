using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery: MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.2f;
    [SerializeField] Color32 hasPackageColor = new Color32(204, 173, 0, 254);
    [SerializeField] Color32 noPackageColor = new Color32(229, 80, 77, 255);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch! I bumped into something!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BubbleTea" && !hasPackage) 
        {
            Debug.Log("I got the bubble tea baby!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
