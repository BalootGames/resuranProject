using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class DeliverOrder : MonoBehaviour {

	public Vector3 firstPosition;
	public Button coin1,coin2,coin3,coin4;
	public Transform  panelEleman;

	private bool draggingItem = false;

	public GameObject draggedObject , draggedSandwich;

	public GameObject [] draggedGoje = 	new GameObject[3];
	public GameObject [] draggedNon = 	new GameObject[4];
	public GameObject [] draggedFalafel = new GameObject[3];
	public GameObject [] draggedKaho = 	new GameObject[3];
	public GameObject [] draggedKhiyarShor = new GameObject[4];
	public GameObject [] draggedSos = 	new GameObject[4];
	public GameObject [] draggedSambose = new GameObject[4];
	public GameObject [] draggedNoshabeMeshki = new GameObject[2];
	public GameObject [] draggedNoshabeZard = new GameObject[2];

	[HideInInspector]
	public static GameObject [] SiniArrayWait = new GameObject[4];

	public float DraggedFoodX;
	public float DraggedFoodY;

	[HideInInspector]
	public float XSini1 = 52f;
	[HideInInspector]
	public float YSini1 = -77f;
	[HideInInspector]
	public float XSini2 = 65f;
	[HideInInspector]
	public float YSini2 = -138f;
	[HideInInspector]
	public float XSini3 = 169f;
	[HideInInspector]
	public float YSini3 = -77f;
	[HideInInspector]
	public float XSini4 = 195f;
	[HideInInspector]
	public float YSini4 = -157f;

	public GameObject FSandWich;
	public GameObject FGSandWich;
	public GameObject FKhSandWich;
	public GameObject FGKhSandWich;
	public GameObject FKSandWich;
	public GameObject FKGSandWich;
	public GameObject FKKHSandWich;
	public GameObject FKKHGSandWich;


	private Vector2 touchOffset;

	public static bool canCreateNewCustomer;

	public int k=0 , i=0 , gojeCount=0 , countTypeSandwich = 0 ;

	int coustomerCount=0;

	public GameObject goje;


	public static Costumer[] moshtaries;
	public static Order[] orders;
	public static Foods[] foodses;


	void Awake(){
		
		foodses = new Foods[7];
		foodses[0] = new Sandwich(true,false,false,false,false);
		foodses[1] = new Sandwich(true,true,false,false,false);
		foodses[2] = new Sandwich(true,false,true,false,false);
		foodses[3] = new Sandwich(true,true, true,false,false);

		//////////////////////
		orders = new Order[4];
	//	for (int i = 0; i < orders.Length; i++) {
			
			orders[0] = new Order(foodses[0],true,false,false);
			orders[1] = new Order(foodses[1],true,false,false);
			orders[2] = new Order(foodses[2],true,false,false);
			orders[3] = new Order(foodses[3],true,false,false);
	//	}
		/////////////////////////////////////////////
		moshtaries = new Costumer[4];
		for (int i = 0; i < moshtaries.Length; i++) {
			moshtaries[i] = new Costumer(orders[i]);
		}
		////////////////

	}
		 

	void Update(){

		if (HasInput)
		{
			DragOrPickUp();
		}
		else
		{
			if (draggingItem) 
				DropItem();
		}



	}//end Update


	Vector2 CurrentTouchPosition
	{
		get
		{
			Vector2 inputPos;
			inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			return inputPos;
		}
	}



	public void isTheSandwichTrue(GameObject[] draggedObject){
		int m = 0;

		/// DOWN LEFT
		if (draggedObject[m].transform.position.x < 1.8 && draggedObject[m].transform.position.x > -0.8 &&
		      draggedObject[m].transform.position.y < -1 && draggedObject[m].transform.position.y > -3) {

			if (draggedFalafel [i] == draggedObject [m]) {
				(Instantiate (FSandWich, new Vector2 (65, -138), Quaternion.Euler (0, 0, 0))as GameObject).transform.SetParent (panelEleman, false);
				if (draggedGoje [0] == draggedObject [m + 1]) {
					FSandWich.gameObject.SetActive (false);
					(Instantiate (FGSandWich, new Vector2 (65, -138), Quaternion.Euler (0, 0, 0))as GameObject).transform.SetParent (panelEleman, false);
				}
			}

			if(draggedFalafel[m] == draggedObject[m] && draggedGoje[m] == draggedObject[m+1])
				(Instantiate(FGSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i] == draggedObject[m] && draggedKhiyarShor[i] == draggedObject[m+1])
				(Instantiate(FKhSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i] == draggedObject[m] && draggedGoje[i] == draggedObject[m+1] && draggedKhiyarShor[i]== draggedObject[m+2])
				(Instantiate(FGKhSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i] == draggedObject[m] && draggedKaho[i] == draggedObject[m+1])
				(Instantiate(FKSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i] == draggedObject[m] && draggedGoje[i] == draggedObject[m+1] && draggedKaho[i] == draggedObject[m+2])
				(Instantiate(FKGSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i]== draggedObject[m] && draggedKhiyarShor[i] == draggedObject[m+1] && draggedKaho[i] == draggedObject[m+2])
				(Instantiate(FKKHSandWich)as GameObject).transform.SetParent (panelEleman, false);


			if(draggedFalafel[i] == draggedObject[m] && draggedGoje[i] == draggedObject[m+1]
				&& draggedKhiyarShor[i] == draggedObject[m+2] && draggedKaho[i] == draggedObject[m+3])
				(Instantiate(FKKHGSandWich)as GameObject).transform.SetParent (panelEleman, false);


			
		}

//		for( m = 0 ; i<4 ; i++){
//
//
//		//return FGKhSandWich;
//		}
	}


	public GameObject IsOrderTrue(){

		// agar sefaresh amaade (darkhast shode) barabar ba yeki az araye ha bod draggerd object marbote ra bargardan 

		// if order == foods[0]
		//coustomer.setActive(false);
		//coin1.gameObject.SetActive(true);



		//if(){
			//return DraggedFoods1;	
		//}

		//if(){
			//return DraggedFoods2;	
		//}

		return FGKhSandWich;

		DraggedFoodX = draggedSandwich.transform.position.x;
		DraggedFoodY = draggedSandwich.transform.position.y;

		if (DraggedFoodX < -6 && DraggedFoodX > -8 && DraggedFoodY > 0 && DraggedFoodY < 4.5) {}
			
	}

	public void firstPlaceOrder(){

		if (DraggedFoodX < -6 && DraggedFoodX > -8 && DraggedFoodY > 0 && DraggedFoodY < 4.5) {}

	}

	public void secendPlaceOrder(){

		if (DraggedFoodX < -2 && DraggedFoodX > -4 && DraggedFoodY > 0 && DraggedFoodY < 4.5) {}

	

	}

	public void thirdPlaceOrder(){
		if (DraggedFoodX < 2.9 && DraggedFoodX > 0.9 && DraggedFoodY > 0 && DraggedFoodY < 4.5) {}

	}

	public void forthPlaceOrder(){

		if (DraggedFoodX < 7.1 && DraggedFoodX > 5.1 && DraggedFoodY > 0 && DraggedFoodY < 4.5) {}

	}





	public void DragOrPickUp()
	{
		var inputPosition = CurrentTouchPosition;

		if (draggingItem)
		{
			draggedObject.transform.position = inputPosition + touchOffset;
		}
		else
		{
			RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
			if (touches.Length > 0)
			{
				var hit = touches[0];
				firstPosition = (Vector3)touches[0].transform.position;
				if (hit.transform != null)
				{
					draggingItem = true;
					draggedObject = hit.transform.gameObject;
					touchOffset = (Vector2)hit.transform.position - inputPosition;
					draggedObject.transform.localScale = new Vector3(1.3f,1.3f,1.3f);
				}

			}
		} 
	}



	private bool HasInput
	{
		get
		{
			// returns true if either the mouse button is down or at least one touch is felt on the screen
			return Input.GetMouseButton(0);
			//return Input.GetTouch(0);
		}
	}
		

	void DropItem()
	{
		

		draggingItem = false;
		draggedObject.transform.localScale = new Vector3(1f,1f,1f);



		if (draggedObject.transform.position.x < 1.8 && draggedObject.transform.position.x > -0.8 &&
			draggedObject.transform.position.y < -1 && draggedObject.transform.position.y > -3) {
				
			SiniArrayWait[countTypeSandwich] = draggedObject;
			//draggedObject.SetActive(false);
			if(countTypeSandwich<4){
				 
				countTypeSandwich++;
				isTheSandwichTrue (SiniArrayWait);

				print ("countTypeSandwich: " + countTypeSandwich);
				print ("araaaay: " + SiniArrayWait[countTypeSandwich]);

				//			if (draggedGoje [0] == draggedObject) {
				//				(Instantiate (goje,new Vector2(176,-93),Quaternion.Euler(0, 0, 0)) as GameObject).transform.SetParent (panelEleman, false);
				//			}
				//	
			}

		}

		//====================first Customer

		if (draggedNon[i].transform.position.x < -6 && draggedNon[i].transform.position.x > -8 &&
			draggedNon[i].transform.position.y > 0 && draggedNon[i].transform.position.y < 4.5
			
		) 
		{

			draggedNon[i].SetActive(false);
			i++;


			Destroy (CoustomerCome.tempCustomers [0]);
			CoustomerCome.isEmptyPlace [0] = false;

			coin1.gameObject.SetActive(true);

			//			tempCoin  = Instantiate (coin ) as GameObject;
			//			tempCoin.transform.SetParent (panel, false);

		}

		//====================Secoend Customer
		if (draggedSandwich.transform.position.x < -2 && draggedSandwich.transform.position.x > -4 &&
			draggedSandwich.transform.position.y > 0 && draggedSandwich.transform.position.y < 4.5) {

			draggedSandwich.SetActive(false);

			Destroy (CoustomerCome.tempCustomers [1]);
			CoustomerCome.isEmptyPlace [1] = false;

			coin2.gameObject.SetActive(true);

			//			tempCoin  = Instantiate (coin ) as GameObject;
			//			tempCoin.transform.SetParent (panel, false);

		}


		//==================== Third Customer


		if (draggedNon[i].transform.position.x < 2.9 && draggedNon[i].transform.position.x > 0.9 &&
			draggedNon[i].transform.position.y > 0 && draggedNon[i].transform.position.y < 4.5) {

			draggedNon[i].SetActive(false);
			i++;

			Destroy (CoustomerCome.tempCustomers [2]);
			//CoustomerCome.tempCustomers [1].gameObject.SetActive (false);
			CoustomerCome.isEmptyPlace [2] = false;

			coin3.gameObject.SetActive(true);

			//			tempCoin  = Instantiate (coin ) as GameObject;
			//			tempCoin.transform.SetParent (panel, false);

		}

		//==================== Forth Customer
		if (draggedGoje[gojeCount].transform.position.x < 7.1 && draggedGoje[gojeCount].transform.position.x > 5.1 &&
			draggedGoje[gojeCount].transform.position.y > 0 && draggedGoje[gojeCount].transform.position.y < 4.5 ) {

			draggedGoje[gojeCount].SetActive(false);
			gojeCount++;

			Destroy (CoustomerCome.tempCustomers [3]);
			//CoustomerCome.tempCustomers [1].gameObject.SetActive (false);
			CoustomerCome.isEmptyPlace [3] = false;

			coin4.gameObject.SetActive(true);

			//			tempCoin  = Instantiate (coin ) as GameObject;
			//			tempCoin.transform.SetParent (panel, false);

		}

		//goje





		//==============================  Sini Ha Va Avardan ELEman ha =====================================

				// UP LEFT
//				if (draggedObject.transform.position.x < 1.6 && draggedObject.transform.position.x > -0.6 &&
//					draggedObject.transform.position.y < -1 && draggedObject.transform.position.y > -3) {
//		
//				
//		
//				
//				}
//		
//				/// DOWN LEFT
//				if (draggedObject.transform.position.x < 1.8 && draggedObject.transform.position.x > -0.8 &&
//					draggedObject.transform.position.y < -1 && draggedObject.transform.position.y > -3) {
//		
//				
//		
//					
//		
//				}
//		
//				//UP RIGHT
//				if (draggedObject.transform.position.x < 3.3 && draggedObject.transform.position.x > 1.3 &&
//					draggedObject.transform.position.y < 0 && draggedObject.transform.position.y > -2) {
//		
//				
//		
//				}
//		
//				//DOWN RIGHT
//				if (draggedObject.transform.position.x < 3.7 && draggedObject.transform.position.x > 1.7 &&
//					draggedObject.transform.position.y < -1 && draggedObject.transform.position.y > -3) {
//		
//				
//		
//				}

		//======================================================================================



		draggedObject.transform.position=firstPosition;


		print (draggedObject.transform.position.x + "  " + draggedObject.transform.position.y);
	}



	public void setActiveSandiwich(){
		draggedObject.SetActive (true);
	}

	public void samboseActive(){
		draggedObject.SetActive(true);
	}


}//end
