using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Starting position for the parallax game object
    Vector2 startingPosition;

    // Start Z value of the parallax game object
    float startingZ;

    // Distance that the camera has moved from the starting position of the parallax object
    Vector2 canMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.position.z;

    float clippingPlance => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    // The futher the object from the player, faster the ParallaxEffect object will move. Drag it's Z value closer to the target to make it move slower  
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlance;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        // When the target moves, move the parallax object the same distance time a multiplier
        Vector2 newPosition = startingPosition + canMoveSinceStart * parallaxFactor;

        // The X/Y position changes based on target travel speed time the parallax factor, but Z stays comsistent
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ); 
    }
}
