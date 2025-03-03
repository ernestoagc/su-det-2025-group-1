//=======================================
//handle function: send webpage to client
//=======================================
void webpage()
{
  server.send(200,"text/html", webpageCode);
}

void connect2Network() 
{
  WiFi.begin(ssid, password);
  Serial.println("Printing this device's details bellow...");
  Serial.print("MacAddress: ");
  Serial.println(WiFi.macAddress());
  Serial.print("Device Name: ");
  Serial.println(WiFi.getHostname());
  Serial.print("Attempting to connect to " + String(ssid) + " network...");
  while(WiFi.status() != WL_CONNECTED){Serial.print("."); delay(500);}
  WiFi.mode(WIFI_STA);
  Serial.println();
  Serial.println("Successfully connected to network!");
  Serial.print("Local IP: ");
  Serial.println(WiFi.localIP());
  //-----------------------------------------------
  server.on("/", webpage);
  //-----------------------------------------------
  server.begin(); webSocket.begin();
}

void sendMessage2Clients() {
  if(oldJSON != JSONtxt) webSocket.broadcastTXT(JSONtxt);
  oldJSON = JSONtxt;
}
