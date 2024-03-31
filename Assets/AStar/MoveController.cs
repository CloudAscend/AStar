using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    public float moveSpeed;

    private PlayerInput playerInput;
    private Rigidbody rigidbody;
    private InputAction moveAction;

    private Vector3 moveVec;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidbody = GetComponent<Rigidbody>();

        moveAction = playerInput.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        moveVec.x = moveAction.ReadValue<Vector2>().x * moveSpeed;
        moveVec.y = rigidbody.velocity.y;
        moveVec.z = moveAction.ReadValue<Vector2>().y * moveSpeed;

        rigidbody.velocity = moveVec;
    }
}
