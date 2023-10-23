using UnityEngine;

public class SpaceCharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 2f;
    public float idleTime = 5f;

    private float lastInputTime;
    private Vector3 targetRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, moveZ, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

        float rotateX = Input.GetAxis("Mouse X");
        float rotateY = Input.GetAxis("Mouse Y");

        targetRotation += new Vector3(-rotateY, rotateX, 0f) * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(targetRotation);

        if (Input.anyKey)
        {
            lastInputTime = Time.time;
        }

        if (Time.time - lastInputTime > idleTime)
        {
            Vector3 targetPosition = new Vector3(0f, 0f, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
            targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime);
        }
    }
}