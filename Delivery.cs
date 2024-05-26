using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // bool var named hasPackage.
    bool hasPackage;
    // Serialized float var named destroyTime.
    [SerializeField] float destroyTime = 0.5f;
    // Serialized Color32 var named hasPackageColor. (Green-ish color.)
    [SerializeField] Color32 hasPackageColor = new Color32(50, 255, 0, 255);
    // Serialized Color32 var named noPackageColor. (White/default color.)
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    // SpriteRenderer var named spriteRenderer.
    SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // OnTriggerEnter2D is called when the Collider other enters the trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the tag of the other object is "Package" and hasPackage is false.
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!!!"); // Log message.
            hasPackage = true; // Set hasPackage to true.
            Destroy(other.gameObject, destroyTime); // Destroy the package after destroyTime(0.5).
            spriteRenderer.color = hasPackageColor; // Change the color of the car to hasPackageColor.
        }

        if (other.tag == "Customer" && hasPackage) // If the tag of the other object is "Customer" and hasPackage is true.
        {
            Debug.Log("Package delivered!!!"); // Log message.
            hasPackage = false; // Set hasPackage to false.
            spriteRenderer.color = noPackageColor; // Change the color of the car to noPackageColor.
        }
    }
}
