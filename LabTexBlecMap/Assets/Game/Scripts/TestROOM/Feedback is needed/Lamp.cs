using UnityEngine;

public class Lamp : MonoBehaviour
{
    Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
    }
    public void TernON(bool power)
    {
        if (power == false)
        {
           
            renderer.material.color = Color.red;
        }
        else if (power == true)
        {
           
            renderer.material.color = Color.green;
        }
       
    }
}
