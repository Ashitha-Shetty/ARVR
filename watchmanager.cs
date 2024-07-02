using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
public class watchmanager : MonoBehaviour
{
    // public GameObject obj1,obj2;
    // // Start is called before the first frame update
    // void Start()
    // {

    // obj1.SetActive(true);
    // obj2.SetActive(false);
    // }
    // // Update is called once per frame
    // public void btnNextClick()
    // {
    // obj1.SetActive(false);
    // obj2.SetActive(true);
    // }
    // public void btnPrevClick()
    // {
    // obj1.SetActive(true);
    // obj2.SetActive(false);
    // }
    public GameObject[] Watchwindow;
    public GameObject[] WatchModel;
    Animation anim1, anim2;
    // Start is called before the first frame update
    void Start()
    {
        WatchModel[0].SetActive(true);
        Watchwindow[0].SetActive(true);
        WatchModel[1].SetActive(false);
        Watchwindow[1].SetActive(false);
        //get component of animation
        anim1 = Watchwindow[0].GetComponent<Animation>();
        anim2 = Watchwindow[1].GetComponent<Animation>();
    }
    public void Watch1()
    {
        WatchModel[0].SetActive(true);
        Watchwindow[0].SetActive(true);
        WatchModel[1].SetActive(false);
        Watchwindow[1].SetActive(false);
        anim1["watch1Anim"].speed = 1.0f;
        anim1.Play();

    }
    public void watch2()
    {
        WatchModel[0].SetActive(false);
        Watchwindow[0].SetActive(false);
        WatchModel[1].SetActive(true);
        Watchwindow[1].SetActive(true);
        anim2["watch2Anim"].speed = 1.0f;
        anim2.Play();
    }
    public void buttonCloseClick()
    {
        string
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        if (buttonName == "close1")
        {
            //reverse of close animation
            anim1["watch1Anim"].speed = -1.0f;
            anim1["watch1Anim"].time =
            anim1["watch1Anim"].length;
            anim1.Play();
        }
        else if (buttonName == "close2")
        {
            anim2["watch2Anim"].speed = -1.0f;
            anim2["watch2Anim"].time =
            anim2["watch2Anim"].length;
            anim2.Play();
        }
    }


}