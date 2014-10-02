using UnityEngine;
using System.Collections;

public class ClockRealtime : MonoBehaviour 
{
	bool zeroMin = false;
	bool zeroHwr = false;
	float seconds = 5;
	public int offsetValue = 0;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//var currentTime = System.DateTime.Now;
		//int currentHour = currentTime.Hour;
		//int currentMin = currentTime.Minute;
		int currentHour = System.DateTime.Now.Hour;
		int currentMin = System.DateTime.Now.Minute;

		currentHour += offsetValue;



		if (currentHour > 24) 
		{
			currentHour -=24;
		}

		if(currentHour < 10)
		{
			zeroHwr = true;
		}


		if(currentMin < 10)
		{
			zeroMin = true;
		}

		var strHour =currentHour.ToString();
		var strMinute =currentMin.ToString();
		
		if(zeroMin && zeroHwr)
		{
			GetComponent<TextMesh>().text = ("0" + strHour + ":0" + strMinute);
		}
		else if (zeroMin && !zeroHwr)
		{
			GetComponent<TextMesh>().text = (strHour + ":0" + strMinute);
		}
		else if (!zeroMin && zeroHwr)
		{
			GetComponent<TextMesh>().text = ("0" + strHour + ":" + strMinute);
		}
		else
		{
			GetComponent<TextMesh>().text = (strHour + ":" + strMinute);
		}
		zeroMin = false;
		zeroHwr = false;

		while (seconds > 0) 
		{
			seconds -= Time.deltaTime;
		}
		seconds = 10;
	}
}
