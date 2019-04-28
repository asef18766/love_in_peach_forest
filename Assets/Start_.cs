using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_ : MonoBehaviour
{

    public GameObject play_bg;
    public GameObject play;
    public GameObject credit;
    public GameObject credit_bg;
    public GameObject back;

    // Use this for initialization
    void Start()
    {
        credit_bg.SetActive(false);
        back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("unity_love_in_peach_forest");
    }

    public void Credit()
    {
        credit_bg.SetActive(true);
        back.SetActive(true);
        play_bg.SetActive(false);
        play.SetActive(false);
        credit.SetActive(false);
    }

    public void Back()
    {
        credit_bg.SetActive(false);
        back.SetActive(false);
        play_bg.SetActive(true);
        play.SetActive(true);
        credit.SetActive(true);
    }
}
