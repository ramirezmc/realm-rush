using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI goldText;
	Bank bank;
    void Start()
    {
	    bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
	    DisplayGold(); 
    }
    
	void DisplayGold()
	{
		goldText.text = "Gold: " + bank.CurrentBalance.ToString();
	}
}
