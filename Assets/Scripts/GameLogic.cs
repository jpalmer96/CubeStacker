using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

	//public GameObject PlayerBlock = GameObject.FindGameObjectsWithTag ("PlayerBlock");



	public static GameLogic instance;         //A reference to our game control script so we can access it statically.


	//GameObject playerObject;
	public GameObject PlayerCube;
	//Rigidbody2D rb2d;

	public GameObject[] player;
	public GameObject[] prevBlocks;
	List<float> prevBlocksX = new List<float>();
	List<float> tempList = new List<float> ();

	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {

		int playerSize = 4;
		player = new GameObject[playerSize];

		for(int i =0; i < 9; i++){
			prevBlocksX.Add (i);
		}

		//Creates Player Array
		for (int i = 0; i < playerSize; i++) {
			GameObject playerObject = Instantiate(PlayerCube, new Vector2(i, 1.5f), Quaternion.identity);

			playerObject.AddComponent<PlayerScript>();
			player [i] = playerObject;

		}

		//Creates PrevBlocks

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			for (int i = 0; i < player.Length; i++) {
				if ((player [i].transform.position.x == prevBlocksX [0]) || (player [i].transform.position.x == prevBlocksX [1]) ||
					(player [i].transform.position.x == prevBlocksX [2]) || (player [i].transform.position.x == prevBlocksX [3])) {

					tempList.Add (player [i].transform.position.x);

				} else {
					player [i].SetActive (false);
					Destroy (player [i]);
					//Destroy (player[i].GetComponent(PlayerScript));

				}


			}

			prevBlocksX = tempList;

			for (int i = 0; i < tempList.Count; i++) {
				GameObject playerClone = Instantiate (PlayerCube, new Vector2 (tempList [i], tempList [i]), Quaternion.identity);


			}
			tempList.Clear ();
		}


	}

}
