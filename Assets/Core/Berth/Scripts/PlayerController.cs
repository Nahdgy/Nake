using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] PlayerController playerController;
    
    private Rigidbody rb;

    private InputManager inputManager;

    private Animator animator;

    private bool hasAnimator;

    private int xVel, yVel;

    private const float speed = 2f;

    private Vector2 currentVelocity;

    void Start()
    {
        hasAnimator = TryGetComponent<Animator>(out animator);
        rb = GetComponent<Rigidbody>();
        inputManager= GetComponent<InputManager>();

        xVel = Animator.StringToHash("xVelocity");
        yVel = Animator.StringToHash("yVelocity");
    }

    private void Move()
    {
        if (!hasAnimator) return;

        float targetSpeed = speed;
        if (inputManager.Move == Vector2.zero) targetSpeed = 0.1f;

        currentVelocity.x = Mathf.Lerp(currentVelocity.x, inputManager.Move.x * targetSpeed, ;
        currentVelocity.y = targetSpeed * inputManager.Move.y;

        var xVelDiff = currentVelocity.x - rb.velocity.x;
        var zVelDiff = currentVelocity.y - rb.velocity.z;

        rb.AddForce(transform.TransformVector(new Vector3(xVelDiff, 0, zVelDiff)), ForceMode.VelocityChange);

        animator.SetFloat(xVel, currentVelocity.x);
        animator.SetFloat (yVel, currentVelocity.y);
    }

}
