using UnityEngine;
using System.Collections;

public class SceneChangeEvent3 : EventScript {

    public GameObject UI;
    public override void ClickAction()
    {
        StartCoroutine("UiText");

    }
    public IEnumerator UiText()// UI 그려주고 화살표 생성
    {

      

        UI.GetComponent<UITextManager>().DrawText(); // 그려준다
        yield return new WaitForSeconds(3f); //3초 후 
        UI.GetComponent<UITextManager>().EraseText(); // 지운다
        yield return new WaitForSeconds(1f);

    }
}
