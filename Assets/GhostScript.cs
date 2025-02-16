using NUnit.Framework.Internal.Commands;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostScript : MonoBehaviour
{
    public GameObject pacman;
    public ManageMovement manageMovementScript;
    public float ghostSpeed;
    public float ghostCheckDistance;
    private Vector3 ghostDirection;
    private Vector3 lastCommand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ghostSpeed = 5;
        ghostDirection = Vector3.zero;
        ghostCheckDistance = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 verticalDirection = Vector3.zero;
        Vector3 horizontalDirection = Vector3.zero;
        Vector3 relativePosition = pacman.transform.position - transform.position;

        if (relativePosition.x < 0)
        {
            horizontalDirection = Vector3.left;
        }
        else
        {
            horizontalDirection = Vector3.right;
        }
        if (relativePosition.y < 0)
        {
            verticalDirection = Vector3.down;
        }
        else
        {
            verticalDirection = Vector3.up;
        }
        Debug.DrawRay(transform.position, horizontalDirection * ghostCheckDistance, Color.green);
        Debug.DrawRay(transform.position, verticalDirection * ghostCheckDistance, Color.green);
        RaycastHit2D checkHorizontal = Physics2D.Raycast(transform.position, horizontalDirection, ghostCheckDistance, 128);
        RaycastHit2D checkVertical = Physics2D.Raycast(transform.position, verticalDirection, ghostCheckDistance, 128);

        if (ghostDirection == Vector3.zero)
        {
            //Debug.Log("Stopped");
            if (checkHorizontal)
            {
                Debug.DrawRay(transform.position, -horizontalDirection * ghostCheckDistance, Color.blue);
                checkHorizontal = Physics2D.Raycast(transform.position, -horizontalDirection, ghostCheckDistance, 128);
                if (checkHorizontal)
                {
                    horizontalDirection = Vector3.zero;
                }
                else
                {
                    horizontalDirection = -horizontalDirection;
                }
            }
            if (checkVertical)
            {
                Debug.DrawRay(transform.position, -verticalDirection * ghostCheckDistance, Color.blue);
                checkVertical = Physics2D.Raycast(transform.position, -verticalDirection, ghostCheckDistance, 128);
                if (checkVertical)
                {
                    verticalDirection = Vector3.zero;
                }
                else
                {
                    //Debug.Log("Go negative");
                    verticalDirection = -verticalDirection;
                }
            }
            if (horizontalDirection == Vector3.zero)
            {
                lastCommand = verticalDirection;
            }
            else if (verticalDirection == Vector3.zero)
            {
                lastCommand = horizontalDirection;
            }
            else
            {
                //Debug.Log("Random");
                if (Random.Range(0, 2) == 0)
                {
                    //Debug.Log("Go Vertical" + verticalDirection);
                    lastCommand = verticalDirection;
                }
                else
                {
                    lastCommand = horizontalDirection;
                }
            }
        }
        else
        {
            if ((ghostDirection == horizontalDirection) || (ghostDirection == -horizontalDirection))
            {
                lastCommand = verticalDirection;
            }
            else if ((ghostDirection == verticalDirection) || (ghostDirection == -verticalDirection))
                {
                lastCommand = horizontalDirection;
            }
            else
            {
                if (Random.Range(0, 2) == 0)
                {
                    lastCommand = verticalDirection;
                }
                else
                {
                    lastCommand = horizontalDirection;
                }
            }
        }
        ghostDirection = manageMovementScript.MoveCharacter(transform.position, ghostDirection, lastCommand);
        transform.position = transform.position + ((ghostDirection * ghostSpeed) * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, manageMovementScript.ChangeRotationZ(ghostDirection));
        transform.localScale = manageMovementScript.ChangeScale(transform.localScale, ghostDirection);
    }
}
