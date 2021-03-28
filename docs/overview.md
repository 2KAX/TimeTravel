# Vue d'ensemble

## Le scénario

Version courte qui met l'accent sur les interactions du jeu, pour la version longue, se référer au rapport `G1 - Time Travel 2019.pdf` section 2 "Présentation de l'application"

Le joueur est d'abord dans la temporalité années '80.

* Son soi futur l'invite à venir voir les dégâts de la pollution:  il joue la cassette avec le walkman pour se téléporter dans le futur.

* Il joue une musique western sur le synthétiseur, qui fait apparaître une cassette.
On utilise cette cassette pour se téléporter dans la temporalité Western.

* Le joueur détruit un mur fissuré avec de la dynamite. Il trouve la clé du coffre-fort. Il retourne dans le futur pour trouver la cassette années '80.

* Il place la cassette non-rembobinée dans le tiroir inter-dimensionnel, et retourne dans le western. Il la rembobine avec un crayon, place la clé dans le tiroir et se téléporte dans les années '80.

* Il récupère la clé, ouvre le coffre, prend la graine et la plante .

  **NB**: L'animation du coffre est dans les assets, mais pas implémentée, le coffre juste disparait

* Il peut aller dans le futur voir des arbres, une fois qu'il a planté la graine.

## La scène

Le jeu se déroule dans 3 époques différentes: Western, années '80 et années 2050 futuriste.

Une scène est présente pour chaque environnement. Il y a de plus une scène finale pour le futur corrigé, mais elle ne fait pas véritablement partie du jeu, elle est purement scénaristique.

_Sun_Lamp_ s'applique partout puisque c'est une lumière directionnelle.
_[CameraRig]_ et _[SteamVR]_ proviennent de SteamVR.

Enfin on a le _walkman_ qui sera téléporté avec le joueur.

Le choix du design est de faire tout à la main dans l'esprit de la game jam.

## Notions sur les scripts

### Les trois époques

Chaque époque est dans une scène différente.


Les différentes époques sont modélisées et gérées par la classe `ZoneManager`. Il est attaché au walkman.
On y définit la classe Zone ainsi:

```cs
enum Zone { A, B, C }
```

`Zone.A` correspond au Western, `Zone.B` aux années '80, et `Zone.C` au futur.

Ce script expose les fonctions `GoToX` qui permettent de téléporter le joueur et certains objets dans les différentes temporalités.

### Commentaires

Les commentaires de la forme `// 2 -` ont été ajoutés par le deuxième groupe de projet (2020). À cause du coronavirus, nous n'avons pas eu le temps de faire grand chose.

Ce format de commentaires n'a pas été suivi l'année d'après (2021).

## Comportements et fonctionalités

Dans cette section, on décrit le comportement de certains scripts essentiels au scénario. Pour la description complète de chaque script, se référer au document scripts.md.

### Joueur
#### Déplacements

On utilise la téléportation pour se déplacer. Elle est implémentée dans LaserPointer. On utilise un cube aplati pour le laser.

**IDEA**: Utiliser un arc au lieu d'une ligne droite pour sélectionner l'endroit où se téléporter car cela permet d'avoir plus de précision lorsqu'on essaye de se déplacer loin. Si on est en ligne droite on a un petit angle de travail. Avec un arc, on peut compenser. cf. Le déplacement dans les démos SteamVR.

#### Grab

Implémenté dans ControllerGrabObject, on attache l'objet au controlleur sur l'appui d'un bouton.

On utilise une boite de collision devant le contrôleur qui est "trigger" lorsqu'il entre en collision avec un rigidbody. On attache alors l'objet à notre contrôleur.

### Mécaniques du jeu

#### Walkman et cassettes

Le walkman entre en collision avec la cassette. Celle-ci entre dans le walkman, et la musique est jouée. On ne peut pas la jouer deux fois de suite. La première fois qu'on essaye de jouer la cassette, on est téléporté devant le tiroir. Sans doute pour que la téléportation se passe bien ?

Les fonction ZoneManager.GoToX sont appelées par l'évènement onMusicChange de chaque cassette.

**TODO**: Fadeout lorsqu'on utilise une cassette

**TODO?**: Bruit de cassette abîmé pour les mauvaises.

#### Synthétiseur

Lorsqu'on touche le synthé pour la première fois, il joue la première note de la musique. Il faut finir la mélodie en posant ses mains sur le piano pour que la cassette apparaisse. La musique se met en pause lorsque le joueur ne touche plus le synthé, avant de reprendre où il s'est arrêté lorsqu'il touche à nouveau le synthé. Il reste possible de jouer de la musique même lorsqu'on a déjà fait apparaître la cassette une fois, ce qui est logique car l'instrument de musique est toujours là, on peut donc la jouer en boucle même si c'est inutile.

#### Destruction du mur avec de la dynamite

Le script Dynamite prend en charge l'animation et la réapparition de la dynamite. Il déclenche aussi la fracturation du mur. La mèche commence à brûler lorsqu'on attrape la dynamite.
La fracturation du mur est implémentée dans Fracturable. Il va ajouter une force sur les morceaux, et détruire le tout dès qu'il touche le sol.

#### Tiroir inter-dimensionnel

Le script tiroir expose une fonction qui permet de récupérer ses enfants pour les déplacer lorsqu'on change d'époque.

Le script 80s/Drawer_constraint restreint la position du tiroir selon l'axe X jusqu'à une position d'arrêt. Il est uniquement appliqué sur le tiroir des années '80.

**IDEA**: On peut sans doute le généraliser pour appliquer les contraintes sur les autres tiroirs. Une autre option est d'utiliser un joint personnalisé: <https://gamedev.stackexchange.com/questions/129659/how-do-i-configure-a-joint-for-a-sliding-door-in-unity>

#### Rembobinage au crayon

L'interaction marche, **TODO** : trouver un moyen de la mettre plus en valeur, pour que le joueur sache qu'il faut faire ça.

#### Ouverture du coffre

**TODO**: rajouter l'animation d'ouverture du coffre quand la clé est insérée.

#### Planter la graine

Quand la graine est approché du pot, elle se déplace dedans et la partie verte de la graine dépasse du pot pour montrer qu'elle a été plantée, tout ça grâce au script
PlanterGraine.

### Autres choses

**TODO?**: Écran de fin de jeu à améliorer.

---

## Fichiers de test qui peuvent être ignorés (et supprimés)

* ViveControllerInputTest

Pour les codes mis en commentaire, et les commentaires, à vous de juger.
