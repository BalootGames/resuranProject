using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {
	public static float money;
	public Text moneyText;

	public void destCoin(){

		this.gameObject.SetActive(false);
		money += 200;
		moneyText.text = money + "$";
	}
}
