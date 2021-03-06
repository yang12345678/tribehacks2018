﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.Threading;
using System.Net;
using System.Timers;

public class Minting : MonoBehaviour {

	public GameObject[] enemySpawn;
	public Transform enemyPrefab;
	public Transform goodPrefab;
	public float creating = 0;
	public float nextCreating = 0;

	public float chaos = 0;
	public double decrypto = 0;
	public double cryptholder = 0;
	public string cryptoCoin = "BTC";
	public int difficulty = 2;
	public int coinCount = 0;

	List<string> cryList = new List<string>();
	List<double> iList = new List<double>();

	void Start()
	{
		difficulty = int.Parse(StaticClass.CrossSceneInformation);
		CryptoSelection ();
	}

	void Update()
	{
		if (creating == 48.00f/difficulty) 
		{
			cryptholder = Cryptography (cryptoCoin);
			if ((cryptholder) <= decrypto) 
			{
				decrypto = cryptholder;
				Instantiate (enemyPrefab, transform.position, transform.rotation);
				creating = 0.00f;

				if (coinCount == difficulty - 1) {
					
					coinCount = 0;
				} 
				else 
				{
					coinCount += 1;
				}

				cryptoCoin = cryList[coinCount];
				Debug.Log (coinCount);

			}

			else
			{
				decrypto = cryptholder;
				Instantiate (goodPrefab, transform.position, transform.rotation);
				creating = 0.00f;
			}
		}
		creating += 0.125f;
	}

	void CryptoSelection()
	{
		if (difficulty >= 2) {
			cryList.Add ("BTC");
			cryList.Add ("ETH");
		}

		if (difficulty >= 4) {
			cryList.Add ("XRP");
			cryList.Add ("BCH");
		}

		if (difficulty == 6) {
			cryList.Add ("LTC");
			cryList.Add ("EOS");
		}
	}
		


	double Cryptography(string cry)
	{
		string url = "https://min-api.cryptocompare.com/data/price?fsym=";
		string urlstr = "&tsyms=USD";
		string crypto = cry;
		double big_num;

		WebClient client = new WebClient ();
		string content = client.DownloadString(url + crypto + urlstr);
		string result = content.Substring(7, content.Length -8);

		Double.TryParse(result, out big_num);
		return big_num;
	}
		
}
