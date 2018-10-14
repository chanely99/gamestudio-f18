# Game Studio Unity Workshop 1: Intro to the Unity Editor

# Resources

* [Download Unity](https://unity3d.com/get-unity/download)
* [Screencast of last year's workshop](https://www.youtube.com/watch?v=GqUyJ3tX6ew&t=6s)
* [Unity Official Reference](https://docs.unity3d.com/Manual/index.html)

# Workshop Content
 *fill this in
 *fill this in
 *fill this in

## Setting up Unity
#### 1. Download Unity [here](https://unity3d.com/get-unity/download)
#### 2. After opening, select 'new'
#### 3. Type "Rollerball" under Project name
#### 4. Select 3D, then click on 'Create project'

## The Unity Editor
> <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/editor.png" width=400>
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
Select > <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/move.png" width=20> or press the W key. This will let you move gameobjects you select. If you have other gameobjects in the scene, holding v will allow you to select corners of the object and snap to vertices of other objects in the scene. You can specify the location in the Inspector. 
#### Rotate tool
Select > <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/rotate.png" width=20> or press the E key. This will let ou rotate the object along an X, Y, and Z axis. You can select and pull the lines around the gameobject, or specify the values in the Inspector. 
#### Scale tool
Select > <img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-1-intro-to-Unity-Editor/scale.png" width=20> or press the R key. This will let you change the scale of the object in the X, Y, and Z direction. You can also specify the values in the Inspector. 

### The "Walls"
Using the above tools, we can construct the walls for our rollerball's arena. If you moved your plane, make sure it is at position (0, 0, 0).Click on the Create tab, then on the pop up click on 3D Object-> Cube. Repeat this three times, then enter these values for each: 
..* pos = (5.25, 0.5, 0), scale = (0.5, 1, 11)
..* pos = (-5.25, 0.5, 0), scale = (0.5, 1, 11)
..* pos = (0, 0.5, 5.25), scale = (10, 1, 0.5)
..* pos = (0, 0.5, -5.25), scale = (10, 1, 0.5)

### The "Arena"
Technically, we could end this section and leave the 

### Components and GameObjects
So we've been calling the things we make in the game GameObjects, but haven't really discussed what they are yet. But that's what they are - the things we make in the game. This includes the actual "objects" like our arena, but also things like lights, cameras, and special effects. 

Components are, well, components, of GameObjects. These are the different things we see in the GameObject's inspector, including the Transform(position, rotation, and scale). We can also add more interesting components like rigidbodies, colliders, and audio. 

### Creating the Player and PlayerController Script
