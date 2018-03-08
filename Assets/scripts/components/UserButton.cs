using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserButton : MonoBehaviour {
    private PoSController controller;
    private UserController userController;
    public Button buttonComponent;
    public Text nameLabel;
    public RectTransform buttonTransform;

    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindObjectOfType<PoSController>();
        userController = GameObject.FindObjectOfType<UserController>();
        buttonComponent.onClick.AddListener(HandleClick);
    }

    public void Setup(string username)
    {
        nameLabel.text = username;
    }

    public void HandleClick()
    {
        userController.SetActiveUsername(nameLabel.text);
        controller.gotoEnterPasswordScreen();
    }

    public void setAtAnchors(Vector2 anchorMin, Vector2 anchorMax)
    {
        buttonTransform.anchorMin = anchorMin;
        buttonTransform.anchorMax = anchorMax;
        buttonTransform.offsetMin = new Vector2(0, 0);
        buttonTransform.offsetMax = new Vector2(0, 0);
    }
}
