using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class inventory : MonoBehaviour {


    //private OrderManager theOrder;
        // 캐릭터가 움직이면 안되겠죠 ?

    private Itemlistslot[] slots; // 아까전에 짠 인벤토리 슬롯 UI

    private List<ToyandItem> itemList; // Shop에서 소지한 아이템 리스트
    private List<ToyandItem> TabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트

    public Text Description_text; // 아이템 설명
    public string[] tabDescription; // 탭 부연 설명 - 이건 아직까지 필요 없다. 
    

    public Transform tf; // slot 부모 객체

    public GameObject go; // 인벤토리 활성화 비활성화
    public GameObject[] selectedTabImages;


    public int selectedItem; // 선택된 아이템
    private int selectedtab; // 선택된 탭

    private bool activated; // 인벤토리 활성화시 true;
    private bool tabActivated; // 탭 활성화시
    private bool itemActivated; // 아이템 활성화시 true
    private bool stopKeyinput; //키 입력 제한(소비할때 질의가 나올텐데 그때 키입력 방지)
    private bool preventExec;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);
    

	// Use this for initialization
	void Start () {
        itemList = new List<ToyandItem>();
        TabList = new List<ToyandItem>();
        slots = tf.GetComponentsInChildren<Itemlistslot>();

        itemList.Add(new ToyandItem("item1", 100, "장난감", "장난감들 리스트를 확인하는는 과정입니다.", ToyandItem.ItemType.Toy));
        itemList.Add(new ToyandItem("item2", 200, "먹이", "특식(먹이) 리스트를 확인하는 과정입니다..", ToyandItem.ItemType.Use));


        itemList.Add(new ToyandItem("item1", 100, "고양이풀", "고양이들이 너무너무 좋아하는 고양이 푸울 ~", ToyandItem.ItemType.Toy));
        itemList.Add(new ToyandItem("item2", 200, "참치", "냥이 친구들 끼리 먹다가 없어져도 모를만큼 맛있는 참치캔 ~", ToyandItem.ItemType.Use));


    }

    public void RemoveSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } // Shop 슬롯 초기화

    public void ShowTab()
    {
        RemoveSlot();
        SelectedTab();
    } // 탭 활성화
    public void SelectedTab()
    {
        StopAllCoroutines();

        Color color = selectedTabImages[selectedtab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i=0;i< selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color;
        }
        Description_text.text = tabDescription[selectedtab];
        StartCoroutine(SelectedTabEffectCoroutine());
    } // 선택된 탭을 제외하고 다른 모든 탭의 컬러 초기화(0)
    IEnumerator SelectedTabEffectCoroutine()
    {
        while (tabActivated)
        {
            Color color = selectedTabImages[0].GetComponent<Image>().color;
            while(color.a < 0.5f){
                color.a += 0.03f;
                selectedTabImages[selectedtab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedtab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } // 선택된 탭 반짝임 효과
    
    public void Showitem()
    {
        TabList.Clear();
        RemoveSlot();
        selectedItem = 0;

        switch (selectedtab)
        {
            case 0:
                for(int i = 0; i< itemList.Count; i++)
                {
                    if (ToyandItem.ItemType.Use == itemList[i].itemType)
                        TabList.Add(itemList[i]);
                }
                break;
            case 1:
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (ToyandItem.ItemType.Toy == itemList[i].itemType)
                        TabList.Add(itemList[i]);
                }
                break;
        } // 탭에 따른 아이템 분류, 그것을 아이템 ShopList 에 추가

        for(int i =0; i<TabList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(TabList[i]);
        } // Shop 탭 리스트 내용을 Shop 슬롯에 추가

        SelectedItem();

    }// 아이템 활성화(TabList 에 조건에 맞는 아이템들만 넣어주고, 인벤토리 슬롯에 출력)
    public void SelectedItem()
    {
        StopAllCoroutines();
        if(TabList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for (int i = 0; i < TabList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color;
            
            Description_text.text = TabList[selectedItem].itemDescription;
            // 반짝반짝 거리는거
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
        {
            Description_text.text = "해당 타입의 아이템을 가지고 있지 않습니다.";
        }
    } // 선택된 아이템을 제외하고, 다른 모든 탭의 컬러 값을 0으로 조정
    IEnumerator SelectedItemEffectCoroutine()
    {
        while (itemActivated)
        {
            Color color = slots[selectedItem].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } // 선택된 아이템 반짝임 효과

    void Update()
    {
        
        if (!stopKeyinput)
        {
            // 클릭하면 반짝반짝
            if (Input.GetKeyDown(KeyCode.I))
            {
                activated = !activated;

                if (activated)
                {
                    go.SetActive(true);
                    selectedtab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
                else
                {
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false;
                }
            }
            // 탭을 방향키로 이동
            if (activated)
            {
                if (tabActivated)
                {
                    // 좌,우 방향키 누르면 탭이 이동
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (selectedtab < selectedTabImages.Length - 1)
                            selectedtab++;
                        else
                            selectedtab = 0;
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (selectedtab > 0)
                            selectedtab--;
                        else
                            selectedtab = selectedTabImages.Length - 1;
                        SelectedTab();
                    }
                    // 선택하면 각 탭의 아이템들이 나오는 것
                    else if (Input.GetKeyDown(KeyCode.Z))
                    {
                        // 아예 아이템창 선택
                        Color color = selectedTabImages[selectedtab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedtab].GetComponent<Image>().color = color;
                        //아이템창 활성화
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true;
                        Showitem();
                    }
                } // 탭활성화시 키입력 처리

                else if (itemActivated)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (selectedItem < TabList.Count - 1)
                            selectedItem += 1;
                        else
                            selectedItem = 0;

                        SelectedItem();

                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (selectedItem > 1)
                            selectedItem -= 1;
                        else
                            selectedItem = TabList.Count -1 - selectedItem;

                        SelectedItem();
                    }
                    /*
                    else if (Input.GetKeyDown(KeyCode.RightArrow))
                    {

                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {

                    }
                    */
                    else if (Input.GetKeyDown(KeyCode.Z) && !preventExec )
                    {
                        if(selectedtab == 0)
                        {
                            stopKeyinput = true;
                            // 물약을 마실거냐 ? 같은 선택지 호출
                        }
                        else if(selectedtab == 1)
                        {
                            //장비 장착
                        }
                        else
                        {
                            // 물약, 장비를 제외한것이다.
                        }

                    }
                    else if (Input.GetKeyDown(KeyCode.X))
                    {
                        // 뒤로가기
                        StopAllCoroutines();
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }
                } // 아이템 활성화시 키 입력 처리.

                if (Input.GetKeyUp(KeyCode.Z)) // 중복 실행 방지
                    preventExec = false;
            }
        }
    }
    

	
}
