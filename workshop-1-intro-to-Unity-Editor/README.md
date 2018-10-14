# Game Studio Unity Workshop 1: Intro to the Unity Editor

# Resources

* [Download Unity](https://unity3d.com/get-unity/download)
* [Screencast of last year's workshop](https://www.youtube.com/watch?v=GqUyJ3tX6ew&t=6s)
* [Unity Official Reference](https://docs.unity3d.com/Manual/index.html)

# Workshop Content
 * Unity Editor UI
 * Creating Objects
 * Writing a Basic PlayerController and CameraController

# Setting up Unity
1. Download Unity [here](https://unity3d.com/get-unity/download)
2. After opening, select 'new'
3. Type "Rollerball" under Project name
4. Select 3D, then click on 'Create project'

# The Unity Editor
> <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/editor.png" width=800>
### Scene View (Blue)
This window lets you see what you're creating in Unity. Through the scene view, you can select and edit game objects in the scene. 

### Game View and Console (Orange)
This lets you see how your scene will play out when you press play. You can also change this windos to show the Console by selecting the Console tab. The console will show errors and warnings upon compiling your game's scripts. You can also use the console to print statements for debugging. 
 
### Project Window (Red)
Under this window you can see the files you currently have in this project. You can (and should) also create folders to organize the scripts, scenes, gameobjects, artwork, and other assets your project uses. 

### Hierarchy (Green)
Under this window you can see a list of the objects in this specific scene. As we have just created this project, there's only the main camera and directional light, and by clicking on them in the hierarchy, you can see more details in the inspector (outlined in pink)

### Moving Around
Hold right-click, and use the WASD keys to move forwards, left, backwards, and right, respectively. You can also use Q key to move down, and the E key to move up. Clicking F while selecting a gameobject will let you focus on it. You can also hold the right keys and move your mouse to rotate the camera. 

# Manipulating GameObjects and making the arena

### The "Floor"
First we want to create an "arena" for our rollerball game. To do this, we can use the default gameobjects Unity provides us with. Click on the Create tab under the Hierarchy, then on the pop-up click on 3D Object->Plane. After clicking, the plane should pop up in your scene view. 

### Move tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/move.png" width=20> or press the W key. This will let you move gameobjects you select. If you have other gameobjects in the scene, holding v will allow you to select corners of the object and snap to vertices of other objects in the scene. You can also specify the coordinates of the object in the Inspector.

### Rotate tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/rotate.png" width=20> or press the E key. This will let ou rotate the object along an X, Y, and Z axis. You can select and pull the lines around the gameobject, or specify the values in the Inspector. 

### Scale tool
Select <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/scale.png" width=20> or press the R key. This will let you change the scale of the object in the X, Y, and Z direction. You can also specify the values in the Inspector. 

### The "Walls"
Using the above tools, we can construct the walls for our rollerball's arena. If you moved your plane, make sure it is at position (0, 0, 0).Click on the Create tab, then on the pop up click on 3D Object-> Cube. Repeat this three times, then enter these values for each: 

* pos = (5.25, 0.5, 0), scale = (0.5, 1, 11)
* pos = (-5.25, 0.5, 0), scale = (0.5, 1, 11)
* pos = (0, 0.5, 5.25), scale = (10, 1, 0.5)
* pos = (0, 0.5, -5.25), scale = (10, 1, 0.5)

### The "Arena"
Technically, we could end this section and leave the arena as it is. But that means we have a plane and 4 cubes cluttering the hierarchy. This is how chaos wins. We can fit these objects into a single object we can call Arena. Click on Create, then on Create Empty. An Empty is just a gameobject with nothing in it. Double-click on the empty (it should be called GameObject in the hierarchy), then rename it "Arena". Then you can drag your plane and cubes to go under the Arena object like so: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/arena.png" width=200>

We can also reset the position of the arena by going into its inspector, clicking on the gear to the right, and clicking on "Reset".

### Components and GameObjects
So we've been calling the things we make in the game gameobjects, but haven't really discussed what they are yet. But that's what they are - the things we make in the game. This includes the actual "objects" like our arena, but also things like lights, cameras, and special effects. 

Components are, well, components, of gameobjects. These are the different things we see in the gameobject's inspector, including the transform(position, rotation, and scale). We can also add more interesting components like rigidbodies, colliders, and audio. 

# Creating the Player and PlayerController Script
Note before we go on: Coding is definitely not needed to use Unity but it makes some things a bit easier to do when you’re starting out. We don't expect anyone here to know how to code at all, so if you're worried at that well make things really easy and we’ll go slowly. If you're not that interested in coding just bear with us and we'll get to the fun stuff after.

### Materials
We can add color to our scene with materials. Create one by clicking Create (the one under the Project Window, not under the hierarchy), then "Material". This will create a new material for us. In the inspector, click on the white box with next to a dropper icon. This will open up a color window where you can choose whatever color you want for your material. Click on the Material in the Project window to rename it "Arena". To use your material, simply drag it into the scene and onto whatever gameobject you want to recolor. Notice how if you edit your material color after an object has it, the object's color will change too. 

### The Player
To play the game, we want to be able to see our player through the main camera. Click on Main Camera in the hierarchy, and in the inspector give it the values position = (0, 6, -6), rotation = (50, 0, 0) so we can better see the arena in our game view. Or adjust it however you want, it's a free country. 

Create a sphere (Create-> 3D Object -> Sphere), and rename it "Player". Set its position to (0, 0.5, 0). Go into the Inspector for Player, and press "Add Component" at the bottom of the window. Type in "rigidbody", and select it when it pops up. 

### Rigidbodies
By adding a rigidbody to an object, we let it experience physics. This means the object can be pulled down by gravity, and react to collisions(if there's also a Collider). Without the Rigidbody, gameobjects won't be able to move.

### Tags
We can add tags to gameobjects in Unity. These are used to help identify GameObjects for scripting purposes. Click on Player, and in the Inspector, you can find this box: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/tags.png" width=200>

When you click the "Untagged" box, a dropdown menu will appear with your tag options. Select Player, and now your player will be tagged!

### Unity Programming Terms
So we are going to code a bit for our PlayerController Script, so here are some terms used in programming for Unity: 

* variable: like a variable in math, but can hold values other than just numbers. In C#, the language Unity uses, the variable's type and name have to be declared.

* private and public variables: Public variables are visible to all classes. Other classes or objects can access them. Private variables can only be used by the class they're in. Public variables can also be edited in the Unity Editor under the Inspector. 

* float: a value that can have a fractional value(i.e. 2.34, 7.92, 6.44)

* function: Basically a block of code with a name. This allows us to write blocks of code that do different things separately, which makes it easier to write and debug. You can call functions (aka run them) in other functions. 

### PlayerController Script 
Under the Project Window, click Create -> C# Script. Rename the script "PlayerController". In the hierarchy, select the Player, then in the Inspector click on Add Component then search and add the script. Double click the script under the project window to launch the code editor. This will be Visual Studio if you have a windows, or MonoDevelop if you have a mac. The code should look like this: 
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

Add this code after "usingUnityEngine;" and before "public class": 
```cs
[RequireComponent(typeof(Rigidbody))]
``` 
This will require the player to have a Rigidbody, so that we can use physics to move it around. 

Add this code to the inside of MonoBehavior and before Start:
```cs
[Range(50, 200)]
public float speed = 100; 
private Rigidbody rb = GetComponent<Rigidbody>(); 
```
The second line creates a float variable that we'll use to determine the speed of the player. The first line makes sure it's always between 50 and 200. The third line creates a variable named rb that is of the type rigidbody.

Add this code to the inside of void Start: 
```cs
rb = GetComponent<Rigidbody>(); 
	
```

This code assigns the Rigidbody attached to our player to the variable rb so we can more easily access it. 

Add this code to the inside of void Update: 
```cs
float x = Input.GetAxis("Horizontal"); 
float z = Input.GetAxis("Vertical");

rb.AddForce(new Vector3(x, 0, z) * Time.deltaTime * speed); 
```
Input.GetAxis() is a built-in method by Unity that detects whether or not the player is pressing WASD or the arrow keys. It will return a value between -1 and 1, 1 being up or right, -1 being down or left. We're creating the variables horizontal and vertical to hold these values. 

In the third line, we are creating a Vector3 variable with the x and z values being horizontal and vertical respectively. Y is zero because we don't want the player to move the ball up and down. 

The last line uses the rigidbody (remember we stored that in the variable rb) to add a force to the ball using a vector made with the x and z inputs. By multiplying this by Time.deltaTime, we make our game frame rate independent. (i.e. we make the player move x units per second rather than x units per frame). We then multiply it by our speed variable. 


## Moving the Camera
Create a new script called "CameraController" the same way we made the PlayerController. After creating it, be sure to select the camera, then AddComponent ->CameraController. Before the Start method, add: 
```cs
public Transform player; 
private Vector3 offset; 
```
A transform stores a GameObject's position, rotation, and scale. The camera will need to know the player's position so it can follow the player. 

A Vector3 is how Unity represents 3D vectors and points. If you're unfamiliar with [vectors](https://www.youtube.com/watch?v=bOIe0DIMbI8&feature=youtu.be&t=19) from math, they're just lines that have a designated length and direction. We're going to use it to specify how far away and at what angle the camera should be from the player at all times. 

Add this code to the inside of void Start: 
```cs
offset = this.transform.position - player.position;
```

This sets the offset vector to be the distance and angle the camera is away from the player at the start of the scene. 

Add this code to the inside of void Update: 
```cs
this.transform.position = player.position + offset;
```

This sets the camera's position to be the same as the player's, but weith the offset. Since it's in the Update method, it makes sure that the camera is always the same distance away from the player. 

In the editor, be sure to set the player Transform to the player's transform. Do this by clicking on the player in the hierarchy, and dragging and dropping it to the space under the CameraController in the Inspector. It should look like this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/transformCameraController.png" width=400>

# Pickups
Pickups in Unity are just gameobjects that detect if a player has touched them, then does something. Our pickup is going to destroy itself if the player touches it. 
 
### Creating the Pickups
Create a cube using Create->3D Object->Cube. Set the scale to (0.25, 0.25, 0.25), rotation to (30, 60, 30), and position to wherever you want(but reachable with your player). Double click on it in the hierarchy and rename it to pickup. Create a new material and apply it to pickup. (refer back to the [materials](https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/README.md#materials) section for how to do this)

### Colliders and Triggers
Before we continue, press play and try to go through the pickup. What happens? As you probably guessed, nothing. It's just a cube that we can run into and bounce off of. If we look at the Cube through the Inspector, we can see that it has a Box Collider. Under the Box Collider, there is a checkbox labeled Is Trigger. Check the box, and try pressing play again. 

Now the player goes through the collider. This is because now instead of being a solid object, the collider is now a Trigger Zone, which means we can write code to do something if something runs into and triggers the pickup. 


## Pickup Script
Create a new script and call it PickupController. 

This time, we can get rid of the Update and Start methods. Our collider comes with its own method that we can use to detect when something hits it. In the brackets after MonoBehavior, add this code:

```cs
private void OnTriggerEnter(Collider other) {
	if (other.CompareTag("Player")){
		Destroy(this.gameObject);
	}

```
So our function's name is OnTriggerEnter, and Unity will automatically call it for us. Inside the parentheses is Collider other, which gives us access to the info of whatever hit us, which is probably the player. 

Now the inside the function we have an if statement that's triggered by "other.CompareTag("Player"). For this to work, you'll need to have [tagged](https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/README.md#tags) the player. Remember other is a reference to whatever hit the powerup. This checks other's tag to see if it's the player. If so, it will activate the Destroy(this.gameObject), which, well, destroys this gameobject. 

## Prefabs
Now that we have what our pickup should look like and behave, we want to have multiple of them. By making it a prefab, we can make it a sort of template that we can reuse throughout our scene. In addition, if you wanted to change something about the powerup(script, size, color, etc.), by changing the prefab the changes automatically apply to all the objects in the scene. 

We can make our powerup a prefab by clicking on it in our main scene, then dragging and dropping it to the project window. It should pop up now in the project window. Now that we have it as a prefab, we can drag and drop a bunch of them into our scene. 

Like with the Arena, we don't want a bunch of cubes cluttering our hierarchy, so we can create an empty (Create ->Create Empty), and name it Pickups. 

## Cleaning up the Project Window
Like how we cleaned up the Hierarchy by placing similar gameObjects under one gameObject, we can create folders in the project window to organize things. This is a good practice, especially as you build larger and larger games. Under the project window, click Create -> Folder to create a nwe folder. Create 4 of these, and rename them "Materials", "Prefabs", "Scenes", and "Scripts". Drag the assets in the project window to their appropriate folders. 


<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/ProjectWindowClean.png" width=500>
















