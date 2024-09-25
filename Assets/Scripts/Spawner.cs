using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject PowerUp, WpEnemiesPrefab;
    bool enemyPhase = true;
    int iter = 0;
    List<string> operator1 = new List<string>();
    List<string> operator2 = new List<string>();
    List<int> number1 = new List<int>();
    List<int> number2 = new List<int>();
    List<int> enemy_health = new List<int>();
    public int bullPow;


    // Start is called before the first frame update
    void Start()
    {
        setValue();
        setEnemyHealth();
        InvokeRepeating("spawn",0f,3f);
    }

    void setEnemyHealth()
    {
        bullPow = GameObject.Find("GM").GetComponent<GM>().getPower();

        enemy_health.Clear();

        if (bullPow < 100)
        {
            Debug.LogWarning("Telah memasuki fase: " + bullPow);
            enemy_health.Add(3);
            enemy_health.Add(50);
            enemy_health.Add(100);
            enemy_health.Add(300);
            enemy_health.Add(400);
            enemy_health.Add(500);
            enemy_health.Add(800);
        }
    }

    void setValue()
    {
        operator1.Add("+");
        operator1.Add("x");
        operator1.Add("+");
        operator1.Add("x");
        operator1.Add("+");
        

        operator2.Add("x");
        operator2.Add("+");
        operator2.Add("x");
        operator2.Add("+");
        operator2.Add("x");

        number1.Add(4);
        number1.Add(2);
        number1.Add(20);
        number1.Add(4);
        number1.Add(200);

        number2.Add(3);
        number2.Add(9);
        number2.Add(2);
        number2.Add(100);
        number2.Add(3);
    }

    void spawn()
    {
        if (enemyPhase)
        {
            // GameObject enemy = Instantiate(Enemy) as GameObject;
            // enemy.GetComponent<Enemy>().set_health(enemy_health[iter]);
            // Instantiate game object WpEnemies terlebih dahulu
            // GameObject wpEnemies = Instantiate(WpEnemiesPrefab) as GameObject;
            GameObject wpEnemies = Instantiate(WpEnemiesPrefab, transform.position, Quaternion.identity);

            // Kemudian, cari game object Enemies di dalam WpEnemies
            GameObject enemy = wpEnemies.transform.Find("enemies").gameObject;

            // Akses komponen Enemy dari game object Enemies
            enemy.GetComponent<Enemy>().set_health(enemy_health[iter]);
            // enemy.transform.position = transform.position;
        } else{
            if (iter < operator1.Count && iter < number1.Count && iter < operator2.Count && iter < number2.Count)
            {
                GameObject powerUp = Instantiate(PowerUp) as GameObject;
                powerUp.GetComponent<PowerUp>().spawned(operator1[iter], number1[iter], operator2[iter], number2[iter]);
                powerUp.transform.position = transform.position;
                iter++;
            }
            else
            {
                Debug.LogWarning("Index melebihi ukuran daftar.");
            }
        }

        enemyPhase = !enemyPhase;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
