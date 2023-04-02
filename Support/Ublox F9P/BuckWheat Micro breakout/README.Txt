# SimpleRTK2B-Micro-breakout-board

A small break out board for the ArduSimple SimpleRTK2B Micro.

The PCB is intended for [AgOpenGPS](https://github.com/farmerbriantee/AgOpenGPS "github.com/farmerbriantee/AgOpenGPS") users that wish to use a [Micro F9P](https://www.ardusimple.com/product/simplertk2b-micro/ "Ardusimple") as a base station. A USB micro B connection on the PCB provides power to the Micro F9P and also allows for USB communication between the Micro F9P and the host.

The board also additional breakout points that facilitate experimentation and development.

These images are of a V1.0 board. V1.1 updates the LED resistor value to decrease LED brightness and flips the top layer silkscreen to match the text on the F9P sticker.

# Features
1. A USB Micro B port and 3.3v regulator. The USB port can power the Micro and also allows for USB connection to the Micro. Plug the USB cable into your PC, a Raspberry Pi, and Orange Pi, etc. Use the USB connection for U-Center setup, base station communication, etc.
2. Power status LED. If the Micro F9P has 3.3v then the LED is lit.
3. Breakout connections for all the Micro's IO points. The side connections are a standard 0.1" pitch. You could solder female headers to the top to use jumper wires. You could solder male headers to the bottom to use the PCB on a breadboard. You can solder in wires. Or just leave them alone.
4. Bottom connection point with serial 1 and power. A great connection point if you want to use a wired UART connection.
5. Mounting holes. 1"x1.25" pattern, M3 or 4-40 holes.



# Power
You can power the board in 1 of these 3 ways:
1. Through the USB plug.
2. Through the VUSB connection on the bottom. Connect 5v.
3. Through the 3V3 connection on the bottom. Connect 3.3v. This will bypass the SMD voltage regulator.

Warning: Do not attempt to power the board in more than 1 way. If you do, you may damage your USB port or damage the SMD voltage regulator.



# Ordering using JLCPCB's SMT Service
You'll need the Gerber file, the BOM file, and the Pick and Place (CPL) file. All the JLCPCB default options are ok. 1 oz fill is ok. Snazz it up and change the board colour if you like. Use the SMT assembly service for the Top Side.



# For the Tinkerers
The EasyEDA files are provided. All of the unused pads are called out with headers if you want to order the PCB that way. The design is licensed under CERN-OHL-S-2.0, any improvements or modifications should be made available under the same licence. If you see any isues or have any suggestions please create a ticket on GitHub.
