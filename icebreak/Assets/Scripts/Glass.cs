using UnityEngine;
using System.Collections;

public class Glass : MonoBehaviour {
	
	public Rect smallR;
	public Vector2 bigR;
	public float playSpeed = 10;
	public Texture2D []glassLevelT;
	public Texture2D []AITs0;
	public Texture2D []AITs1;
	public Texture2D []AITs2;
	public Texture2D []AITs3;
	public Texture2D []AITs4;
	public Texture2D []AITs5;
	public Texture2D []AITs6;
	public Texture2D []AITs7;
	public Texture2D []AITs8;
	public Texture2D []AITs9;
	private int lv=0;
	private float timmer=0;
	private int stat=0;
	private Texture2D []In;
	
	// Use this for initialization
	void Start () {
		smallR=new Rect(Screen.width-glassLevelT[lv].width, 
			                     Screen.height-glassLevelT[lv].height, 
			                     glassLevelT[lv].width, glassLevelT[lv].height);
	}
	
	// Update is called once per frame
	void Update () {
		if(stat == 1){
			if(timmer >= playSpeed*In.Length){
				stat = 0;
				timmer = 0;
			}else{
				timmer += Time.deltaTime;}
		}
		
	}
	
	public bool setLv(int rlv){
		if(rlv < glassLevelT.Length){
			lv = rlv;
		return true;}
		else return false;
	}
	
	public bool addIce(){
		if(lv+1 < glassLevelT.Length){
			switch(lv){
				case 0:
					In = AITs0;
				break;
				case 1:
					In = AITs1;
				break;
				case 2:
					In = AITs2;
				break;
				case 3:
					In = AITs3;
				break;
				case 4:
					In = AITs4;
				break;
				case 5:
					In = AITs5;
				break;
				case 6:
					In = AITs6;
				break;
				case 7:
					In = AITs7;
				break;
				case 8:
					In = AITs8;
				break;
				case 9:
					In = AITs9;
				break;
				default:
					throw new System.Exception("Wrong lv");
			}
			lv++;
			timmer = 0;
			stat = 1;
			return true;
		}
		else return false;
	}
	
	void OnGUI(){
		if(stat == 0){
			GUI.DrawTexture(smallR,glassLevelT[lv], ScaleMode.StretchToFill);
		}else if(stat == 1){
			if(timmer/playSpeed >= In.Length){
				stat = 0;
			}else {
				GUI.DrawTexture(new Rect(Screen.width/2 - bigR.x/2, 
				                         Screen.height/2 - bigR.y/2, 
				                         bigR.x, bigR.y), 
				                In[(int)(timmer/playSpeed)], ScaleMode.StretchToFill);
			}
		}else throw new System.Exception("Wrong stat");
	}
}
