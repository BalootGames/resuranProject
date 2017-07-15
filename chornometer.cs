using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class chornometer : MonoBehaviour {

	public Text chornoMeterText;
	public int seconds=490,sec,min;

	// Use this for initialization


	void Awake () {
		StartCoroutine (counter());
	}


	IEnumerator counter(){
		min=seconds/60;
		sec = seconds % 60;
		for(int i=seconds;i>=0;i--){

			if(sec==0&&min==0){
				chornoMeterText.text="END";
				yield break;
			}
			if(sec==0&&min!=0){
				min--;
				sec=59;
			}

			chornoMeterText.text=min.ToString("D2")+" : "+sec.ToString("D2");
			sec--;
			yield return new WaitForSeconds(1);
		}
	
	}
		

}//end