using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] Camera _camera;
    float _currentTilt = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        FirstPersonCamera();
        Movement();

    }

    void FirstPersonCamera() {
        float deltaMouseX = Input.GetAxis("Mouse X");
        float deltaMouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up,deltaMouseX*_mouseSensitivity);

        _currentTilt -= deltaMouseY * _mouseSensitivity;
        _currentTilt = Mathf.Clamp(_currentTilt,-70,70);
        _camera.transform.localEulerAngles = new Vector3(_currentTilt,0,0);
    }

    void Movement() {
        Vector3 sidewaysMovementVector = transform.right*Input.GetAxis("Horizontal");
        Vector3 frontbackMovementVector = transform.forward*Input.GetAxis("Vertical");
        Vector3 movementVector = sidewaysMovementVector + frontbackMovementVector;

        GetComponent<CharacterController>().Move(movementVector * _moveSpeed * Time.deltaTime);

    }
}
