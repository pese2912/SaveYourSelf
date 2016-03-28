using UnityEngine;
using System.Collections;

public class BodyEvent : EventScript {

    public GameObject target;

    public override void ClickAction()
    {
        target.GetComponent<FEctl>().isObjectSelected = true;
    }
}
