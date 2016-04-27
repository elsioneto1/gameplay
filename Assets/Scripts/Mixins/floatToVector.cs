using UnityEngine;
using System.Collections;

public class floatToVector : Data
{

    //MULTI INSTANCE PER OBJECT

    // convert int data to vector 3 data
    // it's needed to set a vector to make the conversion

    public string intData;
    public string vector3Data;
    public enum Axis { X, Y, Z }
    public Axis axis;

    floatData input;
    vector3Data data;

    // Use this for initialization
    void Start()
    {

        floatData[] intDatas = GetComponents<floatData>();
        vector3Data[] v3Datas = GetComponents<vector3Data>();

        foreach (floatData iData in intDatas)
        {
            if (iData.MyName == intData)
            {
                input = iData;
            }
        }

        foreach (vector3Data v3Data in v3Datas)
        {
            if (v3Data.MyName == vector3Data)
            {
                data = v3Data;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (input == null || data == null)
        {
            Debug.Log("Not enough info.");
            return;
        }

        if (axis == Axis.X)
        {
            data.data = new Vector3(input.data, data.data.y, data.data.z);
        }
        else if (axis == Axis.Y)
        {
            data.data = new Vector3(data.data.x, input.data, data.data.z);
        }
        else if (axis == Axis.Z)
        {
            data.data = new Vector3(data.data.x, data.data.y, input.data);
        }
    }

}
