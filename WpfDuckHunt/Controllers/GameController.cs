using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Framework.WpfInterop.Input;
using WpfDuckHunt.Models;
using Microsoft.Xna.Framework.Graphics;
using System.Security.RightsManagement;
using System.Text.Json;
using System.IO;
using SharpDX.Direct3D9;
using System.Windows;
using WpfDuckHunt.Views;

namespace WpfDuckHunt.Controllers
{
    public class GameController
    {

        private static Game game = new Game();
        
        public static Game getGame()
        {
            return game;
        }

        public static int getScore()
        {
            return game.score;
        }

        public static void newGame()
        {
            game.dogActors.Clear();
            Dog dog = new Dog(x: 0, y: 320, state: EnumDogState.SNIFF, frame: 0, Animation_duration: 0);
            game.dogActors.Add(dog);
            Duck duck = new Duck(x: 240, y: 260, state: EnumDuckState.NOTHING, score: 500, FlyingDirection: EnumDuckFlyingDirection.UP, frame: 0, Animation_duration: 0);
            game.duckActors.Add(duck);
        }
        public static void updateControllers(float delta)
        {
            foreach(var dogActor in game.dogActors)
            {
                if (dogActor.State == EnumDogState.SNIFF)
                {
                    DogController.sniff(dogActor, delta);
                }
                if (dogActor.State == EnumDogState.JUMP_UP)
                {
                    DogController.jumpUp(dogActor, delta);
                }
                if (dogActor.State == EnumDogState.JUMP_DOWN)
                {
                    DogController.jumpDown(dogActor, delta);
                }
            }
            foreach(var duckActor in game.duckActors)
            {
                if(duckActor.State == EnumDuckState.RIGHTFLY)
                {
                    DuckController.flyRight(duckActor, delta);
                }
                if(duckActor.State == EnumDuckState.LEFTFLY)
                {
                    DuckController.flyLeft(duckActor, delta);
                }
            }
        }

        public static void updateActors(float delta)
        {
            ////////  DOG ACTORS  //////// 
            foreach(var dogActor in game.dogActors)
            {

                if (dogActor.State == EnumDogState.SNIFF)
                {
                    dogActor.animation_duration += delta;
                    dogActor.Frame += 8 * delta;
                    if (dogActor.Frame > 4)
                    {
                        dogActor.Frame = 0;
                    }
                    if (dogActor.animation_duration >= 4.0)
                    {
                        dogActor.animation_duration = 0;
                        dogActor.State = EnumDogState.SNIFF1;
                    }
                }

                if (dogActor.State == EnumDogState.SNIFF1)
                {
                    dogActor.animation_duration += delta;
                    dogActor.Frame += 8 * delta;

                    if (dogActor.Frame > 2)
                    {
                        dogActor.Frame = 0;
                    }
                    if (dogActor.animation_duration > 2.5)
                    {
                        dogActor.animation_duration = 0;
                        dogActor.State = EnumDogState.JUMP_UP;
                    }
                }

                if (dogActor.State == EnumDogState.JUMP_UP)
                {
                    dogActor.Frame = 0;
                    if (dogActor.yPos < 200)
                    {
                        dogActor.State = EnumDogState.JUMP_DOWN;
                    }

                }

                if (dogActor.State == EnumDogState.JUMP_DOWN)
                {
                    dogActor.Frame = 1;
                    if (dogActor.yPos > 250)
                    {
                        dogActor.State = EnumDogState.NOTHING;
                        foreach(var duckActor in game.duckActors)
                        {
                            if(duckActor.State == EnumDuckState.NOTHING)
                            {
                                duckActor.State = EnumDuckState.RIGHTFLY;
                            }
                        }
                    }

                }



            }
            //////// DUCK ACTORS  ////////
            foreach(var duckActor in game.duckActors)
            {
                if (duckActor.State == EnumDuckState.RIGHTFLY)
                {   
                    
                    
                    duckActor.Frame += 8 * delta;
                    
                    if(duckActor.Frame > 3)
                    {
                        duckActor.Frame = 0;

                    }

                    if (duckActor.xPos > 550 || duckActor.yPos < 0)
                    {
                        duckActor.FlyingDirection = EnumDuckFlyingDirection.DOWN;
                        duckActor.State = EnumDuckState.LEFTFLY;

                    }
                    if(duckActor.xPos < 0 || duckActor.yPos > 270)
                    {
                        duckActor.FlyingDirection = EnumDuckFlyingDirection.UP;
                        duckActor.State = EnumDuckState.LEFTFLY;
                    }

                }

                if (duckActor.State == EnumDuckState.LEFTFLY)
                {
                    
                    
                    duckActor.Frame += 8 * delta;

                    if (duckActor.Frame > 3)
                    {
                        duckActor.Frame = 0;

                    }

                    if (duckActor.xPos < 0 || duckActor.yPos > 269)
                    {
                        duckActor.FlyingDirection = EnumDuckFlyingDirection.UP;
                        duckActor.State = EnumDuckState.RIGHTFLY;

                    }
                    if (duckActor.xPos < -1)
                    { 
                        duckActor.FlyingDirection = EnumDuckFlyingDirection.DOWN;
                        duckActor.State = EnumDuckState.RIGHTFLY;
                    }

                }

                if(duckActor.State == EnumDuckState.DIE)
                {
                    duckActor.animation_duration += delta;
                    if (duckActor.animation_duration > 2.5)
                    {
                        duckActor.animation_duration = 0;
                        duckActor.State = EnumDuckState.NOTHING;
                    }
                }
            }
        }

        public static void checkCollision(double x, double y)
        {
            
            foreach(var duckActor in game.duckActors)
            {
                double duckX1,duckX2,duckY1,duckY2;
                duckX1 = duckActor.xPos - 25;
                duckX2 = duckActor.xPos + 25;
                duckY1 = duckActor.yPos + 60;
                duckY2 = duckActor.yPos - 20 ;

                if(duckY1 >= y && y >= duckY2 && x >= duckX1 && duckX2 >= x)
                {
                    duckActor.State = EnumDuckState.DIE;
                    duckActor.Frame = 0;
                    game.score += duckActor.score;

                }

            }
            
        }
        public static void saveGame()
        {
      
            string fileName = "data.json";
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(game);
            File.WriteAllText(fileName, jsonString);
            game.duckActors.Clear();
            game.dogActors.Clear();

        }

        public static void loadGame()
        {
            string fileName = "data.json";
            string jsonString = File.ReadAllText(fileName);
            var game1 = Newtonsoft.Json.JsonConvert.DeserializeObject<Game>(jsonString);

            foreach (var dog in game1.dogActors) {
                game.dogActors.Add(dog);
            }
            foreach (var duck in game1.duckActors)
            {
                game.duckActors.Add(duck);
            }

        }

    }
}
