using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraPositioningValues))]
public class CameraScriptEditor : Editor {

    CameraPositioningValues trgt;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	public void OnSceneGUI () {


        //DrawDefaultInspector();
        UnityEditor.Handles.BeginGUI();
        if (trgt == null)
        {
            trgt = (CameraPositioningValues)target;
        }

        UnityEditor.Handles.color = Color.blue;

        UnityEditor.Handles.Label(trgt.PositionofInterestOpposite(), "Opposite");
        
        //Handles.BeginGUI(new Rect(0,0,100,100));
        //Handles.EndGUI();
	}



}
