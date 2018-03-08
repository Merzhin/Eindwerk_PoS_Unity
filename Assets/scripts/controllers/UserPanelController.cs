using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPanelController : MonoBehaviour {
    public Transform contentPanel;
    public GameObject userButtonPrefab;
    private RestController rest;
    private List<GameObject> buttons;

    // Use this for initialization
    void Start()
    {
        buttons = new List<GameObject>();
        rest = GameObject.FindObjectOfType<RestController>();
    }

    public void RefreshDisplay()
    {
        RemoveButtons();
        AddButtons();
    }

    private void RemoveButtons()
    {
        foreach (GameObject obj in buttons)
        {
            obj.SetActive(false);
            GameObject.Destroy(obj);
        }
    }

    private void AddButtons()
    {
        for (int i = 0; i < rest.AvailableUsernames().Count; i++)
        {
            GameObject newButton = GameObject.Instantiate(userButtonPrefab);
            newButton.transform.SetParent(contentPanel, false);
            UserButton userButton = newButton.GetComponent<UserButton>();
            float minY = 1 - .25f * (i + 1);
            float maxY = .25f + minY;
            userButton.setAtAnchors(new Vector2(0, minY), new Vector2(1, maxY));
            userButton.Setup(rest.AvailableUsernames()[i]);
        }
    }
}
