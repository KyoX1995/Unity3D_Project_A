using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_layer_change : MonoBehaviour {
 
    GameObject[] layer_change_gos;
    // Use this for initialization
    void Start () {
        layer_change_gos = GameObject.FindGameObjectsWithTag("Layer_change");
        
    }
	
	// Update is called once per frame
	void Update () {
      

    }

    private void OnTriggerEnter(Collider collider)
    {

        foreach (GameObject layer_change_go in layer_change_gos)
        {
            string name_cur = layer_change_go.GetComponent<SpriteRenderer>().sortingLayerName;
            if (name_cur == "FrontOfPlayer")
            {
                layer_change_go.GetComponent<SpriteRenderer>().sortingLayerName = "BehindPlayer";
            }
        }
    }
}
