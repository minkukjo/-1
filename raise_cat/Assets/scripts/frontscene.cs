using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontscene : MonoBehaviour {

    // 양육 탭
    public GameObject walking;
    public GameObject shop;
    public GameObject sleep;
    public GameObject goaway;
    public GameObject tool;
    // 양육 & 교감 탭 선정
    public GameObject R;
    public GameObject C;
    public GameObject Cat_Box;
    public GameObject Circle_set;   
    
    // Use this for initialization
    void Start () {
        walking = GameObject.Find("walking");
        shop = GameObject.Find("shoping");
        sleep = GameObject.Find("sleeping");
        goaway = GameObject.Find("going");
        tool = GameObject.Find("tooling");

        R = GameObject.Find("raising_main");
        C = GameObject.Find("comunicate_main");
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void OnClickTouch()
    {
        if(Circle_set.activeSelf)
        {
            Circle_set.SetActive(false);
        }
        else
        {
            Circle_set.SetActive(true);
        }
    }
    public void OnClickR()
    {
        Cat_Box.SetActive(false);
        Circle_set.SetActive(false);
        R.transform.SetAsLastSibling();
    }
    public void OnClickC()
    {
        Cat_Box.SetActive(true);
        Circle_set.SetActive(false);
        C.transform.SetAsLastSibling();
    }
    
    public void OnClickwalking()
    {
        walking.transform.SetAsLastSibling();
    }
    public void OnClickbackwalking()
    {
        walking.transform.SetAsFirstSibling();
    }

    public void OnClickshop()
    {
        shop.SetActive(true);
        shop.transform.SetAsLastSibling();
    }
    public void OnClickbackshop()
    {
        //StopAllCoroutines();
        //shop.SetActive(false);

        shop.transform.SetAsFirstSibling();
    }

    public void OnClicksleep()
    {
        sleep.transform.SetAsLastSibling();
    }
    public void OnClickbacksleep()
    {
        sleep.transform.SetAsFirstSibling();
    }

    public void OnClickgoaway()
    {
        goaway.transform.SetAsLastSibling();
    }
    public void OnClickbackgoaway()
    {
        goaway.transform.SetAsFirstSibling();
    }

    public void OnClicktool()
    {
        tool.transform.SetAsLastSibling();
    }
    public void OnClickbacktool()
    {
        tool.transform.SetAsFirstSibling();
    }

}
