using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoolCallback : Mixin {


    // MULTI INSTANCE PER GAMEOBJECT

    // bind a bool variable to  it, and when it's true, it will trigger the callback sequence
    // the bool can only call ONE bool callback per time

    public string boolData;
    boolData data;
    public List<string> callbacks;
    public List<string> MixinsNameToBeCalled ;

	// Use this for initialization
	void Start () {

	    boolData[] datas = GetComponents<boolData>();
        foreach(boolData d in datas)
        {
            if (d.MyName == boolData)
            {
                data = d;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
       

        if (data == null)
            return;
        if (data.value)
        {

            
            foreach (string s in callbacks)
            {

                foreach (string s1 in MixinsNameToBeCalled)
                {
                    if (s1 == "")
                    {
                        SendMessage(s);
                    }
                    else
                    {
                        SendMessage(s, s1);
                    }
                }
            }
            data.value = false;
        }


	}


}
