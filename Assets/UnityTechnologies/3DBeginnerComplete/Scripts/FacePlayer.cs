using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform player;
    private float lookRange = 5f;
    private float rotation_speed = 100;

    // Find the player object - need its transform
    private void Start()
    {
        player = (GameObject.Find("JohnLemon")).transform;
    }

    private void Update()
    {

        // Calculate the difference between player and enemy position vectors
        Vector3 diff = player.position - transform.position;

        // Check if the distance is in range of when we want to face the player
        if (diff.magnitude <= lookRange)
        {
            // Debug.Log("Player in range: " + diff.magnitude);
            Face(diff);
        }
    }

    private void Face(Vector3 diff)
    {

        // Normalize the difference between enemy and player vectors so it only represents direction
        diff = diff.normalized;

        // Now find the dot product
        float dot = Vector3.Dot(diff, transform.forward);
        Debug.Log("Dot product: " + dot);

        // Calculate the angle to rotate based on the dot product
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // Find cross product between forward direction and direction to player to determine the sign of rotation
        Vector3 crossProduct = Vector3.Cross(transform.forward, diff);

        // Ensure the angle is within the correct range
        if (crossProduct.y < 0)
        {
            angle = -angle;
        }

        // Rotate to face the player. This happens immediately and it's pretty choppy so I tried to fix it in the following lines
        transform.Rotate(Vector3.up, angle);

        /* The following was sourced from chatGPT in a vain attempt to try and smooth the movement out. It
        sort of worked but ideally I could delay the movement by a bit, because in the game world the Gargoyle
        hasn't spotted the player. It doesn't make sense for the movement to track them exactly. I don't have
        any familiarity with Unity so with the constraints on using the dot product for this and time this
        will have to do */

        // Calculate the target rotation based on the angle to rotate
        Quaternion target_rotation = Quaternion.AngleAxis(angle, Vector3.up);

        // Rotate towards the target based on rotation_speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation, rotation_speed * Time.deltaTime);
    }
}
