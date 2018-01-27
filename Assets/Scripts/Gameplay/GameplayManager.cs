using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    void Start()
    {
        CreateLevel();
    }

    private void CreateLevel()
    {
        List<TileConfiguration> tileConfigurations = new List<TileConfiguration>()
        {
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[0,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[0,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[0,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[0,3]

            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,3]

            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[2,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[2,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[2,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[2,3]

            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,2]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,3]
        };

        Level level = new Level();
        level.TileConfigurations = tileConfigurations;

        // TODO send it to the level manager or something to initialize the level.
    }
}