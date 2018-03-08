using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PoSController : MonoBehaviour {
    private RestController restController;
    private ScreenController screenController;

	// Use this for initialization
	void Start () {
        restController = GameObject.FindObjectOfType<RestController>();
        screenController = GameObject.FindObjectOfType<ScreenController>();
        gotoStartScreen();
	}
	
    public void gotoStartScreen()
    {
        screenController.gotoScreen(PoSScreen.StartScreen);
    }
     public void gotoUserSelectionScreen()
    {
        screenController.gotoScreen(PoSScreen.SelectUserScreen);
        restController.EndShift();
    }

    public void gotoEnterPasswordScreen()
    {
        screenController.gotoScreen(PoSScreen.EnterInitialPasswordScreen);
    }

    public void gotoMainScreen()
    {
        restController.StartShift();
        screenController.gotoScreen(PoSScreen.MainPoSScreen);
    }

	
}
