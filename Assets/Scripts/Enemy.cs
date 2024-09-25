using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public TMP_Text teks;
    private Setting setting;
    private GameObject wpEnemies; // Tambahkan variabel untuk menyimpan referensi ke wpEnemies

    // Start is called before the first frame update
    void Start()
    {
        setting = FindObjectOfType<Setting>();
        teks.text = health.ToString();
        wpEnemies = transform.parent.gameObject; // Dapatkan referensi ke wpEnemies
    }

    public void set_health(int h){
        health = h;
        teks.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*setting.downSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col){
        // Fungsi pengurangan healt enemy jika tertembak berdasarkan power bullets
        health = health - GameObject.Find("GM").GetComponent<GM>().getPower();
        // =========
        teks.text = health.ToString();
        if (health > 0)
        {
            GameObject.Find("GM").GetComponent<GM>().enemyHit();
        } else {
            GameObject.Find("GM").GetComponent<GM>().enemyDeath();
            GameObject.Find("GM").GetComponent<GM>().IncreaseAttackPower(0);
            // Destroy(gameObject);
            Destroy(wpEnemies); // Hancurkan objek wpEnemies
        }
    }
}
