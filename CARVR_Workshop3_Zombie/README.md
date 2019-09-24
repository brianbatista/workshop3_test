

1. Creating the main menu.
    1. Open the empty "Menu" scene (Project window -> "Scenes" folder -> "Menu")
    2. In that empty scene, create a Canvas for our UI (Hierarchy -> right click -> UI -> Canvas)
    3. blah, TODO: finish this

    1. 

1. Creating the main menu.
    1. Open the empty "Menu" scene (Project window -> "Scenes" folder -> "Menu")
    2. In that empty scene, create a Canvas for our UI(Hierarchy -> right click -> UI -> Canvas)
    3. After creating the Canvas, you'll also have added to your Hierarchy an "Event Manager". Do NOT delete this, since it controls the entire UI for you.
    4. Add a Button to your Canvas as a Child. (Hierarchy -> right click -> UI -> Button)
    5. Scale the button up by using the Rect tool (press T on your Keyboard). Don't forget to scale the text up
    6. Create a Text box (Hier. -> right click -> UI -> Text) and do the same proccess as for the Button (scale the Text box and font size using Rect. tool)
    7. Your button is already interactable (you can test it on Play), so all you need to do is add the script of "What the button will do".
    8. Under Event Manager, add a new script called "Button Master".
    9. First off, create a public variable of type Gameobject called "startButton".
    10. Next, add an Awake method (void Awake) and fill it with a single line:
        1. `startButton.OnClick.AddListener("EnterGame");`

        2. This script takes the startButton (any button you assign it to on the Inspector), and when it's clicked on, it'll add a Listener on it to the event EnterGame (which we will write below).
    11. We're going to use EnterGame to change scenes, but we can't yet because we didn't assign the correct class up on "Using".
            So head to the top of the script and add under "using UnityEngine;" --> "using UnityEngine.SceneManagement;"
    12. Now, start writing EnterGame:

            ```private void EnterGame()
            {
                // We now have access to the SceneManager class because of "using UniteEngine.SceneManagement"
                SceneManager.LoadScene(1);
                // We're using LoadScene(1) because of how the scene is built in the Build Settings.
            }```

    13. Enter play mode, and try to start the game. Good luck running...
    14. You're on your own now, go get 'em, tiger!
2. Orient yourself to the project.
    1. Take a look around the ZombieScene, get to know the three main root GameObjects.
        1. Player - this is you!
        2. Environment - this is a collection of cubes and other stuff to define the walls.
        3. EventMaster - holds a script for spawning the zombies.
    2. Take a look around the assets in the Project window.
        1. We've written a few scripts, but some of them are broken! :(    (zombies ate our brains...)
        2. There is a Prefab for the zombies, but you shouldn't have to touch that...     (rotten flesh is gross)
    3. How to make progress if you're stuck:
        1. Totally lost and unsure where to start? Raise your hand, we don't bite!
        2. Unsure how to do something specific, like shoot a raycast? Google "unity <problem>", like "unity raycast", and look for links to docs.unity3d.com
2. Hope you brought your flashlight!
    1. We can't see anything, so lets add a "spot light".
    2. Somewhere buried under the Player GameObject, there is an empty "Flashlight" GameObject.
    3. Add a Light component to the Flashlight, and make sure to set Type to "Spot".
    4. Fiddle with the settings to make it seem like a real flashlight!
3. Run for your life!
    1. The Player GameObject has a "playerMove" script, open it in your IDE and take a look for what might be wrong.
    2. We already figured out how to look around, and where we *should* move, but we forgot to actually... move.
    3. Try using the *characterController* to *Move* the player.
    4. Also, our neck seems to be confused about up and down...
4. Defend yourself!
    1. We have a gun (script attached to our Player), but it's pretty useless right now.
    2. Our last few brain cells scraped together some pseudocode, but someone needs to actually implement it.
    3. Hint: we did something similar in workshop 2 (available on GitHub)
5. Hide in the safe room!
    1. Have you found the safe room with the green door? It should block access to zombies, but right now it blocks us too! Useless!
    2. The physics engine has a concept of "layers", which are different categories of objects.
    3. We already set up special layers for the player, zombies, and the door.
    4. We can control how these layers interact with **"layer-based collision detection"**...
6. Make it more *sp00ky!*
    1. What other fun game mechanics can you think of? Brainstorm with your group, and ask questions if you're not sure how to implement something. Be creative and have fun with it! 