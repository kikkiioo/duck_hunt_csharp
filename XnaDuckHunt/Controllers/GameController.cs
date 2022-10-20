using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Framework.WpfInterop.Input;
using WpfDuckHunt.Models;
using Microsoft.Xna.Framework.Graphics;

namespace WpfDuckHunt.Controllers
{
    public class GameController
    {
        public static Game game = new Game();
        

        public static void newGame()
        {
            game.dogActors.Clear();
            Dog dog = new Dog(x: 0, y: 320, state: EnumDogState.SNIFF, frame: 0, Animation_duration: 0);
            game.dogActors.Add(dog);
            Duck duck = new Duck(x: 240, y: 260, state: EnumDuckState.NOTHING, duckType: "black", score: 500,FlyingDirection:"up", frame: 0, Animation_duration: 0);
            game.duckActors.Add(duck);
        }
        public static void updateControllers(float delta)
        {
            for (int i = 0; i < game.dogActors.Count; i++)
            {
                if (game.dogActors[i].State == EnumDogState.SNIFF)
                {
                    DogController.sniff(game.dogActors[i], delta);
                }
                if (game.dogActors[i].State == EnumDogState.JUMP_UP)
                {
                    DogController.jumpUp(game.dogActors[i], delta);
                }
                if (game.dogActors[i].State == EnumDogState.JUMP_DOWN)
                {
                    DogController.jumpDown(game.dogActors[i], delta);
                }
            }
            for (int i = 0; i < game.duckActors.Count; i++)
            {
                if(game.duckActors[i].State == EnumDuckState.RIGHTFLY)
                {
                    DuckController.flyRight(game.duckActors[i], delta);
                }
                if(game.duckActors[i].State == EnumDuckState.LEFTFLY)
                {
                    DuckController.flyLeft(game.duckActors[i], delta);
                }
            }
        }

        public static void updateActors(float delta)
        {
            ////////  DOG ACTORS  //////// 
            for (int i = 0; i < game.dogActors.Count; i++)
            {
                if (game.dogActors[i].State == EnumDogState.SNIFF)
                {
                    game.dogActors[i].animation_duration += delta;
                    game.dogActors[i].Frame += 8 * delta;
                    if (game.dogActors[i].Frame > 4)
                    {
                        game.dogActors[i].Frame = 0;
                    }
                    if (game.dogActors[i].animation_duration >= 4.0)
                    {
                        game.dogActors[i].animation_duration = 0;
                        game.dogActors[i].State = EnumDogState.SNIFF1;
                    }
                }

                if (game.dogActors[i].State == EnumDogState.SNIFF1)
                {
                    game.dogActors[i].animation_duration += delta;
                    game.dogActors[i].Frame += 8 * delta;

                    if (game.dogActors[i].Frame > 2)
                    {
                        game.dogActors[i].Frame = 0;
                    }
                    if (game.dogActors[i].animation_duration > 2.5)
                    {
                        game.dogActors[i].animation_duration = 0;
                        game.dogActors[i].State = EnumDogState.JUMP_UP;
                    }
                }

                if (game.dogActors[i].State == EnumDogState.JUMP_UP)
                {
                    game.dogActors[i].Frame = 0;
                    if (game.dogActors[i].yPos < 200)
                    {
                        game.dogActors[i].State = EnumDogState.JUMP_DOWN;
                    }

                }

                if (game.dogActors[i].State == EnumDogState.JUMP_DOWN)
                {
                    game.dogActors[i].Frame = 1;
                    if (game.dogActors[i].yPos > 250)
                    {
                        game.dogActors[i].State = EnumDogState.NOTHING;
                        for (int j = 0; j < game.duckActors.Count; j++)
                        {
                            if(game.duckActors[j].State == EnumDuckState.NOTHING)
                            {
                                game.duckActors[j].State = EnumDuckState.RIGHTFLY;
                            }
                        }
                    }

                }



            }
            //////// DUCK ACTORS  ////////
            for (int j = 0; j < game.duckActors.Count; j++)
            {
                if (game.duckActors[j].State == EnumDuckState.RIGHTFLY)
                {   
                    
                    
                    game.duckActors[j].Frame += 8 * delta;
                    
                    if(game.duckActors[j].Frame > 3)
                    {
                        game.duckActors[j].Frame = 0;

                    }

                    if (game.duckActors[j].xPos > 550 || game.duckActors[j].yPos < 0)
                    {
                        game.duckActors[j].flyingDirection = "down";
                        game.duckActors[j].State = EnumDuckState.LEFTFLY;

                    }
                    if(game.duckActors[j].xPos < 0 || game.duckActors[j].yPos > 270)
                    {
                        game.duckActors[j].flyingDirection = "up";
                        game.duckActors[j].State = EnumDuckState.LEFTFLY;
                    }

                }

                if (game.duckActors[j].State == EnumDuckState.LEFTFLY)
                {
                    
                    
                    game.duckActors[j].Frame += 8 * delta;

                    if (game.duckActors[j].Frame > 3)
                    {
                        game.duckActors[j].Frame = 0;

                    }

                    if (game.duckActors[j].xPos < 0 || game.duckActors[j].yPos > 269)
                    {
                        game.duckActors[j].flyingDirection = "up";
                        game.duckActors[j].State = EnumDuckState.RIGHTFLY;

                    }
                    if (game.duckActors[j].xPos < -1)
                    { 
                        game.duckActors[j].flyingDirection = "down";
                        game.duckActors[j].State = EnumDuckState.RIGHTFLY;
                    }

                }

                if(game.duckActors[j].State == EnumDuckState.DIE)
                {
                    game.duckActors[j].animation_duration += delta;
                    if (game.duckActors[j].animation_duration > 2.5)
                    {
                        game.duckActors[j].animation_duration = 0;
                        game.duckActors[j].State = EnumDuckState.NOTHING;
                    }
                }
            }
        }

        public static void checkCollision(double x, double y)
        {
            
            for(int i = 0; i < game.duckActors.Count; i++)
            {
                double duckX1,duckX2,duckY1,duckY2;
                duckX1 = game.duckActors[i].xPos - 25;
                duckX2 = game.duckActors[i].xPos + 25;
                duckY1 = game.duckActors[i].yPos + 60;
                duckY2 = game.duckActors[i].yPos - 20 ;

                if(duckY1 >= y && y >= duckY2 && x >= duckX1 && duckX2 >= x)
                {
                    game.duckActors[i].State = EnumDuckState.DIE;
                    game.duckActors[i].Frame = 0;

                }

            }
            
        }

    }
}
