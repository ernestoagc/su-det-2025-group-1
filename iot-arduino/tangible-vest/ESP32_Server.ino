
//==================================
//ESP32 Tangible accessory for hypersensitivity exposure therapy
//==================================
#include <WiFi.h>
#include <WebServer.h>
#include <WebSocketsServer.h>
//-----------------------------------------------

// const char* ssid = "dsv-extrality-lab";
// const char* password = "expiring-unstuck-slider";
const char* ssid = "NetworkName";
const char* password = "passw0rd2";

//-----------------------------------------------

const int ledPin = 13; // LED pin
const int touchPin = 1;
const int touchThreshold = 50000;

const int leftVibrationPin = 3;
const int rightVibrationPin = 34;
//-----------------------------------------------
WebServer server(80);
WebSocketsServer webSocket = WebSocketsServer(81);
//-----------------------------------------------
boolean LEDonoff=false; String JSONtxt; String oldJSON; int currentClientNumber; int currentpotVal; int oldpotVal; int mappedPotVal; bool buttonMessageSent; int buttonState;
//-----------------------------------------------
#include "html.h"
#include "header.h"
//====================================================================

void setup()
{
  Serial.begin(115200);
  pinMode(ledPin, OUTPUT); // Set LED pin as an output
  pinMode(leftVibrationPin, OUTPUT); // Set LED pin as an output
  pinMode(rightVibrationPin, OUTPUT); // Set LED pin as an output
  
  //-----------------------------------------------
  connect2Network();
  webSocket.onEvent(webSocketEvent);

  buttonMessageSent = false;
  
  delay(1000); // give me time to bring up serial monitor
  Serial.println("ESP32 Touch Test");
}
//====================================================================

void loop()
{
  int touchInputState = touchRead(touchPin);
  digitalWrite(ledPin, touchInputState > touchThreshold ? HIGH : LOW); // Set LED state based on touch input threshold

  if(touchInputState > touchThreshold) {
    webSocket.broadcastTXT("EMERGENCY BUTTON PRESSED");
    Serial.println("Sent: EMERGENCY BUTTON SENT");
  }
  
  if(WiFi.status() != WL_CONNECTED) {
    Serial.println("Lost connection to network! Attempting to reconnect...");
    connect2Network();
    return;
  }

  webSocket.loop(); server.handleClient();
  if(currentClientNumber != webSocket.connectedClients()){
    if(currentClientNumber < webSocket.connectedClients()) Serial.println("A new client has connected!");
    else Serial.println("A client has disconnected");
    Serial.print("Number of clients currently connected: ");
    Serial.println(webSocket.connectedClients());
    
    currentClientNumber = webSocket.connectedClients();
  }
} 

//====================================================================

void webSocketEvent(uint8_t num, WStype_t type, uint8_t * payload, size_t length) {
  if(type == WStype_TEXT) {
    String message = String((char*)payload);
    Serial.print("Received message: ");
    Serial.println(message);
    
    if (message.startsWith("VIBRATE LEFT:")) {
      int timeMs = message.substring(13).toInt();
      Serial.print("Activating left vibration for ");
      Serial.print(timeMs);
      Serial.println(" ms");
      digitalWrite(leftVibrationPin, HIGH);
      delay(timeMs);
      digitalWrite(leftVibrationPin, LOW);
    }
    else if (message.startsWith("VIBRATE RIGHT:")) {
      int timeMs = message.substring(14).toInt();
      Serial.print("Activating right vibration for ");
      Serial.print(timeMs);
      Serial.println(" ms");
      digitalWrite(rightVibrationPin, HIGH);
      delay(timeMs);
      digitalWrite(rightVibrationPin, LOW);
    }
  }
}
