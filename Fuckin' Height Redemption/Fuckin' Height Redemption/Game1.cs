using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Design;

//test

namespace Fuckin__Height_Redemption
{
    // A FAIRE !
    /*
     
     * 
     * Backgounds (menu:ok/pause/jeu)
     * Menu Pause
     * class: GamePadEvent, Zombie
     * methods: GamePadMove (joueur)
     * colision jouer/zombie
     * bite
     * 

    */


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            this.IsMouseVisible = true;
        }


        ////////////////////////////////////// VARIABLES ! //////////////////////////////////////////////////////

        string status; // Statut du jeu: Principal,Jouer,Multi,Options,Jeu,Pause,Creer,Rejoindre,Audio,Video,Commandes
        bool languefr;
        bool fullscreen; // defini si le jeu est en fullscreen ou non
        bool jeu_manette; // defini si la manette est activée
        bool clique_souris;

        Joueur joueur;
        Zombie zombie;


        MouseEvent souris;
        KeyboardEvent clavier;
        GamePadEvent manette;





        ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

        Texture2D background;
        Texture2D backgroundmenu;

        MenuButton Bjouer;
        MenuButton Bmulti;
        MenuButton Boptions;
        MenuButton Bquitter;
        MenuButton Bretour;

        MenuButton Bnouveaujeu;
        MenuButton Bcontinuer;

        MenuButton Bcreer;
        MenuButton Brejoindre;

        MenuButton Bvideo;
        MenuButton Baudio;
        MenuButton Bcommandes;

        MenuButton Blangue;
        MenuButton Bfullscreen;
        MenuButton Bfenetre;

        MenuButton Bmanette;
        MenuButton Bbox;


        Vector2 positionBoutton1;
        Vector2 positionBoutton2;
        Vector2 positionBoutton3;
        Vector2 positionBoutton4;



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ////////////////////////////////////// VARIABLES ! //////////////////////////////////////////////////////

            status = "Principal";
            languefr = true;
            fullscreen = true;
            jeu_manette = true;

            joueur = new Joueur(Vector2.One, Content.Load<Texture2D>("Player 0"), Content.Load<Texture2D>("Player 45"), Content.Load<Texture2D>("Player 90"), Content.Load<Texture2D>("Player 135"), Content.Load<Texture2D>("Player 180"), Content.Load<Texture2D>("Player 225"), Content.Load<Texture2D>("Player 270"), Content.Load<Texture2D>("Player 315"));
            zombie = new Zombie(new Vector2(1000,1000), 1.5f, Content.Load<Texture2D>("Zombie 0"), Content.Load<Texture2D>("Zombie 45"), Content.Load<Texture2D>("Zombie 90"), Content.Load<Texture2D>("Zombie 135"), Content.Load<Texture2D>("Zombie 180"), Content.Load<Texture2D>("Zombie 225"), Content.Load<Texture2D>("Zombie 270"), Content.Load<Texture2D>("Zombie 315"));

            souris = new MouseEvent();
            clavier = new KeyboardEvent();
            manette = new GamePadEvent(PlayerIndex.One);

            ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

            background = Content.Load<Texture2D>("background");
            backgroundmenu = Content.Load<Texture2D>("menuprincipal");

            // principal
            Bjouer = new MenuButton(Vector2.One, Content.Load<Texture2D>("jouer"), Content.Load<Texture2D>("play"));
            Bmulti = new MenuButton(Vector2.One, Content.Load<Texture2D>("multijoueur"), Content.Load<Texture2D>("multiplayer"));
            Boptions = new MenuButton(Vector2.One, Content.Load<Texture2D>("options"), Content.Load<Texture2D>("options"));
            Bquitter = new MenuButton(Vector2.One, Content.Load<Texture2D>("quitter"), Content.Load<Texture2D>("exit"));
            Bretour = new MenuButton(Vector2.One, Content.Load<Texture2D>("retour"), Content.Load<Texture2D>("back"));

            // Jouer
            Bnouveaujeu = new MenuButton(Vector2.One, Content.Load<Texture2D>("nouveaujeu"), Content.Load<Texture2D>("newgame"));
            Bcontinuer = new MenuButton(Vector2.One, Content.Load<Texture2D>("continuer"), Content.Load<Texture2D>("continue"));


            // Multi
            Bcreer = new MenuButton(Vector2.One, Content.Load<Texture2D>("créer"), Content.Load<Texture2D>("create"));
            Brejoindre = new MenuButton(Vector2.One, Content.Load<Texture2D>("rejoindre"), Content.Load<Texture2D>("join"));


            //Options
            Bvideo = new MenuButton(Vector2.One, Content.Load<Texture2D>("vidéo"), Content.Load<Texture2D>("video"));
            Baudio = new MenuButton(Vector2.One, Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio"));
            Bcommandes = new MenuButton(Vector2.One, Content.Load<Texture2D>("commandes"), Content.Load<Texture2D>("controls"));

            // Video
            Blangue = new MenuButton(Vector2.One, Content.Load<Texture2D>("anglais"), Content.Load<Texture2D>("french"));
            Bfullscreen = new MenuButton(Vector2.One, Content.Load<Texture2D>("pleinecran"), Content.Load<Texture2D>("fullscreen"));
            Bfenetre = new MenuButton(Vector2.One, Content.Load<Texture2D>("fenetre"), Content.Load<Texture2D>("windowed"));

            // Commandes
            Bmanette = new MenuButton(Vector2.One, Content.Load<Texture2D>("manette"), Content.Load<Texture2D>("controller"));
            Bbox = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"));



            // Positions
            positionBoutton1 = new Vector2(16 * Window.ClientBounds.Width / 24, Window.ClientBounds.Height / 8);
            positionBoutton2 = new Vector2(positionBoutton1.X, positionBoutton1.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            positionBoutton3 = new Vector2(positionBoutton2.X, positionBoutton2.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            positionBoutton4 = new Vector2(positionBoutton3.X, positionBoutton3.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);


            base.Initialize();
        }// End initialize









        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }











        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }










        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            souris.UpdateMouse();
            clavier.UpdateKeyboard();
            manette.UpdateGamepad();

            if (status == "Jeu")
            {
                if(jeu_manette && manette.Connected())
                    joueur.MoveGamePad(manette, Window.ClientBounds.Height, Window.ClientBounds.Width);
                else
                    joueur.MoveKeyboard(clavier, Window.ClientBounds.Height, Window.ClientBounds.Width);

                

                zombie.Move(joueur, Window.ClientBounds.Height, Window.ClientBounds.Width);
            }

            if (status == "Principal")
            {

                Bjouer.SetPosition(positionBoutton1);
                Bmulti.SetPosition(positionBoutton2);
                Boptions.SetPosition(positionBoutton3);
                Bquitter.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bjouer.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Jouer";
                }
                if (souris.GetRectangle().Intersects(Bmulti.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Multi";
                }
                if (souris.GetRectangle().Intersects(Boptions.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Options";
                }
                if (souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    this.Exit();
                }

                clique_souris = souris.LeftClick();
            }


            if (status == "Jouer")
            {

                Bnouveaujeu.SetPosition(positionBoutton1);
                Bcontinuer.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Jeu";
                }
                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Continuer";
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Principal";
                }

                clique_souris = souris.LeftClick();
            }


            if (status == "Multi")
            {

                Bcreer.SetPosition(positionBoutton1);
                Brejoindre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    //status = "Creer";
                }
                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    //status = "Rejoindre";
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Principal";
                }

                clique_souris = souris.LeftClick();
            }


            if (status == "Options")
            {

                Bvideo.SetPosition(positionBoutton1);
                Baudio.SetPosition(positionBoutton2);
                Bcommandes.SetPosition(positionBoutton3);
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Video";
                }
                if (souris.GetRectangle().Intersects(Baudio.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    //status = "Audio";
                }
                if (souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Commandes";
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Principal";
                }

                clique_souris = souris.LeftClick();
            }

            if (status == "Video")
            {

                Blangue.SetPosition(positionBoutton1);
                Bfullscreen.SetPosition(positionBoutton2);
                Bfenetre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Blangue.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    languefr = !languefr;
                }
                if (souris.GetRectangle().Intersects(Bfullscreen.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    fullscreen = !fullscreen;
                    graphics.ToggleFullScreen();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Options";
                }

                clique_souris = souris.LeftClick();
            }

            if (status == "Commandes")
            {

                Bmanette.SetPosition(positionBoutton1);
                Bbox.SetPosition(new Vector2(Bmanette.GetPosition().X + Bmanette.GetTexturefr().Width + 20, positionBoutton1.Y));

                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bmanette.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bbox.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Options";
                }


                clique_souris = souris.LeftClick();
            }


            base.Update(gameTime);
        }// End Update












        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (status == "Jeu")
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                joueur.DrawJoueur(spriteBatch);
                zombie.DrawZombie(spriteBatch);
            }

            if (status == "Principal")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bjouer.DrawButton(spriteBatch, languefr);
                Bmulti.DrawButton(spriteBatch, languefr);
                Boptions.DrawButton(spriteBatch, languefr);
                Bquitter.DrawButton(spriteBatch, languefr);
            }
            if (status == "Jouer")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bnouveaujeu.DrawButton(spriteBatch, languefr);
                Bcontinuer.DrawButton(spriteBatch, languefr);
                Bretour.DrawButton(spriteBatch, languefr);
            }
            if (status == "Multi")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bcreer.DrawButton(spriteBatch, languefr);
                Brejoindre.DrawButton(spriteBatch, languefr);
                Bretour.DrawButton(spriteBatch, languefr);
            }
            if (status == "Options")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bvideo.DrawButton(spriteBatch, languefr);
                Baudio.DrawButton(spriteBatch, languefr);
                Bcommandes.DrawButton(spriteBatch, languefr);
                Bretour.DrawButton(spriteBatch, languefr);
            }
            if (status == "Video")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Blangue.DrawButton(spriteBatch, languefr);
                if (!fullscreen)
                    Bfullscreen.DrawButton(spriteBatch, languefr);
                else
                    Bfenetre.DrawButton(spriteBatch, languefr);
                Bretour.DrawButton(spriteBatch, languefr);
            }
            if (status == "Commandes")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bmanette.DrawButton(spriteBatch, languefr);
                Bbox.DrawButton(spriteBatch, jeu_manette);
                Bretour.DrawButton(spriteBatch, languefr);
            }






            spriteBatch.End();

            base.Draw(gameTime);
        }// End Draw

    }// End Game1
}
