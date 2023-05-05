using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed, _playerHeight = 2, _moveMultiplier;
    private float _horizontalInput, _verticalInput;
    public float _gravityMultiplier;

    [SerializeField]
    private bool _isGrounded;
    public bool _canMove = true;

    [SerializeField]
    private LayerMask _whatIsGround;

    private Vector3 _moveDirection, _velocity = Vector3.zero;

    [SerializeField]
    Animator _anim;

    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private Transform _oriantation;

    public SanityBar SanityBar;

    bool sane;
   
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        ControllerInputs();
        LimitVelocity();
        GroundCheck();
        WalkAnimation();
    }

    private void OnTriggerEnter(Collider pills)
    {

         if (pills.gameObject.tag == "pills")
         {
                SanityBar.t += 100;
                // SanityBar.slider.value = 100f;
                Debug.Log("recovered");
                Destroy(pills.gameObject);
         }
       
    }
    private void WalkAnimation()
    {
        float _palyerVelocity = Mathf.Abs(_rb.velocity.x);
        _anim.SetFloat("Speed", _palyerVelocity);
    }
    void ControllerInputs()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

    }
    void GroundCheck()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight * .5f + .2f, _whatIsGround);
    }
    void Move()
    {
        if (_canMove)
        {
            _moveDirection = _oriantation.forward * _verticalInput + _oriantation.right * _horizontalInput;
            if (_isGrounded)
            {
                _rb.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
            }
            else if (!_isGrounded) _rb.AddForce(_moveDirection.normalized * _moveSpeed * _moveMultiplier, ForceMode.Force);
        }
    }
    void LimitVelocity()
    {
        Vector3 _vel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);
        if (_vel.magnitude > _moveSpeed)
        {
            Vector3 _limitVel = _vel.normalized * _moveSpeed;
            _rb.velocity = new Vector3(_limitVel.x, _rb.velocity.y, _limitVel.z);
        }
    }

}
