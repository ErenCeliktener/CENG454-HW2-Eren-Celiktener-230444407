// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Eren Celiktener | Student ID: 230444407
using UnityEngine;
public class FlightController : MonoBehaviour
{
// Flight sensitivity and speed settings
[SerializeField] private float pitchSpeed = 45f; // degrees/second
[SerializeField] private float yawSpeed = 45f; // degrees/second
[SerializeField] private float rollSpeed = 45f; // degrees/second
[SerializeField] private float thrustSpeed = 5f; // units/second
private Rigidbody rb;
void Start() // Called once at the start of the game
{
rb = GetComponent<Rigidbody>();
rb.freezeRotation = true; // Prevents the physics engine from rotating the object
}
void Update() // Process flight mechanics in every frame
{
HandleRotation();
HandleThrust();
}
private void HandleRotation()
{
// Pitch Control
float pitchInput = Input.GetAxis("Vertical");
if (pitchInput != 0) transform.Rotate(Vector3.right, pitchInput * pitchSpeed * Time.deltaTime);
// Yaw Control
float yawInput = Input.GetAxis("Horizontal");
if (yawInput != 0) transform.Rotate(Vector3.up, yawInput * yawSpeed * Time.deltaTime);
// Roll Control
float rollInput = 0f;
// Q for left roll, E for right roll and Cancel each other if both are pressed
if (Input.GetKey(KeyCode.Q)) rollInput += 1f;
if (Input.GetKey(KeyCode.E)) rollInput -= 1f;
if (rollInput != 0) transform.Rotate(Vector3.forward, rollInput * rollSpeed * Time.deltaTime);
}
private void HandleThrust()
{
// Forward Thrust    
if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
}
}