using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    GameControls _playerInput;
    CharacterController _characterController;

    Vector3 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _currentRunMovement;
    Vector3 _appliedMovement;
    Vector3 _cameraRelativeMovement;
    bool _isMovementPressed;
    bool _isRunPressed;
    bool _isInDialogue;

    float _rotationFactorPerFrame = 15;

    float _speedMultiplier = 5;
    float _runMultiplier = 8;
    int _zero = 0;

    float _gravity = -9.8f;
    float _groundedGravity = -.05f;
    bool _isJumpPressed = false;
    float _initialJumpVelocity;
    float _maxJumpHeight = 1;
    float _maxJumpTime = .75f;
    bool _isJumping = false;
    bool _requireNewJumpPress = false;
    int _jumpCount = 0;
    Dictionary<int, float> _initialJumpVelocities = new Dictionary<int, float>();
    Dictionary<int, float> _jumpGravities = new Dictionary<int, float>();
    Coroutine _currentJumpResetRoutine = null;

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    public CharacterController CharacterController { get { return _characterController; } }
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public Coroutine CurrentJumpResetRoutine { get { return _currentJumpResetRoutine; } set { _currentJumpResetRoutine = value;} }
    public Dictionary<int,float> JumpGravities { get { return _jumpGravities; } }
    public Dictionary<int,float> InitialJumpVelocities { get { return _initialJumpVelocities; } }
    public int JumpCount { get { return _jumpCount; } set { _jumpCount = value; } }
    public bool IsMovementPressed { get { return _isMovementPressed; } }
    public bool IsRunPressed { get { return _isRunPressed; } }
    public bool IsJumping { set { _isJumping = value; } }
    public bool RequireNewJumpPress { get { return _requireNewJumpPress; } set { _requireNewJumpPress = value; } }
    public bool IsJumpPressed { get { return _isJumpPressed; } }
    public bool IsInDialogue { get { return _isInDialogue; } set { _isInDialogue = value; } }
    public float Gravity { get { return _gravity; } }
    public float RunMultiplier { get { return _runMultiplier; } }
    public float SpeedMultiplier { get { return _speedMultiplier; } }
    public float CurrentMovementY { get { return _currentMovement.y; } set { _currentMovement.y = value; } }
    public float AppliedMovementY { get { return _appliedMovement.y; } set { _appliedMovement.y = value; } }
    public float AppliedMovementX { get { return _appliedMovement.x; } set { _appliedMovement.x = value; } }
    public float AppliedMovementZ { get { return _appliedMovement.z; } set { _appliedMovement.z = value; } }
    public Vector2 CurrentMovementInput { get { return _currentMovementInput; } }
    

    private void Awake()
    {
        _playerInput = new GameControls();
        _characterController = GetComponent<CharacterController>();

        _states = new PlayerStateFactory(this);
        _currentState = _states.Grounded();
        _currentState.EnterState();
        

        _playerInput.InGame.Move.started += OnMovementInput;
        _playerInput.InGame.Move.canceled += OnMovementInput;
        _playerInput.InGame.Move.performed += OnMovementInput;
        _playerInput.InGame.Run.started += onRun;
        _playerInput.InGame.Run.canceled += onRun;
        _playerInput.InGame.Jump.started += onJump;
        _playerInput.InGame.Jump.canceled += onJump;

        setupJumpVariables();
    }

    void setupJumpVariables()
    {
        float timeToApex = _maxJumpTime / 2;
        float initialGravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
        float secondJumpGravity = (-2 * (_maxJumpHeight + 2)) / Mathf.Pow((timeToApex * 1.25f), 2);
        float secondJumpInitialVelocity = (2 * (_maxJumpHeight + 2)) / (timeToApex * 1.25f);
        float thirdJumpGravity = (-2 * (_maxJumpHeight + 4)) / Mathf.Pow((timeToApex * 1.5f), 2);
        float thirdJumpInitialVelocity = (2 * (_maxJumpHeight + 4)) / (timeToApex * 1.5f);

        _initialJumpVelocities.Add(1, _initialJumpVelocity);
        _initialJumpVelocities.Add(2, secondJumpInitialVelocity);
        _initialJumpVelocities.Add(3, thirdJumpInitialVelocity);

        _jumpGravities.Add(0, initialGravity);
        _jumpGravities.Add(1, initialGravity);
        _jumpGravities.Add(2, secondJumpGravity);
        _jumpGravities.Add(3, thirdJumpGravity);
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = _cameraRelativeMovement.x;
        positionToLookAt.y = _zero;
        positionToLookAt.z = _cameraRelativeMovement.z;
        Quaternion currentRotation = transform.rotation;
        if (_isMovementPressed)
        {
            Debug.DrawRay(transform.position, positionToLookAt);
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    private void Start()
    {
        _characterController.Move(_appliedMovement * Time.deltaTime);
    }

    private void Update()
    {
        handleRotation();
        _currentState.UpdateStates();
        _cameraRelativeMovement = ConvertToCameraSpace(_appliedMovement);
        _characterController.Move(_cameraRelativeMovement * Time.deltaTime);
    }

    Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
        float currentYvalue = vectorToRotate.y;

        
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        Vector3 cameraForwardZProduct = vectorToRotate.z * cameraForward;
        Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;

        Vector3 vectorRotatedToCameraSpace = cameraForwardZProduct + cameraRightXProduct;
        vectorRotatedToCameraSpace.y = currentYvalue;
        return vectorRotatedToCameraSpace;
        
        /*
        Vector3 rotatedVector = new Vector3(vectorToRotate.x, 0, vectorToRotate.z);
        var rot = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        rotatedVector = rot * rotatedVector;
        rotatedVector.y = currentYvalue;
        return rotatedVector;
        */
    }




    void onRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    void onJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        _requireNewJumpPress = false;
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    private void OnEnable()
    {
        _playerInput.InGame.Enable();
    }

    private void OnDisable()
    {
        _playerInput.InGame.Disable();
    }
}
