# First-person-Unity-Arduino
This project send analog data collected by a joystick via serial port to unity. It is an ideal project to control third person characters or creat your own videogame control.  

## How it works ⚙️
**01** _Load the next script to arduino_
```
void setup() {
  // put your setup code here, to run once:
   Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.print(analogRead(0));
  Serial.print(",");
  Serial.println(analogRead(1));
  delay(10);

}
```
**02** _Connect the Joystick on the Arduino UNO analog ports: horizontal axis (A0) and vertical axis (A1) _ <br>
https://raw.githubusercontent.com/vicjomaa/First-person-Unity-Arduino/master/Images/Circuit.JPG

**04** _Load ArduinoSerial.cs script in your scene _
```
This file  setup your comminication port  "COM2" and communication speed
   /* configura el puerto serial */
    public static string port = "COM2";
    
    /* configura la velocidad de transmision de informacion. */
    public int baudrate = 9600;
    .
    .
    .
    
    // Envia  a info del puerto serial de tipo string
    public void escribirQueue(string mensaje)
    {
        salidaDatos.Enqueue(mensaje);

    }


    // Lee la info del puerto serial y la convierte en un string
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
    
```


## Build in 🛠️
* Unity 2017  -VideoGame editor
* Arduino - Joystick Script



## Created by ✒️
* Coding : Milton Mahecha and Victor Mahecha.
*Inspired by the Alan Zucconi Tutorial https://www.alanzucconi.com/2015/10/07/how-to-integrate-arduino-with-unity/

