using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_ : MonoBehaviour
{

    public bool show;
    public GameObject dialog_bg;
    public UnityEngine.UI.Text text;
    int index;

    public void Dialogs(string[] s)
    {
        if (!show)
        {
            show = true;
            dialog_bg.transform.position = new Vector3(0, 0, 0);
        }

        if (index >= s.Length)
        {
            index = 0;
            show = false;
            text.text = "";
            dialog_bg.transform.position = new Vector3(-1000, -1000, 0);
            return;
        }

        text.text = s[index];
        index++;
    }

    // Use this for initialization
    void Start()
    {
        dialog_bg.transform.position = new Vector3(-1000, -1000, 0);
        show = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
