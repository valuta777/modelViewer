using UnityEngine;
using System.Collections;
using System.IO;

[System.Serializable]
public class Model {
    private static int lastId = 0;
    public readonly int id;
    public GameObject model;
    public Texture2D texture;
    public string title;
    Model()
    {
        id = lastId++;
    }
}
