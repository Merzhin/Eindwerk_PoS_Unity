using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class LogoController : MonoBehaviour {
    private Dictionary<string, Sprite> logos;
    public List<LogoCollectionEntry> logosToImport;

	// Use this for initialization
	void Start () {
        logos = new Dictionary<string, Sprite>();
        foreach (LogoCollectionEntry entry in logosToImport)
        {
            logos.Add(entry.identifier, entry.sprite);
        }
	}
	
	public Sprite getLogo(string logoIdentifier)
    {
        Sprite result;
        logos.TryGetValue(logoIdentifier, out result);
        return result;
    }

    [System.Serializable]
    public class LogoCollectionEntry
    {
        public string identifier;
        public Sprite sprite;
    }
}
