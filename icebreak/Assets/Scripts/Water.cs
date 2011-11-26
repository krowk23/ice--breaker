using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public double percentOfCapacity=0;
	public void AddWater(double index){percentOfCapacity+=index;}
	public void ReduceWater(double index){percentOfCapacity-=index;}
}
