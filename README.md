# Why and how to use
Pool System is a design pattern where, to gain CPU efficiency and avoid the constant calls caused by Unity's Instantiate, it is worthwhile to implement this system to optimize your project if your game has many enemy or projectile spawns, for example.

Instead of making calls through Instantiate, all objects will be initialized at the beginning of the project. This component will allow you to create your own pool or a singleton, which can be called from anywhere in the project.

As mentioned above, it works for multiple replications at the same time within the scene. However, if it is for a single use, I recommend activating the Singleton variable, as it makes calling from anywhere easier.

# Tutorial
## First Step
Put "PoolSystem.cs" in a object in a scene.
## Second Step
Set the variables.
### Polled Object
Put a prefab object you want to pool in "Polled Object".
### Max Objects
Set the maximum lenght of the pool in "Max Objects".
### Time To Auto Disable
Set the time to auto disable the objet to return to pool list in "Time To Auto Disable".
### Ignore Maximum
"Ignore Maximum" is a condition to prevent errors. If you want to respect the pool's maximum quantity, disable it. However, it is enabled by default because, in most situations, you can exceed the maximum allowed. In this case, it will instantiate and destroy the excess objects.
### Is Singleton
If you want the script works like a singleton (Call from everywhere), turn on. If not, you must turn off and assign a ref script to call it.
## Third Step
To activate the objects, you simply need to call the "TakeFromPool();" function. It has three versions: just activating, or passing position and rotation as parameters.

In singleton, you call direct from script, writing PoolSystem.Instance.TakeFromPool();.
