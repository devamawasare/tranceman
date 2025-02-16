using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class PacmanScript : MonoBehaviour
{
    public GameObject eyes;
    private Animator eyesAnimator;
    public float pacmanSpeed;
    private Vector3 pacmanDirection;
    private Vector3 lastCommand;
    public ManageMovement manageMovementScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        eyesAnimator = eyes.GetComponent<Animator>();
        pacmanSpeed = 5;
        pacmanDirection = Vector3.zero; //pacman will be stationary only in the beginning before any key is pressed
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //pacmanDirection = Vector3.up;
            lastCommand = Vector3.up;
            eyesAnimator.SetInteger("LookDirection", 2);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lastCommand = Vector3.down;
            eyesAnimator.SetInteger("LookDirection", 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastCommand = Vector3.left;
            eyesAnimator.SetInteger("LookDirection", 1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastCommand = Vector3.right;
            eyesAnimator.SetInteger("LookDirection", 3);
        }
        pacmanDirection = manageMovementScript.MoveCharacter(transform.position, pacmanDirection, lastCommand);
        transform.position = transform.position + ((pacmanDirection * pacmanSpeed) * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, manageMovementScript.ChangeRotationZ(pacmanDirection));
        transform.localScale = manageMovementScript.ChangeScale(transform.localScale, pacmanDirection);
    }
}