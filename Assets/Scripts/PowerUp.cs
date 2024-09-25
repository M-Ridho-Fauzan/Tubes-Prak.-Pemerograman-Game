using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUp : MonoBehaviour
{
    public TMP_Text opsi1, opsi2;
    string operator1, operator2;
    int number1, number2;
    private Setting setting;

    // Start is called before the first frame update
    public void Start()
    {
        setting = FindObjectOfType<Setting>();
    }

    public void spawned(string opr1, int n1, string opr2, int n2)
    {
        operator1 = opr1;
        number1 = n1;
        operator2 = opr2;
        number2 = n2;
        opsi1.text = $"{operator1+number1}";
        opsi2.text = $"{operator2+number2}";
    }

    public void addAttack(string idOption)
    {
        string simbol = "";
        int number = 0;

        if (idOption == "1"){
            simbol = operator1; 
            number = number1;
        }

        if (idOption == "2"){
            simbol = operator2; 
            number = number2;
        }

        GameObject.Find("GM").GetComponent<GM>().addPower(simbol, number);
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* setting.downSpeed *Time.deltaTime);
    }
}
