using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerControl : MonoBehaviour
{
    //tombol untuk menggerakan ke atas
    public KeyCode upButton = KeyCode.W;
 
    //tombol untuk menggerakan ke bawah
    public KeyCode downButton = KeyCode.S;
 
    //Kecepatan gerak
    public float speed = 5.0f;
 
    //batas atas dan bawah game scene
    public float yBoundary = 9.0f;
 
    //rigidbody 2D raket
    private Rigidbody2D rigidBody2D;
 
    //skor pemain
    private int score;
 
    // Titik tumbukan terakhir dengan bola, untuk menampilkan variabel-variabel fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;
 
 
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
 
 
 
    void Update()
    {
 
    //dapatkan kecepatan raket
    Vector2 velocity = rigidBody2D.velocity;
 
    //jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y
    if (Input.GetKey(upButton))
    {
        velocity.y = speed;
    }
    //tombol ke bawah
    else if (Input.GetKey(downButton))
    {
        velocity.y = -speed;
    }
    // tidak menekan tombol, kecepatan 0
    else
    {
        velocity.y = 0.0f;
    }
 
    //masukkan kembali kecepatannya ke rigidBody2D.
    rigidBody2D.velocity = velocity;
 
    //dapatkan posisi raket
    Vector3 position = transform.position;
 
    //jika posisi raket melewati batas atas
    if (position.y > yBoundary)
    {
        position.y = yBoundary;
    }
 
    // jika posisi raket melewati batas bawah
    else if (position.y < -yBoundary)
    {
        position.y = -yBoundary;
    }
 
    //masukan kembali posisinya ke trasform
    transform.position = position;
 
    }
 
   
    public void IncrementScore()
    {
        score++;
    }
 
    //Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }
 
    //mendapatkan nilai skor
    public int Score
    {
        get { return score; }
    }
 
    // Untuk mengakses informasi titik kontak dari kelas lain
    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
 
    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
}