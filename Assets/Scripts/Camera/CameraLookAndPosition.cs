using UnityEngine;
using System.Collections;

public class CameraLookAndPosition : MonoBehaviour
{


    public GameObject Player;
    public GameObject Interest;
    public float playerWeight;
    public float interestWeight;
    public float cameraAngleFromDisplacement;

    Vector3 getPointOfInterestToLook;
    public float DistanceFromPoint;

    public GameObject CamerRef;

    public vector3Data playerPos;
    public vector3Data cameraPos;

    public float cameraPositionPlayerWeight;
    public float cameraPositionInterestWeight;

    public floatData DistanceFromCamera;
    public floatData CameraAngle;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {


        setCameraPosition();
        setLook();


        playerPos.data = Player.transform.position;
        cameraPos.data = Interest.transform.position;

        Camera.main.transform.position -= (Camera.main.transform.position - CamerRef.transform.position) * 0.1f;
    }

    Vector3 PlayerInterestDisplacement()
    {
        return Interest.transform.position - Player.transform.position;
    }

    void setCameraPosition()
    {
        Vector3 center = Player.transform.position;

        float index;
        index = 1 * cameraPositionPlayerWeight;
        index += 1 * cameraPositionInterestWeight;

        center = Player.transform.position * cameraPositionPlayerWeight + Interest.transform.position * cameraPositionInterestWeight;
        center /= index;

       // center = center - CamerRef.transform.position;

        float angle = Mathf.Atan2(PlayerInterestDisplacement().z, PlayerInterestDisplacement().x);
        angle += CameraAngle.data;
        Debug.Log(center);
        // make the camera position properly
        CamerRef.transform.position = center + (new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * DistanceFromCamera.data) + new Vector3(0, 5, 0);



    }

    void setLook()
    {
        Vector3 center = Player.transform.position;

        float index;
        index =     1 * playerWeight;
        index +=    1 * interestWeight;

        center = Player.transform.position * playerWeight + Interest.transform.position * interestWeight;
        center /= index;

        center = center - CamerRef.transform.position;

        Camera.main.transform.forward -= (Camera.main.transform.forward - center.normalized ) * 0.2f ; 

    }

}