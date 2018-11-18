# Game Studio Unity Workshop 5: First Person Shooter Part 2

# Resources
* [Last Week's Completed FPS Project](https://drive.google.com/open?id=1DDbZW6zNVywCeoTdGrQyeDfDG2MthJ5Q)
* [Standard Assets Download](https://drive.google.com/open?id=1GciTrxEXrEegq-WkGEAXiA3dF-6rzgc6)
* [Unity Official Documentation](https://docs.unity3d.com/Manual/index.html)

# Workshop Content workshop-5-FPS-tutorial-pt2
* Adding Terrain
* Day/night system
* Gamecontroller and Spawning Enemies

# Cool Non-Workshop Studio Announcements
Before you keep reading, just wanted to plug a few cool things we're doing this quarter. We're going to have a competition for the best game by the end of the quarter using the concepts you've picked up from these tutorials(and any that you've learned on your own). Winners will get Steam gift cards!!! 

Next week, we'll be working in 2D, which is something we haven't done yet, but very, very similar to 3D, and you don't need to have gone to previous workshops. 

We will also likely have a fun gaming social near the end of the quarter, and have the chance to get your butt kicked by me in Smash Ultimate. Well, only really if you're missing a thumb. Otherwise you'll have the chance to crush me, which is also reportedly fun. 

# Setting Up
This workshop is going to be building off last week's, so if you missed it, or want a clean slate to work with, the link to download a complete version is in the Resources section. Press play, and test your player so it works as expected. 

This week we'll be working with the environmental pack, so like with the other packs go to Assets -> Import Package -> Environment. Then, create a new scene by going to Project Window, then Create -> Scene. Rename this scene "Terrain", and enter. 

# Intro to Terrains
In Terrain, first remove the main camera. Next, we want to add a new "terrain" using Create -> 3D Object -> Terrain. This giant white plane will appear in your scene: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/lameterrain.png" width = 500>

So what is a terrain? It's a special object Unity uses for rendering large scenes. On very large maps, even powerful computers would struggle to load and render all textures and maintain a high frame rate. The terrain element in Unity allows for easy customization of many attributes of a scene, such as how far out to render objects, level of detail to render and other settings to create pretty, and fast scenes easily. It's also useful to create things like hills, textures, and grasses within Unity. 

You may have noticed that Unity running slower than usual after adding the terrain. This is because it's trying to generate a lighint map every time something changes on the terrain, which takes a LOT of power. Since we're editing the scene, we can turn this off by going to window -> Lighting -> Settings, then un-checking the "Auto Generate" checkbox: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/nolightpls.png" width = 500>

In the same window, we can add fog to improve depth perception and make our scene cooler. Check off the box next to Fog under Other Settings, and make sure the density is .01 and mode is "Exponential Squared". You can also change the fog to whatever color you want. 

# Editing the Terrain
As it is, the terrain is really big and kind of hard to edit. We can change this by going to Terrain -> Settings in the Inspector, and changing the terrain width to 100, length to 100, and height to 50. 

We also want to add walls to the Terrain so the player can't fall off. Create a cube with Create -> 3D Object -> Cube, then change the scale to (100,10,1). Make 4 of these walls, and move/rotate them so they surround the terrain.

We don't really want giant white walls at the end of a nice, grassy scene though, so we can turn off the renderers of the walls, since we only need their colliders. Do this by un-checking the box next to "Mesh Renderer" in the Inspector for each wall, so it looks like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/boxterrainbutnobox.png" width = 500>

### Brushes
Brushes are kind of like paintbrushes irl, they let you "paint" the terrain with whatever features you want. In the inspector, you can edit the brush size, opacity, etc. and there's some pretty nifty shapes you can make your brush be as well. To use the brush, simply hover over the terrain, and you should see a blue circle indicating where your feature will go. Next, just click, and hold for as long as you want to add features. 

First we need to choose what texture we want to use. In the Inspector under Terrain, select the button "Edit Textures". This will open a window where you can add whatever texture you want from the environment assets we downloaded. Select "grasshillalbedo", then select "Add". This will make your terrain look like a grassy field. 

It's just a field, though. Add another texture (I chose SandAlbedo) the same way, then select the Brush tool. Click and drag your mouse across the terrain, and add a path, or your initials or something. 

Everything else in this terrain section is really up to you - feel free to play around with the options. 

### Raising/Lowering Terrain
These two buttons: <img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/raiseterrainbuttons.png" width = 60> let you make hills or valleys by raising the terrain up or down. Select the first one, and click on some point on your terrain. If you hold your mouse down, it'll raise even higher. The second button lets you specify a specific height, and is useful for making features like plateaus. For example, if I made this:

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/mountaincluster.png" width = 500>

weird cluster of mountains with the first button, I can use the second button to turn it into this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/plateau.png" width = 500>

By changing the brush size and adding different textures, you can also add neat-looking things like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/cooltexture.png" width = 500>

### Adding Trees
The fourth button will let you add trees. First, select the kind of tree you want to place down by clicking on Edit Trees -> Add Tree. Click on the black circle next to the empty prefab box, and choose your favorite. Now, if you click on your terrain with this option, it'll place trees in the blue area. You can adjust the radius with the Brush Size bar, and how tall the trees are with the Tree Height bar. 

You may be wondering how Unity is able to render our super-realistic trees without using too much power and time. Our models are speedtrees, which is a fast way for Unity to render trees by rendering them as flat objects that just face the camera, rather than a complete 3d one. 

### Adding Grass
The sixth button is the "Paint Details" button, and we'll use it to add grass in our scene. Just like with Trees and the textures, we can specify what grass we want to add by clicking Edit Details -> Add Grass Texture. Now we can paint the grass with our brush like with the other details. Feel free to play around with different kinds of brushes and see what you like. 

# Fixing the Environment
We've been doing this all in the editor - let's see what actually happens when we play the scene. Drag in your FPS Controller into the scene, then press play. The grass is pretty cool and moving, but the trees are static, and the lighting is pretty bad and mostly dark. That's because we turned off lighting in the beginning of this workshop. Once you're satisfied with editing the terrain, go back to Window -> Lighting -> Settings, and check the box next to "Auto Generated". As a warning, this will take a bit more time to load, so don't worry if it does. 

To fix the trees, we can add a "Wind Zone" component to the terrain by going the Inspector -> Add Component -> Wind Zone. The default wind is quite a lot, so turn it down. I set mine to (.2, .1, .1, .01). 

You can also add water by first creating a depression to fill with water, then adding Standard Assets -> Environment -> Water -> Water -> WaterProDaytime to the depression and sizing it so it fits. For reference, mine looked like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-5-FPS-tutorial-pt2/water.png" width = 500>

# DayCycler
You may have noticed that every time we create a new scene, it always comes with a Main Camera, and a Directional Light. Light is handled in several different ways in Unity([here](https://docs.unity3d.com/Manual/Lighting.html) to learn more). Directional light is usually used for a sunlight effect, since it represents really large, infinitely far sources of light. Because the distance between the source and our scene isn't defined, the light doesn't fade or change. 

If you live on earth, you probably know that daylight changes when the earth moves around the sun. We can mimic this effect by rotating the directional light. Create a C# script named DayCycler, and add it to the Directional Light in the scene. Open it up in your text editor

After MonoBehavior and before the Start method, add: 
```cs
public int dayLengthSeconds = 120;
private float initX;
```
The first variable will hold how long we want our "day" to be. The second will hold the initial x component of the rotation of our light. 

Inside the Start Method, add: 
```cs
initX = this.transform.rotation.x;
```
This stores the x component of the rotation of the light at the start of the scene. 

Inside the Update Method, add: 
```cs
this.transform.rotation = Quaternion.Euler(initX + (360*Time.time)/dayLengthSeconds, this.transform.rotation.y, this.transform.rotation.z);
```
Wow that's long. But not terribly complicated. It's just changing the rotation to have a value that's the same for the y and z components, and changing the initial x component by just a bit. 

# GameController
In creating games, it's usually good to have a central "GameController" script that can handle interaction between different elements of the game. That way, our game works even if we don't have a specific gameObject with a script we need it's no problem. 

We want our gamecontroller to be able to spawn enemies for us to kill. Create an empty gameObject in our scene and name it GameController. Add a C# script called GameController to it, and open it up in your code editor. 

Before the Start Method, add: 
```cs
public GameObject player;
public GameObject enemy;
public int maxEnemies;
public Transform[] spawnPositions;
private int enemyCount;
private List<GameObject> enemies;
```

Since the GameController controls the game, there's a lot of variables to keep track of things. Player, Enemy, enemyCount, and maxEnemies are pretty intuitive. SpawnPositions is a transform array, which is basically a container of different transforms, or specific locations. Enemies is a List of GameObjects, which is basically like an array, but with some more functionalities we'll be using in the rest of the gameController script.

Inside the Start Method, add: 
```cs
enemies = new List<GameObject>();
```

This creates our enemies List at the start of our scene. 

Inside the Update method, add: 
```cs
if(enemyCount < maxEnemies) {
	SpawnEnemy();
}
for(int i = enemies.Count -1; i >=0; i--) {
	if(enemies[i] == null) {
		enemies.RemoveAt(i);
		enemyCount--;
	}
}
```
The first if statement will spawn a new enemy if the curent number of enemies in the scene is fewer than the maximum number of enemies we allow. 

The second part of this code is a for loop. For loops are used in programming to repeat an action multiple times. The condition of the for loop is "int i = enemies.Count -1; i >=0; i--". The first part creates an integer i, which is initially the number of enemies in the scene - 1. We need to subtract 1 because in programming, arrays start counting at 1, so enemies[0] is the first object in the array, enemies[1] the second, and so on. The second part checks if the i integer is greater than or equal to 0. If not, the third part decreases i by one at the end of each cycle. We can expect this for loop to run enemies.Count times. 

Inside the for loop, our code is checking if the value at the ith entry of enemies is null or not. If so, that means an enemy was killed by the player, and needs to be removed from our enemies array. That's exactly what the rest of our code does. 

After the Update Method, add the SpawnEnemy method: 
```cs
void SpawnEnemy() {
	Transform spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];
	GameObject e = Instantiate(enemy, spawnPos);
	enemies.Add(e);
	e.GetComponent<EnemyController>().AddPlayerPos(player.transform);
	enemyCount++;
}
```
Remember that this method is called by our GameController to create an enemy if the current number of enemies is less than the maximum number of enemies we want. It first chooses the position to spawn the enemy from by choosing a random entry in the spawnPositions array. Next, it creates a GameObject e, with the Instantiate method. Instantiate is how we can create objects in our game, and we're pass it enemy, which is our enemy prefab, and spawnPos, the position we want to spawn it at. The next line adds this newly created gameObject to our enemies array. Then, it tells the enemy where the player is by using Enemy's AddPlayerPos method and passing in player.transform, the current location of the player. Finally, it increases enemyCount. 

# Update EnemyController
We want our enemy to follow our player, and to do that we need to update our Enemy to have a function AddPlayerPos so it knows where the player is, and change the Update Method to move the enemy towards the player instead of back and forth. 

Add this to the the other variables of EnemyController: 
```cs
public Transform playerPos; 
```

Add this AddPlayerPos method: 
```cs
public void AddPlayerPos(Transform pos) {
        playerPos = pos;
    }
``` 

This is a pretty simple function, that takes in a Transform named pos, and sets the playerPos variable to be pos. 

Change the Update Method to this: 
```cs
if (playerPos != null) {
	Vector3 diffPos = Vector3.Normalize(playerPos.position - this.transform.position);
	rb.AddForce(speed * new Vector3(diffPos.x, 0, diffPos.z));
}
if(health<=0)
{
	Destroy(this.gameObject);
}
```

This first checks that the playerPos isn't null, since trying to access parts of a null variable leads to sadness. If not, it then creaets a vector in the direction of the player. Then, it adds the vector as a force to the enemy's rigidbody rb. 

# Final Touches
That's it for new/updating scripts. Create 3 empty gameObjects named SpawnPos, and add it to the slots of the spawnPositions array in the GameController. Set maxEnemies to 3 (or 300 if you're particularly bold), the EnemyController speed to 500, and the EnemyController's physics material to "Metal", just so it slides better. 

Yay!

# Scripts
DayCycler.cs
```cs
public class DayCycler : MonoBehaviour {
	public int dayLengthSeconds = 120;
	private float initX;
	void Start(){
		initX = this.transform.rotation.x;
	}
	void Update(){
		this.transform.rotation = Quaternion.Euler(initX + (360*Time.time)/dayLengthSeconds, this.transform.rotation.y, this.transform.rotation.z);
	}
}
```

GameController.cs
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public int maxEnemies;
    public Transform[] spawnPositions;

    private int enemyCount;
    private List<GameObject> enemies;
	// Use this for initialization
	void Start () {
        enemies = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyCount < maxEnemies) {
            SpawnEnemy();
        }
        for(int i = enemies.Count -1; i >=0; i--) {
            if(enemies[i] == null) {
                enemies.RemoveAt(i);
                enemyCount--;
            }
        }
	}
    void SpawnEnemy() {
        Transform spawnPos = spawnPositions[Random.Range(0, spawnPositions.Length)];
        GameObject e = Instantiate(enemy, spawnPos);
        enemies.Add(e);
        e.GetComponent<EnemyController>().AddPlayerPos(player.transform);
        enemyCount++;
    }
}
```

EnemyController.cs (updated)
```cs
public class EnemyController : MonoBehaviour {
    private Rigidbody rb;
    private float time = 0;
    public float speed = 5;
    private int health = 50;
    public Transform playerPos; 

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    public void AddPlayerPos(Transform pos) {
        playerPos = pos;
    }

    void Update () {
        if (playerPos != null) {
            Vector3 diffPos = Vector3.Normalize(playerPos.position - this.transform.position);
            rb.AddForce(speed * new Vector3(diffPos.x, 0, diffPos.z));
        }
        if(health<=0)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }
}
```















