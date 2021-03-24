Scripts liés aux controls / déplacement 

* ControllerGrabObject : script des manettes pour attraper / lancer des objets

* LaserPointer: gérer le déplacement dans la scène, ce script nécessite de mettre le layer "Floor" sur les GameObjects où le déplacement dessus est autorisé

* WhenGrabbed : classe abstraite appellée par ControllerGrabObject pour activer des effets quand on grab ou release un objet

* ZoneManager : Gère les zones

Scripts liés aux objets de la scène : 

* Cassette : Ce script crée la classe Cassette qui regroupe toutes les informations nécessaires de la cassette. (PS : les cassettes dans la scène sont appellés K7...)

* Drawer_constraint : Permet de restreindre le déplacement du tiroir sur un axe horizontal

* Dynamite (dérive de WhenGrabbbed) : Ce script gère la classe Dynamite et les méthodes liées à cette classe.

* Fracturable :  Cette classe fracturable gère la fracture du GameObject, principalement à l'aide de la classe Dynamite

* PenCassette.cs : Permet d'activer la cassette du futur avec le crayon à papier en la rembobinant par derrière

* PlayingSynthesizer : gérer le synthétiseur

* PlanterGraine : permet de planter la graine dans les années 80 et de se tp à la fin du jeu, réagit au nom "Graine" de l'objet qui déclanche le trigger

* tiroir : script du tiroir magique pour avoir les objets entre plusieurs scènes

* Walkman : Ce script est à placer sur le Walkman, il sert à gérer les interactions du walkman avec les cassettes qui seront mises dedans grâce au Controller. Dès que la cassette est mise dans le Walkman, on joue la musique qui est associé à la cassette si la musique qui est jouée est la bonne il y a un changement de temporalité.

* messagemanager.cs : script which display the conversation of the introduction.

* managedissolve.cs : script which change the value of property of the dissolve shader.

* introtrigger.cs : scripte let appear the futur detective.

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

# Cassette.cs (DEPRECATED)

Ce script crée la classe Cassette qui regroupe toutes les informations nécessaires de la cassette. (Not that helpful)

Apparently this script isn't necessary anymore

## Attached to 

All K7 objects

## Parameters

- ac : An Audio Clip to be played
- onMusicChange : Apparently a function to be executed (doesn't seem to be set)
- autresCassettes : A list of other cassette (What does it do? Sometimes it is filled, sometimes not)
- Zm : Reference to the ZoneManager
- tiroirs : A reference to the drawer objects (that have an tiroir script attached)
- isSelected : Apparently indicates if the cassette object is selected or not
- asource : reference to the audio source that will play the audio clip

## Explanation

If the cassette object collides with the walkman and if it is selected (What does it means to be selected?)
If it's the first time plays the audio and calls the function associated with onMusicChange
If not, teleports all cassettes in autresCassettes to the drawer

changeCassette() - Teleports the user to the drawer

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
# Pencassette.cs

Manages the interaction between futureK7 and pen

## Attached to

Both triggers of K7FUTURE

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

- Timer : can be used to stop the music if the player isn't fast enough to play the whole music, and used to know if the first note was already played or isn't finished
- TimerMusic : used to know if we have played the whole music or not
- TimeLimit : must be longer than the first note, can be used with Timer to make this this task more difficult
- FirstNote : AudioClip for the first note
- Melody : AudioClip for the complete melody
- Cassette : A reference to the GameObject Cassette in the scene.
- asr : AudioSource associated to the synthesizer

## Explanation

The interaction uses the Collider associated with the Synthesizer prefab, if the Player Hands touch it twice within a time limit a song is played and a cassette appears, otherwise he needs to start again.
The Synthesizer must have a Collider and a RigidBody component, and the player's hands able to do the task must have the tag "Player" and a trigger collider, otherwise nothing happens.

# tiroir.cs

Manages the utility of the drawer.
When the player teleports between the different times, it follows keeping everything that is inside.

## Attached to

drawer, drawer80s, drawer2050 and drawer2050 (from the green future).
Also found references in the K7farWest, the K7future and the Kyrick1998queen_2050.
We can probably remove the references in the K7 with the removal of the Cassette.cs script.

## Parameters

- autresTiroirs : A list of all the other drawers
- Zm : A reference to the zoneManager.
- ZoneTiroir : The zone the drawer corresponds to.

## Explanation

Teleports all the hierarchical children of the correspondent drawer to the new zone.

# TurnCamera.cs

Debug script to use the joysticks to turn the camera.

## Attached to

Controller (left) and Controller (right) from the CameraRig

## Parameters

- HandType : Right or Left Hand
- TurnSensitivity : The speed with which to turn the camera

# ZoneManager.cs

class that manages the movement between the different scenes,keeing the attached object.

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


# introtrigger.cs

inherited from WhenGrabbed.
Make the avatar appear when you first touch the walkman.

## Atached to 

Walkman prefab

## Parameters

-isFirst : check if the first touch to walkman
-dis : class for trigger the effect of show up



# Singleton.cs

## Attached to

Object that you only want to appear once in the game

## Parametre

-existsInstance : check if the object is already in the scene or not



