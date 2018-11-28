using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inventory : MonoBehaviour {

    private Itemlistslot[] slots; // 아까전에 짠 인벤토리 슬롯 UI

    private List<ToyandItem> itemlist; // 플레이어가 소지한 아이템 리스트

    public Text Description_text; // 아이템 설명
    public string[] tabDescription; // 탭 부연 설명 - 이건 아직까지 필요 없다. 

    public Transform tf; // slot 부모 객체

    public GameObject go; // 인벤토리 활성화 비활성화
    public GameObject[] selectedTabImages;


    public int selectedItem; // 선택된 아이템
    private int selectedtab; // 선택된 템

    private bool activated; // 인벤토리 활성화시 true;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


	// Use this for initialization
	void Start () {
        itemlist = new List<ToyandItem>();
        slots = tf.GetComponentsInChildren<Itemlistslot>();
	}
	
    

	
}
