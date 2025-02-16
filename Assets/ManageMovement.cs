using JetBrains.Annotations;
using NUnit.Framework.Internal.Commands;
using UnityEngine;
using System;

public class ManageMovement : MonoBehaviour
{
    public float movementRayDistance;
    public float commandRayOffset;
    public float commandRayDistance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementRayDistance = 0.5f;
        commandRayDistance = 0.8f;
        commandRayOffset = 0.47f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 MoveCharacter(Vector3 position, Vector3 currentDirection, Vector3 movementCommand)
    {
        //Debug.DrawRay(position - (currentDirection * commandRayOffset), movementCommand * commandRayDistance, Color.red);
        //Debug.DrawRay(position + (currentDirection * commandRayOffset), movementCommand * commandRayDistance, Color.red);
        //Debug.DrawRay(position, currentDirection * movementRayDistance, Color.green);
        RaycastHit2D checkCommandHitBack = Physics2D.Raycast(position - (currentDirection * commandRayOffset), movementCommand, commandRayDistance, 128);
        RaycastHit2D checkCommandHitFront = Physics2D.Raycast(position + (currentDirection * commandRayOffset), movementCommand, commandRayDistance, 128);
        RaycastHit2D checkMovementHit = Physics2D.Raycast(position, currentDirection, movementRayDistance, 128);
        if (currentDirection == movementCommand)
        {
            if (checkMovementHit)
            {
                currentDirection = Vector3.zero;
            }
        }
        else
        {
            if (checkCommandHitBack || checkCommandHitFront)
            {
                if (checkMovementHit)
                {
                    currentDirection = Vector3.zero;
                }
            }
            else
            {
                currentDirection = movementCommand;
            }
        }
        return currentDirection;
    }

    public int ChangeRotationZ(Vector3 currentDirection)
    {
        int zRotation = 0;
        if (currentDirection == Vector3.up)
        {
            zRotation =  90;
        }
        else if (currentDirection == Vector3.down)
        {
            zRotation = -90;
        }
        else if (currentDirection == Vector3.left)
        {
            zRotation = 0;
        }
        else if (currentDirection == Vector3.right)
        {
            zRotation = 0;
        }
        return zRotation;
    }

    public Vector3 ChangeScale(Vector3 currentScale, Vector3 currentDirection)
    {
        Vector3 newScale = Vector3.zero;
        if (currentDirection == Vector3.zero) return currentScale;
        if (currentDirection == Vector3.up)
        {
            newScale = SetXScale(currentScale, 1);
        }
        else if (currentDirection == Vector3.down)
        {
            newScale = SetXScale(currentScale, 1);
        }
        else if (currentDirection == Vector3.left)
        {
            newScale = SetXScale(currentScale, -1);
        }
        else if (currentDirection == Vector3.right)
        {
            newScale = SetXScale(currentScale, 1);
        }
        return newScale;
    }

    private static Vector3 SetXScale(Vector3 scale, int value)
    {
        scale.x = Math.Abs(scale.x) * value;
        return scale;
    }
}
