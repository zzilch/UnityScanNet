using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScanNet;

public class SampleJson : MonoBehaviour
{
    public House house;
    public GameObject houseObject;
    // Start is called before the first frame update
    void Start()
    {
        string pathToJson = "Assets/UnityScanNet/Samples/scene0024_01.json";
        house = Scene.GetHouseByJson(pathToJson);
        houseObject = Scene.GetHouseObject(house);
        houseObject.GetComponent<HouseLoader>().Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
