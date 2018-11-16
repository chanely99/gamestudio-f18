# Game Studio Unity Workshop 4: First Person Shooter

# Resources
* [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
* [Completed Project for Download](https://drive.google.com/open?id=1DDbZW6zNVywCeoTdGrQyeDfDG2MthJ5Q)
* [Standard Assets Download](https://drive.google.com/open?id=1GciTrxEXrEegq-WkGEAXiA3dF-6rzgc6)

# Workshop Content
* Level Creation Review
* FPS Controller script
* Enemy Controller script

# Setting Up
Today's game is an entirely new kind of game, so we're going to create a new game from scratch. Just like in the first workshop, we can create a new game by opening up Unity, then selecting New Game. Remember to check 3D, and name our game First Person Shooter. 

Now that we are in an empty void again, we can import standard assets like we did in the second workshop to make prototyping our game easier. Do this by goint to assets -> import package -> characters, then assets -> import package -> prototyping. 

You can also download Standard assets using [this link](https://drive.google.com/open?id=1GciTrxEXrEegq-WkGEAXiA3dF-6rzgc6)

# Creating our Level
Just like before, we can make a game quickly using the assets we imported. Before we start, though, remember that we've been trying to keep all the gameobjects in our level under one empty gameobject for better organization. Under the Hierarchy go to Create -> Create Empty, then rename it "level". 

Next, go to Standard Assets ->Prototyping->Prefabs and select FloorPrototype64x1x64. Drag it into the Hierarchy to be a child of level. Next, drag in WallPrototype08x08x01. Scale it so that it's a good-enough looking wall, then duplicate it 3 times to create more. Move and rotate these duplicates so that we have a proper arena for our fps. For reference, my walls were scaled at (11,8,4) and ended up looking like this: 

<img src ="https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/sexybox.png" width=500>

So far, we've been using the gameobject assets in from the standard assets package. But it also comes with really easy to use scripts as well. We're going to use the firstperson controller that comes with our character's standard assets. Download the character standard assets by going to Assets -> Import Package -> Characters and importing it. There should now be a Characters folder in the Standard Assets folder. 

# The FPS controller
Sometimes you don't need to reinvent the wheel while making your game, so instead of writing our own scripts to control the player from scratch, we can just use code someone else wrote for us. The FPS controller conveniently comes with a script, rigidbody, and camera. It comes with a few basic utilities, like moving around with the mouse, jumping, and running. All we need to add is an actual gameobject so we can see where it is. First go into Prefabs and drag the FPSController prefab in our Hierarchy. Next, use  Create->3D->Capsule to create a capsule, then make it a child of the the fps controller and reset its position to (0,0,0). We can delete the main camera from the Hierarchy, since the fps controller has a camera attached to it.

We can also take the time to make our scene a bit nicer-looking. Feel free to drag in and move things as you like, but I'm going to use a CubePrototype02x02x02 and 4 RampPrototype04x02x02's leading to the cube. Remember that we can move things uniformly by holding down Ctrl(Cmd on mac), or snapping objects by holding down v. 

For reference, my scene looks like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/levelwithramp.png" width=500>

Because I like ramps+cube configuration I made, I can make it into a prefab so we can use it over again. Remember that we can do this by making an empty game object named "Ramps", dragging the ramps to be under this gameobject, then dragging the gameobject into our project window. 

<img src ="https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/sadpyramidprefab.png" width=500>

# What We Do in the Shadows 
Now if we click play and walk around our scene, notice how nothing has any shadows, even though we have light in our scene. Being able to cast shadows is controlled by the mesh renderer of the gameobjects, and by default our walls don't. Simply select the floors and walls in our scenes, and in the Inspector go to mesh renderer -> lighting, then select "cast shadows"After doing this, things will look normal again :)

# Creating our Gun
### The Gun
A third of "First Person Shooter" is shooter, so we should have a gun for our player to shoot out of. Under our first person character, create an empty gameobject called gun. Then, create a cube with Create -> 3D Object -> Cube. Change its scale to (.2,.2,.5) and make it a child of the gun and make sure its position is reset. Change the gun's position to be (.86, .23, 1.08). 

### The Crosshair
Most FPS shooters come with a crosshair in the midldle of the screen so players know where they're aiming. As you probably guessed, this is a job for Unity's UI. It's just gonna be a green square in the middle of our screen. Create a UI image by going to Create -> UI Object -> image. Change the color to green by clicking on the box next to "Color" in the inspector, and using the color window that pops up. Remember that for UI, we need to specify where each component is exactly, or else it may be different on different screens. We can make sure our crosshair is in the middle by first clicking on the target-looking box in Rect Transform. This should pop up: 

<img  src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/anchorsaweigh.png" width=500>

Notice that it tells us we can hold Shift to set pivot, and Alt to set position. We want to set the position to the middle, so hold alt, and then click the box in the middle. If we look in our game view, the box should have snapped to the middle of the screen, and if we adjust the size of our view, it will stay in the center like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/dontbecrosshair.png" width=500>

It's kind of big for a crosshair, so change the width and height to both be 5. 

### The Bullet
We can make a bullet by going to Create -> 3D -> Sphere, then scaling it down to (.1, .1, .1). Make it a child of our gun, and adjust it to be somewhere near the end of our gun. Since our bullet should always come out from here we should make this position a spawn point. Create an empty gameobject called BulletSpawnPoint, and make its position the position you liked your bullet. 

### Shooting Script
We want to add a script to control how we shoot. Create a new Script with Create -> C# Script, and rename it "Shooting" and attach it to the FirstPersonCharacter. Open it up in your code editr. 

We can delete the Start Method. After "MonoBehavior {" and before the Update method, add: 
```cs
public GameObject projectile;
public Transform bulletSpawn;
```

These two variables will hold the bullet and bullet's spawn point. 

In the Update Method, add: 
```cs
if(Input.GetButtonDown("Fire1"))
	{
    	Rigidbody clone;
        clone = Instantiate(projectile.GetComponent<Rigidbody>(), bulletSpawn.position, bulletSpawn.rotation);
        clone.velocity = transform.TransformDirection(Vector3.forward * 50);
    }

```

This first checks if the player has "Fire1" pressed down. Now you may be thinking "my keyboard doesn't have a button that says Fire1", and you're correct. We can designate a button to be considered Fire1 in Unity by going to Edit-> Project Settings -> Input. This will open up the Input manager, and we will find that Unity treats the left click as "Fire1". 

After checking that our player has clicked their mouse, our script is going to create a clone object, and set it to Instantiate(lotsofwords). The Instantiate method in Unity is used to <ADD MORE>. We then set a velocity for our bullet, so it's immediately flying in the direction we want. 

Now that our script is done, we just need to add a few more things. We need to add a rigidbody to our bullet by selecting the bullet, then in the Inspector go to Add Component, and typing in "rigidbody". We need to add this because our script is looking for a Rigidbody. Add the script to our FPS Controller. Then, drag the Bullet prefab and BulletSpawnPoint into their respective slots. It should look like this: 

<img src = "https://github.com/chanely99/gamestudio-f18/blob/master/workshop-4-FPS-tutorial/shootinginspector.png" width=500>

# Bullet Script
Notice how the bullet's not disappearing. If we just keep on shooting, we could end up with a TON of bullets. We can change this by making our bullet destroy itself anytime it hits a wall. 

Create a script with Create -> C# Script and naming it "Bullet". After opening it up in your code editor, delete the Start and Update Methods, and add: 
```cs
private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
```
This function will be triggered if the bullet hits anything with a collider, and destroy the bullet. Save and exit the script, and add it to your bullet prefab. When you push Play though, nothing pops up!

This is because our player has a collider too, and the bullet's OnCollisionEnter is instantly getting triggered. To fix this, we can add a check with: 

```cs
private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
```

That way we can first check that we're not triggered by something tagged "Player" (! means not in C#). We also need to add a tag to our player by selecting our Player, then going to Add Tag -> Player.

# Enemies
It's no fun shooting randomly at things, all good FPS games have enemies to shoot at. We create a Basic enemy with Create -> 3D Object -> Capsule. Go to the Inspector and add a Rigidbody with Add Component -> Rigidbody. Then under Rigidbody make its mass 50, then select Contraints and check off X, Y, and Z for Freeze Rotation. 

### EnemyController Script
Create an EnemyController Script with Create -> C# Script, and attach it to the enemy we've created. Then, open it up in your code editor. After "MonoBehavior{" and before the Start method, add these variables: 
```cs
private Rigidbody rb;
private float time = 0;
public float speed = 5;
```
The first variable will hold the enemy's Rigidbody so our script can do things with/to it. The second variable is a counter. We're going to use it so that we can change what the enemy does over time. The third variable is the speed we want the enemy to move at, which we can play around with since it's a public variable. 

In the Start Method, add: 
```cs
rb = this.gameObject.GetComponent<Rigidbody>();
```

This will assign the Rigidbody to be the one attached to the enemy. 

In the Update method add: 
```cs
if(time<2)
    {
       rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
    }
else if(2<time && time<4)
    {
    	rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }
else
    {
  		time = 0;
    }
time += Time.deltaTime;
```
This is quite a bit of code, but not terribly complicated. First it's going to check if the time variable is less than 2. If so, it's going to move right. Otherwise if it's between 2 and 4, it's going to move to the left. If the time variable has passed 4, it's going to reset. "time += Time.deltatime" will increase the time variable by 1 each second. This script will make the enemy move back and forth, in a 4 second cycle. 

We also want to have the enemies die if they get hit by a projectile. To make this happen, we just need to add: 
```cs
private int health = 50; 
```
 after the other variables. This will store how much health the enemy has. 

 Next, add this to the update method: 
```cs
if(health<=0)
	{
		Destroy(this.gameObject);
	}

```
This is just going to check that if the heath is at or less than 0, then destroy the enemy if so. 

Lastly, we need to add a OnCollisionEnter method to deduct the health. Add this after the Update Method: 
```cs
private void OnCollisionEnter(Collision collision)
{
	if(collision.gameObject.CompareTag("Bullet"))
		{
        	health--;
        }
}

``` 

That finishes the EnemyController Script! Notice that we deduct the health of whatever we hit if the gameobject hitting the enemy has a "Bullet Tag". Add this tag the same way we did with the player, and we're all set!

# Scripts

BulletScript.cs
```cs
public class BulletScript : MonoBehaviour{
private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
```

Shooting.cs 
```cs
public class Shooting : MonoBehaviour {
    public GameObject projectile;
    public Transform bulletSpawn;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody clone;
            clone = Instantiate(projectile.GetComponent<Rigidbody>(), bulletSpawn.position, bulletSpawn.rotation);
            clone.velocity = transform.TransformDirection(Vector3.forward * 50);
        }
	}
}
```

EnemyController.cs
```cs
public class EnemyController : MonoBehaviour {
    private Rigidbody rb;
    private float time = 0;
    public float speed = 5;
    private int health = 50;
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update () {
        if(time<2)
        {
            rb.velocity = new Vector3(-speed, 0, 0);


        }
        else if(2<time && time<4)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            time = 0;
        }
        time += Time.deltaTime;
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












