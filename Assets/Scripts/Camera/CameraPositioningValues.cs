using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraPositioningValues : MonoBehaviour
{

    public List<GameObject> ObjsOfInterest;
    public GameObject objOfInterest;
    public GameObject Player;
    Camera camera;

    public float OffDistance = 9;


    Vector3 Base1Locked;
    Vector3 Base2Locked;
    Vector3 Base1LockedOpposite;
    Vector3 Base2LockedOpposite;

    public GameObject cameraRef;


    // blue point opposite
    public vector3Data FarOppositePoint;
    // Green Point 
    public vector3Data FarOppositePointComplementary;
    //green point inside
    public vector3Data FarOppositePointComplementary_mirror;

    // yellow points
    public vector3Data FarOppositeXBase;
    public vector3Data FarOppositeYBase;

    // purple points
    public vector3Data FarOppositeXBaseFixed;
    public vector3Data FarOppositeYBaseFixed;

    //OppositeBluePoint
    public vector3Data FarOppositePointMirror;

    //RedPoints
    public vector3Data FarOppositePointMirrorXBase;
    public vector3Data FarOppositePointMirrorYBase;

    //Purple points inside the red points
    public vector3Data FarOppositePointMirrorXBaseFixed;
    public vector3Data FarOppositePointMirrorYBaseFixed;

    // cyan point
    public vector3Data MirrorFarOppositeComplementary;


    float playerInterestDistance;


	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        objOfInterest = ObjsOfInterest[0];
	}
	
	// Update is called once per frame
	void Update () {
	
        //calculate the object of interest based on heuristics 

        camera.transform.position = BaseTriangle1PositionOfInterest();
       //) * 0.5f;

        
	}


    public void OnDrawGizmos()
    {


        objOfInterest = ObjsOfInterest[0];

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(getBaricenter(), 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(PositionofInterestOpposite(), 1);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(PositionofInterestOpposite_Inside(), 1);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(BaseTriangle1PositionOfInterest(), 1);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(BaseTriangle2PositionOfInterest(), 1);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BaseTriangle1Opposite(), 1);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(BaseTriangle2Opposite(), 1);

        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(BaseTriangle1PositionOfInterest_LOCKED(), 0.6f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(BaseTriangle2PositionOfInterest_LOCKED(), 0.6f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(BaseTriangle1PositionOfInterestOpposite_LOCKED(), 0.6f);

        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(BaseTriangle2PositionOfInterestOpposite_LOCKED(), 0.6f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(ComplementaryOpposite(), 1);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(MirroredComplementaryOpposite(), 1);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(MirrorOpposite(), 1);

        Gizmos.DrawSphere(MirrorOppositeComplementary(), 1);


        


        cameraRef.transform.position = BaseTriangle1PositionOfInterest();

        playerInterestDistance = Vector3.Distance(Player.transform.position, objOfInterest.transform.position);
    }


    

    public GameObject ObjectOfInterest()
    {



        return objOfInterest;

    }

    public Vector3 getBaricenter()
    {

        Vector3 baricenter = Vector3.zero;


        for (int i = 0; i < ObjsOfInterest.Count; i++ )
        {

            baricenter += ObjsOfInterest[i].transform.position;

        }

        baricenter /= ObjsOfInterest.Count;

        return baricenter;

    }

   
    public Vector3 PositionofInterestOpposite()
    {
        camera = GetComponent<Camera>();
        Vector3 pos = Vector3.zero;

        pos = getBaricenter() - objOfInterest.transform.position;
        pos += getBaricenter() - (3 * pos);
        Vector3 FixedDistance = (pos - objOfInterest.transform.position ).normalized;
        
        pos = FixedDistance * 9 + objOfInterest.transform.position;
        pos.y = 2.5f;


        return pos;

    }

    public Vector3 PositionofInterestOpposite_Inside()
    {
        camera = GetComponent<Camera>();
        Vector3 pos = Vector3.zero;

        pos = getBaricenter() - objOfInterest.transform.position;
        pos += getBaricenter() + (3 * pos);
        Vector3 FixedDistance = (pos - objOfInterest.transform.position).normalized;

        pos = FixedDistance * OffDistance + objOfInterest.transform.position;
        pos.y = 2.5f;


        return pos;

    }



    public Vector3 BaseTriangle1Opposite()
    {

        Vector3 Base = Vector3.zero;


        Base = new Vector3(objOfInterest.transform.position.x, 2.5f, PositionofInterestOpposite_Inside().z);

        return Base;

    }

    public Vector3 BaseTriangle2Opposite()
    {

        Vector3 Base = Vector3.zero;


        Base = new Vector3(PositionofInterestOpposite_Inside().x, 2.5f, objOfInterest.transform.position.z);

        return Base;

    }


    public Vector3 BaseTriangle1PositionOfInterest()
    {

        Vector3 Base = Vector3.zero;


        Base = new Vector3(objOfInterest.transform.position.x, 2.5f, PositionofInterestOpposite().z);

        return Base;

    }

    public Vector3 BaseTriangle2PositionOfInterest()
    {

        Vector3 Base = Vector3.zero;


        Base = new Vector3(PositionofInterestOpposite().x, 2.5f, objOfInterest.transform.position.z);

        return Base;

    }

    public Vector3 BaseTriangle1PositionOfInterest_LOCKED()
    {
        Vector3 BaseLocked = Vector3.zero;


        BaseLocked = BaseTriangle1PositionOfInterest();
        if (Vector3.Distance(BaseLocked, objOfInterest.transform.position) < 3)
        {
            return Base1Locked + objOfInterest.transform.position;
        }

        Base1Locked = BaseLocked - objOfInterest.transform.position;
        return BaseLocked;
    }

    public Vector3 BaseTriangle2PositionOfInterest_LOCKED()
    {
        Vector3 BaseLocked = Vector3.zero;


        BaseLocked = BaseTriangle2PositionOfInterest();
        if (Vector3.Distance(BaseLocked, objOfInterest.transform.position) < 3)
        {
            return Base2Locked + objOfInterest.transform.position;
        }

        Base2Locked = BaseLocked - objOfInterest.transform.position;
        return BaseLocked;
    }

    public Vector3 BaseTriangle1PositionOfInterestOpposite_LOCKED()
    {
        Vector3 BaseLocked = Vector3.zero;


        BaseLocked = BaseTriangle1Opposite();
        if (Vector3.Distance(BaseLocked, objOfInterest.transform.position) < 3)
        {
            return Base1LockedOpposite + objOfInterest.transform.position;
        }

        Base1LockedOpposite = BaseLocked - objOfInterest.transform.position;
        return BaseLocked;
    }

    public Vector3 BaseTriangle2PositionOfInterestOpposite_LOCKED()
    {
        Vector3 BaseLocked = Vector3.zero;


        BaseLocked = BaseTriangle2Opposite();
        if (Vector3.Distance(BaseLocked, objOfInterest.transform.position) < 3)
        {
            return Base2LockedOpposite + objOfInterest.transform.position;
        }

        Base2LockedOpposite = BaseLocked - objOfInterest.transform.position;
        return BaseLocked;
    }

    public Vector3 MirrorOpposite()
    {
        float atan2 = Mathf.Atan2(Player.transform.position.z - PositionofInterestOpposite().z, Player.transform.position.x - PositionofInterestOpposite().x);

        Vector3 MirrorOposite = Vector3.zero;


        MirrorOposite = new Vector3(Mathf.Cos(atan2) * 9, 0, Mathf.Sin(-atan2) * 9) + objOfInterest.transform.position;


        return MirrorOposite;
    }

    public Vector3 MirrorOppositeComplementary()
    {
        float atan2 = Mathf.Atan2(Player.transform.position.z - PositionofInterestOpposite().z, Player.transform.position.x - PositionofInterestOpposite().x);

        Vector3 MirrorOposite = Vector3.zero;


        MirrorOposite = new Vector3(Mathf.Sin(atan2) * 9, 0, - Mathf.Cos(atan2) * 9) + objOfInterest.transform.position;


        return MirrorOposite;
    }


    public Vector3 ComplementaryOpposite()
    {

        float atan2 = Mathf.Atan2(Player.transform.position.z - PositionofInterestOpposite().z, Player.transform.position.x - PositionofInterestOpposite().x);


        Vector3 BaseLocked = Vector3.zero;

        float oppositeAngle = 0;

        if ( atan2 > 0 && atan2 < 1.5f )
        {
            oppositeAngle = 1.5f - atan2;
        }
        else if (atan2 > 1.5f && atan2 < 3.14f)
        {
            oppositeAngle = 3.14f - atan2 + 1.5f;
        }
        else if (atan2 < -1.5f && atan2 > -3.14f)
        {
            oppositeAngle = -3.14f - (atan2) + (-1.5f);
        }
        else if (atan2 < 0 && atan2 > -1.5f)
        {
            oppositeAngle = -1.5f - atan2;
        }

        if ( atan2 == 0)
        {
            oppositeAngle = 1.5f;
        }

        Vector3 oppositeComplementary = new Vector3(-Mathf.Cos(oppositeAngle) * 9, 0, -Mathf.Sin(oppositeAngle) * 9) + objOfInterest.transform.position;


        return oppositeComplementary;
    }

    public Vector3 MirroredComplementaryOpposite()
    {

        float atan2 = Mathf.Atan2(Player.transform.position.z - PositionofInterestOpposite().z, Player.transform.position.x - PositionofInterestOpposite().x);

        Vector3 BaseLocked = Vector3.zero;

        float oppositeAngle = 0;

        if (atan2 > 0 && atan2 < 1.5f)
        {
            oppositeAngle = 1.5f - atan2;
        }
        else if (atan2 > 1.5f && atan2 < 3.14f)
        {
            oppositeAngle = 3.14f - atan2 + 1.5f;
        }
        else if (atan2 < -1.5f && atan2 > -3.14f)
        {
            oppositeAngle = -3.14f - (atan2) + (-1.5f);
        }
        else if (atan2 < 0 && atan2 > -1.5f)
        {
            oppositeAngle = -1.5f - atan2;
        }

        if (atan2 == 0)
        {
            oppositeAngle = 1.5f;
        }


        Vector3 oppositeComplementary = new Vector3(-Mathf.Cos(oppositeAngle) * 9, 0, Mathf.Sin(oppositeAngle) * 9) + objOfInterest.transform.position;


        return oppositeComplementary;
    }






}
