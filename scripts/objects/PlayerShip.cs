using UnityEngine;
using UnityEditor;
using System.Collections;
using Models;

public class PlayerShip : Models.Ship {

	protected Sprite sprite;

	public void Awake(){
		this.Initialize();

		PlayerPrefs.SetString("ShipSprite", "Assets/Resources/sprites/ships/player/red/player1.png");

		this.sprite = (Sprite) Resources.Load(PlayerPrefs.GetString("ShipSprite"), typeof(Sprite));
		this.sr.sprite = this.sprite;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	protected override void Shoot(){

	}

	protected override void Move(){

	}
}
