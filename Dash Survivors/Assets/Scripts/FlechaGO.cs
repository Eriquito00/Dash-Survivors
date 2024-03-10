using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlechaGO : MonoBehaviour
{
    public GameObject ArribaFlecha;
    public GameObject AbajoFlecha;
    // Start is called before the first frame update
    void Start()
    {
        ArribaFlecha.SetActive(true);
        AbajoFlecha.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            AbajoFlecha.SetActive(false);
            ArribaFlecha.SetActive(true);
        }

        if (ArribaFlecha.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)))
        {
            Jugar();
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ArribaFlecha.SetActive(false);
            AbajoFlecha.SetActive(true);
        }

        if (AbajoFlecha.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z)))
        {
            SalirAlMenu();
        }
    }
    private void Jugar()
    {
        ArribaFlecha.SetActive(false);
        AbajoFlecha.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
    private void SalirAlMenu()
    {
        ArribaFlecha.SetActive(false);
        AbajoFlecha.SetActive(false);
        SceneManager.LoadScene("Inicio");
    }
}
