# Feel The Edge

## Take Control of the Distractions, Find Your Peace!

  <img src="vr-unity/readme/poster.jpg" width="600" />  

## Introduction

Feel The Edge is an educational VR experience designed to help users deal with different distractions by simulating multiple audio and visual triggers, all while they are in a safe environment.

This experience focuses on people with **Anxiety Disorder** and **sensory hypersensitivity**, especially those sensitive to sounds and lights.

The experience is especially valuable to these users, as they can adapt to an environment filled with multiple audio and light triggers, which are usually very challenging for them. All of these triggers are introduced in a **safe environment**.

When users feel uncomfortable or reach their limit, they can change the level of distractions or stop the experience by pressing the **panic button** attached to their chest, which will suspend the experience and transport them to a comforting scene.

---

## Design Process

The Design Process started with a **brainstorming session**, where each of us tried to think of as many problems, ideas, and solutions as possible, covering various disabilities, and solutions that could be completed within the given timeframe.

<img src="vr-unity/readme/brainstorm.png" width="600" />  


Afterward, each team member presented one idea to the classroom and received feedback on which option was the most logical to proceed with.

<img src="vr-unity/readme/sketch.png" width="600" />  

Once the project idea was decided, the team discussed the project purpose and the experience itself. This discussion helped build the **Design Document**, which included a timeline for each week.

<img src="vr-unity/readme/whiteboard.jpg" width="600" />  

---

### Persona

To better understand people with sensory hypersensitivity, the team browsed through articles to learn about the challenges our target group faces in everyday life, how they feel about it, and how they cope with it.

From that, two **personas** were created from the information gathered, with the goal of addressing their needs and pain points, and making decisions and solutions based on an person who fits the target group.

#### John - Persona and User Journey Map

<img src="vr-unity/readme/JohnPersona.png" width="600" />  
<img src="vr-unity/readme/JohnJourney.png" width="600" />  

#### Emma - Persona and User Journey Map

<img src="vr-unity/readme/EmmaPersona.png" width="600" />  
<img src="vr-unity/readme/EmmaJourney.png" width="600" />  

After this process, the team identified key problems and developed solutions for how the whole experience would look. The solution is an experience designed to help users practice their stability while being distracted by objects and sounds that typically cause anxiety.

The team envisioned a **Safe Space** and Environment where users can manipulate different options and find or increase their threshold level.

---

### Classroom

This would be achieved by using a menu where the user could activate disturbing sounds, trigger lights that flicker, and control the people in the room and their movement—challenges identified as particularly problematic for these individuals.

<img src="vr-unity/readme/classroom_scene.jpg" width="600" />  
---

### Safe Space, Emergency Button, Tactile Feedback

For safety, the safe space environment is where users enter once they press the **emergency button** attached to their chest.

Users also have the option to control the **tactile feedback** they receive on their shoulders when someone approaches them in VR.

<img src="vr-unity/readme/vestonbody.png" width="600" />  



---

### User Testing

The demo version of the experience was presented and tested by several people, providing us valuable feedback to improve the experience. Based on this feedback, we adjusted our presentation of how the experience would look, as well as made minor changes to gameplay and UI elements (such as the Menu) to make the experience smoother for users.

---

## System Description

### Features

Feel The Edge includes the following features:

- A **virtual classroom environment** where users can control their surroundings, such as adjusting the level of sound, light flickering, and controlling people’s movements.
- An **easily accessible intuitive emergency button** that leads users to the Safe Space if they feel uncomfortable and wish to stop the experience.
- **Simulation of people walking near you**, where vibration motors activate when people walk close to you.

---

### Features Decisions

- Hand tracking was chosen over Controllers in order to simplify it for inexperienced users and to make it feel more natural.
- Stationary Environment was decided on in order to reduce risk of motion sickness and because enabling movement provides no benefit to the experience at the moment with current version.
- Button on chest was chosen to provide an intuitive tap out button, which can be a faster way to exit the experience when people get nervous.
- Menu panel - The menu was initially put in front of the user, and they could activate by poking the left hand. Two problems occurred during testing, one that the users would spend most of the experience with menu activated, that would cover most of the screen and ruin the experience. Another one was having difficulties to pinch effectively, without spending a lot of time on it. This becomes a problem, especially when people start to panic.
- Poke - this decision was chosen after user testing, poking feels more natural and it is easier interaction for unexperienced people. Pinch was another interaction that was tested and used at the beginning. Removing pinch and changing it to poke also makes more sense as the participants get used to poke interaction before the experience starts, and having the same interaction throughout whole experience ensures that the users are quick and comfortable.

---

#### Watch the DEMO VIDEO or try out the live version by [this GitHub Repository](https://github.com/ernestoagc/su-det-2025-group-1)

---

## Installation

To install and run "Feel The Edge", follow the instructions below.

### IOT Vest

The tactile vest used to enable the users to intuitively tap out of the experience and also feel tactile feedback is built as follows.

