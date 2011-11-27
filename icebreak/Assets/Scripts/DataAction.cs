using UnityEngine;
using System.Collections;

public class DataAction : MonoBehaviour {
	/*----Data*/
			public Player player;
		
			public IceTower iceTower;
	    	public GameObject currentIce=null;
	  		
	  		//glass
	
	/*----Action
			ice into glass 	    
	    	
	    	public Shake(){
	    	 if(player.IfCanShake()){}
	    	}
	    	public Special(){
	    	 if(player.IfHaveSpecial()){}
	    	}
	    	cards
	*/
	
	// Use this for initialization
	void Start () {
		SetIceTower(GameObject.Find("IceTower").GetComponent<IceCreater>().head);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void SetIceTower(IceTower head){iceTower=head;}
	public void SetCurrentIce(GameObject iceHitted){currentIce=iceHitted;}
}
