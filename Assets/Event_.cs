using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("C# Script")]
public class Event_ : MonoBehaviour
{

    public string[] dialogs;
    public string[] rejectDialogs;
    public float mood;
    public float viliage_mood;
    public Item_ take;
    public Item_ send;
    public float reqMood;
    public float village_reqMood;
    public int day;
    public int askIndex;//問句是第幾句，set to -1 if you don't want to as
    public Entity_ player;
    public Canvas_ canvas;
    int index = 0;
    bool done = true;

    public void Dialog()
    {
        if (index == 0) Init();
        Debug.Log(dialogs[0]);

        if (index - 1 == askIndex) done = Accept();
        canvas.Dialogs(done ? dialogs : rejectDialogs);

        index++;
    }

    public bool Accept()
    {
        if ((take == null || player.inventory.Contains(take)) && Input.GetKey("z"))//任務成功
        {
            if (take != null) player.inventory.Remove(take);
            player.prefer += mood;
            player.village_prefer+=viliage_mood;
            if (send != null) player.inventory.Add(send);
            return true;
        }
        return false;
    }

    public void Init()
    {
        dialogs[askIndex] += " (Z: 接受, X: 反對)";

        string[] s = new string[askIndex +1+ rejectDialogs.Length];
        rejectDialogs.CopyTo(s, askIndex+1);
        rejectDialogs = s;
    }
}
