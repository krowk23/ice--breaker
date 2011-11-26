using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private string name="Nobody"; //undo
	private int score=0; //undo
	private GameObject iceInHand=null;
	private int cards=0; //undo
	private bool canShake=false;
	private bool haveSpecial=false; //undo
	
	public void SetName(string index){name=index;}
	public string GetName(){return name;}
	public void AddScore(int index){score+=index;}
	public int GetScore(){return score;}
	public void TakeIce(GameObject index){iceInHand=index;}
	public GameObject GetIce(){return iceInHand;}
	public void SwitchCanShake(){canShake=!canShake;}
	public bool IfCanShake(){return canShake;}
	
	
	
}
