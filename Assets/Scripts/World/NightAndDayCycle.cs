using System.Net.Sockets;
using UnityEngine;

public class NightAndDayCycle : MonoBehaviour
{
    // Rotation of Directional Light
    private float rotationX = 0f;

    // 180/0.15 = 20 minutes Gameplay
    private float degreesPerSecond = 0.15f;


    // Initialize rotation X to 0
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }


    void Update()
    {
        // Increment rotation over time
        rotationX += Time.deltaTime * degreesPerSecond;

        // If rotation exceeds 180(sunset), reset to 0 
        if (rotationX >= 180f)
        {
            // Game ends
            //GameOver()
            rotationX -= 180f;
        }

        // Apply rotation around the X axis for sunrise/sunset effect
        transform.rotation = Quaternion.Euler(rotationX, 0, 0);
    }
}