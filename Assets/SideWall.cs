using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SideWall : MonoBehaviour
{
    //pemain yang akan bertambah skornya jika bola menyentuh dinding ini
    public PlayerControl player;
 
    // Skrip GameManager untuk mengakses skor maksimal
    [SerializeField]
    private GameManager gameManager;
 
    //akan dipanggil ketika objek lain ber-collider (bola) bersentuhan dengan dinding
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        //jika objek tersebut bernama "ball"
        if (anotherCollider.name == "Ball")
        {
            //tambahkan skor ke pemain
            player.IncrementScore();
 
            //Jika skor pemain belum mencapai skor maksimal..
            if (player.Score < gameManager.maxScore)
            {
                //restart game setelah bola mengenai dinding
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}