using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace UnityScanNet
{
    [System.Serializable]
    public class House
    {
        public string sceneId;
        public float[] front;
        public float[] up;
        public float unit;
        public Node[] nodes;

        public static House GetHouse(JSONObject j)
        {
            House house = new House();
            house.sceneId = j.GetField("sceneId").str;
            house.unit = j.GetField("unit").n;
            house.front = new float[3];
            house.up = new float[3];
            JSONObject j_front = j.GetField("front");
            JSONObject j_up = j.GetField("up");
            for(int i=0;i<3;i++)
            {
                house.front[i] = j_front.list[i].n;
                house.up[i] = j_up.list[i].n;
            }
            JSONObject j_nodes = j.GetField("object");
            house.nodes = new Node[j_nodes.list.Count];
            for(int i=0;i<house.nodes.Length;i++)
            {
                house.nodes[i] = Node.GetNode(j_nodes.list[i]);
            }
            return house;
        }

        public static House GetHouse(string id)
        {
            House house = new House();
            house.sceneId = id;
            house.front = new float[3]{0.0F,-1.0F,0.0F};
            house.up = new float[3]{0.0F,0.0F,1.0F};
            house.unit = 1.0F;
            house.nodes = new Node[1];
            house.nodes[0] = Node.GetNode(id);
            return house;
        }

    }

    [System.Serializable]
    public class Node
    {
        public int index;
        public string modelId;
        public float[] transform;
        public int parentIndex;

        public static Node GetNode(JSONObject j)
        {
            Node node = new Node();
            node.index = (int)j.GetField("index").n;
            node.modelId = j.GetField("modelId").str;
            node.parentIndex = (int)j.GetField("parentIndex").n;
            node.transform = new float[16];
            JSONObject j_t = j.GetField("transform").GetField("data");
            for(int i=0;i<16;i++)
            {
                node.transform[i] = j_t.list[i].n;
            }
            return node;
        }

        public static Node GetNode(string id)
        {
            Node node = new Node();
            node.index = 0;
            node.modelId = "scannetv2."+id;
            node.parentIndex = -1;
            node.transform = new float[16]{1F,0F,0F,0F,0F,1F,0F,0F,0F,0F,1F,0F,0F,0F,0F,1F};
            return node;
        }
    }
}
