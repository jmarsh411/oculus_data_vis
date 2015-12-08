# oculus_data_vis
3D data visualization on the Oculus Rift - a Wayne State University Fall 2015 senior project

To run this project you will need to use Unity 5.2.1 from the following link:
https://unity3d.com/get-unity/download/archive
Newer versions of Unity are currently not compatible.

You will also need to download and install the Oculus Runtime 0.7 from the following link:
https://developer.oculus.com/downloads/pc/0.7.0.0-beta/Oculus_Runtime_for_Windows/
Newer versions of the runtime have not been tested.

Make sure that your system meets the recommended specs:
- NVIDIA GTX 970 / AMD 290 equivalent or greater
- Intel i5-4590 equivalent or greater
- 8GB+ RAM
- Compatible HDMI 1.3 video output
- 2x USB 3.0 ports
- Windows 7 SP1 or newer, plus the DirectX platform update

and setup the Oculus Rift following the official documentation at
https://developer.oculus.com/documentation/pcsdk/latest/concepts/book-intro/

You may also have to open the oculus configuration utility before attempting the view the visualization, as the oculus service often crashes, and this will restart it.

NOTE FOR AMD USERS: We experienced an issue after updating to AMD's Radeon Software Crimson Edition Display Driver version 15.30.1025
This update caused our previously working visualization to cause graphical glitches followed by a Windows bluescreen and a reboot. This version of AMD's display driver should be avoided for the purposes of running this project.
