using System.Collections.Generic;
using UnityEngine;


public class DoorScript : MonoBehaviour
{
  [SerializeField] private List<ButtonPanel> buttonPanels;
    private int bpActive = 0;
    private bool energy = false;

    private void Start()
    {
        foreach (var buttonPanel in buttonPanels)
        {
            buttonPanel.GetDoorScript(this);
        }
    }
    public void ButtonPanelActivated(int act)
    {
        bpActive+= act;
        if (bpActive >= buttonPanels.Count)
        {
            OpenTheDoor();
           
        }
        else { CloseTheDoor(); }
    }


    public void PowerUpDooor(bool e)
    {
        energy = e;
        OpenTheDoor();
    }
    public void OpenTheDoor()
    {
        if (energy == true && bpActive >= buttonPanels.Count)
        {
            gameObject.SetActive(false);
        }
       
    }
    public void CloseTheDoor()
    {
        if (energy == true)
        {
            gameObject.SetActive(true);
        }
        
    }
}
