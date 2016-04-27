using UnityEngine;
using System.Collections;

public class distanceBetweenTwoPoints : floatData {

    // calculates the distance between two variables, assuming that both of them starts at zero

    public string data1;
    public string data2;

    Data _data1;
    Data _data2;

   // public float data;

	// Use this for initialization
	void Start () {

        Data[] datas = GetComponents<Data>();
        
        foreach (Data d in datas)
        {

            if (d.MyName == data1)
            {
                _data1 = d;
            }
            if (d.MyName == data2)
            {
                _data2 = d;
            }

        }

       


	}
	


	// Update is called once per frame
	void Update () {
       data = calculateDistance(_data1, _data2);
	}


    public float calculateDistance<T>(T d1, T d2) where T: Data
    {
        float f = 0;

        Debug.Log(d1.GetType().ToString());
        if (d1.GetType().ToString() == "floatData")
        {
            float f1 = (float)d1.GetType().GetField("data").GetValue((Object)d1);
            float f2 = (float)d2.GetType().GetField("data").GetValue((Object)d2);
            return Mathf.Sqrt((f1 * f1) + (f2 * f2));
        }

        if (d1.GetType().ToString() == "vector3Data")
        {
            Vector3 f1 = (Vector3)d1.GetType().GetField("data").GetValue((Object)d1);
            Vector3 f2 = (Vector3)d2.GetType().GetField("data").GetValue((Object)d2);
            return Vector3.Distance(f1,f2);
        }



        return f;
    }



 

}
