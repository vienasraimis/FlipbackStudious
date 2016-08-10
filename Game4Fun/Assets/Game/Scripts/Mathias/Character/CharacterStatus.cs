using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class CharacterStatus : MonoBehaviour
{
    public UIElements ui;

    public void Step(Vector3 move)
    {
        //Pythagoras
        var steps = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2));
        ui.stepbar.value -= steps;

        var alpha = (ui.stepbar.maxValue - ui.stepbar.value) / ui.stepbar.maxValue;

        ui.OverLap.color = new Color(ui.OverlapColor.r, ui.OverlapColor.g, ui.OverlapColor.b, alpha);
    }

    public void AddHealth(float health)
    {
        ui.stepbar.value += health;
    }

    void Awake()
    {
        ui.Awake();
    }
}

[System.Serializable]
public class UIElements
{
    [Header("Health related")]
    public Slider stepbar;

    public Image OverLap;
    public Color OverlapColor;

    public void Awake()
    {
        OverlapColor = OverLap.color;
    }
}