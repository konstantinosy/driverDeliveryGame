using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define a class named FollowCamera that inherits from MonoBehaviour.
public class FollowCamera : MonoBehaviour
{
    // Serialized GameObject var named thingToFollow so we can reference in the editor which object to follow.(The car)
    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        // Set the position of the camera to the position of the thingToFollow object which in this case is the car.
        // Add a new Vector3(0, 0, -10) to the position of the car to make the camera follow the car from a distance.
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
