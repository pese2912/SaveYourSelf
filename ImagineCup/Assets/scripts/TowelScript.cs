using UnityEngine;
using System.Collections;

public class TowelScript : MonoBehaviour {

    public GameObject towelOnTheTable;
    public GameObject towelBeforeWet;
    public GameObject wetTowel;
    public GameObject uiTextManager;
    public GameObject Arrow;
    public GameObject Direction;
    public GameObject towel;
    public GameObject Player;

    [HideInInspector]
    public enum State { table, hand, wet };

    public State state;

	// Use this for initialization
	void Start () {
        state = State.table;
        Player = GameObject.Find("Player");
        Direction = GameObject.Find("Direction");
	}
	
	// Update is called once per frame
	void Update () {

       

	    switch(state)
        {
            case State.table :
                towelBeforeWet.SetActive(false);
                wetTowel.SetActive(false);
                towelOnTheTable.SetActive(true);
                break;
            case State.hand :
                wetTowel.SetActive(false);
                towelOnTheTable.SetActive(false);
                towelBeforeWet.SetActive(true);
                break;
            case State.wet :
                towelOnTheTable.SetActive(false);
                towelBeforeWet.SetActive(false);
                wetTowel.SetActive(true);
                break;
        }
	}

    public void UiManager(string ui, string arrow) // UI 그려주고 화살표 생성
    {
        StartCoroutine(UiText(ui, arrow));
    }

    public IEnumerator UiText(string ui, string arrow)// UI 그려주고 화살표 생성
    {

        yield return new WaitForSeconds(1f); 
        uiTextManager = GameObject.Find(ui); // 해당 ui문장을 

        uiTextManager.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후

        uiTextManager.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);

        Arrow = GameObject.Find(arrow);
        yield return new WaitForSeconds(1f);


        GameObject.Find("Ment0").GetComponent<UITextManager>().DrawText();
        Direction.transform.FindChild("Arrow5").gameObject.SetActive(true); 

        Arrow.GetComponent<SelectableObject>()._IsArrowAppearing = true; // 해당 오브젝트 위 화살표 활성화
        StartCoroutine("CheckMove");
    }
    IEnumerator CheckMove()
    {
        yield return null;
        GameObject pposition = GameObject.Find("Position7");

        while (true)
        {
            if (Player.transform.position == pposition.transform.position)
            {
                GameObject.Find("Ment10").GetComponent<UITextManager>().DrawText();
                GameObject.Find("Move7").SetActive(false);
                break;
            }

            yield return null;
        }
    }
    public void ChangeStateTable()
    {
        this.state = State.table;
    }

    public void ChangeStateHand()
    {
        this.state = State.hand;
    }

    public void ChangeStateWet()
    {
        this.state = State.wet;
    }

   
  
}
