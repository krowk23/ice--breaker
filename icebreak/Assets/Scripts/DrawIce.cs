using UnityEngine;
using System.Collections;

public class DrawIce : MonoBehaviour {	
	
	private GameObject ARcamera;
	private GameObject ice;
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
			if(Input.touches[0].phase==TouchPhase.Began){
				touchPos.x=Input.touches[0].position.x;	
				touchPos.y=Input.touches[0].position.y;
				Ray ray=ARcamera.camera.ScreenPointToRay(touchPos);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit) && !isHitIce){
															touchDir=-ray.direction;
															ice=hit.transform.gameObject;
															isHitIce=true;
			}}
			if(Input.touches[0].phase==TouchPhase.Ended){			
				isHitIce=false;
		}
		}else{
			if(Input.GetMouseButton(0)){
				touchPos=Input.mousePosition;
				Ray ray=ARcamera.camera.ScreenPointToRay(touchPos);
				RaycastHit hit = new RaycastHit();
				if(Physics.Raycast(ray, out hit) && !isHitIce){
															touchDir=-ray.direction;
															ice=hit.transform.gameObject;
															isHitIce=true;
			}}
			if(Input.GetMouseButtonUp(0)){			
				isHitIce=false;
		}}
		if(isHitIce)MoveIce();
	}
	
	private void MoveIce(){
		Vector3 iceScreenPos=ARcamera.camera.WorldToScreenPoint(ice.transform.position);
		Vector3 destination=Vector3.zero;
		print(iceScreenPos);
		if(iceScreenPos.z >= 300)destination.z=1;
		
		if(iceScreenPos.x > touchPos.x)destination.x=-1;
		else destination.x=1;
		
		if(iceScreenPos.y > touchPos.y)destination.y=1;
		else destination.y=-1;
		
		ice.rigidbody.velocity=ARcamera.transform.InverseTransformDirection(destination)*5;
		
	}
}