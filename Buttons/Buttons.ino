#include <Bounce.h>

Bounce button2 = Bounce(2, 10); //D2
Bounce button3 = Bounce(3, 10); //D3
Bounce button4 = Bounce(4, 10); //D4
Bounce button5 = Bounce(5, 10); //D5

void setup() {
  pinMode(2, INPUT_PULLUP);
  pinMode(3, INPUT_PULLUP);
  pinMode(4, INPUT_PULLUP);
  pinMode(5, INPUT_PULLUP);
  pinMode(6, OUTPUT);
  digitalWrite(6, HIGH);
}
void loop() {
  button2.update();
  button3.update();
  button4.update();
  button5.update();

  if (button2.risingEdge()) {
    Keyboard.set_key1(KEY_P);
    Keyboard.send_now();
    Keyboard.set_key1(0);
    Keyboard.send_now();
  }
  if (button3.risingEdge()) {
    Keyboard.set_key1(KEY_O);
    Keyboard.send_now();
    Keyboard.set_key1(0);
    Keyboard.send_now();
  }
  
  if (button4.fallingEdge()) {
    Keyboard.set_key1(KEY_P);
    Keyboard.send_now();
    Keyboard.set_key1(0);
    Keyboard.send_now();
  }
  if (button5.fallingEdge()) {
    Keyboard.set_key1(KEY_O);
    Keyboard.send_now();
    Keyboard.set_key1(0);
    Keyboard.send_now();
  }

}

