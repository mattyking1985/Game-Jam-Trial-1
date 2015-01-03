using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
