using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("C# Script")]
public class Event_ : MonoBehaviour
{

    public string[] dialogs;
    public string[] rejectDialogs;
    public float mood;
    public Item_ take;
    public Item_ send;
    public float reqMood;
    public int day;
    public int askIndex;//set to 0 if you don't want to ask
    public Entity_ player;
    public Canvas_ canvas;
    int index = 0;
    bool done = true;

    public void Dialog()
    {
        canvas.Dialogs(done ? dialogs : rejectDialogs);

        index++;
        if (index == askIndex) done = Accept();
    }

    public bool Accept()
    {
        if (take == null || player.inventory.Contains(take))
        {
            if (take != null) player.inventory.Remove(take);
            player.prefer += mood;
            if (send != null) player.inventory.Add(send);
            return true;
        }
        return false;
    }

    public void Awake()
    {
        string[] s = new string[askIndex + rejectDialogs.Length];
        rejectDialogs.CopyTo(s, askIndex);
        rejectDialogs = s;
    }
}
