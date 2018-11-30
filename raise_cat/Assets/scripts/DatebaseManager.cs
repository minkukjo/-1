using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatebaseManager : MonoBehaviour {

    static public DatebaseManager instance;

	// Use this for initialization
	private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;

    public List<ToyandItem> itemList = new List<ToyandItem>();


    void Start()
    {
        itemList.Add(new ToyandItem("item1", 100, "장난감", "장난감들 리스트를 확인하는는 과정입니다.", ToyandItem.ItemType.Toy));
        itemList.Add(new ToyandItem("item2", 200, "먹이", "특식(먹이) 리스트를 확인하는 과정입니다..", ToyandItem.ItemType.Use));

    
        itemList.Add(new ToyandItem("item1", 100, "고양이풀", "고양이들이 너무너무 좋아하는 고양이 푸울 ~", ToyandItem.ItemType.Toy));
        itemList.Add(new ToyandItem("item2", 200, "참치", "냥이 친구들 끼리 먹다가 없어져도 모를만큼 맛있는 참치캔 ~", ToyandItem.ItemType.Use));

    }




}
