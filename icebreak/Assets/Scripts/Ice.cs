using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {
	public GameObject _gameObject;
	public double volume;
	
	private int frameCount;
	private bool isMelt;
	
	void Start () {
		if(this.gameObject.renderer != null){
			renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,0.37f);
		}
		frameCount = 0;
		isMelt = true;
	}
	
	void Update () {
		if(isMelt){
			frameCount++;
			if(transform.localScale.x <= 0.001f && transform.localScale.y <= 0.001f && transform.localScale.z <= 0.001f){
				Destroy(gameObject);
			}
			if(frameCount%120 == 0){
				volume-=0.1;
				float xZoom=Random.Range(0.99f,0.996f),yZoom=Random.Range(0.99f,0.996f),zZoom=Random.Range(0.99f,0.996f);
				transform.localScale = new Vector3(transform.localScale.x*xZoom,transform.localScale.y*yZoom,transform.localScale.z*zZoom);
				rigidbody.mass *= xZoom*yZoom*zZoom;
			}
		}
	}
	
	void OnCollisionStay(Collision collision) {
		if(frameCount > 240 && frameCount%60 == 1 && collision.gameObject.tag == "Ice"){
			if(Random.Range(0.0f,1.0f) >= 0.996f){
				GameObject newIce = new GameObject("Ice");
				newIce.tag="Ice";
				newIce.active=true;
				newIce.transform.position = new Vector3(0,0,0);
				newIce.AddComponent("Rigidbody");
				newIce.rigidbody.mass = this.rigidbody.mass + collision.rigidbody.mass;
				this.gameObject.transform.parent = newIce.transform;
				collision.gameObject.transform.parent = newIce.transform;
				Destroy(this.gameObject.rigidbody);
				Destroy(collision.gameObject.rigidbody);
				newIce.AddComponent("Ice");
				newIce.GetComponent<Ice>().volume=this.gameObject.GetComponent<Ice>().volume+collision.gameObject.GetComponent<Ice>().volume;
				Destroy(this.gameObject.GetComponent<Ice>());
				Destroy(collision.gameObject.GetComponent<Ice>());
				
				isMelt = false;
			}
		}
	}
}
