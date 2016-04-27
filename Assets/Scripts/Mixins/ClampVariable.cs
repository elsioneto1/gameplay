using UnityEngine;
using System.Collections;

public class ClampVariable : MonoBehaviour {

    public string variable;

    Data _data;
    public float maxConstrain;
    public float minConstrain;

	// Use this for initialization
	void Start () {
	
        Data[] datas = GetComponents<Data>();

        for (int i = 0 ; i < datas.Length; i++)
        {
            if ( datas[i].MyName == variable)
            {
                _data = datas[i];
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
       // REFLECTION MAGIC
        if (_data == null)
            return;

        if (_data.GetType().ToString() == "floatData")
        {

            if ((float)_data.GetType().GetField("data").GetValue((Object)_data) < minConstrain)
                _data.GetType().GetField("data").SetValue((Object)_data,minConstrain);

            if ((float)_data.GetType().GetField("data").GetValue((Object)_data) > maxConstrain)
                _data.GetType().GetField("data").SetValue((Object)_data, maxConstrain);

        }
        else
        {

            if ((int)_data.GetType().GetField("data").GetValue((Object)_data) < minConstrain)
                _data.GetType().GetField("data").SetValue((Object)_data, (int)minConstrain);

            if ((int)_data.GetType().GetField("data").GetValue((Object)_data) > maxConstrain)
                _data.GetType().GetField("data").SetValue((Object)_data, (int)maxConstrain);

        }
	}
}
