using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public string name="Nobody"; //undo
	public int score=0; //undo
	private int cards=0; //undo
	private bool canShake=false;
	private bool haveSpecial=false; //undo
	
	public void SetName(string index){name=index;}
	public void AddScore(int index){score+=index;}
	public void SwitchCanShake(){canShake=!canShake;}
	public bool IfCanShake(){return canShake;}
	public void SwitchHaveSpecial(){haveSpecial=!haveSpecial;}
	public bool IfHaveSpecial(){return haveSpecial;}	
}
