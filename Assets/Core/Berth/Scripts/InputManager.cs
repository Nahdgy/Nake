using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private PlayerInput PlayerInput;

    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }

    private InputActionMap _currentMap;
    private InputAction _moveAction, _lookAction;

    private void Awake()
    {
        _currentMap = PlayerInput.currentActionMap;
        _moveAction = _currentMap.FindAction("Move");
        _lookAction = _currentMap.FindAction("Look");

        _moveAction.performed += OnMove;
        _lookAction.performed += OnLook; 
        
        _moveAction.canceled += OnMove;
        _lookAction.canceled += OnLook;


    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    } 
    
    private void OnLook(InputAction.CallbackContext context)
    {
        Look = context.ReadValue<Vector2>();
    }

   void OnEnable()
    {
        _currentMap.Enable(); 
    }

    void OnDisable()
    {
        _currentMap.Disable();
    }

   
 
}
