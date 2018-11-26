# Game Studio Unity Workshop 5: First Person Shooter Part 2

# Resources
* [Assets for Today's Workshop](https://oc.unity3d.com/index.php/s/qTyIUQc2swvpFE7?_ga=2.63544873.721226498.1543123809-587483059.1535924028)
* [Unity Official Documentation](https://docs.unity3d.com/Manual/index.html)
* [Video of this workshop](https://unity3d.com/learn/tutorials/topics/2d-game-creation/project-goals?playlist=17093)

# Workshop Content 
* Setting Up 
* BirdController
* Animations Review
* GameController
* ColumnController

# Setting Up
This week we're creating a 2D game, so be sure to check off the box that says 2D before your create it. Otherwise, everything else is the same as setting up a 3D game. When you enter Unity, the editor will look basically the same, except the Scene View will be a flat area rather than a 3D space.

First thing we want to do is import the assets we'll be using for our game. Download them [here](https://oc.unity3d.com/index.php/s/qTyIUQc2swvpFE7?_ga=2.63544873.721226498.1543123809-587483059.1535924028) and add them to the game by dragging the folder into the project window. 

Once that's done, go into the Sprites folder, and select birdhero. In 2D, we use sprites, or artwork, to represent backgrounds, characters, and everything in between. Notice that after clicking on it, the inspector window looks like this: 

<img src= "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/birdheroinspector.png" width=200>

This is because our birdhero actually has 3 sprites attached to it,  which we'll need to separate for Unity. We can do this by first changing Sprite Mode from Single to Multiple, then clicking on Sprite Editor. (You'll get a warning for "Unapplied import settigs" but just ignore it) The sprite editor looks like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/spriteeditor.png" width=500>

Click on Slice, and in the window that pops up, select Slice. This'll have Unity automatically slice up sprites for us, which is very convenient. Once this is done, you should notice very faint, gray boxes around the three birds. Now if you exit the Sprite Editor, you'll notice that BirdHero now has BirdHero_0 to 3 under it. These are the individual sprites we got from our spritesheet. 

Drag BirdHero_0 into the hierarchy, and rename him bird, since he hasn't done anything yet and doesn't deserve the title of hero. Next, drag in the GrassThinSprite that's also in the Sprites folder and rename it to Ground. Make the Y position -2.5 so that the default background can't be seen. Finally, drag in the SkyTileSprite, and make it the a child of the Ground sprite so that it'll follow it around, then rename it to Sky. 

# Layers and Colliders
You may notice that the sky is in front of the ground right now, which is pretty wrong. We can fix that with Layers, which we kind of ignored in our 3D workshops, but need to use a lot more in 2D. Using Layers, we can differentiate which objects are "closer" to the camera. Default is the most bottom layer and furthest from the camera, and any that we add on will be closer. 

Click on the Layer box in the Inspector (Right next to Tag) and click "Add Layer". Add 3 new Sorting Layers called Background, Midground, and Foreground respectively, then exit out of there. Under Sprite Renderer in the Inspector, change the Sorting Layer of Bird to Foreground, Ground to Midground, and Sky to Background. 

We want Physics to work for out game, so we can do this by using Rigidbodies just like with 3D. Add a RigidBody2D (make sure it's 2D and not just RigidBody) to our bird for physics, and a Polygon Collider2D so that it can colllide with things. This is analagous to a Mesh Collider in 3D, since it follows the outline of our bird's sprite. 

Next, we can add a Box Collider2D to the ground. Notice that the collider's not actually where the ground is. Adjust it by clicking "Edit collider" under Box Collider2D in the Inspector, and adjusting the green box in the Project Window until you're happy. 

# BirdController Script
Create a new script called BirdController, and make sure it's attached to the Bird gameobject. 

Before the Start Method, add: 
```cs
private bool isDead;
private Rigidbody2D rb;
public float upForce = 200f;
```
These are kinda intuitive, just variables we're going to use. 

Inside the Start Method, add: 
```cs
isDead = false;
rb = GetComponent<Rigidbody2D>();
```
Our bird should not initially be dead or else the game would suck, and the second line will set our rb variable to be the RigidBody attached to this gameobject. 

Inside the Update Method, add: 
```cs
if (!isDead)
{
	if(Input.GetMouseButtonDown(0))
		{
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0,upForce));
		}
}
```
This makes sure that each frame, our code will check if the bird is dead. If not, it'll then check if the player has clicked their mouse. If so, it'll add a velocity going up. 

If you save the script and press play, we can move up and down. All we need to add is a check that if we hit something, we "die". 

To do this, add this function to BirdController: 
```cs
private void OnCollisionEnter2D(Collision2D collision)
{
    isDead = true;
    rb.velocity = Vector2.zero; 
}

```
We want our bird to die if it collides with anything, either the ground, or the columns. Because OnCollisionEnter is called when that happens, we can just set the isDead variable to true, then set the velocity to 0 so the bird doesn't keep moving forward. 

# Animating the Bird
Remember that we can create and control animations in Unity using the Animation tab. We want to add a Flapping, Idle, and Dead. 

First create an Animations folder in your Project  Add it with Window -> Animation. Next, select the bird in the Hierarchy, then click Create in the Animator window. Rename this new Animation "Idle". Add this new Animation to our Animations Folder. 

In the Animation window, click on Add Property -> Sprite Renderer -> "+" next to Sprite here: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/addsprite.png" width=500>

First delete the second keyframe at 1:00. That's all we need to do for Idle, so we can create our next clip, Flap, by selecting the tab labled "Idle" next to "Samples", then selecting "Create new clip" and naming this new clip Flap. 

Flap is basically the same as Idle, except we want to change to the BirdHero_1 sprite in set intervals. Go back to Idle, and copy the keyframe by selecting it with your mouse, then going to Edit -> Copy in the toolbar. Go to Flap, and go to Edit -> Paste to add the keyframe in. For this Animation, we just want it to change to the Flap sprite. Do this by going to Sprite Renderer, and changing the sprite to be BirdHero_1. 

Repeat the same process with BirdHero_2 to create the Die animation. 

Once our animations are made, we need a way to change between them. Open up the State Machine in the Animator tab. It should look like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/animator.png" width=500>

Click on the + button above "List is Empty", and add two Triggers: flap, and die. 

We now need to designate transitions. Right click the idle state to add a new transition, and drag it to Die. Click on the arrow, and in the Inspector, uncheck "Has Exit Time", since once the player is dead, it should stay dead. Under Conditions, select the + button and select die. 

We can do the same for flap. Right click the idle state to add a new transition, and drag it to Flap. But this time, we're going to keep has exit time since it'll go back to idle after running. 

All three animations consist of a single frame, each with their respective sprites like so: 
<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/idle.png" width=200><img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/flap.png" width=200><img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/die.png" width=200>
# Adding Animation to BirdController
Add this to the the other variables: 
```cs
private Animator anim;
```
This variable is going to hold the animator attached to the bird. 

Add this to the inside of Start: 
```cs
anim = GetComponent<Animator>();
```
This gets the animator attached to the bird, and assigns it to anim. 

Change the inside of the Update Method to this: 
```cs
if (!isDead)
	{
		if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0,upForce));
                anim.SetTrigger("Flap");
            }
    }

```
This will play the Flap animation  when the player clicks the mouse.

Change the inside of OnCollisionEnter Method to this: 
```cs
isDead = true;
anim.SetTrigger("Die");
```
This'll play the Die animation when the player dies. 

# Adding UI
Create a UI text with Create -> UI -> Text in the Hierarchy. Delete the EventSystem, since we don't really need it. Change the text to read "Score: ". Change the size to 32, font to luckiestguy, and allign the text to be in the center of the textbox. Set the Horizontal and Vertical Overflow to be Overflow rather than Truncate. 

We can make set the score box to always be in the corner by clicking on the target-shaped box under Rect Transform, clicking Alt, then the box in the uppper right corner. 

Copy the Score Text, and edit the copy to say "Game Over" and underneath say "Flap to Restart". Move this to the top center, and make the "Score:" text a child of Game Over. Finally, uncheck the Game Over text in the inspector so we don't see it while playing the game. 

# GameController 
Remember from the last workshop that we can have a gamecontroller to keep track of the entire game. Add an empty gameobject into the scene, and name it "GameController". Create a GameController Script, and add it to this object. 

In your code editor, we ant a way to check if the bird died, and make the GameOver text show up if so. 

Add this to the top of the script: 
```cs
using UnityEngine.UI; 
```

Add these variables before the Start Method: 
```cs
public static GameController instance; 
public Text scoreText;             
public GameObject gameOvertext;       
private int score = 0;                      
public bool gameOver = false;               
public float scrollSpeed = -1.5f;
```
These are mostly pretty intuitive, just variables we're going to use. We're including another GameController Instance in order to make sure that this is the only gamecontroller object in the scene. 

Replace the Start Method with this: 
```cs
void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy (gameObject);
    }
```
This method is how we actually check that this is the only gamecontroller object in the scene. If not, it'll destroy itself. 

Add this inside the Update Method: 
```cs
if (gameOver && Input.GetMouseButtonDown(0)) 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
```

This will reset the game if it's in the gameover screen, and if the player clicks the mouse. 

Next, add a BirdScored function: 
```cs
public void BirdScored()
    {
        if (gameOver)   
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
```
This function increments the score whenever it's called. It will first check if it's gameover. If so, we can't score, so we'll end the function early by returning. Otherwise, we'll increase the score counter, then update the UI text to be Score and the new score. 

Finally, add the BirdDied function: 
```cs
public void BirdDied()
    {
        gameOvertext.SetActive (true);
        gameOver = true;
    }
```
This function is going to be called if the bird died, so it'll "turn on" the gameover text, and set the gameOver variable to true. 


To make sure this is actually called when the bird dies, we need to call it from our BirdController Script. Open that up in your code editor, and add this to the list of variables: 
```cs
public GameController GameController; 
```
This'll make sure the Bird has access to the GameController. 

And add this to the OnCollisionEnter function: 
```cs
GameController.instance.BirdDied();
```
This'll call the BirdDied function when the Bird dies. 

# Scrolling Background
First we want to add a ribidbody2D to our ground gameobject, then set the body type to Kinematic in the inspector, since we don't want the ground to fall, just move. Next, create a Scrolling script and add it to the ground. Open it up in your code editor. 

Add these variables before the Start Method: 
```cs
public GameController GameController; 
private Rigidbody2D rb;
```
These two variables will hold a reference to our GameController and the object's rigidbody, respectively.

Add this to the inside of the Start Method: 
```cs
rb = GetComponent<Rigidbody2D>();
rb.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
```
This will assign the rb variable to be the rigidbody attached to the gameobject, and make it have a velocity with the value of the scrollspeed we assigned in the GameController. 

Add this to the inside of the Update Method: 
```cs
if (GameController.instance.gameOver )
	{
		rb.velocity = Vector2.zero;
	}
```
Each frame, the ground will check if the game is over or not. If so, it'll stop scrolling. 

# Repeat the Background
We need 2 grounds to make sure that the bird is infinitely scrolling, so select the ground in the Hierarchy, then duplicate it with CTRL-D. Then, move it to be right of the first ground.

We need a RepeatingBackground script to move the first ground to the riht of the other whenever we get past it. Create this script, and open it up in your code editor. 

Before the Start Method, add: 
```cs
private BoxCollider2D groundCollider;
private float groundLength;
```
Thse are two variables that'll hold the Collider attached to this object, and the length of the ground respectively. 

Inside the Start Method, add: 
```cs
groundCollider = GetComponent<BoxCollider2D>();
groundLength = groundCollider.size.x;
```
This will assign the two variables to be the box collider on this object, and the size of the collider. 

Inside the Update Method, add: 
```cs
if(transform.position.x < -groundLength)
	{
		Vector2 offset = new Vector2(groundLength * 2f, 0);
		ransform.position = (Vector2)transform.position + offset;
	}
```
Each frame we're going to check if the camera is past the ground. If so, it'll move the ground to be on the right side of the other ground object. 

# Adding Columns
Drag the ColumnSprite from the Sprites Folder to the Hierarchy, and set the sorting layer to be the Midground. Bring it down to be y = -4. Add a Box Collider, and edit the collider so that it's actually around the column. Duplicate it, and set the rotation to z = 180 and position y = 8. For reference, mine looks like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-6-FlappyBird/gamewithcols.png" width=500>

Make an empty gameobject called Columns, and make the two columns children of this gameobject. Because we want to move the columns with the ground, add a Rigidbody2D, and set it to kinematic so it's not affected by gravity. Also add a BoxCollider2D and set it to be in the gap between the two columns. That way, we can check if the player passes through, and increment the score. Be sure to check off IsTrigger so that the player can pass through. The last thing we need to do is create a ColumnController script to handle "respawning" the columns. Create it and open it up in your code editor. 

Before the Start Method, add these variables: 
```cs
public GameController GameController;
public GameObject columnPrefab;                            
public int columnPoolSize = 5;                                
public float spawnRate = 3f;                        
public float columnMin = -1f;                    
public float columnMax = 3.5f;                 

private GameObject[] columns;                            
private int currentColumn = 0;                                

private Vector2 objectPoolPosition = new Vector2 (-15,-25);     
private float spawnXPosition = 10f;

private float timeSinceLastSpawned;
```
There's a lot of variables here, but most of them are pretty intuitive. "columns" is an array, which if you recall is basically a list of other gameobjects. We're making a "pool" of objects, which is basically objects we're going to move to the right of the screen as soon as they pass the left side of the screen. ColumnMin and ColumnMax are the furthest up and down the columns can spawn as. 

Inside the Start Method, add: 
```cs
timeSinceLastSpawned = 0f;
columns = new GameObject[columnPoolSize];
for(int i = 0; i < columnPoolSize; i++)
	{
		columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
	}
```
Because it's the beginning of the game, the timeSinceLastSpawned will be set to 0. Next, it'll create the columns object by assigning it space in memory with the "new" keyword. The final part of this code is a for loop, which if you remember is a way to repeat commands multiple times in programming. Our loops is going to make columnPoolSize number of columns. 

Inside the Update Method, add: 
```cs
timeSinceLastSpawned += Time.deltaTime;
if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
	{   
		timeSinceLastSpawned = 0f;
		float spawnYPosition = Random.Range(columnMin, columnMax);
		columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn ++;
		if (currentColumn >= columnPoolSize) 
		{
			currentColumn = 0;
		}
	}
```
Our Update Method is first going to incrememnt the timeSinceLastSpawned by 1 each second using the built-in Time.deltaTime function. Then, it's going to check that the game isn't over, and it's time to spawn according to the spawnrate we set. 

If so, it'll reset the timeSinceLastSpawned, and generate a random y position for the column. It'll then move the column the player just passed to be just right offscreen of the player. 

Awesome. First attach this script to the GameController. Take the column object we created and drag it into our project window to make it a prefab. 

# Scripts
BirdController.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    private bool isDead;
    private Rigidbody2D rb;
    public float upForce = 200f;
    private Animator anim;
	// Use this for initialization
	void Start () {
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0,upForce));
                anim.SetTrigger("Flap");
            }
        }
	}
	private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rb.velocity = Vector2.zero; 
        anim.SetTrigger("Die");
    }

}

