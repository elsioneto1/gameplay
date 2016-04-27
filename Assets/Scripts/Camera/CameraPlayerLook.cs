using UnityEngine;
using System.Collections;

public class CameraPlayerLook : MonoBehaviour {

    public Camera camera;
    public GameObject player;
    public GameObject interest;
    CameraPositioningValues cpv;
    public float dot_Player;
    public float dot_Interest;

    public float PlyaerIdealAngle_Min;
    public float PlyaerIdealAngle_Max;

    public Vector3 Cross_CameraPlayer;
    public Vector3 Cross_CameraInterest;

    public GameObject cameraRef;


    // 0 is completely aligned
    public float CrossCameraOffLimit = 0.67f;
    public float DotCameraOffLimit = 0.7f;

    public float optimalInterestView;




	// Use this for initialization
	void Start () {

        camera = GetComponent<Camera>();
        cpv = GetComponent<CameraPositioningValues>();

        //0 is in the middle, 0.67 is in the corner
        optimalInterestView = CrossCameraOffLimit * 0.5f;

	}
	
	// Update is called once per frame
	void Update () {
        CalculateAngleBetweenpointsOfInterest();
        CameraLook();
	}

    void CalculateAngleBetweenpointsOfInterest()
    {

        if (player != null)
        {

            dot_Player = Vector3.Dot(new Vector3(cameraRef.transform.forward.x, 0, cameraRef.transform.forward.z),
                (new Vector3(cameraRef.transform.position.x, 0, cameraRef.transform.position.z) -
                new Vector3(player.transform.position.x, 0, player.transform.position.z)).normalized);

            Cross_CameraPlayer = Vector3.Cross(
                new Vector3(cameraRef.transform.forward.x, 0, cameraRef.transform.forward.z),
                (new Vector3(cameraRef.transform.position.x, 0, cameraRef.transform.position.z) -
                new Vector3(player.transform.position.x, 0, player.transform.position.z)).normalized
            );

        }

        if (interest != null)
        {
            dot_Interest = Vector3.Dot(new Vector3(cameraRef.transform.forward.x, 0, cameraRef.transform.forward.z),
                (new Vector3(cameraRef.transform.position.x, 0, cameraRef.transform.position.z) -
                new Vector3(interest.transform.position.x, 0, interest.transform.position.z)).normalized);


            Cross_CameraInterest = Vector3.Cross(
                new Vector3(cameraRef.transform.forward.x, 0, cameraRef.transform.forward.z),
                (new Vector3(cameraRef.transform.position.x, 0, cameraRef.transform.position.z) -
                new Vector3(interest.transform.position.x, 0, interest.transform.position.z)).normalized
            );

        }

    }

    void CameraLook()
    {
        


        if ( (Cross_CameraInterest.y - optimalInterestView) > 0)
        {

            cameraRef.transform.Rotate(new Vector3(0, -1, 0));

        }
        if (((Cross_CameraInterest.y - optimalInterestView)) < -0.2f)
        {
            cameraRef.transform.Rotate(new Vector3(0, 1, 0));

        }


        camera.transform.forward -= (camera.transform.forward - cameraRef.transform.forward) * 0.5f;

    }

}
