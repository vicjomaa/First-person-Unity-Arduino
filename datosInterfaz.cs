using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datosInterfaz : MonoBehaviour {


    // UI elements
    public string comField;

    public GameObject personaje;

   
    public string direccionArd;
    public float analogo0;
    public float analogo1;
    public float analogo2;
    public float analogo3;
    public float analogo4;
    public float analogo5;

    private ArduinoSerial arduinoInfo;


    public float moveSpeed = 10f;
    public float turnSpeed = 50f;


    // Use this for initialization
    void Start () {

        arduinoInfo = FindObjectOfType<ArduinoSerial>();
        setCom();
        arduinoInfo.comienzaThread();

    }
	
	// Update is called once per frame
	void Update () {

        if (ArduinoSerial.conexion)
        {
            
            direccionArd = arduinoInfo.leerQueue();
            componentes(direccionArd);
            
        }
        


    }

    public void setCom() {
            
            ArduinoSerial.port = comField;
            

    }

    public void componentes(string data)
    {
        if (direccionArd != null)
        {
            string[] compoArdu = direccionArd.Split(',');

            analogo0 = float.Parse(compoArdu[0]);
            analogo1 = float.Parse(compoArdu[1]);
            movimiento(analogo0, analogo1);




        }

    }

    public void movimiento(float x, float y) {

        if (x > 600f)
            personaje.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (x < 400f)
            personaje.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (y > 600f)
            personaje.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (y < 400f)
            personaje.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        
    }
}
