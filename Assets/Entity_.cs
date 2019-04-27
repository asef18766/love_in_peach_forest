using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Entity_ : MonoBehaviour {
	// Use this for initialization
	public float detect_radius=40;
	int cur_npc_index=0;
	public GameObject indicator;
	Transform tf;
	Vector2 moving_dir;
	public enum  walk_dir{UP,DOWN,LEFT,RIGHT};
	Npc_[] interactable_NPC;
	public List<Item_> inventory;
	public float prefer=0.0f;
	public Canvas_ canvas_;
	public int day=0;
	void Start () {
		tf=GetComponent<Transform>();
		interactable_NPC=FindObjectsOfType<Npc_>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!Canvas_.show)
		{
			move(playerControler());
			interact();
		}
		else
			talk();
		
		spirite_update();
	}
	void talk()
	{
		if(Input.GetKeyDown(KeyCode.Z))
			interactable_NPC[cur_npc_index].interact();
	}
	void spirite_update()
	{
		Vector2 v2 = Camera.main.ScreenToViewportPoint( Input.mousePosition );
		v2.x-=0.5f;
		v2.y-=0.5f;
		float ang=(float)(Math.Acos(v2.normalized.x)*360/(Math.PI*2));
		if(v2.y<0)
			ang=-ang;
		//Debug.Log("ang:"+ang);
		ang=(ang+360)%360;
		tf.rotation=Quaternion.Euler(0,0,ang);
		//Debug.Log(v2);
	}
	walk_dir[] playerControler()
	{
		walk_dir[] ret=new walk_dir[4];
		int element=0;
		if(Input.GetKey(KeyCode.A))
		{
			ret[element]=walk_dir.LEFT;
			element++;
		}
		if(Input.GetKey(KeyCode.W))
		{
			ret[element]=walk_dir.UP;
			element++;
		}
		if(Input.GetKey(KeyCode.D))
		{
			ret[element]=walk_dir.RIGHT;
			element++;
		}
		if(Input.GetKey(KeyCode.S))
		{
			ret[element]=walk_dir.DOWN;
			element++;
		}
		if(element!=4)
			Array.Resize(ref ret,element);
		return ret;
	}
	void move(walk_dir[] w_dir)
	{
		float x=tf.position.x,
			  y=tf.position.y;
		
		for(int u=0;u!=w_dir.Length;++u)
		{
			if(w_dir[u]==walk_dir.LEFT)
				tf.position+=((new Vector3(-1, 0, 0))*Time.deltaTime*tf.localScale.x);

			if(w_dir[u]==walk_dir.UP)
				tf.position+=((new Vector3( 0, 1, 0))*Time.deltaTime*tf.localScale.x);

			if(w_dir[u]==walk_dir.RIGHT)
				tf.position+=((new Vector3( 1, 0, 0))*Time.deltaTime*tf.localScale.x);

			if(w_dir[u]==walk_dir.DOWN)
				tf.position+=((new Vector3( 0,-1, 0))*Time.deltaTime*tf.localScale.x);
		}
		
		moving_dir.x=tf.position.x-x;
		moving_dir.y=tf.position.y-y;
		//Debug.Log(dir);
	}
	int findNearestNPC()
	{
		int index=0;
		for(int i=1;i<interactable_NPC.Length;++i)
		{
			double r1=Math.Sqrt(Math.Pow(tf.transform.position.x-interactable_NPC[index].transform.position.x,2)+
							    Math.Pow(tf.transform.position.y-interactable_NPC[index].transform.position.y,2));
			double r2=Math.Sqrt(Math.Pow(tf.transform.position.x-interactable_NPC[i].transform.position.x,2)+
							    Math.Pow(tf.transform.position.y-interactable_NPC[i].transform.position.y,2));
			if(r1>r2)
				index=i;
		}
		return index;
	}
	void interact()
	{
		Collider2D[] r=Physics2D.OverlapCircleAll(tf.position,detect_radius);
		//Debug.Log("collide with "+r.Length+" objects");
		for( int u=0 ; u!=r.Length ; ++u )
			if(r[u])
			{
				if(r[u].tag!="Player");
					//Debug.Log("obj has tag:"+r[u].tag);
				switch(r[u].tag)
				{
					case "enemy":
						//Debug.Log("enemy spotted.");
						indicator.transform.position=r[u].transform.position;
						break;
					case "npc":
						//Debug.Log("let's having talk.");
						indicator.transform.position=r[u].transform.position;
						if(Input.GetKeyDown(KeyCode.Z))
						{
							cur_npc_index=findNearestNPC();
							Debug.Log("interact npc id:"+cur_npc_index);
							Debug.Log("interact npc size:"+interactable_NPC.Length);
							interactable_NPC[cur_npc_index].interact();
						}
						break;
					case "item":
						Debug.Log("something is on the floor.");
						break;
					case "diary":
						if(Input.GetKeyDown(KeyCode.Z))
							day++;
						break;
				}
			}
				
	}
}
