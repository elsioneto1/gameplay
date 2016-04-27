using UnityEngine;
using System.Collections;

public class vectorToFloat : MonoBehaviour {

    public string vectorData;
    vector3Data _vectorData;

    public string FloatData;
    floatData _floatData;

    public enum getAxis {X,Y,Z}
    public getAxis axis;
	// Use this for initialization
	void Start () {

	    vector3Data[] vDatas = GetComponents<vector3Data>();
        foreach ( vector3Data v3d in vDatas )
        {
            if (v3d.MyName == vectorData)
            {
                _vectorData = v3d;
            }
        }

        floatData[] fDatas = GetComponents<floatData>();
        foreach (floatData f in fDatas)
        {
            if (f.MyName == FloatData)
            {
                _floatData = f;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

       // Debug.Log(_vectorData);
       // Debug.Log(_floatData);

        if (_vectorData == null || _floatData == null)
            return;

	    if (axis == getAxis.X)
        {
            _floatData.data = _vectorData.data.x;
        }
        else if (axis == getAxis.Y)
        {
            _floatData.data = _vectorData.data.y;
        }
        else if (axis == getAxis.Z)
        {
            _floatData.data = _vectorData.data.z;
        }

	}
}