```

GameController.cs
```cs
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameController : MonoBehaviour {
	public GameObject gameOverText;
	public bool gameOver = false;
	public Text scoreText; 
	private int score = 0; 
	public float scrollspeed = -1.5f; 
	public static GameController instance; 

	void Awake () {
		if (instance ==null)
		{
			instance = this;
		}
		else if (instance!=this)
		{
			Destroy(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void BirdDied()
	{
		gameOverText.SetActive(true);
		gameOver = true;
	}

	public void BirdScored()
	{
		if (gameOver)   
			return;
		score++;
		scoreText.text = "Score: " + score.ToString();
	}

	public void BirdDied()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}
```

Scrolling.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {
	public GameController GameController; 
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
	}

	// Update is called once per frame
	void Update () {
		if (GameController.instance.gameOver )
		{
			rb.velocity = Vector2.zero;
		}
	}

}
```

RepeatingBackground.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundLength;
	// Use this for initialization
	void Start () {
		groundCollider = GetComponent<BoxCollider2D>();
		groundLength = groundCollider.size.x;
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.x < -groundLength)
		{
			Vector2 offset = new Vector2(groundLength * 2f, 0);
			transform.position = (Vector2)transform.position + offset;
		}
	}
}
```

ColumnPool.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

	public GameController GameController;
	public GameObject columnPrefab;                            
	public int columnPoolSize = 5;                                
	public float spawnRate = 3f;                        
	public float columnMin = -1f;                    
	public float columnMax = 3.5f;                 

	private GameObject[] columns;                            
	private int currentColumn = 0;                                

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;
		columns = new GameObject[columnPoolSize];
		for(int i = 0; i < columnPoolSize; i++)
		{
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}


	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{   
			timeSinceLastSpawned = 0f;
			float spawnYPosition = Random.Range(columnMin, columnMax);
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn ++;
			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}
		}
	}
}
```










