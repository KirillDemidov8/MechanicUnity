using UnityEngine;public class Picker : MonoBehaviour{    [SerializeField] private Senser sensor; // —сылка на наш новый скрипт сенсора
    [SerializeField] private Transform holdPoint;    [SerializeField] private float smoothSpeed = 10f;

    private GameObject carriedCube;

    void Update()    {        if (Input.GetMouseButtonDown(0))
        {            if (carriedCube == null)                PickUp();            else                Drop();        }        if (carriedCube != null)        {            carriedCube.transform.position = Vector3.Lerp(carriedCube.transform.position, holdPoint.position, Time.deltaTime * smoothSpeed);            carriedCube.transform.rotation = Quaternion.Lerp(carriedCube.transform.rotation, holdPoint.rotation, Time.deltaTime * smoothSpeed);        }    }    void PickUp()    {
        // —прашиваем у сенсора, видит ли он куб
        GameObject target = sensor.GetTarget();
        if (target == null) return;        carriedCube = target;        carriedCube.transform.SetParent(holdPoint);

        Rigidbody rb = carriedCube.GetComponent<Rigidbody>();        if (rb != null)        {            rb.isKinematic = true;            rb.useGravity = false;        }    }    void Drop()    {        Rigidbody rb = carriedCube.GetComponent<Rigidbody>();        if (rb != null)        {            rb.isKinematic = false;            rb.useGravity = true;        }        carriedCube.transform.SetParent(null);        carriedCube = null;    }}