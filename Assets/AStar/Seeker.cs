using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 target;

    private Rigidbody rigidbody;
    private Grid grid;

    private Vector3 moveVec;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        grid = Grid.instance;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        moveVec.x = target.x - transform.position.x;
        moveVec.z = target.z - transform.position.z;

        moveVec = moveVec.normalized * moveSpeed;
        moveVec.y = rigidbody.velocity.y;

        rigidbody.velocity = moveVec;

        MovePoint();
    }

    private void MovePoint()
    {
        if (grid.path == null) return;

            if (Vector3.Distance(transform.position, target) <= 0.5f)
            grid.path.Remove(grid.path[0]);

        target = grid.path[0].worldPosition;
    }
}
