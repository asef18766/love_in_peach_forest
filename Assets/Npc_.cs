using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_ : MonoBehaviour {
	public List<Event_> data;
	public string id;
	public Canvas_ canvas_;
    public Entity_ player;
    Event_ ev=null;//ongoing event


	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void interact()
	{
		if(ev==null)
        {
            foreach (Event_ e in data)
            {
                if (player.prefer >= e.reqMood)
                {
                    ev = e;
                    break;
                }
            }
        }
        Debug.Log("fuck you"+(ev==null));
        if (ev != null)
        {Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");
                    Debug.Log("over:"+ev.Dialog());
            if (!Canvas_.show)//the event is over
            {
				Debug.Log("b4 eventlist length:"+data.Count);
                data.Remove(ev);
				Debug.Log("aft eventlist length:"+data.Count);
                ev = null;
            }
        }
        else
            Debug.Log("No usable event");
    }
}