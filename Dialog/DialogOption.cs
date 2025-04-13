using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogOption
{

    /// <summary>
    /// Texte du choix 
    /// </summary>
    public string textOption;


    /// <summary>
    /// Poursuit le dialog � l'index sp�cifi�
    /// </summary>
    public string jumpToTag;

    /// <summary>
    /// mot cl� pour indiquer le choix du joueur
    /// </summary>
    public string eventReference;

    
    /// <summary>
    /// Indique que cette option est l'option de base
    /// </summary>
    public bool defaultOption;
}