- The whole system is mounted onto a T-Shirt which has been opened in the back to allow size adjustment via velcro.
- The vibration motors are put on the inside of the arm pieces where they can be fixed to the arm using velcro straps.
- The ESP32 with the breadboard and wiring is set inside a pouch made out of textile on the T-Shirt.
- To allow modularity the vibration sensors and the capacitive touch sensor are detachable via connectors.

  <img src="vr-unity/readme/connectors.jpg" width="600" />

- For the intuitive tap out button the capacitive touch sensor is mounted on a soft plastic which is glued onto the T-Shirt.

  <img src="vr-unity/readme/TShirt_laidout.jpg" width="600" />


#### Components

- T-Shirt
- Velcro
- ESP32-S2 Thing Plus
- LiPo Battery 3.7 V, 1500
- 2x Vibration Motor
- Piece of copper or other conductive material (adjust capacity threshold in code to fit material)
- 2x 1k Ohm Resistor
- 2x BC547C NPN Transistor
- Breadboard small
- Various wires

#### Wiring/Schematics

  <img src="vr-unity/readme/schematics_vest.png" width="600" />

  <img src="vr-unity/readme/esp32.jpg" width="600" />


### Software

 **1. Setting Up Unity Hub** 
Download and install Unity Hub from [official page](https://unity.com/download)

**2. Installing Unity Editor and Required Modules**
In Unity Hub, go to the 'Installs' tab and click on the 'Add' button to install a new version of the Unity Editor. Select Unity Editor LTS version 2022.3.56f1
Also, during the installation setup, you should select the following options: 
- Microsoft Visual Studio IDE (for code editing). 
- Android Build Support 

![unityhub](vr-unity/readme/unity-installation.png)

**3) Configuring  Unity Project**
**a. Import the Meta XR SDK:**
- Navigate to Window > Package Manager.
- Click the '+' icon and select 'Add package by name'.
- Enter 'com.meta.xr.sdk.all' and click 'Add'. Restart Unity if prompted.

![meta-library](vr-unity/readme/unity-import-sdk.png)


**b. Build Setting Configuration:**
 - Go to File > Build Settings 
 - select 'Android' as the target platform. 
 - Click 'Switch Platform' to confirm.
 - On Scenes in Build add: startup-environment, design-environment and safety-environment 

![setting-build](vr-unity/readme/unity-build-setting.png)

To install and run Feel The Edge on your platform or device, follow the instructions below:

| **Platform** | **Device** | **Requirements**                            | **Commands**                                                                                                                                          |
| ------------ | ---------- | ------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| Windows      | Meta Quest | Unity 2022.3 or higher, Arduino             | `git clone https://github.com/user/repo.git`<br>`cd project-xr`<br>`open MainScene.unity`<br>`Build and Run`                                          |
| Android      | Phone      | Android 19 or higher, ARCore 1.18 or higher | `git clone https://github.com/user/repo.git`<br>`cd solar-system-xr`<br>`open SolarSystemXR.unity`<br>`switch platform to Android`<br>`build and run` |

You also need to install the following dependencies or libraries for your project:

- **Library A** – a Unity plugin for building VR and AR experiences
- **Library B** – a C# wrapper for speech recognition and synthesis

---

## Usage

To use Feel The Edge and interact with its features, follow the guidelines below:

1. The game is stationary and uses hand tracking. Get yourself comfortable, preferably sitting.
2. Open Feel The Edge on your VR headset.
3. Read the instructions and press the Start button using the poke gesture.
4. Once in the Classroom, start the experience by clicking the buttons on your left hand. These buttons will change the environment around you.
5. Listen and look at what's happening around you, and try to increase the level of distractions once you feel comfortable with the current level.
6. If you feel uncomfortable or wish to stop the experience, press the button on your chest to be transported to the Safe Space.

## Configuration

Both the VR Headset and the tactile IOT vest have to be connected to the same network.

---

## References

Sounds:

- https://freesound.org/s/144904/
- https://freesound.org/s/232175/
- https://freesound.org/s/43365/
- https://freesound.org/s/546033/
- https://freesound.org/s/766202/
- https://freesound.org/s/149468/
- https://freesound.org/s/610761/
- https://freesound.org/s/580685/
- https://freesound.org/s/506759/
- https://freesound.org/s/219220/
- https://freesound.org/s/377003/

3D Assets:

- https://assetstore.unity.com/packages/3d/props/interior/bedroom-interior-low-poly-assets-295074
- https://assetstore.unity.com/packages/3d/environments/school-assets-146253
- https://assetstore.unity.com/packages/3d/characters/city-people-free-samples-260446

---

## Contributors

Evgeniia Dolgikh  
evdo4579@student.su.se  
[Linkedin](https://www.linkedin.com/in/evgeniiadolgikh/)

Antonio Jerkovic  
anje7074@student.su.se  
[Linkedin](https://www.linkedin.com/in/antonio00232/)

Ernesto Galarza  
erga4586@student.su.se  
[Linkedin](https://www.linkedin.com/in/ernestoagc/)  

Florian Unger  
flun4103@student.su.se  
[Linkedin](https://www.linkedin.com/in/florian-unger-ab943a17b/)  
