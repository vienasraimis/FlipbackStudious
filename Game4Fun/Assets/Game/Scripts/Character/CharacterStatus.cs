using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{
    public UIElements ui;

    #region publics

    public void Step(Vector3 move)
    {
        //Pythagoras
        var steps = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2));
        ui.stepbar.value -= steps;


        //Blood overlap
        var alpha = GetAlpha();
        ui.OverLap.color = new Color(ui.OverlapColor.r, ui.OverlapColor.g, ui.OverlapColor.b, alpha);
    }

    public void AddHealth(float health)
    {
        ui.stepbar.value += health/10;
    }
    
    public float GetAlpha()
    {
        return (ui.stepbar.maxValue - ui.stepbar.value) / ui.stepbar.maxValue;
    }

    public void SpeedBoost(float speed, float t)
    {
        if (t == 0) return;
    }

    #endregion

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