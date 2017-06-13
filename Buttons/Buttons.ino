#include <Bounce.h>

Bounce button4 = Bounce(4, 10); //D4
Bounce button5 = Bounce(5, 10); //D5

void setup() {
  pinMode(4, INPUT_PULLUP);
  pinMode(5, INPUT_PULLUP);
  pinMode(6, OUTPUT);
  digitalWrite(6, HIGH);
}
void loop() {
  button4.update();
  button5.update();
  
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

