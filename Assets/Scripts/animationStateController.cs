using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    private float speed;
    private bool isWalkingBackward;

    private float rotationSpeed = 90f;
    private float targetRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
        {
            speed = vertical;
            isWalkingBackward = false;
        }
        else if (vertical < 0)
        {
            speed = -vertical;
            isWalkingBackward = true;
        }
        else
        {
            speed = 0;
        }

        animator.SetFloat("speed", speed);
        animator.SetBool("isWalkingBackward", isWalkingBackward);

        if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation += rotationSpeed;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation -= rotationSpeed;
        }

        float currentRotation = transform.eulerAngles.y;
        float newRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, newRotation, 0);
    }
}
