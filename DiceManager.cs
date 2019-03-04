using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//DiceManager Class
//Managers played dice and keeps score of all rolled dice
public class DiceManager : MonoBehaviour {

    //********************** varables ***********************

    int totalRolls = 0; // Stores total numbers of rolls 
    int currentRoll = 0; // Stores the total roll the was currently rolled
    public Dice[] diceList; // Stores all dice that are in play 
   
    


    // Use this for initialization
  
    void Start () {

	
	}//END of Start()
	
	// Update is called once per frame
	void Update () {

        // When Spacebar is pressed, call "Roll" function from inside the dice script for each dice that is in play 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            currentRoll = 0;// reset to show the total current roll
            Debug.Log("currentRoll = " + currentRoll);

            for (int i = 0; i < diceList.Length; i++)// calls all playable dice to reset by calling the function "Roll"
            {
                diceList[i].Roll();// calls the dice's function "Roll" in selected element 
            }//END of "Roll" for loop 
        }//END of If Statement for Spacebar
        
   
	
	}//END of Update()

    // ***************************** Public Functions *****************************************
    // called only by the dice script when dice has stopped rolling 
    public void CheckIn(int rolled)
    {
        currentRoll += rolled;// adds the current total rolls 
        totalRolls += rolled;// adds the ongoing total rolls 
         
        Debug.Log("You Rolled: " + currentRoll + " Total score: " + totalRolls); // displays the current and total rolls -DEBUG ONLY-

    }//END of CheckIn()
    
}//END of DiceManager class
