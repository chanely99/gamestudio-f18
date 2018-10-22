# Game Studio Unity Workshop 2: Intro to Level Design

# Resources
* [Last Week's workshop](https://github.com/uclaacm/gamestudio-f18/tree/master/workshop-1-intro-to-Unity-Editor)
* [Download Unity](https://unity3d.com/get-unity/download)
* [Screencast of last year's workshop](https://www.youtube.com/watch?v=GqUyJ3tX6ew&t=6s)
* [Unity Official Reference](https://docs.unity3d.com/Manual/index.html)

# Workshop Content
 * Bouncepad powerup
 * Powerup Counter UI
 * Start Screen
 * Scene Switcher Script

# Setting Up

Assets are files that can be used in your game or project. These include scripts, artwork, audio, and many more things to make it easier to make your game. You can make your own, or purchase them in the Unity Asset Store. Unity also comes with some default assets we will use in this workshop. 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/import.png" width=800>

(A)Select Assets -> Import Package -> Prototyping. (B)Click on it, and an Import window should pop up. Select Import, and Unity will import the assets for you. (This will take a bit, don't worry) (C)Once downloaded, a folder labeled "Standard Assets" will pop up in your project window. 

#Creating our Level

First, we want to make our player a prefab. Remember that we make gameobjects that we want to reuse into prefabs, or templates. Do that by going into the Hierarchy, clicking on the player, then dragging and dropping it into your Prefabs folder. 

We then can make a new scene for our workshop by going to Create -> Scene. (the one under the Project Window, not the Hierarchy) Rename this scene BetterScene, and double click it to enter. We should have a new, empty scene to work with. 

We can start making our level with the assets we just imported In your Project window, go to Standard Assets -> Prototyping -> Prefabs -> FloorPrototype04x01x04. Be sure that you got the floor from the Prefabs folder, not the Models folder, since the one in the Models folder will not have a collider, and the player will just fall through. Drag that into your level. Next, go to the Prefabs folder, and drag our Player into the scene. 

Go to the Hierarchy and select the Main Camera. In the Inspector, select Add Component, and type in CameraController. Add this to the Main Camera by pressing Enter, then like before, click and drag the Player from the Hierarchy to the box labeled "None (Transform)". Move and Rotate the Camera until you're happy with where it is. (Don't remember how to move objects? Click [here](https://github.com/uclaacm/gamestudio-f18/tree/master/workshop-1-intro-to-Unity-Editor#manipulating-gameobjects-and-making-the-arena) )

Add two more of the FloorPrototype04x01x04 into the scene in the forward direction. To check which way is forward, just click Play, then move forward. Remember you can(and should) move using the X, Y, and Z arrows. You can also select and snap to vertices by holding down v to select the vertex, and moving it near other gameobjects in the scene. When moving objects with the arrows, you can also hold down the Control button(Command on Mac) to move unit by unit. 

Since we're going to make a jump powerup, let's make a wall for our player to overcome. Go into Standard Assets -> Prefabs and select CubePrototype04x04x04, and drag it into our scene. Move it to the end of your level, and hold down v when moving it so it can snap to your floor. Go into Standard Assets -> Prefabs and select FloorPrototype08x01x08 and drag it into your scene as well, and move it to the top of the wall. Your scene should now look like this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/levelscene.png" width=800>

# Bounce Pad

### Making the Bounce Pad
Let's create our super jump powerup. Under Hierarchy, select Create -> 3D Object -> Plane. Drag it into the scene on the floor in front of the player. Double click on it in the Hierarchy, and rename it to "Bounce Pad". Like with our Player and Powerup, we will probably want to use more than one of these, so we should make it a prefab too. Click and drag it into our Prefabs folder.

Next, we can make make give it color with a Material. Remember that we can make a material by selecting Create -> Material in the Project Window. Rename this Material "super jump", make sure it's in the Materials folder, then make it whatever color you want. (Click [here](https://github.com/uclaacm/gamestudio-f18/tree/master/workshop-1-intro-to-Unity-Editor#materials) if you forgot how) Add the Material to the Bounce Pad by dragging and dropping it onto the Bounce Pad. 

### Bounce Pad Script
Before we go into our Bounce script, let's review PickupController from last workshop. The code for that script looks like: 

```cs
public class PickupController : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")){
			Destroy(this.gameObject);
		}
	}
}
```
We're going to basically use the same logic, but instead of destroying the bounce pad when the player touches it, we want to make our ball jump up high. 

So let's actually write the script. Like before, go into the scripts folder, then create a new script by clicking on Create -> C# Script. Rename the script Bounce, and double click it to launch Visual Studio or MonoDevelop. Delete the Start and Update methods, and replace them with: 

```cs
public float bouncePower = 15;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddForce(this.transform.up * bouncePower, ForceMode.Impulse);
        }
    }
```

Really similar to the pickupController script, right? The only difference here is in the if statement, where instead of destroying the gameObject, we have: 

```cs
Rigidbody rb = other.GetComponent<Rigidbody>();
rb.AddForce(this.transform.up * bouncePower, ForceMode.Impulse);
```

The first line, if you remember from the [PlayerController script](https://github.com/uclaacm/gamestudio-f18/tree/master/workshop-1-intro-to-Unity-Editor#how-to-do-this) gets the rigidbody attached to the bouncepad, and assigns it to the variable rb. The next line uses the addForce method that comes with the rigidbody. This method takes in two variables: a vector3 and the mode of force to apply. The vector3 we use is this.transform.up * bouncepower, which is a vector that is in the direction up and with the magnitude bouncePower. The mode of force we chose is ForceMode.Impulse, which means we wnat to apply our force instantaneously. There are different forcemodes for different situations, but we want our powerup to make our ball jump up immediately, so that's why we want to use Impulse. (You can check out the other kinds of ForceModes [here](https://docs.unity3d.com/ScriptReference/ForceMode.html))

Be sure to save the script before exiting back to the editor. Be sure to add the script to the Bouncepad by clicking it in the Hierarchy, then in the Inspector Add Component -> Bounce. Then, like the pickup, we need to make it a trigger. Under the Inspector and under Mesh Collider, check the box next to Convex, then the box next to Is Trigger. We need to check the extra Convex box because the plane comes with a Mesh Collider instead of a box collider, and by checking it we make sure our collider doesn't have any holes. Remember that we clicked the Is Trigger box to make sure our pad can detect if the player passed through. 

Click Play, then roll over to the bounce pad. Your player will shoot into the air! Make your bouncepad a prefab by dragging it from the Hierarchy to the Prefabs folder, then stick as many as you want into the scene. :)

# Respawning 
The powerup is great, but the game basically ends any time the player falls off, since you're basically falling forever until we restart the game. Because we aren't terrible people, we want to fix that for our player. 

### Setting up the Boundary
What we're going to do is basically have a giant plane under the level, and whenever the player falls down and hits the plane, we want to make the player "teleport" to their original position in the level. 

Add a Plane into the scene by clicking on Create -> 3D Object -> Plane. Click on it, then in the Inspector, then uncheck the box next to Mesh Renderer. This makes the plane "disappear", but it's still there, it's just not being rendered by Unity. Like our BouncePad, we want our Respawn plane to be able to detect if a player hits it, so under Mesh Collider, check the box next to Convex, then the box next to Is Trigger. We also want to make our plane really big, so under Transform, change the Scale values to (10, 1, 10). Move the plane to under our level so it looks like this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/respawn.png" width=600>

### Respawn script
Go into our scripts folder again, and click on Create -> C# Script, and rename it RespawnController. Delete the Update Method. 

Before the Start Method, add: 
```cs
public Transform playerTransform;
private Vector3 startPosition;
```

This sets up two variables: a Transform to hold the player's position named playerTransform, and a Vector3 to hold the start position. We need the playerTransform to know what gameObject the player is, and the startPosition so we know where to respawn the player to. 

Inside the Start Method, add: 
```cs
Vector3 startPosition = playerTransform.position;
```

This assigns the startPosition variable to be the position that the player is at when the scene starts. 

After the Start Method, add: 
```cs
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.transform.position = startPosition;
            rb.angularVelocity = Vector3.zero;
        }
    }
```
Remember that this function runs whenever the player runs into our respawn plane. Like the other powerups, the function checks if the gameObject that collided with it is the Player by cheking the tag. Then, it gets stores the rigidbody of the player into the variable rb. Then, it assigns the position of rb(the player) to the startposition, effectively teleporting the player to where they started. Finally, it assigns rb to have a velocity of 0, so that the player doesn't have their falling velocity when they start over. 

# Pickups Counter (yay UI!)
### Setting up the UI
For the next part of the workshop, let's work on making a simple UI to show how many pickups we've gotten. 

First, we want to make a UI text. Do this by clicking on Create -> UI -> Text. Notice that the text is under something called Canvas in the hierarchy, and that something called EventSystem appeared in the Hierarchy as well. In Unity, the Canvas is basically a skeleton object that holds all our UI objects. EventSystem handles events in a Unity scene, and can be used for more complicted things than we're covering for now. 

Move the text to the corner of the screen by setting the position to (350, 125, 0). In the Inspector, in the box under Text, change the text to "Pickups Collected"

### TextController Script
In order to update the pickup counter, we need to add a textcontroller script to our text. Create one under Scripts, and open it in your code editor. At the very top, under "using Unity Engine;", add: 
```cs
using UnityEngine.UI;
```

This line lets us use UI methods that we didn't need before. 

Before the Start Method, add: 
```cs
private Text m_text;
private GameObject[] pickups;
public int current;
public int total;
```

Wow that's a lot more variables than last time. For textController, we need to have access to the Text we're going to change, which we'll store in m_text. The second line describes an array of gameobjects named pickups. In programming, an array is a list of objects, so we're going to store all the pickups in our scene in the pickups array. The last two lines are integers that will store the current number of pickups picked up, and the total pickups in the scene. 

Inside the Start Method, add: 
```cs
m_text = GetComponent<Text>();
pickups = GameObject.FindGameObjectsWithTag("Pickup");
total = pickups.Length;
```
The first line assigns m_text to be the text component of the text this script is attached to. The second line uses the FindGameObjectsWithTag method, which finds all the objects with the tag "Pickup", and puts them into the picups array. The last line calculates the total, which is simply how big the pickups array is. 

After the Start Method and before the Update Method, add: 
```cs
void changeText(string text)
{
	m_text.text = text;
}
```
This is a function that we've made that takes in a string, and assigns our variable m_text to be that string. We put this into a separate function so it's easier to read and use later on. 

Inside the Update Method, add: 
```cs
if (current == total)
	changeText("You Won!");
else
	changeText("Pickups Collected: " + current.ToString() + '/' + total.ToString());
```

Remember that the Update method runs each frame. So that means that each frame, we're first going to check if the player has picked up all the pickups, i.e. that the current number pickups picked up is equal to the total number of pickups. If so, it will make the text "You Won!". Otherwise, the text will show how many pickups collected so far out of the total. 

### Modifying the Pickup
So for this to work, we need to first tag all our pickups, and also make sure that the current counter updates each time the player destroys one. 

First add the tag by going into the Prefabs folder, and selecting your Pickup prefab. Like with the player, select the box labeled "Untagged" in the inspector, and click on "Add Tag". The Inspector will then change to this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/addtag.png" width=600>

Select the + icon, and type in "Pickup" into "new tag", then click on "Save". Exit the Inspector, then click on the Pickup in the Prefabs folder again. Now you should be able to add the "Pickup" tag. 

For the second part, open up the PickupController script. Right now, it should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")){
			Destroy(this.gameObject);
		}
	}
}
```

Inside the if statement, add this code: 
```cs
TextController text = Object.FindObjectOfType<TextController>();
text.current += 1;
```

This code finds the textController using Unity's FindObjectOfType method since we only have one TextController in our scene. It then updates the TextController's current counter by 1. This is good since TextController has no way of knowing when the player picks up a powerup on their own. 

# Start Screen
Most games we play don't start right away, there's usually a Start Screen with a big, pretty "Start" button. We can create one with the Unity UI. 

### Setting up the UI
Since we can consider each scene to be a "level", we can just make a separate scene for our Start Screen. <DUPLICATE SCENE???>

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

The last thing we need to do is include our two scenes into the build. 

# Summary
Today we've gone over using Unity's prototyping assets, making the bounce pad powerup, creating a pickup counter, and creating a start screen. 

Your final scene should (but doesn't have to exactly) look like this: 
<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/finallevel.png" width=600>

Your start screen should (but doesn't have to exactly) look like this: 
<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-2-intro-to-Level-Design/finalstart.png" width=600>

For reference, your Bounce script should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	public float bouncePower = 15;


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.AddForce(this.transform.up * bouncePower, ForceMode.Impulse);
		}
	}
}
```

Your RespawnController script should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour {
	public Transform playerTransform;
	private Vector3 startPosition;
	private void Start()
	{
		Vector3 startPosition = playerTransform.position;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.transform.position = startPosition;
			rb.angularVelocity = Vector3.zero;
		}
	}

}
```

Your TextController script should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    private Text m_text;
    private GameObject[] pickups;
    public int current;
    public int total;
    // Use this for initialization
    void Start()
    {
        m_text = GetComponent<Text>();
        pickups = GameObject.FindGameObjectsWithTag("Pickup");
        total = pickups.Length;
    }
    void changeText(string text)
    {
        m_text.text = text;
    }
    // Update is called once per frame
    void Update()
    {
        if (current == total)
            changeText("You Won!");
        else
            changeText("Pickups Collected: " + current.ToString() + '/' + total.ToString());
    }
}
```  

Your PickupController should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")){
			TextController text = Object.FindObjectOfType<TextController>();
			text.current += 1;
			Destroy(this.gameObject);
		}
	}
}
```

Your SceneSwitcher script should look like this: 
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour {


    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
}

```






























