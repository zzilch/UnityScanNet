using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScanNet;

public class SampleId : MonoBehaviour
{
    public House house;
    public GameObject houseObject;
    // Start is called before the first frame update
    void Start()
    {
        string id = "scene0024_01";
        house = Scene.GetHouseById(id);
        houseObject = Scene.GetHouseObject(house);
        houseObject.GetComponent<HouseLoader>().Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
