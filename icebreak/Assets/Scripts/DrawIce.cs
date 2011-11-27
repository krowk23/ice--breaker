using UnityEngine;
using System.Collections;

public class DrawIce : MonoBehaviour {	
	public DataAction data;
	
	private GameObject ARcamera;
	private GameObject  iceHitted;
	private bool isHitIce = false;
	private Vector3 touchDir;
	private Vector3 touchPos = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		ARcamera=GameObject.Find("ARCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.multiTouchEnabled){
			if(Input.touches[0].phase!=TouchPhase.Ended){
				touchPos=new Vector3(Input.touches[0].position.x,Input.touches[0].position.y,0);
				Ray ray=ARcamera.camera.ScreenPointToRay(touchPos);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag=="Ice" && !isHitIce){
															touchDir=-ray.direction;
															iceHitted=hit.transform.gameObject;
															data.SetCurrentIce(iceHitted);
															isHitIce=true;
			}}
			if(Input.touches[0].phase==TouchPhase.Ended){	
				data.SetCurrentIce(null);
				isHitIce=false;
		}
		}else{
			if(Input.GetMouseButton(0)){
				touchPos=Input.mousePosition;
				Ray ray=ARcamera.camera.ScreenPointToRay(touchPos);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag=="Ice" && !isHitIce){
															touchDir=-ray.direction;
															iceHitted=hit.transform.gameObject;
															data.SetCurrentIce(iceHitted);
															isHitIce=true;
			}}
			if(Input.GetMouseButtonUp(0)){			
				data.SetCurrentIce(null);
				isHitIce=false;
		}}
		if(isHitIce)MoveIce();
	}
	
	private void MoveIce(){
		Vector3 iceScreenPos=ARcamera.camera.WorldToScreenPoint(iceHitted.transform.position);
		Vector3 destination=Vector3.zero;
		if(iceScreenPos.z>300)destination.z=(iceScreenPos.z-300)/10;
		destination.x=(touchPos.x-iceScreenPos.x)/10;
		destination.y=(iceScreenPos.y-touchPos.y)/10;
		iceHitted.transform.position+=((ARcamera.transform.InverseTransformDirection(destination)));
	}
}