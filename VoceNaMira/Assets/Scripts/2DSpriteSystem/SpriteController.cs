using UnityEngine;
using System.Collections;

public class SpriteController : MonoBehaviour {

	public KeyCode moveDown,moveUp, moveLeft,moveRight;
	private float speed = 10; 
	private Sprite sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<Sprite> ();
		sprite.Create(SpriteSet.GetSprite("giumbertoDown"));
		sprite.Play (Sprite.PlayMode.Loop, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveDown)) {
			sprite.Create(SpriteSet.GetSprite("giumbertoDown"));
			sprite.Play (Sprite.PlayMode.Loop, 0.1f);
			transform.position += transform.forward * speed * Time.deltaTime;
		}else if(Input.GetKey (moveLeft)){
			sprite.Create(SpriteSet.GetSprite("giumbertoLeft"));
			sprite.Play (Sprite.PlayMode.Loop, 0.1f);
			transform.position += transform.right * speed * Time.deltaTime; 
		}else if(Input.GetKey (moveRight)){
			sprite.Create(SpriteSet.GetSprite("giumbertoRight"));
			sprite.Play (Sprite.PlayMode.Loop, 0.1f);
			transform.position += transform.right * -speed * Time.deltaTime;
		}else if(Input.GetKey (moveUp)){
			sprite.Create(SpriteSet.GetSprite("giumbertoUp"));
			sprite.Play (Sprite.PlayMode.Loop, 0.1f);
			transform.position += transform.forward * -speed * Time.deltaTime;
		}

		if(Input.GetKeyUp(KeyCode.Escape)){
			sprite.Stop();
			//sprite.setSprite("stop");
		}
	}
}
