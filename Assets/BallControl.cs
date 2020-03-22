using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BallControl : MonoBehaviour
{
    //RigidBody 2D bola
    private Rigidbody2D rigidBody2D;
 
    //Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
 
    void ResetBall()
    {
        //Reset posisi bola menjadi (0,0)
        transform.position = Vector2.zero;
 
        //Reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
 
    void PushBall()
    {
        //tentuka nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
 
        //tentukan nilai acak antara 0 (inklusif) dan 2 (ekslusif)
        float randomDirection = Random.Range(0,2);
 
        //Jika nilainya di bawah 1, bola bergerak ke kiri.
        //jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            //gunakan gaya untuk menggerakkan bola ini
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
 
    }
 
    void RestartGame()
    {
        //bola di posisi semula
        ResetBall();
        //setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
 
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
 
        //mulai game
        RestartGame();
 
    }
 
}