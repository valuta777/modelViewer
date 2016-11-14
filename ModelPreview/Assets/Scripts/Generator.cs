using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class Generator : MonoBehaviour {

    public GameObject buttonPrefab;
    private Database modelDatabase;
	void Start ()
    {
        modelDatabase = GameObject.Find("Database").GetComponent<Database>();
        foreach (Model model in modelDatabase.modelsDatabase)
        {
            GameObject modelButton = Instantiate(buttonPrefab, gameObject.transform) as GameObject;
            modelButton.GetComponentInChildren<Text>().text = model.title;


            //createng thumbnail
            //Texture2D tx = UnityEditor.AssetPreview.GetAssetPreview(model.model);
            //File.WriteAllBytes(Application.dataPath + "/Resources/Images/" + model.model.name + model.id + ".png", tx.EncodeToPNG());


            modelButton.transform.Find("Image").GetComponent<RawImage>().texture = model.texture;
            int id = model.id;
            UnityAction clickAction = () => { OnButtonClick(id); };
            modelButton.GetComponent<Button>().onClick.AddListener(clickAction);
        }
	
	}

    void OnButtonClick(int id)
    {
        Transform parent = GameObject.Find("ModelContainer").transform;
        foreach (Transform child in parent)
        {
            child.parent = null;
            Destroy(child.gameObject);
        }
        Instantiate(modelDatabase.modelsDatabase.Find(c => c.id == id).model, parent,false);
    }

}
