using UnityEngine;

public class ProjectileLaunchPointMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float rotationSpeed = 2f;
    private bool rotateClockwise = true; // Flag to control rotation direction
    
    private Transform launchPointTransform;

    void Start()
    {
        launchPointTransform = transform;
    }
    void Update()
    {
        // Calculate the rotation angle based on the rotation direction
        float rotationAngle = rotateClockwise ? 90f : -90f;

        //transform.position = transform.parent.forward;
        // Rotate the launch point around the player
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationAngle * Time.deltaTime * rotationSpeed);

        // Check if the rotation angle exceeds 90 degrees or -90 degrees
        if (Mathf.Abs(transform.localEulerAngles.z) >= 90f)
        {
            // Reverse the rotation direction
            rotateClockwise = !rotateClockwise;
        }
    }
}