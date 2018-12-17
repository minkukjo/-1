using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickCircle : MonoBehaviour {

    private Ray ray;
    private RaycastHit hit;
    private string tag_name;
    public GameObject cat;
    public Animator anim;
    public AudioClip[] cat_sound;
    public AudioSource source_audio;
    public int sound_number = 0;
    public GameObject circle;
    public GameObject angry;
	// Use this for initialization
	void Start () {
        anim = cat.GetComponent<Animator>();
        source_audio = cat.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            source_audio.clip = cat_sound[3];
            source_audio.Play();
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == gameObject)
                {
                    tag_name = gameObject.tag;
                    circle.SetActive(false);
                    switch(tag_name)
                    {
                        case "head":
                            anim.SetBool("HEAD", true);
                            sound_number = 0;
                            Invoke("play_sound", 1);
                            Invoke("wait_time", 3);
                            Debug.Log("머리다");
                            break;
                        case "tail":
                            anim.SetBool("TAIL", true);
                            sound_number = 2;

                            Invoke("play_sound", 0.3f);
                            Invoke("wait_time", 2);
                            Debug.Log("꼬리다");
                            break;
                        case "hand":
                            anim.SetBool("HAND", true);
                            sound_number = 1;
                            Invoke("play_sound", 0);
                            Invoke("wait_time", 1);
                            Debug.Log("손이다");
                            break;
                    }
                }
            }
        }
	}

    public void play_sound()
    {
        if(sound_number == 2)
        {
            angry.SetActive(true);
        }
        source_audio.clip = cat_sound[sound_number];
        source_audio.Play();
    }

    public void wait_time()
    {
        anim.SetBool("HEAD", false);
        anim.SetBool("TAIL", false);
        anim.SetBool("HAND", false);
        angry.SetActive(false);
        circle.SetActive(true);

    }
}
