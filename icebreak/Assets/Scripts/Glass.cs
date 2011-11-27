using UnityEngine;
using System.Collections;

public class glass : MonoBehaviour {
	
	public Rect smallR;
	public Vector2 bigR;
	public float playSpeed = 10;
	public Texture2D []glassFull;
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
	private bool isFull = false;
	public float WaterL=0;
	
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
	
	//false: full
	public bool addIce(float V){
		WaterL += V;
		if(WaterL > lv*10){
			return Upgrade(Mathf.CeilToInt(WaterL/10 - lv));
		}else{
			return true;
		}
	}
	
	public bool setLv(int rlv){
		if(rlv < glassLevelT.Length){
			lv = rlv;
			WaterL = lv*10;
			return true;}
		else return false;
	}
	
	//false: full
	public bool Upgrade(int UpNum){
		if(UpNum < 0) throw new System.Exception("glass.Upgrade get a wrong UpNum");
		
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
				print("Wrong lv");
				//throw new System.Exception("Wrong lv");
			break;
		}
		timmer = 0;
		stat = 1;
		lv+=UpNum;
		print(lv);
		if(lv >= glassLevelT.Length){
			print("full");
			lv = glassLevelT.Length;
			isFull = true;
			WaterL=100;
			return false;
		}
		return true;
	}
	
	public bool full(){
		return isFull;}
	
	void OnGUI(){
		if(stat == 0){
			GUI.DrawTexture(smallR, glassLevelT[lv], ScaleMode.StretchToFill);
		}else if(stat == 1){
			if(timmer/playSpeed >= In.Length){
				if(isFull){
					timmer = 0;
					In = glassFull;
					//isFull = false;
				}else{
					stat = 0;}
			}else if(timmer/playSpeed < In.Length -1){
				GUI.DrawTexture(new Rect(Screen.width/2 - bigR.x/2, 
				                         Screen.height/2 - bigR.y/2, 
				                         bigR.x, bigR.y), 
				                In[(int)(timmer/playSpeed)], ScaleMode.StretchToFill);	
			}else if(isFull){
				GUI.DrawTexture(new Rect(Screen.width/2 - bigR.x/2, 
				                         Screen.height/2 - bigR.y/2, 
				                         bigR.x, bigR.y), 
				                In[(int)(timmer/playSpeed)], ScaleMode.StretchToFill);
			}else{
				GUI.DrawTexture(new Rect(Screen.width/2 - bigR.x/2, 
				                         Screen.height/2 - bigR.y/2, 
				                         bigR.x, bigR.y), 
				                glassLevelT[lv], ScaleMode.StretchToFill);
			}
		}else throw new System.Exception("Wrong stat");
	}

	public void ReduceWater(float index){WaterL-=index;}
}
