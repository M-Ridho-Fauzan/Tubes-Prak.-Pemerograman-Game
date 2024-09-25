// dari kode ini, coba buatkan tutor memunculkan game object jika fungsi gameOver() di jalankan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GM : MonoBehaviour
{
    // public GameObject gameOverPanel; // Deklarasikan GameObject yang akan dimunculkan
    public TMP_Text attackTeks;
    public AudioSource enemyHitSound,enemyDeathSound,gameOverSound, powerUpSound, LevelSound;
    int attack_power = 4;
    public GameObject massageObject; 

    void Start()
    {
        massageObject.SetActive(false); // Sembunyikan massage di awal permainan
    }

    public void addPower(string simbol, int number)
    {
        if (simbol == "x"){attack_power = attack_power * number;}
        if (simbol == "+"){attack_power = attack_power + number;}
        attackTeks.text = attack_power.ToString();
        powerUp();
    }

    public void IncreaseAttackPower(int amount)
    {
        attack_power += amount;
        attackTeks.text = attack_power.ToString();
    }

    public int getPower()
    {
        return attack_power;
    }

    public void gameOver(){
        LevelSound.Stop();
        gameOverSound.Play();
        massageObject.SetActive(true); 
    }

    public void enemyHit()
    {
        enemyHitSound.Play();
    }

    public void enemyDeath()
    {
        enemyDeathSound.Play();
    }

    public void powerUp()
    {
        powerUpSound.Play();
    }
}
