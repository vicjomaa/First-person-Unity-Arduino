# First-person-Unity-Arduino
This project send analog data collected by a joystick via serial port to unity. It is an ideal project to control third person characters or creat your own videogame control.  

## How it works ⚙️
_Load the next script to arduino_
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



## Build in 🛠️
* Unity 2017  -VideoGame editor
* Arduino - Joystick Script



## Created by ✒️
* Coding : Milton Mahecha and Victor Mahecha.
*Inspired by the Alan Zucconi Tutorial https://www.alanzucconi.com/2015/10/07/how-to-integrate-arduino-with-unity/

