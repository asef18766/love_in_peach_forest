using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Judge : MonoBehaviour {
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		judge();
	}
	void judge()
	{
		Entity_ player=FindObjectOfType<Entity_>();
		if(player.prefer==50)
		{
			Debug.Log("ending!");
			while(true)
			{
				;
			}
		}
	}
}
