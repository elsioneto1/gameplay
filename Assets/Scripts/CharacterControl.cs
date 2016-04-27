using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    Animator anim;
    public float correctionAngle;
    Jump jump;
    public float atan2;
    float inputX = 0;
    float inputY = 0;

    float input;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        jump = GetComponent<Jump>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!jump.jumping)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }

        if (inputX != 0 || inputY != 0)
        {


            Vector3 movement = Camera.main.transform.forward * - inputX + Camera.main.transform.right * inputY;
            atan2 = Mathf.Atan2(movement.z, movement.x);
            atan2 += correctionAngle;


          



            input = Mathf.Abs(inputX) > Mathf.Abs(inputY) ? Mathf.Abs(inputX) : Mathf.Abs(inputY);
            transform.forward -= (transform.forward - new Vector3(Mathf.Cos(atan2), 0, Mathf.Sin(atan2))) * 0.3f;
            transform.position += (transform.forward * 0.2f) * (input * input);
            anim.SetFloat("axis_Y", input);



        }
        else
        {
            anim.SetFloat("axis_X", 0);
            anim.SetFloat("axis_Y", 0);
        }



	}


    




}
