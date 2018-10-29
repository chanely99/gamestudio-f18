# Game Studio Unity Workshop 3: Scene Management and Animations

# Resources
* [Last Week's Workshop]
* [Fresh Project from Last Week](https://tinyurl.com/acm-roll-2)
* [Last Week's Workshop]
* [Suspicious Link](https://imgur.com/a/5TwcMHT)
* [Scripts](https://tinyurl.com/game-scripts)

# Workshop Content

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
Go to your Standard Assets Folder->Prototyping->Prefabs and drag in a "FloorPrototype04x01x04". Rename it "Moving Platform", and add it to the end of your level like so: 

<img src= "" width=500>

Go to the Animation window and select "Create"

# Rotating Pickups

#Texturing
