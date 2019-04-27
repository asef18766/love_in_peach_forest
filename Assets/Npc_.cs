using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc_ : MonoBehaviour {
	public List<Event_> data;
	public string id;
	public Canvas_ canvas_;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void interact()
	{
		string[] test_str=new string[]{"123","456"};
		canvas_.Dialogs(test_str);
	}
}