using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTab : MonoBehaviour {

    // Use this for initialization
    public int Tabbuttonindex = 0;
    
    public void clickbuttontoy()
    {
        Tabbuttonindex = 0;
    }
    public void clickbuttonfood()
    {
        Tabbuttonindex = 1;
    }

    public int getclickbutton()
    {
        return Tabbuttonindex;
    }
}
