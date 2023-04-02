using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 6.0f; ///float to determine the players movement speed. can be changed in the inspector
    public float lookAroundSpeed = 100.0f; //float to determine the players sensitivty. can be changed in the inspector
    public float Grav = 9.8f;  //adds gravity. explain why important


    private Vector3 moveDir = Vector3.zero;
    private CharacterController chacaterController; //these three are needed for the moevement
    private float yRotation = 0.0f;



    void Start()
    {
        chacaterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;    //ensures they can look around   
    }

    void Update()
    {

        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDir = transform.TransformDirection(moveDir);


        moveDir *= movementSpeed * Time.deltaTime;


        moveDir.y -= Grav * Time.deltaTime; //added this for gravity effect


        chacaterController.Move(moveDir);
        float rotX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * lookAroundSpeed * Time.deltaTime;
        yRotation += Input.GetAxis("Mouse Y") * lookAroundSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -90, 90);
        transform.localEulerAngles = new Vector3(-yRotation, rotX, 0.0f);


    }
}