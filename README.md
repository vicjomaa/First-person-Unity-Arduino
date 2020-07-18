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
<image src="https://raw.githubusercontent.com/vicjomaa/First-person-Unity-Arduino/master/Images/Circuit.JPG" height="256" width="455"><image/>
  
**03** Setup .Net unity framework <br>
Change the **.Net 2.0 Subset** with a version that include the  serialPort class **.Net 2.0**. 
<image src="https://raw.githubusercontent.com/vicjomaa/First-person-Unity-Arduino/master/Images/net.JPG" height="256" width="455"><image/>

**04** _Load ArduinoSerial.cs script and datosInterfaz.cs in your scene_ <br>
* **Load ArduinoSerial.cs** sends and receives data from the Arduino serial port COM#
* **datosInterfas.cs** collects the joystick info sended by the Arduino´s serial port and changes the analog values in a two dimensional movement (Attach it to the gameObject called **personaje**)

**05** _Connect your arduino_ <br>
As a recommendation ports between 1 and 10 works well; however, values greater than 10 cannot be readed properly by unity.
<image src="https://raw.githubusercontent.com/vicjomaa/First-person-Unity-Arduino/master/Images/vector.gif" height="256" width="455"><image/>

## Build in 🛠️
* Unity 2017  -VideoGame editor
* Arduino - Joystick Script



## Created by ✒️
* Coding : Victor Mahecha.
*Inspired by the Alan Zucconi Tutorial https://www.alanzucconi.com/2015/10/07/how-to-integrate-arduino-with-unity/

