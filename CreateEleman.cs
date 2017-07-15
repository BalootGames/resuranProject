using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateEleman : MonoBehaviour {

	public GameObject Goje,Goje1,Goje2 ;

	public GameObject khiyar,khiyar1,khiyar2,khiyar3 ;

	public GameObject kaho,kaho1,kaho2 ;

	public GameObject kahoBtn,gojeBtn,khiyarBtn;

	public GameObject Non,Non1,Non2,NonBtn;

	public GameObject Falafel,Falafel1,Falafel2,FalafelPokhte,FalafelPokhte1,FalafelPokhte2,FalafelBtn;

	public Animator KhordKon;

	int i=0 , j=0 , k=0 , l=0, m=0;


	public void SetActiveGoje(){
		StartCoroutine (GojeKhordkon());
	}

	IEnumerator GojeKhordkon() {
		
		KhordKon.Play ("KhordKon");
		kahoBtn.gameObject.SetActive (false);
		gojeBtn.gameObject.SetActive (false);
		khiyarBtn.gameObject.SetActive (false);
		yield return new WaitForSeconds (2f);
		KhordKon.Play ("idleKhordKon");

		i++;
		if(i==1)
			Goje.gameObject.SetActive (true);
		if(i==2)
			Goje1.gameObject.SetActive (true);
		if(i==3)
			Goje2.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.5f);
		kahoBtn.gameObject.SetActive (true);
		gojeBtn.gameObject.SetActive (true);
		khiyarBtn.gameObject.SetActive (true);
	}


	public void setActivekhiyar(){
		StartCoroutine (KhiyarKhordKon());
	}

	IEnumerator KhiyarKhordKon(){
		KhordKon.Play ("KhordKon");
		kahoBtn.gameObject.SetActive (false);
		gojeBtn.gameObject.SetActive (false);
		khiyarBtn.gameObject.SetActive (false);
		yield return new WaitForSeconds (2f);
		KhordKon.Play ("idleKhordKon");
		j++;

		if(j==1)
			khiyar.gameObject.SetActive (true);
		if(j==2)
			khiyar1.gameObject.SetActive (true);
		if(j==3)
			khiyar2.gameObject.SetActive (true);
		if(j==4)
			khiyar3.gameObject.SetActive (true);

		yield return new WaitForSeconds (0.5f);
		kahoBtn.gameObject.SetActive (true);
		gojeBtn.gameObject.SetActive (true);
		khiyarBtn.gameObject.SetActive (true);
	
	}


	public void setActivekaho(){
		StartCoroutine (KahoKhordKon());
	}

	IEnumerator KahoKhordKon(){
		KhordKon.Play ("KhordKon");
		kahoBtn.gameObject.SetActive (false);
		gojeBtn.gameObject.SetActive (false);
		khiyarBtn.gameObject.SetActive (false);
		yield return new WaitForSeconds (2f);
		KhordKon.Play ("idleKhordKon");
		k++;

		if(k==1)
			kaho.gameObject.SetActive (true);
		if(k==2)
			kaho1.gameObject.SetActive (true);
		if(k==3)
			kaho2.gameObject.SetActive (true);
	
		yield return new WaitForSeconds (0.5f);
		kahoBtn.gameObject.SetActive (true);
		gojeBtn.gameObject.SetActive (true);
		khiyarBtn.gameObject.SetActive (true);
	}

	public void setActiveNon(){
		l++;

		if(l==1)
			Non.gameObject.SetActive (true);
		if(l==2)
			Non1.gameObject.SetActive (true);
		if(l==3)
			Non2.gameObject.SetActive (true);
	}


	public void setActiveFalafel(){
		StartCoroutine (FalafelSorkhKon());
	}


	IEnumerator FalafelSorkhKon(){
		m++;

		if (m == 1) {
			Falafel.gameObject.SetActive (true);
			yield return new WaitForSeconds (2f);
			Falafel.gameObject.SetActive (false);
			FalafelPokhte.gameObject.SetActive (true);
		}
		if (m == 2) {
			Falafel1.gameObject.SetActive (true);
			yield return new WaitForSeconds (2f);
			Falafel1.gameObject.SetActive (false);
			FalafelPokhte1.gameObject.SetActive (true);
		}
		if(m==3){
			FalafelBtn.gameObject.SetActive (false);
			Falafel2.gameObject.SetActive (true);
			yield return new WaitForSeconds (2f);
			Falafel2.gameObject.SetActive (false);
			FalafelPokhte2.gameObject.SetActive (true);
			m = 0;
			FalafelBtn.gameObject.SetActive (true);
		}

	}



}
