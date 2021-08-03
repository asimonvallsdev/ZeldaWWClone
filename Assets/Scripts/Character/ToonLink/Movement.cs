using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //Movement & Rotation
    public float movSpeed_ = 0.0f;
    public float movSpeedDeltaTime_ = 0.0f;
    public float maxSpeed_ = 1.0f;
    public float acceleration_ = 0.1f;
    public float decceleration_ = 0.1f;


    //Animation 
    public Animator animator_;
    private int SpeedHash_;

    private Vector3 velocity_ = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        SpeedHash_ = Animator.StringToHash("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        MovementFunction();
    }

    //--- MOVEMENT ---//
    void MovementFunction()
    {

        velocity_ = new Vector3(Input.GetAxisRaw("Horizontal"),
                            0,
                            Input.GetAxisRaw("Vertical")).normalized;

        if (movSpeed_ < maxSpeed_ && velocity_ != Vector3.zero)
        {

            movSpeed_ += acceleration_;

        }

        if (movSpeed_ > 0.0f && velocity_ == Vector3.zero)
        {
            movSpeed_ -= decceleration_;

            if (movSpeed_ < 0.0f)
            {
                movSpeed_ = 0.0f;
            }
        }


        movSpeedDeltaTime_ = movSpeed_ * Time.deltaTime;
        transform.Translate(movSpeedDeltaTime_ * velocity_, Space.World);
        
        animator_.SetFloat(SpeedHash_, movSpeed_);
    }

}
