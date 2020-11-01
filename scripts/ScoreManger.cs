using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManger : MonoBehaviour
{
	
	public static ScoreManger instance;
	
	public Text text;
	
	int score;
	
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
		{
			instance = this;
		}
    }

	public void ChangeScore(int CoinValue)
	{
		score += CoinValue;

		text.text = "Coins : "+ score.ToString();
	}
	
}
