using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestController : MonoBehaviour {
    // courtesy of https://github.com/proyecto26/RestClient

    private static string baseUrl = "http://tomtintel.be:8080/HDR-Rest";
    private List<string> availableUsernames;
    private List<Item> availableItems;
    private PanelController panelController;
    private UserController userController;

    // TODO: remove
    public List<ItemButton> itemButtons;

    // Use this for initialization
    void Start()
    {
        RestClient.DefaultRequestHeaders["Content-Type"] = "application/json";
        UpdateUsersFromRest();
        UpdateItemsFromRest();
        panelController = GameObject.FindObjectOfType<PanelController>();
        userController = GameObject.FindObjectOfType<UserController>();
        // http://localhost:8080/Eindwerk_PoS_Rest/user/addUser?username=TomT&password=1234
    }

    public List<string> AvailableUsernames()
    {
        return availableUsernames;
    }

    public List<Item> AvailableItems()
    {
        return availableItems;
    }

    public Item GetItemWithId(string id)
    {
        Debug.Log("There are " + availableItems.Count + " items available");
        foreach (Item item in availableItems)
        {
            Debug.Log("comparing id: " + id + " with id: " + item.id);
            if (item.id.Equals(id)) return item;
        }
        return null;
    }

    public void EndShift()
    {
        POST(baseUrl+"/shift/endShift");
    }

    public void StartShift()
    {
        POST(baseUrl + "/shift/" + userController.GetActiveUsername());
    }

    public void UploadOrder(Order order)
    {
        string json = orderToJson(order);
        Debug.Log(json);
        POST(json, baseUrl+"/order");
    }

    public WWW POST(string url)
    {
        WWW www;
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");
        // convert json string to byte
        var formData = System.Text.Encoding.UTF8.GetBytes("{}");
        www = new WWW(url, formData ,postHeader);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    public WWW POST(string json, string url)
    {
        WWW www;
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        postHeader.Add("Content-Type", "application/json");
        // convert json string to byte
        var formData = System.Text.Encoding.UTF8.GetBytes(json);
        www = new WWW(url, formData, postHeader);
        StartCoroutine(WaitForRequest(www));
        return www;
    }

    public bool AuthenticateUser(string username, string password)
    {
        bool result = false;
        string json = "{\"username\": \"" + username + "\", \"password\": \"" + password + "\"}";
        Debug.Log(json);
        WWW www = POST(json, baseUrl+"/user/validateUser");
        while (!www.isDone)
        {

        }
        result = bool.Parse(www.text);
        return result;
    }

    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            Debug.Log("There was an error sending request: " + data.error);
        }
        else
        {
            Debug.Log("WWW Request: " + data.text);
        }
    }

    private string orderToJson(Order order)
    {
        string json = "";
        json += "{";

        foreach (KeyValuePair<string, int> kv in order.orderedItems)
        {
            json += "\""+kv.Key+"\": "+kv.Value + ",";
        }

        if (order.orderedItems.Count > 0)
        {
            json = json.Remove(json.Length - 1);
        }
        json += "}";
        return json;
    }

    public void UpdateUsersFromRest()
    {
        List<string> newList = new List<string>();
        RestClient.Get(baseUrl+"/user").Then(response => 
        {
            Debug.Log(response.text);
            newList.AddRange(JsonHelper2.CreateUsernameArrayFromJSON(response.text));
            availableUsernames = newList;
            panelController.updateSelectUserPanel();
        Debug.Log("There are " + availableUsernames.Count + " usernames available");
        });
    }

    public void UpdateItemsFromRest()
    {
        List<Item> newList = new List<Item>();
        RestClient.Get(baseUrl+"/item").Then(response =>
        {
            Debug.Log(response.text);
            newList.AddRange(JsonHelper2.CreateItemArrayFromJSON(response.text));
            availableItems = newList;
            Debug.Log("There are " + availableItems.Count + " items available");

            Debug.Log("there are "+itemButtons.Count+"registered ItemButtons");
            //TODO: remove
            foreach (ItemButton button in itemButtons)
            {
                Debug.Log("Setting up ItemButton with id: " + button.id);
                button.Setup(newList);
            }

        });
    }

    public static String[] CreateUsernameArrayFromJSON(string jsonString)
    {
        jsonString = "{\"Items\":" + jsonString + "}";
        return JsonHelper2.FromJson<String>(jsonString);
    }
}
