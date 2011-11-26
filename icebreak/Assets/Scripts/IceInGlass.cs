using UnityEngine;
using System.Collections;

public class IceInGlass : MonoBehaviour {
	public DataBasic data;
	public Glass glass;
	private Rect range;
	
	// Use this for initialization
	void Start () {
		data=GameObject.Find("DataBasic").GetComponent<DataBasic>();
		glass=GameObject.Find("Glass").GetComponent<Glass>();
		range=glass.smallR;
	}
	
	// Update is called once per frame
	void Update () {
		if(data.player.GetIce()!=null){
			Vector2 touchPos=Input.touches[0].position;
			if(touchPos.x<range.xMax && touchPos.x>range.xMin && 
			   touchPos.y<range.yMax && touchPos.y>range.yMin){
														AddIce();		
			}
		}
	}
	
	public void AddIce(){
		GameObject ice = data.player.GetIce();
		//double water =  //count the ice volume
		//data.water.AddWater(water);
	}
}
