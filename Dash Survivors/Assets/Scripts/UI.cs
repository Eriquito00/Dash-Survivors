using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text Counter1;
    public Text Counter2;
    public Text Counter3;
    public Text PowerUp1;
    public Text PowerUp2;
    public Text WeaponLevel;
    public Text TotalEnemigos;
    public Text TotalEnemigosMax;
    private int numeroTotalEnemigos;
    private int numeroTotalEnemigosMax;
    // Start is called before the first frame update
    void Start()
    {
        numeroTotalEnemigosMax = PlayerPrefs.GetInt("MaxPuntos", 0);
    }

    // Update is called once per frame
    void Update()
    {
        numeroTotalEnemigos = EnemyN1.killslvl1 + EnemyN2.killslvl2 + EnemyN3.killslvl3;
        TextUpdate();
    }
    void TextUpdate()
    {
        WeaponLevel.text =  Player.weaponLevel.ToString();
        TotalEnemigos.text = numeroTotalEnemigos.ToString();
        TotalEnemigosMax.text = numeroTotalEnemigosMax.ToString();
        if (numeroTotalEnemigos > numeroTotalEnemigosMax)
        {
            numeroTotalEnemigosMax = numeroTotalEnemigos;
            PlayerPrefs.SetInt("MaxPuntos", numeroTotalEnemigosMax);
            PlayerPrefs.Save();
        }
    }
}