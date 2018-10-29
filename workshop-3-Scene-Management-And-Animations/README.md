# Game Studio Unity Workshop 3: Scene Management and Animations

# Resources
* [Last Week's Workshop](https://github.com/chanely99/gamestudio-f18/tree/master/workshop-2-intro-to-Level-Design)
* [Fresh Project from Last Week](https://tinyurl.com/acm-roll-2)
* [Suspicious Link](https://imgur.com/a/5TwcMHT)
* [Scripts](https://tinyurl.com/game-scripts)

# Workshop Content
* Start Screen
* Scene Switcher Script
* Moving Platform Animation
* Rotating Powerup Animation
* Intro to Texturing

# Setting Up 
We are going to build on the same Roll-A-Ball project we've been working on the last two workshops. If you aren't caught up, but want to do the stuff in this workshop, download the project [here](https://tinyurl.com/acm-roll-2)

Quick note for those of you doing the text tutorials rather than the in-person workshops, we covered scene management in the last text tutorial, but didn't get to it in the in-person workshop. If you already make a start scene in the last tutorial, go ahead and skip this next section. 

# Scene Management
Most games we play don't start right away, there's usually a Start Screen with a big, pretty "Start" button. We can create one with the Unity UI. 

### Setting up the UI
Since we can consider each scene to be a "level", we can just make a separate scene for our Start Screen. Duplicate the scene by going into your project window, selecting the current scene, and clicking Ctrl-D. (Cmd for Mac) This will make a copy of Level 1, so go ahead and rename this copy "StartScene"

We can add a button to start the game by going to Create -> UI -> Button. If the Button isn't appearing, change the Y value to 0. Select the Button in the Hierarchy, and under it should be a Text component. Select this component, and in the Inspector change the text to "Start Game". 

Now working with UI is kinda tricky, since your game might be played on screens of different sizes. We can see this in action if you select the Maximize on Play tab at the top of your game view, then play the scene. 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/maximized.png" width=600>

As you can see, the Button doesn't scale the way we want. We can fix this by Selecting Canvas in the Hierarchy, then in the Inspector find hthe box labeled "Constant Pixel Size" next to "UI Scale Mode". Click on the box, and select "Scale with Screen Size". This makes sure that the button will scale properly. 

Also notice that we can still move the player in our start screen. We don't really want that, so just select the Player in the Hierarchy, click on the gear on the far right of the Player Controller Script component, then select "Remove Component". 

### SceneSwitcher Script
This start screen looks great and all, but right now the button does nothing. We need to create a SceneSwitcher script in order for the button to switch scenes when clicked. 

Go to your Scripts folder, create a new script with Create -> C# Script, name it "SceneSwitcher", then open it up in your code editor. 

At the top, after "using UnityEngine;", add: 
```cs
using UnityEngine.SceneManagement;
```

Like before with the UI, this lets us use methods that deal with scene management in Unity. You NEED to include this line in order to switch scenes. 

Delete the Start and Update Methods, and add: 
```cs
public void SwitchScene(string sceneName)
{
	SceneManager.LoadScene(sceneName);
}

```

This script uses the SceneManager method LoadScene to load the scene with whatever name we pass in. 

### Applying the Script
Attaching scripts to UI objects is a bit different from normal gameobjects. Select the Button in the Hierarchy, and find this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/buttonlist.png" width=600>

Select the + icon, and this will let us add our SceneSwitcher script. Drag the script from the Project Window to the box labeled "None (Object)". Then click on the box labeled "No Function", then select MonoScript -> string name. A box should appear under it. This is where we pass our argument, the name of the scene we want to switch to. Type in "Level1" (or whatever you named your first scene). 

The last thing we need to do is include our two scenes into the build. In order to use sceneManagement methods, we need to have the scenes we want to switch over to in our current build. In the Tool bar, go to File -> Build Settings. Click "Add Open Scenes" and your scene should appear in the big box under "Scenes in Build". Then switch over to your Level_1 scene, and do the same thing. If you open your Build Settings, it should look like this: 
<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/build.png" width=600>

# Animations
Unity is super cool and lets us create animations in the editor. You can also import animations you make from Blender or get off the internet as well. Today we're going to make two simple animations: a platform that moves back and forth and pickups that rotate.

To work with animations in Unity, we need to open up the Animator and Animations tabs. Do this by going to the toolbar at the top, and selecting Window->Animator and Window->Animation. Animator lets you create, view, and modify Animator Creator assets, which control when animations are supposed to happen. The Animation window lets you actually create the animation gameobjects. 

Create a new window for our animations by going to the project window, then clicking Create->Folder and name it "Animations". 

# Moving Platforms
### Set up
Go to your Standard Assets Folder->Prototyping->Prefabs and drag in a "FloorPrototype04x01x04". Rename it "Moving Platform", and add it to the end of your level like so: 

<img src= "" width=500>

Go to the Animation window and select "Create". Name this animation "Side Platform", and save it in our Animations folder. 

### The Animation Window
Animation is at its core a sequence of images that are played really fast to give the illusion of movement. We can animate things in 3D in Unity by specifying positions of objects at specified times at a specified rate. 

Before we continue, we should first learn how the animation window works. It should look like this: 

<img src= "" width=500>


Like we said before, this window lets us create individual animation clips and view them. Under the left side is a tool bar with: record, start, back, play, forwards, and end. They work the way you think, kinda like those same buttons on a tv remote. The Add Property button lets us add different animations to a single object. While we're only moving a single, square platform back and forth in this workshop, this can be useful for animating something like a player, which will have multiple parts moving in different ways.

To the right is our timeline, where we can set the times for when our key frames should happen. You can scroll in and out to see shorter or longer time intervals. We can add keyframes by right-clicking, and move them around by dragging them left and right. 

### Making the Moving Platform Animation
Click on the record button (the button with the red dot) and then move your platform 5 units to the right. Remember you can move one unit at a time by holding down the Ctrl key (Cmd on Mac) while moving. Now we can add another keyframe by right-clicking at the two second mark in the timeline, and clicking Add key like so: 

<img src= "" width=500>

Next, move the platform back 5 units to the left. Add another key frame at the 4 second mark in your timeline. Your timeline window should look like this: 

<img src= "" width=500>

Exit record mode by hitting the record button again. We can now see our animation by entering play mode. WoW it's way too fast. Luckily we can change the speed in the Animator window. 

### The Animator Window
When you open up the Animator Window, it should look like this: 

<img src= "" width=500>

Thre are two main sections: the main gridded layout area, and the Layers and Parameters window to the left. 

The layout area lets us create, arrange, and connect states in the Animator Controller. States contain individual animation sequences that will play when the character is in that state. For example, if you were animating a human model, you could have a state for when they're idle, a state for when they fight, and a state for when they're eating waffles. In the Animator Controller, you can control when these animations are played. When we made our Side Platform animation, Unity also added the states "Any State" and "Entry", and an arrow pointing from Entry to Side Platform. "Any State" is a special state that's always active. Entry is active at the start of the scene. The arrow between "Entry" and "Side Platform" means that Side Platform begins when the player enters the scene. 

The Layers and Parameters windows aren't really relevant to this workshop, but they let you get into more detail about controlling your animations. If you want, learn more about it [here](https://docs.unity3d.com/Manual/AnimatorWindow.html).

We can leave the Entry state pointing at our Side window state, since we want the platform to be constantly moving back and forth. All we really need to do is select the Side Platform State, then go to the Inspector and change Speed to .3. This will make the platform move at a better rate. 

### PlatformContainer
There's one last thing we need to do for our animation. Right now, if we duplicated the gameobject, no matter where we put it, it'll snap back to the original location of where we first animated it. 

To fix this, we can just create an empty game object in the scene, called PlatformContainer. Remember that we also used empties to hold groups of gameobjects together so we had fewer things in our Hierarchy. Same thing here. Reset the PlatformController's position by clicking the gear icon to the right of Transform, then clicking "Reset". Click and drag your moving platform to become a child of PlatformContainer by letting it go on top of PlatformContainer in the hierarchy. Now if we move the container, the animation will move as well. For future reference, it would probably be better style to animate an object at the origin, which we can do for our pickup animations. 

# Rotating Pickups
### Set Up
Let's do this by dragging the pickup prefab into our scene, and resetting its position to the origin. Just like with our moving platform, we want to make an empty to hold the animation so that we can move it around later. Create an empty named "FloatingPickup" and reset its position as well. Make the pickup a child of FloatingPickup.

### Making the Animation
Like before, click the "Create" button in our Animation window, and name the new animation "Pickup". We want to make our powerup move up and down and rotate. We

# Texturing
We've previously mentioned using assets from the internet in your game. The Unity editor comes with the Asset Store built in so we can get assets directly into our game. Go to the Asset Store window by clicking the tab next to the Scene View, or by going to the Toolbar and selecting Window->Asset Store. 

There's a LOT of assets here, and feel free to explore. For this workshop, search for "free architectural textures", and select the first option. It should look like [this](https://assetstore.unity.com/packages/2d/textures-materials/free-architectural-textures-23834)

# Common Issues
//Will add more after workshop//
### "Add Property" grayed out in Animation window
This means that your animation isn't attached to your gameobject, so it doesn't know what it's animating. Just drag the the animator from the Project window to the gameobject you want to add it to in the Hierarchy.














