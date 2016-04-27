using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jump : MonoBehaviour {


    public float jumpSpeedUp = 10;
    public float acceleration = -2;
    public Vector3 LandingPoint;
    public bool jumping = false;
    public float totalFlight;
    public float flightDuration;
    public float landingTime;

    public float percentage;
    public List<AnimationClip> clips;
    public Vector3 displacement;
    public Vector3 originPoint;

    public float maxJumpDisplacement = 5;

    Animator anim;
    CharacterControl characControl;
    public Transform headingFront;
   public  Vector3 rotation;

	// Use this for initialization
	void Start () {
        
        totalFlight = 0;
        landingTime = 0;

	    foreach (AnimationClip c in clips)
        {

            totalFlight += c.length;

            if (c.name == "Landing")
            {
                landingTime = c.length;

            }

        }

        anim = GetComponent<Animator>();
        characControl = GetComponent<CharacterControl>();
        rotation = anim.rootPosition;
	}
	
	// Update is called once per frame
	void Update () {
        anim.rootPosition = rotation;

       if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!jumping)
            {
                jumping = true;
                JumpStart();

            }
            anim.SetTrigger("Jump");
        }

        if (jumping)
        {
            JumpingCalc();
        }

	}

    public void JumpStart()
    {

        LandingPoint = transform.position + headingFront.forward * 15;

        flightDuration = totalFlight;
        originPoint = transform.position;
        displacement =  LandingPoint - transform.position  ;

        float halfFlight = flightDuration*0.5f;

      //  jumpSpeedUp = transform.position.y;

        //jumpSpeedUp = (maxJumpDisplacement * (halfFlight)) - ((acceleration * (halfFlight * halfFlight)) * 0.5f) ;


        // V = v0 + a.t
        // -v0 = -V  + a.t
        // v0 = V - a.t
        jumpSpeedUp = -acceleration * halfFlight;


        Debug.Log(jumpSpeedUp);
    }

    public void disableRootMotion()
    {
        
    }

    public void JumpingCalc()
    {
        
        // transform.position += new Vector3(0,jumpSpeedUp,0) ;
        jumpSpeedUp += acceleration*Time.deltaTime  ;

        flightDuration -= Time.deltaTime;
        percentage = flightDuration / totalFlight;

        if (flightDuration > 0)
        {
          
            Vector3 percentageComplete = originPoint + (displacement * (1 - (percentage)));
            transform.position = new Vector3(percentageComplete.x, transform.position.y, percentageComplete.z);
            transform.position += new Vector3(0, jumpSpeedUp, 0)*Time.deltaTime;

        }
        else
        {
           
           // characControl.correctionAngle += 0.34f;
           // anim.applyRootMotion = true;
            jumping = false;
           // transform.position += new Vector3(0, jumpSpeedUp, 0);
           // transform.position = originPoint + displacement;
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
        }

    }

}
