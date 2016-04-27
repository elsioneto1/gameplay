using UnityEngine;
using System.Collections;

public class Mixin : MonoBehaviour {

    // mixin base

	public string myName;
	protected GameObject recipient;

	public void SetRecipient(GameObject recip)
	{
		recipient = recip;
	}

	public GameObject GetRecipient()
	{
		return recipient;
	}	
}
