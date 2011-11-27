using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class IceCreater : MonoBehaviour {
	
	public GameObject iceBig;
	public GameObject iceMidx;
	public GameObject iceMidy;
	public GameObject iceMidz;
	public GameObject iceSmall;
	
	public IceTower head =new IceTower();//record the ice tower in a link list
	
	public int totalFiles;
	
	public TextReader mapReader;
	//public StreamReader mapReader;
	
	void Start ()
	{
		LoadIce(0);
	}
	
	
	void Update ()
	{
	}
	
	void LoadIce(int n)
	{
		
		TextAsset map = (TextAsset)Resources.Load("IceMap/map" + String.Format("{0:00}", n));
		mapReader = new StringReader(map.text);
		
		int width = System.Convert.ToInt32(mapReader.ReadLine());
		int height = System.Convert.ToInt32(mapReader.ReadLine());
		
		print(width + "  " + height);
		String temp;
		IceTower tempIce=head;
		
		for(int i=0; i<height; i++)
		{
			for(int j=0; j<width; j++)
			{
				temp = mapReader.ReadLine();
				IEnumerator tempEnum = temp.GetEnumerator();
				
				for(int k=0; k<width; k++)
				{
					tempEnum.MoveNext();
					
					tempIce.next=new IceTower();
					tempIce=tempIce.next;
					
					if(tempEnum == null) throw new FileLoadException("tempEnum is NULL.");
					print(j + " " + tempEnum.Current);
					switch((char)tempEnum.Current)
					{
					case '0':
						break;
					case '1':
					{
						GameObject ice = Instantiate (iceSmall, transform.TransformDirection(new Vector3(-125+j*50,25+i*50,-125+k*50)) , Quaternion.identity) as GameObject;
						tempIce.ice = ice.GetComponent<Ice>();
						break;
					}
					case '2':
					{
						GameObject ice = Instantiate (iceMidx, transform.TransformDirection(new Vector3(-125+j*50,50+i*50,-100+k*50)) , Quaternion.identity) as GameObject;
						tempIce.ice = ice.GetComponent<Ice>();
						break;
					}
					case '3':
					{
						GameObject ice = Instantiate (iceMidy, transform.TransformDirection(new Vector3(-100+j*50,25+i*50,-100+k*50)) , Quaternion.identity) as GameObject;
						tempIce.ice = ice.GetComponent<Ice>();
						break;
					}
					case '4':
					{
						GameObject ice = Instantiate (iceMidz, transform.TransformDirection(new Vector3(-100+j*50,50+i*50,-125+k*50)) , Quaternion.identity) as GameObject;
						tempIce.ice = ice.GetComponent<Ice>();
						break;
					}	
					case '5':
					{
						GameObject ice = Instantiate (iceBig, transform.TransformDirection(new Vector3(-100+j*50,50+i*50,-100+k*50)) , Quaternion.identity) as GameObject;
						tempIce.ice = ice.GetComponent<Ice>();
						break;
					}
					default:
						throw new FileLoadException("Unknown symbol");
					}
				}
			}
			mapReader.ReadLine();
		}
	}
	
	
}