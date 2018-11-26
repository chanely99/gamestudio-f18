# Game Studio Unity Workshop 5: First Person Shooter Part 2

# Resources
* [Assets for Today's Workshop](https://oc.unity3d.com/index.php/s/qTyIUQc2swvpFE7?_ga=2.63544873.721226498.1543123809-587483059.1535924028)
* [Unity Official Documentation](https://docs.unity3d.com/Manual/index.html)

# Workshop Content 
* 

# Setting Up
This week we're creating a 2D game, so be sure to check off the box that says 2D before your create it. Otherwise, everything else is the same as setting up a 3D game. When you enter Unity, the editor will look basically the same, except the Scene View will be a flat area rather than a 3D space.

First thing we want to do is import the assets we'll be using for our game. Download them [here](https://oc.unity3d.com/index.php/s/qTyIUQc2swvpFE7?_ga=2.63544873.721226498.1543123809-587483059.1535924028) and add them to the game by dragging the folder into the project window. 

Once that's done, go into the Sprites folder, and select birdhero. In 2D, we use sprites, or artwork, to represent backgrounds, characters, and everything in between. Notice that after clicking on it, the inspector window looks like this: 

<img src= birdheroinspector>

This is because our birdhero actually has 3 sprites attached to it,  which we'll need to separate for Unity. We can do this by first changing Sprite Mode from Single to Multiple, then clicking on Sprite Editor. (You'll get a warning for "Unapplied import settigs" but just ignore it) The sprite editor looks like this: 

<img src = spriteeditor>

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
<EXPLANATION>

Inside the Start Method, add: 
```cs
isDead = false;
rb = GetComponent<Rigidbody2D>();
```
<EXPLANATION>

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

If you save the script and press play, we can move up and down. All we need to add is a check that if we hit something, we "die". 

To do this, add this function to BirdController: 
```cs
private void OnCollisionEnter2D(Collision2D collision)
{
    isDead = true;
}

```
<EXPLANATION>

# Animating the Bird
Remember that we can create and control animations in Unity using the Animation tab. We want to add a Flapping, Idle, and Dead. 

First create an Animations folder in your Project  Add it with Window -> Animation. Next, select the bird in the Hierarchy, then click Create in the Animator window. Rename this new Animation "Idle". Add this new Animation to our Animations Folder. 

In the Animation window, click on Add Property -> Sprite Renderer -> "+" next to Sprite here: 

<img src = AddSprite>

First delete the second keyframe at 1:00. That's all we need to do for Idle, so we can create our next clip, Flap, by selecting the tab labled "Idle" next to "Samples", then selecting "Create new clip" and naming this new clip Flap. 

Flap is basically the same as Idle, except we want to change to the BirdHero_1 sprite in set intervals. Go back to Idle, and copy the keyframe by selecting it with your mouse, then going to Edit -> Copy in the toolbar. Go to Flap, and go to Edit -> Paste to add the keyframe in. 

# Adding Animation to BirdController
Add this to the the other variables: 
```cs
private Animator anim;
```
<EXPLANATION>
Add this to the inside of Start: 
```cs
anim = GetComponent<Animator>();
```
<EXPLANATION>
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
<EXPLANATION>
Change the inside of OnCollisionEnter Method to this: 
```cs
isDead = true;
anim.SetTrigger("Die");
```
<EXPLANATION>
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

Add this inside the Update Method: 
```cs
if (gameOver && Input.GetMouseButtonDown(0)) 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
```

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

Finally, add the BirdDied function: 
```cs
public void BirdDied()
    {
        gameOvertext.SetActive (true);
        gameOver = true;
    }
```

To make sure this is actually called when the bird dies, we need to call it from our BirdController Script. Open that up in your code editor, and add this to the list of variables: 
```cs
public GameController GameController; 
```
And add this to the OnCollisionEnter function: 
```cs
GameController.instance.BirdDied();
```
# Scrolling Background
First we want to add a ribidbody2D to our ground gameobject, then set the body type to Kinematic in the inspector, since we don't want the ground to fall, just move. Next, create a Scrolling script and add it to the ground. Open it up in your code editor. 

Add these variables before the Start Method: 
```cs
public GameController GameController; 
private Rigidbody2D rb;
```
<EXPLANATION>

Add this to the inside of the Start Method: 
```cs
rb = GetComponent<Rigidbody2D>();
rb.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
```
<EXPLANATION>

Add this to the inside of the Update Method: 
```cs
if (GameController.instance.gameOver )
	{
		rb.velocity = Vector2.zero;
	}
```
<EXPLANATION>

# Repeat the Background
We need 2 grounds to make sure that the bird is infinitely scrolling, so select the ground in the Hierarchy, then duplicate it with CTRL-D. Then, move it to be right of the first ground.

We need a RepeatingBackground script to move the first ground to the riht of the other whenever we get past it. Create this script, and open it up in your code editor. 

Before the Start Method, add: 
```cs
private BoxCollider2D groundCollider;
private float groundLength;
```
<EXPLANATION>
Inside the Start Method, add: 
```cs
groundCollider = GetComponent<BoxCollider2D>();
groundLength = groundCollider.size.x;
```
<EXPLANATION>
Inside the Update Method, add: 
```cs
if(transform.position.x < -groundLength)
	{
		RepositionBackground();
	}
```
<EXPLANATION>

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










