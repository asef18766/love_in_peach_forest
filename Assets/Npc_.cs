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

        if (ev != null)
        {
            if (ev.Dialog())//the event is over
            {
                data.Remove(ev);
                ev = null;
            }
        }
        else
            print("No usable event");
    }
}