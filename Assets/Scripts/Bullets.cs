using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Soal 1 Pertemuan 10: Cara peluru bergerak keatas lalu ketika mengenai musuh menghilang adalah sebagai berikut:???
    // Soal 2 Pertemuan 10: Bullet  dijadikan prefab, prefab adalah ???
    // Soal 3 Pertemuan 10: Tujuan bullet dijadikan prefab adalah ???
    // public float bulletSpeed;
    private Setting setting;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");

        foreach (GameObject powerUp in powerUps)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), powerUp.GetComponent<Collider2D>());
            }
            // Dapatkan LayerMask untuk Layer PowerUp
    // int powerUpLayerMask = LayerMask.GetMask("PowerUp");

    // // Atur pengabaian tabrakan dengan Layer PowerUp
    // Physics2D.IgnoreLayerCollision(gameObject.layer, powerUpLayerMask);
    //     // ==========
        setting = FindObjectOfType<Setting>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f,setting.bulletSpeed * Time.deltaTime,0f);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
