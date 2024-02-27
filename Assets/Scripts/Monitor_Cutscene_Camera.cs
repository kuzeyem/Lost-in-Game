using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor_Cutscene_Camera : MonoBehaviour
{
    public float targetZ = 2.8f;  // Target Z position
    public float moveSpeed = 0.5f;  // Speed of movement

    private bool isMoving = false;  // Flag to check if the object is currently moving
    private float startTime;  // Time when movement started
    private Vector3 startPosition;  // Initial position before movement

    void Start()
    {
        // Set the initial position
        startPosition = transform.position;

        // Use Invoke to wait until the object has loaded, then start moving after 2 seconds
        Invoke("StartMoving", 2.0f);
    }

    void Update()
    {
        // Check if the object is currently moving
        if (isMoving)
        {
            // Calculate the interpolation factor based on time
            float t = (Time.time - startTime) * moveSpeed;

            // Interpolate between the start and target positions
            transform.position = Vector3.Lerp(startPosition, new Vector3(startPosition.x, startPosition.y, targetZ), t);

            // Check if the movement is complete
            if (t >= 1.0f)
            {
                isMoving = false;  // Stop moving

                // Call the method when movement is complete
                GoLevel1();
            }
        }
    }

    void StartMoving()
    {
        // Set the flag to start moving
        isMoving = true;

        // Record the start time for interpolation
        startTime = Time.time;
    }

    void GoLevel1()
    {
        // You can replace this with your actual code to transition to the next level
        SceneManager.LoadScene("Game");
    }
}
