using System;
using System.Threading;
using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random=UnityEngine.Random;
using UnityEngine.UI;


public class CoustomerCome : MonoBehaviour {

	//Thread thread = new Thread(ComeThread);

	public Text chornoMeterText;

	[HideInInspector]
	public int seconds=4,sec,min;

	int nons = 0 , k = 0 , countCome =0 , temp=0 , n;
	public int customerCount = 0; 

	public Transform panel;

	[HideInInspector]
	public static GameObject[] tempCustomers = new GameObject[6];

	public GameObject[] customer;

	public GameObject sandwich1, sandwich2, sandwich3;

	ArrayList myAL = new ArrayList();

	String[] Jayegah = new string[4];

	public String[] Moshtary1 = {"ALI","hasan","mohsen","mostafa","soroosh","mohsen","haji","aki","fati"};
	public String[] Moshtary = {"ALI","hasan","mohsen","mostafa","soroosh","mohsen","haji","aki","fati"};



	public static bool[] isEmptyPlace = new bool[4];

	int[] JayGasht1 ={1,3,2,0};
	int[] JayGasht2 ={2,1,3,0};
	int[] JayGasht3 = {1,3,0,2};
	int[] JayGasht4 = {0,2,1,3};

	int[] JayGasht = new int[4];


	void Awake(){

		StartCoroutine (counter());


		if (k == 0) {
			for (int i = 0; i < 6; i++) {
				tempCustomers [i] = Instantiate (customer [i]) as GameObject;
				tempCustomers [i].transform.SetParent (panel, false);

				if(i == 0 )
					(Instantiate(sandwich1)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
				if(i == 1 )
					(Instantiate(sandwich3)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
				if(i == 2 )
					(Instantiate(sandwich1)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
				if(i == 3 )
					(Instantiate(sandwich2)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
				if(i == 4 )
					(Instantiate(sandwich2)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
				if(i == 5 )
					(Instantiate(sandwich1)as GameObject).transform.SetParent (tempCustomers[i].transform, false);
			}

			k = 1;
		}


		come ();
		StartCoroutine (CoustomerComeIFIsEmptyPlace());

		//ArrayJaygasht ();
	}

	public void ArrayJaygasht(){

		for(int i=0 ; i<4 ; i++) {
			JayGasht [i] = JayGasht1[i];
		}

		foreach (int i in JayGasht)
			print(i);
	}


	public void come(){

		//null kardan hame jayegaha

		for(int i =0 ; i<4 ; i++){
			Jayegah[i] = "#";
		}
//		foreach ( String obj in Jayegah )
//			print( obj);


//		Queue<string> moshtary = new Queue<string>();
//		moshtary.Enqueue("ali");
//		moshtary.Enqueue("amin");
//		moshtary.Enqueue("mohsen");
//		moshtary.Enqueue("mostafa");
//		moshtary.Enqueue("soroosh");
//		moshtary.Enqueue("haji");
//		moshtary.Enqueue("hasan");


		//while (n < moshtary.Count) {
//			if (myAL.Count == 4) {
//				// if full wait
//
//			} else {
			//dequeue from queue and place into arrayList  ==> okey


			//bayad har adami k az jayegah mire ye motaghiyrei ra bezare ja khodesh k yani null hast


			for (int j = 0; j < 4; j++) {
				temp = JayGasht1 [j];
				Jayegah [temp] = Moshtary[j];
			}
		for(int l=0 ; l<Jayegah.Length ; l++){
			print (Jayegah[l]);
		}
			for (int j = 0; j < 4; j++) {
			//if (moshtary.Count < 8) {
				temp = JayGasht2 [j];
				Jayegah [temp] = Moshtary1[j+4];
			//}
			}
			for (int j = 0; j < 4; j++) {
			
				temp = JayGasht3 [j];
//				Jayegah [temp] = moshtary.Dequeue ();
			}
			for (int j = 0; j < 4; j++) {
				temp = JayGasht4 [j];
	//			Jayegah [temp] = moshtary.Dequeue ();
			}

		for(int l=0 ; l<Jayegah.Length ; l++){
			print (Jayegah[l]);
		}


	}


		
	void Update(){
		
		if (chornoMeterText.text.Equals ("END")) {
				seconds = 4;
				StartCoroutine (counter ());
		}

		if (k == 1) {
			
			for (int i = 0; i < 6; i++) {

				if (i >= 4) {
					Vector3 temp = new Vector3 (tempCustomers [i].transform.position.x + ((i-4) * 4.2f),
						               tempCustomers [i].transform.position.y
					, tempCustomers [i].transform.position.z);
					tempCustomers [i].transform.position = temp;
					tempCustomers [i].gameObject.SetActive (false);
					print ("customer=" + temp);

				} else {
					Vector3 temp = new Vector3 (tempCustomers [i].transform.position.x + (i * 4.2f),
						tempCustomers [i].transform.position.y
						, tempCustomers [i].transform.position.z);
					tempCustomers [i].transform.position = temp;
					tempCustomers [i].gameObject.SetActive (false);
					print ("customer=" + temp);
				}

			}
			k = 0;
		}

		if (customerCount < 6) {
			StopCoroutine ("CoustomerComeIFIsEmptyPlace");
		}else {
			StartCoroutine (CoustomerComeIFIsEmptyPlace());
		}

		if(customerCount > 4){
			StartCoroutine (IsAllPlaceEmpty());
		}
		

//		if (myAL.Count != 4) {
//		
//		}
			
	}//end update

	IEnumerator IsAllPlaceEmpty(){
		int j = 0;
		if (!isEmptyPlace [j] && !isEmptyPlace [j+1] && !isEmptyPlace [j+2] && !isEmptyPlace [j+3] ) {
				yield return new WaitForSeconds (2f);
				tempCustomers [customerCount].gameObject.SetActive (true);
			}
	
	}

	IEnumerator CoustomerComeIFIsEmptyPlace(){
		
		while(customerCount < 6){
			yield return new WaitForSeconds (2f);

			print ("i = " +customerCount);

			if (customerCount >= 4) {
				for(int j=0 ; j<4 ; j++){
				if (!isEmptyPlace [j]) {
						print ("j= "+ j);
					yield return new WaitForSeconds (2f);
					isEmptyPlace [j] = true;
					tempCustomers [j+customerCount].gameObject.SetActive (true);
						customerCount++;
						//break;
					}
				}
			} else {
				temp = JayGasht1 [customerCount];
				if (!isEmptyPlace [temp]) {
					yield return new WaitForSeconds (2f);
					isEmptyPlace [temp] = true;
					tempCustomers [temp].gameObject.SetActive (true);
					customerCount++;
				}
			}

		}
		//StopCoroutine ("CoustomerComeIFIsEmptyPlace");
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


	//	public void CheckEmptyPlace(){
	//		if (chornoMeterText.text.Equals ("END")) {
	//
	//			seconds = 2;
	//			StartCoroutine (counter ());
	//
	//			if (countCome < 4) {
	//				isEmptyPlace [countCome] = true;	
	//				tempCustomers [countCome].gameObject.SetActive (true);
	//				countCome++;
	//			}
	//		}
	//	
	//	}

} // end

