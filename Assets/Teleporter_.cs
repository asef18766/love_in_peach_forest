using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter_ : MonoBehaviour {

	Entity_ player;
	public float detect_radius;
	public Teleporter_ des;
	public bool avaible=true;
	void Start () {
		player=FindObjectOfType<Entity_>();
	}
	
	// Update is called once per frame
	void Update () {
		if(detect()&&avaible)
			StartCoroutine(teleport());
	}
	IEnumerator teleport()
	{
		des.avaible=false;
		player.transform.position=des.transform.position;
		yield return new WaitForSeconds(2);
		des.avaible=true;

		
	}
	bool detect()
	{
		Collider2D[] r=Physics2D.OverlapCircleAll(GetComponent<Transform>().position,detect_radius);
		for(int i=0;i!=r.Length;++i)
		{
			if(r[i].tag=="Player")
			{
				return true;
			}
		}
		return false;
	}
}
