﻿using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public Board board;

	//Have selection thing here

	void Start () {
		TwoPlayerLocal ();
	}

	void OnePlayer () {
	}

	void TwoPlayerLocal () {
		SetUp ();
	}

	void TwoPlayerP2P () {

	}


	private int currentTurnFromParse = 0;
	private string boardState1dString = "";


	void SetUp () {
		GameObject boardObject = new GameObject("board");
		boardObject.transform.parent = transform;
		board = boardObject.AddComponent<Board>();

		// TODO: Run parse coroutine


		Board.turnCounter = this.currentTurnFromParse;// from parse
		//TODO:
		// If thisPlayerNumber = this turn's player
		// and if this turn's player == parse.username
		// then isPlayerWaiting = false;
		// else isPlayerWaiting = true;

		// v !!!!!!!!!! DANGER
		Board.isPlayerWaiting = false; // DEBUG ONLY
		// ^ !!!!!!!!!! DANGER

		Board.setupCurrPlayer (1); // debug using 1 to indicate player 1
		//Board.currPlayer = "PlayerOne"; // from parse

		// Let's store where the peices are now in that string
		for (int i = 0; i < 16; i++)
		{
			// declare local variables so that the values don't have to be fetched through dot operators multiple times if needed
			// This is a minor cost saving optomization
			// ProTip: NEVER EVER optomize before finishing everything up first.
			// There's some sage quote about this, I'm totally breaking this rule, but I'm pretty sure I can get away with it in this case.
			
			if(Board.pieceData[i] !=null)
			{
				int _row = (int) -Board.pieceData[i].GetComponent<Piece>().pos.y/2;
				int _col = (int) Board.pieceData[i].GetComponent<Piece>().pos.x/2;
				string _name = Board.pieceData[i].name;
				
				Board.gameBoardState[_row,_col] = Board.pieceData[i].name;
				Debug.LogWarning("MANAGER PEICE DATA: " + _name + "@ " + _row + "x" + _col);
			}
		}
		// TODO: Setup where peices go!

		// end of parse coroutine


	}
	
	// Use this for initialization

	// Update is called once per frame
	void Update () {
	
	}



	bool CanGo(){
		return false;
	}
	
}
