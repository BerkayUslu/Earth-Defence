using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Transform _transform;

    Vector3 rawMovementVector = new Vector3(0, 0, 0);

    [SerializeField] float playerSpeed = 100;
    [SerializeField] float playerRotationSpeed = 100;

    bool isPunching = false;

    private void Awake()
    {
        _transform = transform;

    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isPunching)
        {
            MoveCharacter();
        }

        if (IsCharacterMoving())
        {
            AdjustDirectionModelLooks();

        }

    }
    public void SetPunchingFlag(bool a)
    {
        isPunching = a;
    }
    public bool IsCharacterMoving()
    {
        return rawMovementVector[0] != 0 || rawMovementVector[2] != 0;
    }

    private void MoveCharacter()
    {
        _transform.position = new Vector3(rawMovementVector[0] * Time.deltaTime + _transform.position.x, _transform.position.y, rawMovementVector[2] * Time.deltaTime + _transform.position.z);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var adjustedSpeed = playerSpeed / 1000;
        var xValue = context.ReadValue<Vector2>()[0];
        var zValue = context.ReadValue<Vector2>()[1];
        rawMovementVector = new Vector3(xValue * adjustedSpeed,0, zValue * adjustedSpeed);
    }

    private void AdjustDirectionModelLooks()
    {
        if (rawMovementVector.magnitude >= 0.1f) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(rawMovementVector.x, 0, rawMovementVector.z));
            _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * playerRotationSpeed);
        }
    }

    public Vector3 GetMovementVector()
    {
        return rawMovementVector;
    }

    public Vector3 WherePlayerLooks()
    {
        Vector3 direction = _transform.rotation * Vector3.forward;
        return direction.normalized;
    }
    public Vector3 GetPosition()
    {
        return _transform.position;
    }
}
