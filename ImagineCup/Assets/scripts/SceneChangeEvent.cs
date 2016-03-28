using UnityEngine;
using System.Collections;

public class SceneChangeEvent : EventScript {

    public override void ClickAction()
    {
        Application.LoadLevel("FireSafeSimulation");
    }
}
