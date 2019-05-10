using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace UnityScanNet
{

    public class HouseLoader : MonoBehaviour
    {
        public House house;

        public void Load()
        {
            Vector3 front = -1*new Vector3(house.front[0],house.front[1],house.front[2]);
            Vector3 up = new Vector3(house.up[0],house.up[1],house.up[2]);
            transform.LookAt(front,up);
            foreach (Transform nodeTransform in transform)
                nodeTransform.GetComponent<NodeLoader>().Load();
        }
    }

    public class NodeLoader : MonoBehaviour
    {
        public Node node;

        public void Load()
        {
            string[] splits = node.modelId.Split('.');
            if (splits[0] == "scannetv2")
            {
                string pathToModel = Config.SCANNET_HOME + "scans/" + splits[1] + "/" + splits[1] + "_vh_clean_2.ply";

                GameObject loadedObject = new GameObject();
                loadedObject.name = splits[1];
                PlyLoader loader = new PlyLoader();
                Mesh mesh = loader.load(pathToModel);
                MeshFilter mf = loadedObject.AddComponent<MeshFilter>();
                mf.mesh = mesh;
                MeshRenderer mr = loadedObject.AddComponent<MeshRenderer>();
                mr.material = new Material(Shader.Find("Custom/VertexColor"));
                
                // Add a MeshCollder to every part of the model
                loadedObject.AddComponent<MeshCollider>();
                // Add rigid body to the gameobject and fix the rotation
                Rigidbody rigid = loadedObject.AddComponent<Rigidbody>();
                rigid.isKinematic = true;
                rigid.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
                
                loadedObject.transform.parent = transform;
                // Apply the transform of the node
                if (node.transform != null)
                {
                    Matrix4x4 matrix = TransformUtils.Array2Matrix4x4(node.transform);
                    TransformUtils.SetTransformFromMatrix(loadedObject.transform, ref matrix);
                }
            }
        }

    }
}
