using UnityEngine;
using System.Collections;

public class control : MonoBehaviour {
	
	public glass wg;
	//private dataBase db;
	// Use this for initialization
	void Start () {
		//db = GameObject.Find("")
		wg = gameObject.GetComponent<glass>();
		if(wg == null) throw new System.Exception("fail to find glass");
		wg.setLv(0);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width*3/4,Screen.height*1/7,70,70),"+2.5")){
			wg.addIce(2.5f);
		}
		if(GUI.Button(new Rect(Screen.width*3/4,Screen.height*3/7,70,70),"+10")){
			wg.addIce(10.0f);
		}
		if(GUI.Button(new Rect(Screen.width*3/4,Screen.height*5/7,70,70),"+20")){
			wg.addIce(20.0f);
		}
	}
}
