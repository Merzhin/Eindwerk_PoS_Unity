using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour {
    private PoSController controller;
    private Button buttonComponent;

    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<PoSController>();
        buttonComponent = gameObject.GetComponent<Button>();
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void HandleClick()
    {
        controller.gotoUserSelectionScreen();
    }
}
