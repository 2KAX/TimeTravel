Scripts liés aux controls / déplacement 

* ControllerGrabObject : script des manettes pour attraper / lancer des objets

* LaserPointer: gérer le déplacement dans la scène, ce script nécessite de mettre le layer "Floor" sur les GameObjects où le déplacement dessus est autorisé

* WhenGrabbed : classe abstraite appellée par ControllerGrabObject pour activer des effets quand on grab ou release un objet

* New_ZoneManager : Gère les zones

Scripts liés aux objets de la scène : 

* Cassette : Ce script crée la classe Cassette qui regroupe toutes les informations nécessaires de la cassette. (PS : les cassettes dans la scène sont appellés K7...)

* Drawer_constraint : Permet de restreindre le déplacement du tiroir sur un axe horizontal

* Dynamite (dérive de WhenGrabbbed) : Ce script gère la classe Dynamite et les méthodes liées à cette classe.

* Fracturable :  Cette classe fracturable gère la fracture du GameObject, principalement à l'aide de la classe Dynamite

* PlayingSynthesizer : gérer le synthétiseur

* tiroir : script du tiroir magique pour avoir les objets entre plusieurs scènes

* New_Walkman : Ce script est à placer sur le Walkman, il sert à gérer les interactions du walkman avec les cassettes qui seront mises dedans grâce au Controller. Dès que la cassette est mise dans le Walkman, on joue la musique qui est associé à la cassette si la musique qui est jouée est la bonne il y a un changement de temporalité.
