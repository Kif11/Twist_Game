﻿using UnityEngine;
using System.Collections;
// Kirill Kovalevskiy

public class GravityAnomaly : MonoBehaviour {

	// Anomaly type dropdown menu
	public enum AnomalyType {Reverse, Low, Zero};
	public AnomalyType anomalyType;

	private bool inAnomaly = false;
	private Collider player;
	
	void Start () 
	{
//		anomalyType = AnomalyType.Reverse;
	}

	void Update()
	{
		if(inAnomaly)
		{
			
			Rigidbody rb = player.GetComponent<Rigidbody>();
			
			switch (anomalyType)
			{
			case AnomalyType.Reverse:
				rb.AddForce(Physics.gravity * rb.mass*-3);
				break;
			case AnomalyType.Low:
				rb.AddForce(Physics.gravity * rb.mass*-0.7f);
				break;
			case AnomalyType.Zero:
				break;
			}
			
		}
	}

	void OnTriggerEnter(Collider other)
	{	
		if (other.tag == "Player")
		{	
			player = other;
			inAnomaly = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			//Debug.Log("Player leave the anomaly");
			
			inAnomaly = false;
		}
	}

}
