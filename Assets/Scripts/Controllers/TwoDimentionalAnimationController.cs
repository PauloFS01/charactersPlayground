using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimentionalAnimationController : MonoBehaviour
{
    Animator myAnimator;
    float velocityZ, velocityX;

    public float acceleration = 2f, deceleration=2f, maximumWalkVelocity = 0.5f, maximumRunVelocity = 2.0f;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get key input from w a d and left shift
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool rundPressed = Input.GetKey("left shift");

        float currentMaximumVelocity = rundPressed ? maximumWalkVelocity : maximumRunVelocity;

        //acceleration 

        if (forwardPressed && velocityZ < currentMaximumVelocity)
        {
            velocityZ += Time.deltaTime * acceleration;
        }
        if (leftPressed && velocityX > -currentMaximumVelocity)
        {
            velocityX -= Time.deltaTime * acceleration;
        }
        if (rightPressed && velocityX < currentMaximumVelocity)
        {
            velocityX += Time.deltaTime * acceleration;
        }

        //deceleration
        if (!forwardPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * deceleration;
        }
        if (!leftPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * deceleration;
        }
        if (!rightPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * deceleration;
        }

        //reset velocity
        if (!forwardPressed && velocityZ < 0.0f)
        {
            velocityZ -= 0.0f;
        }
        if(!leftPressed && !rightPressed && velocityX !=0.0f && (velocityX > -0.5f && velocityX < 0.5f ))
        {
            velocityX = 0.0f;
        }

        //lock velocity
        if(forwardPressed && rundPressed && velocityZ > currentMaximumVelocity)
        {
            velocityZ = currentMaximumVelocity;
        }
        else if (forwardPressed && velocityZ > currentMaximumVelocity)
        {
            velocityZ -= Time.deltaTime * deceleration;
            if(velocityZ > currentMaximumVelocity && velocityX < (currentMaximumVelocity + 0.5f) ) 
            {
                velocityZ = currentMaximumVelocity;
            }
        }
        else if(forwardPressed && velocityZ < currentMaximumVelocity && velocityZ > (currentMaximumVelocity - 0.5f))
        {
            velocityZ = currentMaximumVelocity;
        }
        //18:59
        myAnimator.SetFloat("velocity z", velocityZ);
        myAnimator.SetFloat("velocity x", velocityX);
    }
}
