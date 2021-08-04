using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public CharacterController controller_;

    //Movement 
    public float movSpeed_ = 0.0f;

    //Rotation
    public float turnSmoothTime_ = 0.1f;
    public float turnSmoothVelocity_;
    public Transform cameraTR_;

    //Animation 
    public Animator animator_;
    private int SpeedHash_;


    // Start is called before the first frame update
    void Start()
    {
        SpeedHash_ = Animator.StringToHash("Speed");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //--- MOVEMENT ---//
    void Movement()
    {
  
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"),
                            0,
                            Input.GetAxisRaw("Vertical")).normalized;

        if (direction.magnitude > 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTR_.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity_, turnSmoothTime_);

            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            Vector3 moveDir = Quaternion.Euler(0.0f, targetAngle, 0.0f) * Vector3.forward;

            controller_.Move(moveDir.normalized * movSpeed_ * Time.deltaTime);

        }

        animator_.SetFloat(SpeedHash_, direction.magnitude);


    }
}
