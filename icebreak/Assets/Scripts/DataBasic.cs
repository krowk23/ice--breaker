using UnityEngine;
using System.Collections;

public class DataBasic : MonoBehaviour {
	public Player player;
	public Water water;
	
	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player").GetComponent<Player>();
		water=GameObject.Find("Water").GetComponent<Water>();
	}
}
