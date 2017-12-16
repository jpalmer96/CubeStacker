using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


	public GameObject PlayerCube;
	public GameObject PlayerObject;
	Rigidbody2D rb2d;
	bool right = true;
	public int count;
	public bool grounded;
	//public GameObject[] prevBlocks;
	//List<float> prevBlocksX = new List<float>();

	//double moveSpeed = 1.0;

	// Use this for initialization
	void Start () {

		grounded = true;

		PlayerCube  = GameObject.Find("PlayerBlock");
		//PlayerCube = this.gameObject;  //GameObject with script?

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();

		count = 1;

		InvokeRepeating ("movement", 3.0f, 0.7f);

	}

	// Update is called once per frame
	void Update () {



		//PlayerInput
		if (Input.GetKeyDown(KeyCode.Space)){
			//GameLogic.instance.prevBlocks.CopyTo
			//grounded = checkGrounded ();

			//placeCube ();
			rb2d.transform.Translate (0, 1, 0);
			//} else {
			//missedBlock();
			//this.gameObject.SetActive(false);
			//-or-
			//Destroy(this.gameObject);
		}

		//			prevBlocksX = tempList;
		//				for (int i = 0; i < 4; i++) {
		//				tempList.Remove (i);
		//}

	}

	public void movement(){

		//Right Left boolean
		if (right == true) {
			transform.Translate (1, 0, 0);
			count++;
		} else {
			rb2d.transform.Translate (-1, 0, 0);
			count--;
		}




		//Constraints
		//if (rb2d.transform.position.x > 5) {
		if(count > 3){
			right = false;
		} 
		//else if (rb2d.transform.position.x < -5){
		else if (count <-4){
			right = true;
		}

	}

	//	public void placeCube(){
	//
	//		PlayerObject = this.gameObject;
	//		float cubeX = PlayerObject.transform.position.x;
	//		float cubeY = PlayerObject.transform.position.y;
	//
	//	//Instantiation stuff
	//		GameObject playerClone = Instantiate(PlayerCube, new Vector2(cubeX,cubeY), Quaternion.identity);
	//		//playerClone.name = "blockClone";
	//
	//
	//		//refrence prevBlocks and add X value
	//		//prevBlocksX.Add(cubeX);
	//
	//	}

	//	public bool checkGrounded(){
	//		//for (int i = 0; i < 4; i++ ){
	//		//for (this.gameObject.transform.position.x == int prevBlocksX){
	//			
	//		if ((this.gameObject.transform.position.x == prevBlocksX[0]) || (this.gameObject.transform.position.x == prevBlocksX[1]) || 
	//			(this.gameObject.transform.position.x == prevBlocksX[2]) || (this.gameObject.transform.position.x == prevBlocksX[3])) {
	//			return true;
	//		} else {
	//			return false;
	//		}
	//		
	//	//}			
	////
	////	/* Transform for children objects
	////	 * void Example() {
	////        foreach (Transform child in transform) {
	////            child.position += Vector3.up * 10.0F;
	////        }
	////	 * */
	////}
	//}
}