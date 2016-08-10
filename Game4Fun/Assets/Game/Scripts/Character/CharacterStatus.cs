using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{
    public UIElements ui;

    public void Step(Vector3 move)
    {
        //Pythagoras
        var steps = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2));
        ui.stepbar.value -= steps;
    }
}

[System.Serializable]
public class UIElements
{
    public Slider stepbar;
}
