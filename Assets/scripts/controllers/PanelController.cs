using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {
    private UserPanelController userPanel;

	// Use this for initialization
	void Start () {
        userPanel = GameObject.FindObjectOfType<UserPanelController>();
	}
	
    public void updateSelectUserPanel()
    {
        userPanel.RefreshDisplay();
    }
}
