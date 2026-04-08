using UnityEngine;

public class AsteroidHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget; // Store the target that the asteroid will follow
    }

    private void Update()
    {
        if (target == null) return; // Do nothing if there is no target

        Vector3 direction = (target.position - transform.position).normalized; // Calculate the direction toward the target
        Quaternion targetRotation = Quaternion.LookRotation(direction);  // Create the rotation needed to face the target
        // Rotate toward the target
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move the asteroid forward
    }
}