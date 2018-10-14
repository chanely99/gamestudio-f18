# Game Studio Unity Workshop 1: Intro to the Unity Editor

# Resources

* [Download Unity](https://unity3d.com/get-unity/download)
* [Screencast of last year's workshop](https://www.youtube.com/watch?v=GqUyJ3tX6ew&t=6s)
* [Unity Official Reference](https://docs.unity3d.com/Manual/index.html)

# Workshop Content
 *Unity Editor UI
 *Creating Objects
 *Writing a Basic PlayerController and CameraController

## Setting up Unity
#### 1. Download Unity [here](https://unity3d.com/get-unity/download)
#### 2. After opening, select 'new'
#### 3. Type "Rollerball" under Project name
#### 4. Select 3D, then click on 'Create project'

## The Unity Editor
> <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/editor.png" width=800>
### Scene View(Blue)
This window lets you see what you're creating in Unity. Through the scene view, you can select and edit game objects in the scene. 

### Game View and Console(Orange)
This lets you see how your scene will play out when you press play. You can also change this windo to show the Console by selecting the Console tab. The console will show errors and warnings upon compiling your game's scripts. You can also use the console to print statements for debugging. 
 
### File System(Red)
Under this window you can see the files you currently have in this project. You can (and should) also create folders to organize the scripts, scenes, gameobjects, artwork, and other assets your project uses. 

### Hierarchy(Green)
Under this window you can see the objects in this specific scene. As we have just created this project, there's only the main camera and directional light, and by clicking on them in the hierarchy, you can see more details in the inspector(outlined in pink)

### Moving Around
Hold right-click, and use the WASD keys to move forwards, left, backwards, and right, respectively. You can also use Q key to move down, and the E key to move up. Clicking F while selecting a gameobject will let you focus on it. You can also hold the right keys and move your mouse to rotate the camera. 

## Manipulating GameObjects and making the arena

### The "Floor"
First we want to create an "arena" for our rollerball game. To do this, we can use the default gameobjects Unity provides us with. Click on the Create tab under the Hierarchy, then on the pop-up click on 3D Object->Plane. After clicking, the plane should pop up in your scene view. 

#### Move tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/move.png" width=20> or press the W key. This will let you move gameobjects you select. If you have other gameobjects in the scene, holding v will allow you to select corners of the object and snap to vertices of other objects in the scene. You can specify the location in the Inspector. 
#### Rotate tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/rotate.png" width=20> or press the E key. This will let ou rotate the object along an X, Y, and Z axis. You can select and pull the lines around the gameobject, or specify the values in the Inspector. 
#### Scale tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/scale.png" width=20> or press the R key. This will let you change the scale of the object in the X, Y, and Z direction. You can also specify the values in the Inspector. 

### The "Walls"
Using the above tools, we can construct the walls for our rollerball's arena. If you moved your plane, make sure it is at position (0, 0, 0).Click on the Create tab, then on the pop up click on 3D Object-> Cube. Repeat this three times, then enter these values for each: 
..* pos = (5.25, 0.5, 0), scale = (0.5, 1, 11)
..* pos = (-5.25, 0.5, 0), scale = (0.5, 1, 11)
..* pos = (0, 0.5, 5.25), scale = (10, 1, 0.5)
..* pos = (0, 0.5, -5.25), scale = (10, 1, 0.5)

### The "Arena"
Technically, we could end this section and leave the arena as it is. But that means we have a plane and 4 cubes cluttering the Hierarchy. This is how chaos wins, and we can't have that. We can fit these objects into a single object we can call arena. Click on Create, then on Create Empty. An Empty is just a gameobject with nothing in it. Double-click on the empty (it should be called GameObject in the hierarchy), then rename it "Arena". Then you can drag your plane and cubes to go under the Arena object like so: 

<img src= "fillthisin"" width=100>

We can also reset the position of the arena by going into its inspector, clicking on the gear to the right, and clicking on "transform".

### Components and GameObjects
So we've been calling the things we make in the game GameObjects, but haven't really discussed what they are yet. But that's what they are - the things we make in the game. This includes the actual "objects" like our arena, but also things like lights, cameras, and special effects. 

Components are, well, components, of GameObjects. These are the different things we see in the GameObject's inspector, including the Transform(position, rotation, and scale). We can also add more interesting components like rigidbodies, colliders, and audio. 

## Creating the Player and PlayerController Script
Note before we go on: Coding is definitely not needed to use Unity but it makes some things a bit easier to do when you’re starting out. We don't expect anyone here to know how to code at all, so if you're worried at that well make things really easy and we’ll go slow. If you're not that interested in coding just bear with us and we'll get to the fun stuff after. 

### Materials
We can add color to our scene with materials. Create one by clicking Create(the one under the Files, not under the hierarchy), then "Material". This will create a new Material for us. In the inspector, click on the white box with next to a dropper icon. This will open up a color window where you can choose whatever color you want for your material. Click on the Material in the Files window to rename it "Arena". To use your material, simply drag it into the scene and onto whatever gameobject you want to recolor. 

### The Player
First adjust the camera to have pos = (0, 6, -6), rot = (50, 0, 0) so we can better see the arena in our game view. Or adjust it however you want, it's a free country. 

Create a sphere (Create-> 3D Object -> Sphere), and rename it "Player". Set its position to (0, 0.5, 0). Go into the Inspector for Player, and press "Add Component" at the bottom of the window. Type in "rigidbody", and select it when it pops up. 

### Rigidbodies
By adding a rigidbody to an object, we let it experience physics. This means the object can be pulled down by gravity, and react to collisions(if there's also a Collider). Without the Rigidbody, gameobjects won't be able to move.

###Programming Terms
So we are going to code a bit for our PlayerController Script, so here are some terms used in programming: 

variable: like a variable in math, but can hold values other than just numbers. In C#, the language Unity uses, the variable's type and name have to be declared.

float: a value that can have a fractional value(i.e. 2.34, 7.92, 6.44). 
### PlayerController Script
Under the File Manager, click Create -> C# Script. Rename the script "PlayerController", and double click it to launch the code editor. This will be Visual Studio if you have a Windows, or MonoDevelop if you have a mac. The code should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
```
The important parts of this script that we're going to focus on is the Start and Update methods. Any code inside the brackets after "void Start" will be called once and immediately after the scene is played. Any code inside the brackets after "void Update" will be called every frame while the game is playing.

```cs
	RequireComponent(typeof(Rigidbody));

``` 
## Moving the Camera

## Pickups
