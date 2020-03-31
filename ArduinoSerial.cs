using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;



public class ArduinoSerial : MonoBehaviour
{

    public bool looping = true;

    private Thread thread;

    /* configura el puerto serial */
    public static string port = "COM2";

    
    /* configura la velocidad de transmision de informacion. */

    public int baudrate = 9600;

    // crea variable que recoge informacion del puerto serial
    private SerialPort arduino;

    private Queue salidaDatos; // de unity a arduino
    private Queue entraDatos; // de arduino a unity

    public int QueueLenght = 1;


    public static bool conexion = false;

    // Se ejecuta una vez cuando incia el programa
   

    // Se ejecuta en paralelo a lo que se encuentre dentro de los updates
    public void comienzaThread()
    {
        salidaDatos = Queue.Synchronized(new Queue());
        entraDatos = Queue.Synchronized(new Queue());

        thread = new Thread(arduinoThread);
        thread.Start();


    }

    // Se ejecuta varias veces en cada cambio de frame
    void Update()
    {
        
    }






    // Lee la info del puerto serial y la convierte en un string

    public void escribirQueue(string mensaje)
    {
        salidaDatos.Enqueue(mensaje);

    }

    public string leerQueue()
    {
        if (entraDatos.Count == 0)
        {
            return null;

        }
        else
        {
            return (string)entraDatos.Dequeue();
        }

    }






    public void WriteToArduino(string message)
    {
        arduino.WriteLine(message);
        arduino.BaseStream.Flush();
    }



    public string ReadFromArduino(int timeout)
    {
        arduino.ReadTimeout = timeout;
        try
        {
            return arduino.ReadLine();
        }
        catch (System.Exception)
        {
            return null;
        }
    }





    // inicializa la comunicacion con el arduino
    public bool IsLooping()
    {
        lock (this)
        {
            return looping;
        }
    }

    public void StopThread()
    {
        lock (this)
        {
            looping = false;
        }
    }


    public void arduinoThread()
    {
        arduino = new SerialPort(port, baudrate);
        int timeout = 50;
        arduino.Open();
        print("puerto conectado exitosamente");
        conexion = true;

        while (IsLooping())
        {


            if (salidaDatos.Count != 0)
            {

                string infoEnvio = (string)salidaDatos.Dequeue();
                WriteToArduino(infoEnvio);
            }

            string infoLlegada = ReadFromArduino(timeout);
            if (infoLlegada != null)
            {
                if (entraDatos.Count < QueueLenght)
                {
                    entraDatos.Enqueue(infoLlegada);
                }
            }

        }
        arduino.Close();


    }


    void OnApplicationQuit()
    {

        print("puerto desconectado satisfactoriamente");
        conexion = false;
        StopThread();

    }


}

