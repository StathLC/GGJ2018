using System;
using System.Collections.Generic;
using System.Linq;

namespace Levels
{
    public class Configurations
    {
        private static Random rnd = new Random();
        public static TileConfiguration[] Level1 => new[]
        {
            new TileConfiguration(top: false, bottom: false, right: true, left: false, entrance: true,
                exit: false), //[0,0]
            new TileConfiguration(top: false, bottom: true, right: false, left: true, entrance: false,
                exit: false), //[0,1]
            new TileConfiguration(top: false, bottom: false, right: false, left: false, entrance: false,
                exit: false), //[0,2]
            new TileConfiguration(top: false, bottom: true, right: false, left: false, entrance: false,
                exit: true), //[0,3]

            new TileConfiguration(top: false, bottom: false, right: false, left: false, entrance: false,
                exit: false), //[1,0]
            new TileConfiguration(top: true, bottom: true, right: false, left: false, entrance: false,
                exit: false), //[1,1]
            new TileConfiguration(top: false, bottom: false, right: false, left: false, entrance: false,
                exit: false), //[1,2]
            new TileConfiguration(top: true, bottom: true, right: false, left: false, entrance: false,
                exit: false), //[1,3]

            new TileConfiguration(top: true, bottom: true, right: true, left: true, entrance: false,
                exit: false), //[2,0]
            new TileConfiguration(top: true, bottom: false, right: false, left: true, entrance: false,
                exit: false), //[2,1]
            new TileConfiguration(top: false, bottom: false, right: false, left: false, entrance: false,
                exit: false), //[2,2]
            new TileConfiguration(top: true, bottom: true, right: false, left: false, entrance: false,
                exit: false), //[2,3]

            new TileConfiguration(top: true, bottom: false, right: true, left: false, entrance: false,
                exit: false), //[3,0]
            new TileConfiguration(top: false, bottom: false, right: true, left: true, entrance: false,
                exit: false), //[3,1]
            new TileConfiguration(top: false, bottom: false, right: true, left: true, entrance: false,
                exit: false), //[3,2]
            new TileConfiguration(top: true, bottom: false, right: true, left: true, entrance: false,
                exit: false), //[3,3]
        }.OrderBy(i => rnd.Next()).ToArray();

    

    public static TileConfiguration[] Level2 => new[]
        {
            new TileConfiguration(top:false,bottom:true,right:false,left:false,entrance:true,exit:false),//[0,0]
            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[0,1]
            new TileConfiguration(top:false,bottom:false,right:true,left:true,entrance:false,exit:false),//[0,2]
            new TileConfiguration(top:true,bottom:false,right:false,left:true,entrance:false,exit:false),//[0,3]

            new TileConfiguration(top:false,bottom:true,right:false,left:true,entrance:false,exit:false),//[1,0]
            new TileConfiguration(top:false,bottom:false,right:true,left:true,entrance:false,exit:false),//[1,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[1,2]
            new TileConfiguration(top:false,bottom:false,right:true,left:false,entrance:false,exit:true),//[1,3]

            new TileConfiguration(top:false,bottom:true,right:true,left:false,entrance:false,exit:false),//[2,0]
            new TileConfiguration(top:true,bottom:false,right:false,left:true,entrance:false,exit:false),//[2,1]
            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[2,2]
            new TileConfiguration(top:false,bottom:false,right:true,left:true,entrance:false,exit:false),//[2,3]

            new TileConfiguration(top:false,bottom:true,right:false,left:true,entrance:false,exit:false),//[3,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,2]
            new TileConfiguration(top:true,bottom:false,right:false,left:true,entrance:false,exit:false),//[3,3]
        }.OrderBy(i => rnd.Next()).ToArray();

        public static TileConfiguration[] Level3 => new[]
        {
            new TileConfiguration(top:false,bottom:true,right:false,left:false,entrance:true,exit:false),//[0,0]
            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[0,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,0]
            new TileConfiguration(top:false,bottom:true,right:false,left:true,entrance:false,exit:false),//[1,1]
            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[1,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,0]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,1]
            new TileConfiguration(top:false,bottom:true,right:false,left:true,entrance:false,exit:false),//[2,2]
            new TileConfiguration(top:true,bottom:false,right:true,left:false,entrance:false,exit:false),//[2,3]

            new TileConfiguration(top:false,bottom:true,right:false,left:false,entrance:false,exit:true),//[3,0]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,1]
            new TileConfiguration(top:true,bottom:true,right:false,left:false,entrance:false,exit:false),//[3,2]
            new TileConfiguration(top:true,bottom:false,right:false,left:true,entrance:false,exit:false),//[3,3]
        }.OrderBy(i => rnd.Next()).ToArray();

        private static IReadOnlyCollection<TileConfiguration> Default => new List<TileConfiguration>()
        {
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,0]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[0,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,0]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[1,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,0]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[2,3]

            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[3,0]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[3,1]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[3,2]
            new TileConfiguration(top:false,bottom:false,right:false,left:false,entrance:false,exit:false),//[3,3]
        }.AsReadOnly();
    }
}
