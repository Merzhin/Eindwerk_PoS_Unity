using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {
    private Dictionary<PoSScreen, GameObject> screens;
    public GameObject startScreen;
    public GameObject selectUserScreen;
    public GameObject enterInitialPasswordScreen;
    public GameObject mainPosScreen;

	// Use this for initialization
	void Start () {
        screens = new Dictionary<PoSScreen, GameObject>();
        screens.Add(PoSScreen.StartScreen, startScreen);
        screens.Add(PoSScreen.SelectUserScreen, selectUserScreen);
        screens.Add(PoSScreen.EnterInitialPasswordScreen, enterInitialPasswordScreen);
        screens.Add(PoSScreen.MainPoSScreen, mainPosScreen);
	}

    public void gotoScreen(PoSScreen screen)
    {
        foreach (KeyValuePair<PoSScreen, GameObject> pair in screens)
        {
            if (pair.Key.Equals(screen)) pair.Value.SetActive(true);
            else pair.Value.SetActive(false);
        }
    }
}

public enum PoSScreen
{
    StartScreen,
    SelectUserScreen,
    EnterInitialPasswordScreen,
    MainPoSScreen
}

