using UnityEngine;
using UnityEditor;
using System.Collections;
using Models;

namespace Objects {
	public class PlayerShip : Models.Ship {
		//	Constants
		protected const float DEFAULT_BASE_SPEED = 15;
		protected const float DEFAULT_SHOT_INTERVAL = 0.5f;

		//	Code Attributes
		protected Sprite sprite;
		protected float shotTimeTracker = 0f;

		//	Game Attributes
		[SerializeField] protected float speed;
		[SerializeField] protected float shotInterval;

		public void Awake(){
			//	Initializes components
			this.Initialize();

			//	Initialize ship sprite
			// -------
			PlayerPrefs.SetString("ShipSprite", "sprites/ships/player/red/player1");
			// -------
			string spriteURI = PlayerPrefs.GetString("ShipSprite");
			this.setSprite(spriteURI);

			//	Initializes default game attributes
			this.speed = this.speed == 0 ? DEFAULT_BASE_SPEED : this.speed;
			this.shotInterval = this.shotInterval == 0 ? DEFAULT_SHOT_INTERVAL : this.shotInterval;
		}

		// Use this for initialization
		void Start () {


		}

		// Update is called once per frame
		void Update () {
			this.shotTimeTracker += Time.deltaTime;
			this.Move();

			if(this.shotTimeTracker >= this.shotInterval){
				this.shotInterval = 0f;
				this.Shoot();
			}
		}

		protected override void Shoot(){


		}

		protected override void Move(){
			bool up = Input.GetKey(KeyCode.W);
			bool down = Input.GetKey(KeyCode.S);
			bool left = Input.GetKey(KeyCode.A);
			bool right = Input.GetKey(KeyCode.D);

			float yAxis = 0;
			float xAxis = 0;

			int verticalState = CameraController.GetInstance().isVerticallyOut(gmob.transform.position);
			int horizontalState = CameraController.GetInstance().isHorizontallyOut(gmob.transform.position);

			yAxis = up ? speed : (down ? -speed : 0);
			xAxis = right ? speed : (left ? -speed : 0);

			if(verticalState == -1){
				yAxis = yAxis > 0 ? yAxis : 0;
			} else if(verticalState == 1){
				yAxis = yAxis > 0 ? 0 : yAxis;
			}

			if(horizontalState == -1){
				xAxis = xAxis > 0 ? xAxis : 0;
			} else if(horizontalState == 1){
				xAxis = xAxis > 0 ? 0 : xAxis;
			}

			this.rb.velocity = new Vector2(xAxis, yAxis);
		}

	}

}
