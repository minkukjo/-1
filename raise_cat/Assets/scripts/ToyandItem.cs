using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyandItem : MonoBehaviour {

    public string imagefilename; // Resources 파일의 이미지 파일 이름
    public int itemID; // 아이템의 고유 ID, 중복 불가
    public string itemName; // 아이템의 이름, 중복가능
    public string itemDescription; // 아이템 설명
    public int itemCount;
    public Sprite itemIcon;
    public ItemType itemType; // 장난감, 먹이

    public enum ItemType {
          Use,
          Toy
    }
    public ToyandItem(string _ifn,int _itemID, string _itemName,string _itemDes,ItemType _itemType , int _itemCount = 1)
    {
        imagefilename = _ifn;
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
        // 생성시 만약 이미지와 itemID 를 값을 다르게 선언 했다면
        // 그 파일의 이름을 String 타입의 파라미터로 받아와야됩니다.
        // ex) "고양이껌"

        itemIcon = Resources.Load(_ifn, typeof(Sprite)) as Sprite;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
