# UnityScanNet
A simple ScanNet viewer and physics simulator based on Unity , tested in Unity 2018.3

### Dependency
- [Runtime PLY Importer](https://github.com/zzilch/unity_ply_loader): runtime ply model reader, modified on [andy-thomason's repo](https://github.com/andy-thomason/unity_ply_loader)
#### Optional
 - [C++ PLY Importer](https://github.com/zzilch/UnityPlyLoader): another runtime ply model reader, easy to extend, modified on [warmtrue's repo](https://github.com/warmtrue/UnityPlyLoader)
 - [JSONObject](https://assetstore.unity.com/packages/tools/input-management/json-object-710): ScanNet exported json reader, free

### File Organization
```shell
UnityScanNet
    |-- Assets
        |-- UnityScanNet
            |-- Config.cs - Environment settings
            |-- Json.cs - Data structure for ScanNet
            |-- Scene.cs - Json loader and gameobjects creator
            |-- Loader.cs - Meshes, materials and colliders loader
            |-- Utils.cs - Useful functions
            |-- Shaders
                |-- VertexColor.shader - Shader for vertex color
                |-- VertexColor2.shader - Shader for vertex color with light
                |-- VertexColor3.shader - Shader for vertex color with light and alpha
            |-- Samples
                |-- SampleId.cs - A sample for loading a scene by id
                |-- SampleJson.cs - A sample for loading a scene by exported json
        |-- JSON - JSONObject assets
        |-- PLYLoader - Runtime PLY lodaer
```

### Usage
1. Download ScanNet dataset
2. Set `Config.SCANNET_HOME` as path to ScanNet

#### Load a scene by id  
See the scene SampleId in UnityEditor
```c#
    string id = "scene0024_01";
    house = Scene.GetHouseById(id);
    houseObject = Scene.GetHouseObject(house);
    houseObject.GetComponent<HouseLoader>().Load();
```
#### Load a scene by exported json
See the scene SampleJson in UnityEditor
```c#
    string pathToJson = "Assets/UnityScanNet/Samples/scene0024_01.json";
    house = Scene.GetHouseByJson(pathToJson);
    houseObject = Scene.GetHouseObject(house);
    houseObject.GetComponent<HouseLoader>().Load();
```
