# ControllerGrabObject.cs

This script manages the controls and interactions the user has with the headset controllers

## Attached to

Either the Left or the Right Hand (opposite to Laser Pointer script).

## Parameters

- Movement : An action defined on SteamVR (https://sarthakghosh.medium.com/a-complete-guide-to-the-steamvr-2-0-input-system-in-unity-380e3b1b3311)
- HandType : Right or Left Hand

## Explanation

This script finds the object the hands are touching by using the a collider as trigger.
If the player holds the trigger the object becomes a child of the hand and moves with it.
If the player releases the trigger, releases the object.
Apparently all objects that have a RigidBody can be grabbed, we could maybe use a Layer or a Tag to define them?

# Dynamite.cs

It's a child of WhenGrabbed, controls the Dynamite fire and explosion animation, as well as the explosion effects on the scenem, breaking the wall.
Ce script gère la classe Dynamite et les méthodes liées à cette classe.

## Attached to

The Dynamite prefab

## Parameters

- fuseEffect : Reference to a burning effect in the particle system
- explodeOnTag : tag of the object that should trigger the explosion
- explosionEffect : Reference to an explosion effect in the particle system
- hand : Not used, maybe set by another script (To Delete?)

Grab() - Function to start the fire effect when the Dynamite is grabbed (Behavior specified by the WhenGrabbed abstract class)

# Fracturable.cs

Cette classe fracturable gère la fracture du GameObject

## Attached to 

DestructableWall prefab

## Parameters

- impulseOnFracture : vector3 defining the direction in which the fragments should fly
- onFracture : event to trigger when it breaks (It's called in the script, but not set in the prefabs. Is it set by another script or it can be deleted?)
- timeBeforDebrisDisappear : time to wait before the fragments disappear

# introtrigger.cs

inherited from WhenGrabbed.
Make the avatar appear when you first touch the walkman.

## Atached to 

Walkman prefab

## Parameters

-isFirst : check if the first touch to walkman
-dis : class for trigger the effect of show up

# LaserPointer.cs

Implements movement inside a scene by pointing.
Looks like a script provided by Valve with SteamVR. 

## Attached to

Controller(left) and Controller(right), but only active in one of them

## Parameters

- Movement : An action defined on SteamVR (https://sarthakghosh.medium.com/a-complete-guide-to-the-steamvr-2-0-input-system-in-unity-380e3b1b3311)
- HandType : Right or Left Hand
- CameraRigTransform : Transform of the CameraRig prefab
- TeleportReticlePrefab : A reference to the teleport reticle prefab (the target that is not in the scene)
- HeadTransform : A reference to the player’s head (the camera)
- TeleportReticleOffset : Is the reticle offset from the floor, so there’s no “Z-fighting” with other surfaces
- TeleportMask : A layer mask to filter the areas on which teleports are allowed
- LaserPrefab : A reference to the Laser’s prefab

# managedissolve.cs

Change the value of the dissolve shader to make the avatar appear or disappear

## Atached to 

the objects to appear or disappear

## Parameters

-rend : mesh renderer of the object
-apparait : check if the object was appeard
-isfirsttouch : Save the first touch or not
-effectObject: effect when appearing
-offset : offset of position of the effect
-messageScript: class messagemanager
-message : message to be displayed when appearing

# messagemanager.cs

Display the message box and start a monologue

## Attached to

Canvas in the scene(UI)

## Parameters
- messageText : text  for each display
- allMessage : all texts for entire conversation
- Movement : An action defined on SteamVR 
- HandType : Right or Left Hand
- splitString: string to separate the texts
- splitMessage : separated texts 
- messageNum : index for separated texts
- textSpeed: speed message
- elapsedTime
- nowTextNum: number of actual text
- clickIcon : image de clicl icon
- clickFlashTime : time for flash
- isOneMessage : check if the one separated text was displayed
- isEndMessage : check if all messages was displayed

# Pencassette.cs

Manages the interaction between futureK7 and pen

## Attached to

Both GameObject "trigger" of the tape 80's

## Parameters 

- HasBeenPenned : static variable used to know if the K7 is restored (the tag is back to normal)
- layermask : int used to stock the layer of the pen
- Rembodio : Audiosource of the sound of rewind

## Explanation

We use two trigger on the K7 to detect the pen when we try to rewind the k7 from the back. when a trigger with layer 30 (pen) is detected, we change the tag of the cassette(K7future) and change HasBeenPenned to true, so when it trigger another time it does nothing.

# PlayingSynthesizer.cs

Manages the interactions with the Synthesizer playing the defined song and making the cassette appear for the player.

## Attached to

Synthesizer prefab

## Parameters

- TimerMusic : used to know if we have played the whole music or not
- FirstNote : AudioClip for the first note
- Melody : AudioClip for the complete melody
- Cassette : A reference to the GameObject Cassette in the scene.
- asr : AudioSource associated to the synthesizer

## Explanation

The interaction uses the Collider associated with the Synthesizer prefab, if the Player Hands touch it twice within a time limit a song is played and a cassette appears, otherwise he needs to start again.
The Synthesizer must have a Collider and a RigidBody component, and the player's hands able to do the task must have the tag "Player" and a trigger collider, otherwise nothing happens.

# Singleton.cs

## Attached to

Object that you only want to appear once in the game

## Parametre

-existsInstance : check if the object is already in the scene or not

# tiroir.cs

Manages the utility of the drawer.
When the player teleports between the different times, it follows keeping everything that is inside.

## Attached to

drawer, drawer80s, drawer2050 and drawer2050 (from the green future).
Also found references in the K7farWest, the K7future, the Kyrick1998queen_2050 and the script Walkman.cs.
We can probably remove the references in the K7 with the removal of the Cassette.cs script.

## Parameters
- GoContained : A static list of GameObjects contained in the drawer 
- autresTiroirs : A list of all the other drawers
- Zm : A reference to the zoneManager.
- ZoneTiroir : The zone the drawer corresponds to.

## Explanation

Teleports all the objects contained in the drawer to the new zone by duplicating them and then destroy the first objet in order not to keep the DontDestroyOnLoad.

# TurnCamera.cs

Debug script to use the joysticks to turn the camera.

## Attached to

Controller (left) and Controller (right) from the CameraRig

## Parameters

- HandType : Right or Left Hand
- TurnSensitivity : The speed with which to turn the camera

# ZoneManager.cs

class that manages the movement between the different scenes, keeping the attached object.

## Attached to

Walkman prefab

## Parameters
-zoneActuelle : indicate the actual scene(eighties, Western, fifties ,green)
-used80: if you have already used the 80's cassette
-usedWest:if you have already used the western cassette
-usedfutur:if you have already used the western cassette

# Walkman.cs

Play the corresponding song for a few seconds and then move on to the next scene, according to the cassete you collied with.

## Attached to 

Walkman prefab

## Parameters

-zoneManager: Manage movement between scenes
-currentTape : Cassette that causes conflict with walkman
-asource : in which the song is loaded from script


