using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace UnityScanNet
{
    public class Scene
    {
        public static House GetHouseById(string id)
        {
            return House.GetHouse(id);
        }
        public static House GetHouseByJson(string pathToJson)
        {
            return GetHouseByJsonObject(new JSONObject(File.ReadAllText(pathToJson)));
        }
        public static House GetHouseByJsonObject(JSONObject j)
        {
            return House.GetHouse(j.GetField("scene"));
        }
        /// create house gameobject by house json
        public static GameObject GetHouseObject(House house)
        {

            GameObject houseObject = new GameObject("House#" + house.sceneId);
            HouseLoader houseLoader = houseObject.AddComponent<HouseLoader>();
            houseLoader.house = house;

            foreach (Node node in house.nodes)
            {
                GameObject nodeObject = GetNodeObject(node);
                nodeObject.transform.parent = houseObject.transform;
            }
            return houseObject;
        }

        // create object gameobject by node json
        public static GameObject GetNodeObject(Node node)
        {
            GameObject nodeObject = new GameObject("Node#" + node.modelId);
            NodeLoader nodeLoader = nodeObject.AddComponent<NodeLoader>();
            nodeLoader.node = node;
            return nodeObject;
        }


    }
}
