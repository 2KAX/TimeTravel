﻿using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] GameObject effect;
    [SerializeField] float offset = 0f;

    [SerializeField] messagemanager messageScript;

    //　表示させるメッセージ
    private string message = "Bonjour à toi, moi du passé ! J’ai toujours rêvé de dire ça. . .bref !\n"
            + " Ne t’inquiète pas, je ne suis pas venu te tuer, mais pour demander ton aide.\n<>"
            + "Vois-tu, notre espèce n’a plus la chance de vivre aux côtés d’arbres, ou ne serait-ce que d’un brin d’herbe.\n<>"
            + "Je m’attendais à ce que tu me dévisages, mais sache que mon corps a été victime de radiations, et non pas d’une modélisation lowpoly hasardeuse.\n<>"
            + " Malgré de nombreux signaux d’alarme, vous n’avez pas été capables de nous sauver du réchauffement climatique et la pollution nous intoxique et nous asphyxie, à tel point que notre espèce est vouée à s’éteindre d’ici quelques années.<>"
            + "Mais tu peux changer notre funeste destin en ramenant les arbres dans notre époque.<>"
            + "Cette aventure te mènera à travers différents âges et époques, entre lesquels tu pourras voyager grâce à Boris, ton fidèle walkman et différentes cassettes audios.<>"
            + "Utilise donc celle-ci qui t’amènera à notre époque pour constater les dégâts."
            + "Nous comptons sur moi, euh sur toi, Détective!";
 
    public void Begin()
    {
        Instantiate(effect, transform.position + new Vector3(0f, offset, 0f), Quaternion.identity);
        Instantiate(character);
        messageScript.SetMessagePanel(message);
    }
}
