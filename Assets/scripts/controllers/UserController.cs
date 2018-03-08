using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {
    private string activeUsername;
    private bool isAuthenticated;
    private RestController restController;

	// Use this for initialization
	void Start () {
        restController = GameObject.FindObjectOfType<RestController>();
        activeUsername = "";
        isAuthenticated = false;
	}
	
    public string GetActiveUsername()
    {
        return activeUsername;
    }

	public void SetActiveUsername(string username)
    {
        activeUsername = username;
        isAuthenticated = false;
    }

    public bool AuthenticateUser(string password)
    {
        isAuthenticated = restController.AuthenticateUser(activeUsername, password);
        return isAuthenticated;
    }

    public bool IsAuthenticated()
    {
        return isAuthenticated;
    }
}
