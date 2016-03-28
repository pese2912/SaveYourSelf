using UnityEngine;
using System.Collections;

public class ClickArrow1 : EventScript {

    public GameObject Move;
    public GameObject arrow;
    public override void ClickAction()
    {
        GameObject.Find("Ment0").GetComponent<UITextManager>().EraseText();
        Move.SetActive(true);
        arrow.SetActive(false);
    }
}
