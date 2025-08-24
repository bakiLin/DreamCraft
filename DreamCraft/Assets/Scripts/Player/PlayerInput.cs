using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private KeyboardInputAction inputAction;

    public Action OnStartShoot, OnStopShoot, OnChangeWeapon;

    private void Awake()
    {
        inputAction = new KeyboardInputAction();
    }

    private void OnEnable()
    {
        inputAction.Enable();

        inputAction.Keyboard.Shoot.started += StartShoot;
        inputAction.Keyboard.Shoot.canceled += StopShoot;
        inputAction.Keyboard.ChangeWeapon.started += ChangeWeapon;
    }

    private void OnDisable()
    {
        inputAction.Disable();

        inputAction.Keyboard.Shoot.started -= StartShoot;
        inputAction.Keyboard.Shoot.canceled -= StopShoot;
        inputAction.Keyboard.ChangeWeapon.started -= ChangeWeapon;
    }

    private void StartShoot(InputAction.CallbackContext context) => OnStartShoot?.Invoke();

    private void StopShoot(InputAction.CallbackContext context) => OnStopShoot?.Invoke();

    private void ChangeWeapon(InputAction.CallbackContext context) => OnChangeWeapon?.Invoke();

    public Vector2 GetMoveDirection() => inputAction.Keyboard.Movement.ReadValue<Vector2>();

    public Vector2 GetRotation() => inputAction.Keyboard.Rotation.ReadValue<Vector2>();
}
