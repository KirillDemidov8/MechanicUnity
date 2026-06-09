using System.Collections.Generic;
using UnityEngine;

public class EnergyPanel : MonoBehaviour
{

    [SerializeField] private DoorScript door;
    [SerializeField] private EnergyButtonSwitch energyButtonSwitch;
  
    

    public void ButtonActive(bool act)
    {
        energyButtonSwitch.enabled = act;
       // Debug.Log(act);
        
    }

    public void Touch(bool e)
    {
       // Debug.Log("22");
        
        door.PowerUpDooor(e);
    }

}
