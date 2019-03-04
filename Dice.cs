using UnityEngine;
using System.Collections;

//Dice Class
public class Dice : MonoBehaviour {

    //************ public variables ************************************************* 
    public Rigidbody rb; // the dice Game Object 
    public MeshFilter floor; // the floor Game Object - used to determine orientation 
    public float rayMaxEndpoint = 2; // determines the raycast's maximum end point 
    public DiceManager diceManager; // refers to dice manager game object in the scene 

    //************ variables ********************************************************* 
    Vector3 rest = new Vector3(0,0,0); // determine if the dice is at rest 
    int rolledNum = 0; //number that is rolled
    bool checkedIn = false; // ensures whether or not die checked in with Dice Manager  
    Vector3 startingPos; // starting position of die for re-rolling 
    
    // Use this for initialization
    void Start () {

        startingPos = transform.position; // sets currently placed die position
     

    }//END of Start()
	
	// Update is called once per frame
	void Update () {
        
        // Gets dice roll.  
        FindDiceRoll();

	}//END of Update()

    //*************** Functions ********************* 
    void FindDiceRoll()
    {
        // if Dice is at rest, shoot a raycast vertically up 
        if (rb.velocity == rest && checkedIn == false)
        {
            RaycastHit hit; //create RaycastHit object to capture hit results for rolled number
            Vector3 up = floor.transform.TransformDirection(Vector3.up); // denote which direction is global Y or upward 

            Debug.DrawRay(rb.transform.position, up * 2); // makes raycast visible -DEBUGING ONLY-

            //if Raycast hits a dice number, get the number value. 
            if (Physics.Raycast(rb.transform.position, up * 2, out hit, rayMaxEndpoint))
            {
                GameObject number = hit.collider.gameObject; // store GameObject or number that was hit. 
                TextMesh diceNum = number.GetComponent<TextMesh>(); // store TextMesh component that attached to 'number' GameObject.
                 
                rolledNum = System.Int32.Parse(diceNum.text); // convert string to int for future calculations

               
          
                diceManager.CheckIn(rolledNum); // Sends rolled number to the dice manager for calculation.  
                checkedIn = true; // marks the die (itself) that it has been checked in by the dice manager. 
                
                

               //Debug.Log(diceNum.text); // display number value from 'diceNum' TextMesh Object. 
                
            }//END of get number If statement

        }//END of die at rest If statement

    }//END of FindDiceRoll()

    public void Roll()
    {
        transform.position = startingPos;// set die position to starting position 
        transform.rotation = Random.rotation;// randomize rotation of die at next roll
        checkedIn = false;// reset checkedIn
    }//END of Roll()
}//END of Dice Class
