using UnityEngine;
using System.Collections;

public class PlayerConttoler : MonoBehaviour {

	public float maxSpeed = 10f;
	public float minSwipe= 300f;
	private Vector2 startPos;
	bool facingRight = true;
	private enum Movement{ NONE,MOVE,UP,DOWN}
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			moveAnimation(Movement.NONE,true);
		}
		/*
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];

			switch(touch.phase){
				case TouchPhase.Began:
						startPos = touch.position;
					break;
				case TouchPhase.Ended:
					float swipeDistVert = (new Vector3(0,touch.position.y,0) - new Vector3(0,startPos.y,0)).magnitude;
						if(swipeDistVert > minSwipe){

							float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
							
							if(swipeValue > 0){// up
								
							}else if(swipeValue < 0){//down
								
							}
						}
					float swipeDistHorz = (new Vector3(touch.position.x,0,0) - new Vector3(startPos.x,0,0)).magnitude;
					if(swipeDistHorz > minSwipe){
						
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						
						if(swipeValue > 0){// right
							
						}else if(swipeValue < 0){//left
							
						}
					}
					break;
			}
		}*/
		

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		if(moveHorizontal > 0 || moveHorizontal < 0){
			anim.SetFloat ("Speed",Mathf.Abs(moveHorizontal));
			moveAnimation(Movement.MOVE,true);

			rigidbody2D.velocity = new Vector2 (moveHorizontal * maxSpeed, rigidbody2D.velocity.y);
			 
			if (moveHorizontal > 0 && !facingRight) {
				Flip ();
			}else if(moveHorizontal < 0 && facingRight){
				Flip();
			}
		}
		if(moveVertical > 0 || moveVertical < 0){
			anim.SetFloat ("Speed",Mathf.Abs(moveVertical));
			if (moveVertical > 0) {
				moveAnimation(Movement.UP,true);
			}else if(moveVertical < 0){
				moveAnimation(Movement.DOWN,true);
			}
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,moveVertical * maxSpeed);
			//rigidbody2D.AddForce(new Vector2 (rigidbody2D.velocity.x, moveVertical * maxSpeed));
		}

	}

	private void moveAnimation(Movement move, bool isPlay){
		anim.SetBool("move",(move == Movement.MOVE)? isPlay : !isPlay);
		anim.SetBool("moveUp",(move == Movement.UP)? isPlay : !isPlay);
		anim.SetBool("moveDown",(move == Movement.DOWN)? isPlay : !isPlay);
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
