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

* PlayingSynthesizer : gérer le synthétiseur

* PlanterGraine : permet de planter la graine dans les années 80 et de se tp à la fin du jeu, réagit au nom "Graine" de l'objet qui déclanche le trigger

* tiroir : script du tiroir magique pour avoir les objets entre plusieurs scènes

* Walkman : Ce script est à placer sur le Walkman, il sert à gérer les interactions du walkman avec les cassettes qui seront mises dedans grâce au Controller. Dès que la cassette est mise dans le Walkman, on joue la musique qui est associé à la cassette si la musique qui est jouée est la bonne il y a un changement de temporalité.


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

# PlayingSynthesizer.cs

Manages the interactions with the Synthesizer playing the defined song and making the cassette appear for the player.

## Attached to

Synthesizer prefab

## Parameters

- RightHand : A reference to the RightHand collider (not associated)
- LeftHand : A reference to the LeftHand collider (not associated)
- TimeLimit : 
- FirstNote : AudioClip for the first note
- Melody : AudioClip for the complete melody
- Cassette : A reference to the Cassette script in the scene, can be easily changed to the GameObject instead.
- Walkman : A reference to the Walkman's AudioSource component

## Explanation

The interaction uses the Collider associated with the Synthesizer prefab, if the Player Hands touch it twice within a time limit a song is played and a cassette appears, otherwise he needs to start again.



