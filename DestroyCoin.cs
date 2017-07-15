using UnityEngine;
using System.Collections;

public class DestroyCoin : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log("collision name = " + col.gameObject.name);
		if(col.gameObject.name == "gg")
		{
			Destroy(col.gameObject);
		}
	}
}
