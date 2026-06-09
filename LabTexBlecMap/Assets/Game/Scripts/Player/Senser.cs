using UnityEngine;public class Senser : MonoBehaviour{    private GameObject currentTarget;

    // Метод, который основной скрипт будет вызывать, чтобы забрать объект
    public GameObject GetTarget()    {        return currentTarget;    }    private void OnTriggerEnter(Collider other)    {
        // Проверяем тег
        if (other.CompareTag("CubeBattonPanel"))        {            currentTarget = other.gameObject;        }
        if (other.TryGetComponent(out EnergyPanel energyPanel))        {            energyPanel.ButtonActive(true);        }    }    private void OnTriggerExit(Collider other)    {
        // Если уходим от того же объекта, что засекли — обнуляем
        if (other.gameObject == currentTarget)        {            currentTarget = null;        }

        if (other.TryGetComponent(out EnergyPanel energyPanel))        {            energyPanel.ButtonActive(false);        }    }}