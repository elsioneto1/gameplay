using UnityEngine;
using System.Collections;

public class SetFloatData : Mixin
{

    public floatData dataToBeModified;
    public floatData dataReceiver;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setFloatData(string data)
    {
        if (data == myName)
        {
            dataToBeModified.data = dataReceiver.data;
        }
    }

}
