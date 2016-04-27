using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataComparison : Mixin {

    // only working with floats

    public string data1; 
    floatData _data1;
    public enum OperationType{Less,Greater,Equal}
    public OperationType operationType;
    floatData _data2;
    public string data2;

    public List<string> callbacks;
    public string mixinCallbackParameter;

    public bool verifyConstantly;
	// Use this for initialization
	void Start () {
        floatData[] datas = GetComponents<floatData>();
        foreach (floatData d in datas)
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

        if (!verifyConstantly)
            return;
        verifyVariables();
	}

    void verifyVariables()
    {
        if (operationType == OperationType.Less)
        {
            if (_data1.data < _data2.data )
            {
                foreach(string s in callbacks)
                {
                    if (mixinCallbackParameter == "" )
                    {
                        SendMessage(s);
                    }
                    else
                    {
                        
                        SendMessage(s,mixinCallbackParameter);
                    }
                }
            }
        }
        else if (operationType == OperationType.Equal)
        {
            if (_data1.data == _data2.data)
            {
                foreach (string s in callbacks)
                {
                    if (mixinCallbackParameter == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {

                        SendMessage(s, mixinCallbackParameter);
                    }
                }
            }
        }
        else if (operationType == OperationType.Greater)
        {
            if (_data1.data > _data2.data)
            {
                foreach (string s in callbacks)
                {
                    if (mixinCallbackParameter == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {

                        SendMessage(s, mixinCallbackParameter);
                    }
                }
            }
        }
    }

    void verifyVariables_withName(string mixinName)
    {
        if (myName != mixinName)
            return;

        if (operationType == OperationType.Less)
        {
            if (_data1.data < _data2.data)
            {
                foreach (string s in callbacks)
                {
                    if (mixinCallbackParameter == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {

                        SendMessage(s, mixinCallbackParameter);
                    }
                }
            }
        }
        else if (operationType == OperationType.Equal)
        {
            if (_data1.data == _data2.data)
            {
                foreach (string s in callbacks)
                {
                    if (mixinCallbackParameter == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {

                        SendMessage(s, mixinCallbackParameter);
                    }
                }
            }
        }
        else if (operationType == OperationType.Greater)
        {
            if (_data1.data > _data2.data)
            {
                foreach (string s in callbacks)
                {
                    if (mixinCallbackParameter == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {

                        SendMessage(s, mixinCallbackParameter);
                    }
                }
            }
        }

    }
}
