using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKotnrol : MonoBehaviour
{
    public GameObject gokyuzuBir;
    public GameObject gokyuzuIki;
    public float arkaPlanHız = -1.5f;

    Rigidbody2D fizik1;
    Rigidbody2D fizik2;

    float uzunluk = 0;

    public GameObject engel;
    public int kacAdetEngel;
    GameObject []engeller;

    float degisimZaman = 0;
    int sayac = 0;

    void Start()
    {
        fizik1 = gokyuzuBir.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzuIki.GetComponent<Rigidbody2D>();

        fizik1.velocity = new Vector2(arkaPlanHız, 0);
        fizik2.velocity = new Vector2(arkaPlanHız, 0);

        uzunluk = gokyuzuBir.GetComponent<BoxCollider2D>().size.x;

        engeller = new GameObject[kacAdetEngel];

        for(int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            Rigidbody2D fizikEngel = engeller[i].AddComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaPlanHız, 0);
        }

    }

    
    void Update()
    {
        if(gokyuzuBir.transform.position.x<= -uzunluk)
        {
            gokyuzuBir.transform.position += new Vector3(uzunluk * 2, 0);
        }
        if (gokyuzuIki.transform.position.x <= -uzunluk)
        {
            gokyuzuIki.transform.position += new Vector3(uzunluk * 2, 0);
        }


        degisimZaman += Time.deltaTime;
        if (degisimZaman > 2f)
        {
            degisimZaman = 0;
            float yEksenim = Random.Range(0f, 1f);
            engeller[sayac].transform.position = new Vector3(10, yEksenim);
            sayac++;
            if(sayac >= engeller.Length)
            {
                sayac = 0;
            }
        }
            
    }
    public void oyunBitti()
    {
        for(int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
    }
}
