//Config AOG
  bool isPGNFound = false, isHeaderFound = false;
  uint8_t pgn = 0, dataLength = 0, idx = 0;
  int16_t tempHeader = 0;
  uint8_t AOG[] = {0x80,0x81,0x7D,0xEB,8, 0,0,0,0, 0,0,0,0, 15};
  int16_t AOGSize = sizeof(AOG);
  float gpsSpeed, statuFerti, DebitAOG, Rincage, Largeuroutil = 0;
  
// Config Bluetooth

#include "BluetoothSerial.h"
//#include <analogWrite.h>
#include <Wire.h>

BluetoothSerial SerialBT;

//Config Débit Mètre
volatile int flow_frequency; // Measures flow sensor pulses
// Calculated litres/hour
double vol = 0.0,l_minute,l_tot;
unsigned char flowsensor = 27; // Sensor Input
unsigned long currentTime;
unsigned long cloopTime;
void flow () // Interrupt function
{
   flow_frequency++;
}

//Config commande pompe (cytron md13s)
int Pompe_ON = 25; // Arduino PWM output pin 5; connect to IBT-2 pin 1 (RPWM)
int PinPWD_Pompe = 26; // Arduino PWM output pin 6;
int Puissance_Pompe = 180;
double Debit_Pompe_H =0;
double Debit_AOG_H =0;

//Relais pompe
int Relay_Ferti = 14;
int Relay_Rincage = 12;
uint16_t PWMOutFrequ = 5000;

