using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float AnimBlendSpeed = 8.9f, UpperLimit = -40f, BottomLimit = 70f, LookSensitivity = 21.9f;
    [SerializeField] private Transform CameraRoot, Camera;

    public bool _canMove = true;

    public PlayerCam _camera;

    private Rigidbody rb;

    private InputManager inputManager;

    private Animator animator;

    private bool hasAnimator;

    private int xVel, yVel;

    private const float speed = 2f;

    public Vector2 currentVelocity;

    private float xRot;

    private bool inInventory = false;
    public bool InInventory { get { return inInventory; } set { inInventory = value; } }

    void Start()
    {
        hasAnimator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();

        xVel = Animator.StringToHash("X_Velocity");
        yVel = Animator.StringToHash("Y_Velocity");
    }

    private void FixedUpdate()
    {
        Move();
        LimitVelocity();
    }

    private void LateUpdate()
    {
        CamMov();
    }

    private void Move()
    {
        if (_canMove && !inInventory)
        {
            if (!hasAnimator) return;

            float targetSpeed = speed;
            if (inputManager.Move == Vector2.zero) targetSpeed = 0.1f;

            currentVelocity.x = Mathf.Lerp(currentVelocity.x, inputManager.Move.x * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
            currentVelocity.y = Mathf.Lerp(currentVelocity.y, inputManager.Move.y * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);

            var xVelDiff = currentVelocity.x - rb.velocity.x;
            var zVelDiff = currentVelocity.y - rb.velocity.z;

            rb.AddForce(transform.TransformVector(new Vector3(xVelDiff, 0, zVelDiff)), ForceMode.VelocityChange);

            animator.SetFloat(xVel, currentVelocity.x);
            animator.SetFloat(yVel, currentVelocity.y);
        }
    }

    private void CamMov()
    {
        if (!hasAnimator) return;

        if (_camera._canSee == true && !inInventory)
        {
            var JoystickX = inputManager.Look.x;
            var JoystickY = inputManager.Look.y;
            Camera.position = CameraRoot.position;

            xRot -= JoystickY * LookSensitivity * Time.deltaTime;
            xRot = Mathf.Clamp(xRot, UpperLimit, BottomLimit);

            Camera.localRotation = Quaternion.Euler(xRot, 0, 0);
            transform.Rotate(Vector3.up, JoystickX * LookSensitivity * Time.deltaTime);
        }
    }

    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (_vel.magnitude > speed)
        {
            Vector3 _limitVel = _vel.normalized * speed;
            rb.velocity = new Vector3(_limitVel.x, rb.velocity.y, _limitVel.z);
        }
    }
}
