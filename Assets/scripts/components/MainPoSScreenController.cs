using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPoSScreenController : MonoBehaviour {
    public GameObject[] itemPanels;

	// Use this for initialization
	void Start () {
        ActivatePanel(0);
	}
	
	public void ActivatePanel(int panel)
    {
        foreach(GameObject o in itemPanels)
        {
            o.SetActive(false);
        }
        itemPanels[panel].SetActive(true);
    }
}
