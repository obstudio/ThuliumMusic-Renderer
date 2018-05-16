using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class parsedInfo {
	public section[] Sections;
	
	public static parsedInfo CreateFromJSON(string json) {
		return JsonMapper.ToObject<parsedInfo>(json);
	}
}
public class section {
	public track[] Tracks;
	//Warnings;
}
public class track {
	//Notation;
	public content[] Content;
	//Warnings;
	//Settings;
	//Meta;
	//Effects;
}
public class content {
	public int Pitch;
	public double Volume;
	public double StartTime;
	public double Duration;
}

[System.Serializable]
public class Create : MonoBehaviour {
	public Object prefabObject;

	// Use this for initialization
	void Start () {
		string data = File.ReadAllText(Application.dataPath + "/test.json");
		parsedInfo ParsedInfo = parsedInfo.CreateFromJSON(data);

		foreach(section Section in ParsedInfo.Sections) {
			foreach(track Track in Section.Tracks) {
				foreach(content Content in Track.Content) {
					GameObject Instance = (GameObject)Instantiate(prefabObject, new Vector3(Content.Pitch - 10, ((float)Content.StartTime + 2) * 5 - 3, 0), Quaternion.identity);
					Instance.GetComponent<CubePrefab>().SetDuration(Content.Duration);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
