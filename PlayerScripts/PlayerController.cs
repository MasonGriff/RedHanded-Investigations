using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public Animator SpriteAnim;
    public Rigidbody2D myRB;

    public float plyrWalkSpeed = 2;
    public bool facingRight = true;

    public bool NoteTaking = false;

    float moveTimer;
    
	// Use this for initialization
	void Start () {
        Player = this.gameObject;
        SpriteAnim = Player.GetComponent<Animator>();
        myRB = Player.GetComponent<Rigidbody2D>();
        //plyrWalkSpeed = (plyrWalkSpeed / 6);
        //moveTimer = plyrWalkSpeed;
        if (!facingRight)
        {
            Flip();
        }
        NoteTaking = false;
    }
	
	// Update is called once per frame
	void Update () {
        // moveTimer -= Time.deltaTime;
        float move = Input.GetAxis("Horizontal");
        //movement
        if (Game.current.trackingGame.GameplayPaused == false)
        {
            
            myRB.velocity = new Vector2(move * plyrWalkSpeed, myRB.velocity.y);
            //fip character left or right
            if (move >= 0.01 && facingRight == false)
            {
                Flip();
                facingRight = true;
            }
            if (move <= -0.01 && facingRight == true)
            {
                Flip();
                facingRight = false;
            }
        }
        if (move == 0 && !NoteTaking)
        {
            SpriteAnim.SetInteger("AnimState", 0);
            SpriteAnim.SetBool("Notations", false);
        }
        else if (move != 0 && !NoteTaking)
        {
            SpriteAnim.SetInteger("AnimState", 1);
            SpriteAnim.SetBool("Notations", false);
        }
        else if (NoteTaking)
        {
            SpriteAnim.SetBool("Notations", true);
        }

    }

    //fip character left or right
    void Flip()
    {
        //facingRight = !facingRight; //commented out for time being
        Vector3 tempScale = Player.transform.localScale;
        tempScale.x *= -1f;
        Player.transform.localScale = tempScale;
    }

}
