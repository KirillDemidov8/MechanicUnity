using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
    private DoorScript doorScript;
    private bool active = false;
    public void GetDoorScript(DoorScript ds)
    {
        doorScript = ds;
    }


    // открытие 
    private void OnCollisionEnter(Collision collision)
    {
        if ( !active && collision.gameObject.tag == "CubeBattonPanel")
        {
            active = true;
            doorScript.ButtonPanelActivated(1);
        }
        
    }
    // закрытие 
    private void OnCollisionExit(Collision collision)
    {
        if (active && collision.gameObject.tag == "CubeBattonPanel")
        {
            active = false;
            doorScript.ButtonPanelActivated(-1);
        }
    }
}
