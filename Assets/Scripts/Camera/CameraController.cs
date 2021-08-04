using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float rotationSpeed_ = 1.0f;
    public Transform targetTR_;
    public Transform playerTR_;

    private float rotX_ = 0.0f;
    private float rotY_ = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotX_ += Input.GetAxis("Mouse Y") * rotationSpeed_;
        rotY_ -= Input.GetAxis("Mouse X") * rotationSpeed_;

        rotY_ = Mathf.Clamp(rotY_, -35, 60);

        transform.LookAt(targetTR_);

        targetTR_.rotation = Quaternion.Euler(rotX_, rotY_, 0.0f);
        playerTR_.rotation = Quaternion.Euler(0.0f, rotX_, 0.0f);
    }
}
