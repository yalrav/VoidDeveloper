using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour
{
    public float Speed = 0.3f;
    private bool rotationEnabled = true;
    public float JumpForce = 1f;
    public float idleTime = 5f;
    private float lastInputTime;
    private Vector3 targetRotation;
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody _rb;
    private CapsuleCollider _collider;
    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(_collider.bounds.center.x, _collider.bounds.min.y, _collider.bounds.center.z);


            return Physics.CheckCapsule(_collider.bounds.center, bottomCenterPoint, _collider.bounds.size.x / 2 * 0.9f, GroundLayer);
        }
    }
    private void StopRotation()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            rotationEnabled = !rotationEnabled;
        }
    }

    private Vector3 _movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        SpeedChange();
        JumpLogic();
        MoveLogic();
        RotateLogic();
        deJumpLogic();
    }
     void Update()
    {
     
    }

    private void MoveLogic()
    {
        _rb.AddForce(_movementVector * Speed, ForceMode.Impulse);
    }

    private void JumpLogic()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            _rb.AddForce(transform.TransformDirection(Vector3.up * JumpForce), ForceMode.Impulse);
        }
    }
    private void deJumpLogic()
    {
        if (Input.GetKey(KeyCode.C))
        {
            _rb.AddForce(transform.TransformDirection(Vector3.down * JumpForce), ForceMode.Impulse);
        }
    }

    private void RotateLogic()
    {
        float lookHorizontal = Input.GetAxis("Mouse X");
        float lookVertical = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * lookHorizontal * 0.7f);
        transform.Rotate(Vector3.right * lookVertical * 0.7f);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * 0.5f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * -0.5f);
        }
    }
    private void SpeedChange()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Speed = Speed + 0.1f;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            Speed = Speed - 0.1f;
        }
    }
}