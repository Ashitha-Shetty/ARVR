using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the object
    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to this object
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody component is not set to kinematic
        if (rb.isKinematic)
        {
            rb.isKinematic = false;
        }
    }

    void Update()
    {
        // Get input from keyboard (WASD or arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 direction based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody
        MoveObject(movement);
    }

    void MoveObject(Vector3 direction)
    {
        // Calculate the new position based on speed and direction
        Vector3 newPosition = rb.position + direction * speed * Time.deltaTime;

        // Move the Rigidbody to the new position
        rb.MovePosition(newPosition);
    }
}
