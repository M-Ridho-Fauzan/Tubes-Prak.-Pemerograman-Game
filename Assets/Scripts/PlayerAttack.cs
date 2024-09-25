using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject peluruPrefab;
    public AudioSource suaraTembak;
    // public float attackSpeed;
    private Setting setting;

    // Start is called before the first frame update
    void Start()
    {
        //Soal 5 Pertemuan 10: Baris dibawah ini bertujuan untuk???
        setting = FindObjectOfType<Setting>();
        InvokeRepeating("Tembak",0f,setting.attackSpeed);
    }

    void Tembak(){

        suaraTembak.Play();
        //Soal 6 Pertemuan 10: Baris dibawah ini bertujuan untuk???
        GameObject peluru = Instantiate(peluruPrefab) as GameObject;

        //Soal 7 Pertemuan 10: Baris dibawah ini bertujuan untuk???
        peluru.transform.position = transform.position;

        //Soal 8 Pertemuan 10: Baris dibawah ini bertujuan untuk???
        Destroy(peluru, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