void setup()
{

   Serial.begin(38400);

//Setup Bluetooth
  SerialBT.begin("Cuve Fertilisation 1"); //Bluetooth device name
  Serial.println("The device started, now you can pair it with bluetooth!");
  
//Setup Débit mètre
  pinMode(flowsensor, INPUT);
  digitalWrite(flowsensor, HIGH); // Optional Internal Pull-Up
  attachInterrupt(digitalPinToInterrupt(flowsensor), flow, RISING); // Setup Interrupt
   currentTime = millis();
   cloopTime = currentTime;
   
//Setup Pompe
  pinMode(Pompe_ON, OUTPUT);
  //pinMode(PinPWD_Pompe, OUTPUT);
  pinMode(Relay_Ferti, OUTPUT);
  pinMode(Relay_Rincage, OUTPUT);

  //pinMode(PinPWD_Pompe, OUTPUT);
  ledcAttachPin(PinPWD_Pompe, 1); // assign RGB led pins to channels
  ledcSetup(1, 500, 8); // 12 kHz PWM, 8-bit resolution
}
void loop ()
{

 //Comm AOG
    // Serial Receive
    //Do we have a match with 0x8081?    
    if (SerialBT.available() > 1 && !isHeaderFound && !isPGNFound) 
    {
      uint8_t temp = SerialBT.read();
      if (tempHeader == 0x80 && temp == 0x81) 
      {
        isHeaderFound = true;
        tempHeader = 0;        
      }
      else  
      {
        tempHeader = temp;     //save for next time
        return;    
      }
    }
  
    //Find Source, PGN, and Length
    if (SerialBT.available() > 2 && isHeaderFound && !isPGNFound)
    {
      SerialBT.read(); //The 7F or less
      pgn = SerialBT.read();
      dataLength = SerialBT.read();
      isPGNFound = true;
      idx=0;
    } 
    
    if (SerialBT.available() > dataLength && isHeaderFound && isPGNFound)
    {
      if (pgn == 235) //EB Données fertilisation
      {
        //bit 5,6
        gpsSpeed = ((float)(SerialBT.read()| SerialBT.read() << 8 ))*0.1;

        //bit 7
        statuFerti = ((float)SerialBT.read());
        //Bit 8,9    Débit à appliquer
        DebitAOG = ((float)(SerialBT.read()| SerialBT.read() << 8 )); //high low bytes
        //Bit 10,11    Largeur de travail
        Largeuroutil = ((float)(SerialBT.read()| SerialBT.read() << 8 )); //high low bytes
        //bit 12
        Rincage = ((float)SerialBT.read());
        //reset for next pgn sentence
        isHeaderFound = isPGNFound = false;
        pgn=dataLength=0;   
      }
    }
    else
    {
      //statuFerti = 0;
    } 
    
//Calcul Débit
   currentTime = millis();
   // Every second, calculate and print litres/hour
   if(currentTime >= (cloopTime + 1000))
   {
    cloopTime = currentTime; // Updates cloopTime
    if(flow_frequency != 0){
      // Pulse frequency (Hz) = 7.5Q, Q is flow rate in L/min.
      l_minute = (flow_frequency / 7.5); // (Pulse frequency x 60 min) / 7.5Q = flowrate in L/hour
      Serial.println("Rate: ");
      Serial.print(l_minute);
      Serial.print(" L/M");
      l_tot = l_minute/60;
      vol = vol +l_tot;
      Serial.print("Vol:");       Serial.print(vol);      Serial.print(" L");
      flow_frequency = 0; // Reset Counter
     
    }
    else {
      SerialBT.println(" flow rate = 0 ");
      SerialBT.print("Rate: ");
      Serial.print( flow_frequency );
      Serial.print(" L/M");
      Serial.print("Vol:");
      Serial.print(vol);
      Serial.println(" L");
    }
//Gestion pompe
      if (Rincage == 1 && statuFerti == 0)
    {
      Serial.println("ok");
      digitalWrite(Pompe_ON, LOW);
      digitalWrite(Relay_Ferti, LOW);
      digitalWrite(Relay_Rincage, HIGH);
      ledcWrite(1, 210);
      
    }
    else if (statuFerti == 0)
    {
      digitalWrite(Pompe_ON, LOW);
      digitalWrite(Relay_Ferti, LOW);
      digitalWrite(Relay_Rincage, LOW);
      ledcWrite(1, 0);
    }
    if (statuFerti == 1 && gpsSpeed > 0.5 && DebitAOG > 0.5 && Largeuroutil > 0.5)
    {
      digitalWrite(Pompe_ON, LOW);
      digitalWrite(Relay_Rincage, LOW);
      digitalWrite(Relay_Ferti, HIGH);
      
 //Calcul débit/heure
      Debit_Pompe_H = l_minute * 60 ;
      Debit_AOG_H = DebitAOG * (((gpsSpeed) * Largeuroutil)/10);
      if (l_minute = 0)
      {
        Puissance_Pompe = 180;
      }
 //Augmente la puissance de la pompe
      if (Debit_Pompe_H < Debit_AOG_H)
      {
          if ((Debit_AOG_H - Debit_Pompe_H)> 20 && Puissance_Pompe < 239)
          {
          Puissance_Pompe = Puissance_Pompe + 10;
          }
          if ((Debit_AOG_H - Debit_Pompe_H)> 10 && Puissance_Pompe < 249)
          {
          Puissance_Pompe = Puissance_Pompe + 5;
          }
          if (Puissance_Pompe < 254) Puissance_Pompe = Puissance_Pompe + 1;   
       }
  //Diminue la puissance de la pompe
      if (Debit_Pompe_H > Debit_AOG_H)
      {
        if (Puissance_Pompe > 90)
        {   
          if ((Debit_Pompe_H - Debit_AOG_H)> 20)
          {
          Puissance_Pompe = Puissance_Pompe - 10;
          }
          if ((Debit_Pompe_H - Debit_AOG_H)> 10)
          {
          Puissance_Pompe = Puissance_Pompe - 2;
          }
          Puissance_Pompe = Puissance_Pompe - 1;
        }
      }
    ledcWrite(1, Puissance_Pompe);
    }
    else if (Rincage == 0)
    {
    Puissance_Pompe = 180;
    ledcWrite(1, 0);
    digitalWrite(Pompe_ON, LOW);
    digitalWrite(Relay_Ferti, LOW);
    digitalWrite(Relay_Rincage, LOW);
    }
     //ledcWrite(PinPWD_Pompe, Puissance_Pompe);
     Serial.print("Puissance pompe ");
     Serial.println(Puissance_Pompe);
     Serial.print("speed ");
     Serial.println(gpsSpeed);
     Serial.print("Largeur ");
     Serial.println(Largeuroutil);
     Serial.print("Debit_Pompe_H ");
     Serial.println(Debit_Pompe_H);
     Serial.print("DebitAOG ");
     Serial.println(Debit_AOG_H);
     Serial.println(" ");
     
//send to AOG
     
//Débit pompe
     int16_t DPH = (int16_t)Debit_Pompe_H;
     AOG[5] = (uint8_t)DPH;
     AOG[6] = DPH >> 8;
     
//Puissance Pompe
     int16_t PP = (int16_t)Puissance_Pompe;
     AOG[7] = (uint8_t)PP;
     AOG[8] = PP >> 8;
     
//Volume passé
     int16_t V = (int16_t)vol;
     AOG[9] = (uint8_t)V;
     AOG[10] = V >> 8;
     
//add the checksum
       int16_t CK_A = 0;
      for (uint8_t i = 2; i < AOGSize - 1; i++)
      {
        CK_A = (CK_A + AOG[i]);
      }
      
      AOG[AOGSize - 1] = CK_A;
        
     SerialBT.write(AOG, AOGSize);
     Serial.flush();
     
   }

 
}
