using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

    public static Game current;
    public GameConstant trackingGame;

    public Game() //Keeps track of stuff between scenes for us. Will have to use "Game.current = new Game();" when exiting title screen so this all tracks.
    {
        trackingGame = new GameConstant();
    }

}
