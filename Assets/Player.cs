using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] RuntimeData _runtimeData;
    [SerializeField] float _mouseSensitivity = 10f;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] Camera _camera;

    public float strengthStat = 0f;
    public float speedStat = 0f;

    float _currentTilt = 0f;

    void Awake() {
        GameEvents.StatIncrease += OnStatIncrease;
    }

    void OnStatIncrease(object sender, StatEventArgs args){
        if (args.statType == "speed"){
            speedStat += args.statIncrease;
        } 
        if (args.statType == "strength"){
            strengthStat += args.statIncrease;
        } 
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        FirstPersonCamera();
        if (_runtimeData.CurrentGameplayState == GameplayState.FreeWalk) {
            Movement();   
        }
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

        GetComponent<CharacterController>().Move(movementVector * (_moveSpeed + speedStat) * Time.deltaTime);

    }
}
