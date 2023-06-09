using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;       // default false 
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32();

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // collision action
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Oops!");
    }
    
    // actions when interacting with a trigger
    void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("TRIGGER");

        // if the thing we trigger is a package
        // {
        //      then print "package picked up" to the console
        // }

        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
