using UnityEngine;
using System.Collections;

namespace Models {

	public abstract class Ship : MonoBehaviour {

		//	attributes
		protected float maxHitPoints;
		protected float currentHitPoints;
		protected float baseDamage;
		protected float baseDefense;

		//	gameObject
		protected GameObject gmob;

		//	components
		protected Rigidbody2D rb;
		protected BoxCollider2D bc;
		protected SpriteRenderer sr;

		protected abstract void Shoot();

		protected abstract void Move();

		protected void Initialize(){
			//	Setting game object
			this.gmob = this.gameObject;

			//	Initializing components
			this.rb = this.gmob.GetComponent<Rigidbody2D>();
			this.bc = this.gmob.GetComponent<BoxCollider2D>();
			this.sr = this.gmob.GetComponent<SpriteRenderer>();
		}

		protected void setSprite(string spriteURI){
			this.sr.sprite = (Sprite) Resources.Load(spriteURI, typeof(Sprite));
		}

		public void setPosition(Vector2 position){
			this.transform.position = position;
		}

	}

}
