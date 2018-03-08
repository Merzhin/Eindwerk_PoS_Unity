using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinInputPanel : MonoBehaviour {
    private PoSController controller;
    private UserController userController;
    private int pos;
    private string inputText;
    public Text textField;


    // Use this for initialization
    void Start () {
        controller = GameObject.FindObjectOfType<PoSController>();
        userController = GameObject.FindObjectOfType<UserController>();
        InitializePanel(); 
	}

    private void InitializePanel()
    {
        inputText = "";
        textField.text = "";
    }

    public void addNumber(int i)
    {
        inputText += i.ToString();
        UpdateTextField();
    }

    public void removeNumber()
    {
        if (inputText.Length > 0)
        {
            inputText = inputText.Remove(inputText.Length-1);
            UpdateTextField();
        }
    }
    
    public void ConfirmNumber()
    {
        userController.AuthenticateUser(inputText);
        if (userController.IsAuthenticated())
        {
            controller.gotoMainScreen();
        }
        InitializePanel();
    }

    private void UpdateTextField()
    {
        string asterisks = "";
        for (int i=0; i< inputText.Length; i++)
        {
            asterisks += "*";
        }
        textField.text = asterisks;
    }

    public void Reset()
    {
        this.InitializePanel();
    }

}
