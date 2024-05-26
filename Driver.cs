using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a class named Driver that inherits from MonoBehaviour. 
// MonoBehaviour is the base class from which every Unity script derives.
public class Driver : MonoBehaviour
{
    // Serialized float var named steerSpeed.
    [SerializeField] float steerSpeed = 300;
    // Serialized float var named moveSpeed.
    [SerializeField] float moveSpeed = 20;
    // Serialized float var named slowSpeed.
    [SerializeField] float slowSpeed = 20;
    // Serialized float var named fastSpeed.
    [SerializeField] float fastSpeed = 30;

    // Update is called once per frame.
    void Update()
    {
        // Define variable named steerAmount(float) to get input from the horizontal axis.
        // The Horizontal axis is the left and right arrow keys or the A and D keys.
        // It is multiplied by steerSpeed and Time.deltaTime. 
        // It is multiplied by deltaTime to make the movement frame rate independent.
        // steerSpeed is previously defined as 300 and is Serializable as to be visible in the Unity Inspector.
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        // Same as above but for the vertical axis to control the movement of the car.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // Rotate the car on the Z-axis by the steerAmount.
        transform.Rotate(0, 0, -steerAmount);
        // Move the car on the Y-axis by the moveAmount.
        transform.Translate(0, moveAmount, 0);
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger.
    // Collider2D is a 2D collider that is used to handle collisions in a 2D game.
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // If the tag of the other object is "Boost", then the moveSpeed is set to fastSpeed.
        if (other.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
    }

    // OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider.
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // Then the moveSpeed is set to slowSpeed.
        moveSpeed = slowSpeed;
    }
}
