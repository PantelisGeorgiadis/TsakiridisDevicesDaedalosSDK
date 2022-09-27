# Tsakiridis Devices Daedalos SDK
This repo contains core functionality needed to create applications for the [Tsakiridis Devices Deadalos](http://www.tsakiridis-devices.com/test_evaluation_daedalos.html) audio tube meter/tester.

With the Deadalos device, enthusiasts could test line and power tubes. The device tests the tube filaments, anode and cathode over current, current leakage and measures transconductance (gm), in five different operating points of the tube. Daedalos helps in finding out whether a tube is worn out, or can cause damage to the device that is intended to be used. Finally, Daedalos could be used to easily match tubes.

The SDK contains the required code to communicate with a Tsakiridis Devices Deadalos device and perform and export tube test measurements. It also includes a sample application that demonstrates the SDK functionalities. 

This SDK is used as the basis of the official Tsakiridis Devices Daedalos companion application, that can be downloaded from [here](http://www.tsakiridis-devices.com/software/tsakiridis_devices_daedalos_v1.2.0.zip).

### Build
![build main](https://github.com/PantelisGeorgiadis/TsakiridisDevicesDaedalosSDK/workflows/build/badge.svg?branch=master)

	Open the `TsakiridisDevicesDaedalos.sln` file in Microsoft Visual Studio.
	Press `Build Solution` (or F6) to build the solution.
	Press `Start` (or F5) to run `TsakiridisDevicesDaedalos` sample project.

### Use
Currently, there is no emulator for the Deadalos device. A real device is needed to develop and test applications. Please contact [Tsakiridis Devices](http://www.tsakiridis-devices.com/contact.html) to discuss on how to acquire one. 

Follow the code found in the provided sample to build your custom Deadalos companion application!

### License
Tsakiridis Devices Daedalos SDK is released under the MIT License.
