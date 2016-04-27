using UnityEngine;
using System.Collections;

public class CameraMatrix : MonoBehaviour {

    public Camera camera;
    public GameObject Interest;


    public Vector3 foo;
    public Vector3 bar;

    public Vector3 screenPos;

    public Vector2 worldToCamera;

	// Use this for initialization
	void Start () {
	
	}
	


	// Update is called once per frame
	void Update () {
        CameraValues();
	}


    void CameraValues()
    {
        Debug.Log(camera.projectionMatrix);
        foo = cameraPos(screenPos, camera.worldToCameraMatrix, camera.projectionMatrix );

        bar = camera.WorldToScreenPoint(Interest.transform.position);


        worldToCamera = get2dPoint(Interest.transform.position);

       // camera.transform.position = foo;

    }


    Vector3  cameraPos( Vector3 pos, Matrix4x4 view, Matrix4x4 projection)
    {
        Vector3 cameraPos = Vector3.zero;


        Matrix4x4 viewProjectionInverse = Matrix4x4.Inverse(projection * view);

        Vector3 point = new Vector3(pos.x / Screen.width, pos.y / Screen.height,0);
        return viewProjectionInverse.MultiplyPoint(pos);
    }

    Vector2 get2dPoint(Vector3 pos)
    {

        Matrix4x4 viewProjectionMatrix = camera.projectionMatrix * camera.worldToCameraMatrix;
        Vector3 cameraSpace = viewProjectionMatrix.MultiplyPoint(pos);


        Vector2 screenPoint = Vector2.zero;
        

        screenPoint = new Vector3( cameraSpace.x/Screen.width ,  cameraSpace.y/Screen.height);

        return screenPoint;

    }


}
