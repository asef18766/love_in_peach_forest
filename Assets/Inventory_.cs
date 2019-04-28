using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_ : MonoBehaviour {

    public GameObject nothing;
    bool show;
    public static string[] itemList = { "戒指", "打火機", "用過的衛生紙", "狗", "桃花夾", "髮夾", "瓢蟲", "貓", "鋼筆", "錢包" };
    List<GameObject> list=new List<GameObject>();

	// Use this for initialization
	void Start () {
        show = false;
        gameObject.SetActive(false);
        nothing.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowHide(Entity_ player)
    {
        if(show)
        {
            gameObject.SetActive(false);
            foreach(GameObject cross in list)
            {
                Destroy(cross);
            }

            list.Clear();
        }
        else
        {
            gameObject.SetActive(true);
            bool[] a = new bool[10];
            foreach (Item_ item in player.inventory)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (itemList[i].Equals(item.n))
                    {
                        a[i] = true;
                        break;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Vector3 v = transform.position;
                if (!a[i])
                {
                    GameObject cross = Instantiate(nothing) as GameObject;
                    cross.transform.position = new Vector3(v.x + 3.5f * (i / 5), v.y + -2 * (i % 5));
                    cross.SetActive(true);
                    list.Add(cross);
                }
            }
        }

        show = !show;
    }
}
