using System.Collections.Generic;
using UnityEngine;

public class EnergyButtonSwitch : MonoBehaviour
{
    private bool power = false;
    [SerializeField] private EnergyPanel energyPanel;
    [SerializeField] private Lamp lamp1;
    [SerializeField] private Lamp lamp2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            power =!power;
            energyPanel.Touch(power);
            lamp1.TernON(power);
            lamp2.TernON(power);
        }


    }
}
