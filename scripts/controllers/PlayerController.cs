using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Objects;

public class PlayerController : MonoBehaviour {

	protected PlayerShip playerShip;
	protected PlayerShip playerShipPrefab;


	void Awake(){
		this.playerShipPrefab = (PlayerShip) Resources.Load("prefabs/player_ship", typeof(PlayerShip));

		this.playerShip = PlayerShip.Instantiate(playerShipPrefab);

		Transform spawnpoint = this.transform.Find("Spawnpoint");
		this.playerShip.setPosition(spawnpoint.position);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
