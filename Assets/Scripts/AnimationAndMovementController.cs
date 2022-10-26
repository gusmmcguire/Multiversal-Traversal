using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    GameControls _playerInput;
    CharacterController _characterController;

    Vector3 _currentMovementInput;
    Vector3 _currentMovement;
    Vector3 _currentRunMovement;
    Vector3 _appliedMovement;
    bool _isMovementPressed;
    bool _isRunPressed;

    float _rotationFactorPerFrame = 15;

    float _speedMultiplier = 5;
    float _runMultiplier = 8;

    float _gravity = -9.8f;
    float _groundedGravity = -.05f;
    bool _isJumpPressed = false;
    float _initialJumpVelocity;
    float _maxJumpHeight = 1;
    float _maxJumpTime = .75f;
    bool _isJumping = false;
    int _jumpCount = 0;
    Dictionary<int, float> _initialJumpVelocities = new Dictionary<int, float>();
    Dictionary<int, float> _jumpGravities = new Dictionary<int, float>();
    Coroutine _currentJumpResetRoutine = null;

    private void Awake()
    {
        _playerInput = new GameControls();
        _characterController = GetComponent<CharacterController>();

        _playerInput.InGame.Move.started += context => OnMovementInput(context);
        _playerInput.InGame.Move.canceled += context => OnMovementInput(context);
        _playerInput.InGame.Move.performed += context => OnMovementInput(context);
        _playerInput.InGame.Run.started += onRun;
        _playerInput.InGame.Run.canceled += onRun;
        _playerInput.InGame.Jump.started += onJump;
        _playerInput.InGame.Jump.canceled += onJump;

        setupJumpVariables();
    }

    void setupJumpVariables()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;

        float secondJumpGravity = (-2 * (_maxJumpHeight + 2)) / Mathf.Pow((timeToApex * 1.25f), 2);
        float secondJumpInitialVelocity = (2 * (_maxJumpHeight + 2)) / (timeToApex * 1.25f);
        float thirdJumpGravity = (-2 * (_maxJumpHeight + 4)) / Mathf.Pow((timeToApex * 1.5f), 2);
        float thirdJumpInitialVelocity = (2 * (_maxJumpHeight + 4)) / (timeToApex * 1.5f);

        _initialJumpVelocities.Add(1, _initialJumpVelocity);
        _initialJumpVelocities.Add(2, secondJumpInitialVelocity);
        _initialJumpVelocities.Add(3, thirdJumpInitialVelocity);

        _jumpGravities.Add(0, _gravity);
        _jumpGravities.Add(1, _gravity);
        _jumpGravities.Add(2, secondJumpGravity);
        _jumpGravities.Add(3, thirdJumpGravity);
    }

    void handleJump()
    {
        if (!_isJumping && _characterController.isGrounded && _isJumpPressed)
        {
            if(_jumpCount < 3 && _currentJumpResetRoutine != null)
            {
                StopCoroutine(_currentJumpResetRoutine);
            }
            _isJumping = true;
            _jumpCount += 1;
            _currentMovement.y = _initialJumpVelocities[_jumpCount];
            _appliedMovement.y = _initialJumpVelocities[_jumpCount];
        }
        else if (!_isJumpPressed && _isJumping && _characterController.isGrounded)
        {
            _isJumping = false;
        }
    }

    IEnumerator jumpResetRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _jumpCount = 0;
    }

    void onRun(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    void onJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _currentMovementInput = context.ReadValue<Vector2>();
        _currentMovement.x = _currentMovementInput.x * _speedMultiplier;
        _currentMovement.z = _currentMovementInput.y * _speedMultiplier;
        _currentRunMovement.x = _currentMovementInput.x * _runMultiplier;
        _currentRunMovement.z = _currentMovementInput.y * _runMultiplier;
        _isMovementPressed = _currentMovementInput.x != 0 || _currentMovementInput.y != 0;
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = _currentMovement.x;
        positionToLookAt.y = 0;
        positionToLookAt.z = _currentMovement.z;
        Quaternion currentRotation = transform.rotation;
        if (_isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void handleGravity()
    {
        bool isFalling = _currentMovement.y <= 0 || _isJumpPressed == false;
        float fallMultiplier = 2.0f;
        if (_characterController.isGrounded)
        {
            if(_isJumping)
            {
                _currentJumpResetRoutine = StartCoroutine(jumpResetRoutine());//REFACTOR WITH ANIMATIONS LATER
                if(_jumpCount == 3)
                {
                    _jumpCount = 0;
                }
            }
            _currentMovement.y = _groundedGravity;
            _appliedMovement.y = _groundedGravity;
        }else if (isFalling)
        {
            float previousYVelocity = _currentMovement.y;
            _currentMovement.y = _currentMovement.y + (_jumpGravities[_jumpCount] * fallMultiplier * Time.deltaTime);
            _appliedMovement.y = Mathf.Max((previousYVelocity + _currentMovement.y) * .5f, -20f);
        }
        else
        {
            float previousYVelocity = _currentMovement.y;
            _currentMovement.y = _currentMovement.y + (_jumpGravities[_jumpCount] * Time.deltaTime);
            _appliedMovement.y = (previousYVelocity + _currentMovement.y) * .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleRotation();
        if (_isRunPressed)
        {

            _appliedMovement.x = _currentRunMovement.x;
            _appliedMovement.z = _currentRunMovement.z;
        }
        else
        {
            _appliedMovement.x = _currentMovement.x;
            _appliedMovement.z = _currentMovement.z;
        }
        _characterController.Move(_appliedMovement * Time.deltaTime);
        handleGravity();
        handleJump();
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
