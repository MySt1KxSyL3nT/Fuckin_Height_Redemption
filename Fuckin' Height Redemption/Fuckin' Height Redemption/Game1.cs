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
        bool fullscreen; // defini si le jeu est en fullscreen ou non
        bool jeu_manette; // defini si la manette est activée
        bool clique_souris;
        bool clique_clavier;
        bool clique_manette;

        int elapsedtime;
        int lang; // 1 = francais, 2 = anglais, 3 = italien
        int entiermanette;


        // musique
        bool musique;
        bool effets;
        int entiermusique;
        int entiereffets;
        int volumemusic;
        int volumeeffects;


        Joueur joueur;
        Zombie[] zombie;
        //Zombie newzombie;
        int nombre_zombie;


        MouseEvent souris;
        KeyboardEvent clavier;
        GamePadEvent manette;



        Song sonprincipal;



        ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

        Texture2D background;
        Texture2D backgroundmenu;
        Texture2D pausemenu;
        Texture2D menupause;
        Texture2D menupausa;
        Texture2D barreson;
        Texture2D contourson;

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

        MenuButton Bmusique;
        MenuButton Beffets;
        MenuButton Bboxmusique;
        MenuButton Bboxeffects;
        MenuButton Bmoinsmusic;
        MenuButton Bplusmusic;
        MenuButton Bmoinseffects;
        MenuButton Bpluseffects;
        Rectangle musicbar;
        Rectangle effectsbar;

        MenuButton Blangue;
        MenuButton Blanguefr;
        MenuButton Blangueen;
        MenuButton Blangueit;
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
            fullscreen = true;
            jeu_manette = true;

            joueur = new Joueur(Vector2.One, Content.Load<Texture2D>("Player 0"), Content.Load<Texture2D>("Player 45"), Content.Load<Texture2D>("Player 90"), Content.Load<Texture2D>("Player 135"), Content.Load<Texture2D>("Player 180"), Content.Load<Texture2D>("Player 225"), Content.Load<Texture2D>("Player 270"), Content.Load<Texture2D>("Player 315"));

            nombre_zombie = 0; 

            elapsedtime = 1;
            entiermanette = 1;
            lang = 1;


            //musique
            musique = true;
            effets = !musique;
            entiermusique = 1;
            entiereffets = 1;

            volumemusic = 2;
            volumeeffects = 2;


            souris = new MouseEvent();
            clavier = new KeyboardEvent();
            manette = new GamePadEvent(PlayerIndex.One);


            sonprincipal = Content.Load<Song>("sonprincipal");

            ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

            background = Content.Load<Texture2D>("background");
            backgroundmenu = Content.Load<Texture2D>("menuprincipal");

            menupause = Content.Load<Texture2D>("menupause");
            pausemenu = Content.Load<Texture2D>("pausemenu");
            menupausa = Content.Load<Texture2D>("menupausa");
            barreson = Content.Load<Texture2D>("barreson");
            contourson = Content.Load<Texture2D>("contourson");


            // principal
            Bjouer = new MenuButton(Vector2.One, Content.Load<Texture2D>("jouer"), Content.Load<Texture2D>("play"), Content.Load<Texture2D>("jouerit"));
            Bmulti = new MenuButton(Vector2.One, Content.Load<Texture2D>("multijoueur"), Content.Load<Texture2D>("multiplayer"), Content.Load<Texture2D>("multijoueurit"));
            Boptions = new MenuButton(Vector2.One, Content.Load<Texture2D>("options"), Content.Load<Texture2D>("options"), Content.Load<Texture2D>("optionsit"));
            Bquitter = new MenuButton(Vector2.One, Content.Load<Texture2D>("quitter"), Content.Load<Texture2D>("exit"), Content.Load<Texture2D>("quitterit"));
            Bretour = new MenuButton(Vector2.One, Content.Load<Texture2D>("retour"), Content.Load<Texture2D>("back"), Content.Load<Texture2D>("retourit"));

            // Jouer
            Bnouveaujeu = new MenuButton(Vector2.One, Content.Load<Texture2D>("nouveaujeu"), Content.Load<Texture2D>("newgame"), Content.Load<Texture2D>("nouveaujeuit"));
            Bcontinuer = new MenuButton(Vector2.One, Content.Load<Texture2D>("continuer"), Content.Load<Texture2D>("continue"), Content.Load<Texture2D>("continuerit"));


            // Multi
            Bcreer = new MenuButton(Vector2.One, Content.Load<Texture2D>("créer"), Content.Load<Texture2D>("create"), Content.Load<Texture2D>("creerit"));
            Brejoindre = new MenuButton(Vector2.One, Content.Load<Texture2D>("rejoindre"), Content.Load<Texture2D>("join"), Content.Load<Texture2D>("rejoindreit"));


            //Options
            Bvideo = new MenuButton(Vector2.One, Content.Load<Texture2D>("vidéo"), Content.Load<Texture2D>("video"), Content.Load<Texture2D>("video"));
            Baudio = new MenuButton(Vector2.One, Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio"));
            Bcommandes = new MenuButton(Vector2.One, Content.Load<Texture2D>("commandes"), Content.Load<Texture2D>("controls"), Content.Load<Texture2D>("commandesit"));

            //Audio
            Bmusique = new MenuButton(Vector2.One, Content.Load<Texture2D>("musique"), Content.Load<Texture2D>("music"), Content.Load<Texture2D>("musica"));
            Beffets = new MenuButton(Vector2.One, Content.Load<Texture2D>("effetssonores"), Content.Load<Texture2D>("soundeffects"), Content.Load<Texture2D>("effettisonori"));
            Bboxmusique = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"));
            Bboxeffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"));
            Bmoinsmusic = new MenuButton(Vector2.One, Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"));
            Bplusmusic = new MenuButton(Vector2.One, Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"));
            Bmoinseffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"));
            Bpluseffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"));
            

            // Video
            Blangue = new MenuButton(Vector2.One, Content.Load<Texture2D>("langues"), Content.Load<Texture2D>("languages"), Content.Load<Texture2D>("languesit"));
            Bfullscreen = new MenuButton(Vector2.One, Content.Load<Texture2D>("pleinecran"), Content.Load<Texture2D>("fullscreen"), Content.Load<Texture2D>("pleinecranit"));
            Bfenetre = new MenuButton(Vector2.One, Content.Load<Texture2D>("fenetre"), Content.Load<Texture2D>("windowed"), Content.Load<Texture2D>("fenetreit"));

            //Langues
            Blanguefr = new MenuButton(Vector2.One, Content.Load<Texture2D>("french"), Content.Load<Texture2D>("french"), Content.Load<Texture2D>("francaisit"));
            Blangueen = new MenuButton(Vector2.One, Content.Load<Texture2D>("anglais"), Content.Load<Texture2D>("anglaisit"), Content.Load<Texture2D>("anglaisit"));
            Blangueit = new MenuButton(Vector2.One, Content.Load<Texture2D>("italien"), Content.Load<Texture2D>("italian"), Content.Load<Texture2D>("anglaisit"));

            // Commandes
            Bmanette = new MenuButton(Vector2.One, Content.Load<Texture2D>("manette"), Content.Load<Texture2D>("controller"), Content.Load<Texture2D>("manetteit"));
            Bbox = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"));




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


            // MUSIQUES !
            if (status == "Principal" || status == "Jouer" || status == "Multi" || status == "Options" || status == "Video" || status == "Audio" || status == "Commandes" || status == "Langues")
            {
                if (MediaPlayer.State == MediaState.Stopped)
                    MediaPlayer.Play(sonprincipal);
            }


            if (status == "Nouveau_Jeu")
            {
                joueur = new Joueur(Vector2.One, Content.Load<Texture2D>("Player 0"), Content.Load<Texture2D>("Player 45"), Content.Load<Texture2D>("Player 90"), Content.Load<Texture2D>("Player 135"), Content.Load<Texture2D>("Player 180"), Content.Load<Texture2D>("Player 225"), Content.Load<Texture2D>("Player 270"), Content.Load<Texture2D>("Player 315"));
                zombie = new Zombie[2];
                nombre_zombie = 0;
                elapsedtime = 1;
                status = "Jeu";
            }

            if (status == "Jeu")
            {
                if (jeu_manette && manette.Connected())
                {
                    joueur.MoveGamePad(manette, Window.ClientBounds.Height, Window.ClientBounds.Width);
                    if (manette.IsPressed(Buttons.Start) && !clique_manette)
                        status = "Pause";
                    clique_manette = manette.IsPressed(Buttons.Start);
                }
                else
                {
                    joueur.MoveKeyboard(clavier, Window.ClientBounds.Height, Window.ClientBounds.Width);
                    joueur.SetAngleVisee(souris.GetPosition()); // defini l'angle de la visee (vers la souris)
                    if (clavier.KeyPressed(Keys.Escape) && !clique_clavier)
                        status = "Pause";
                    clique_clavier = clavier.KeyPressed(Keys.Escape);
                }

                joueur.SetVisee(); // Creer un vecteur de visee avec l'angle

                foreach (Zombie z in zombie)
                {
                    if (z != null)
                    {
                        z.Move(joueur, Window.ClientBounds.Height, Window.ClientBounds.Width);
                        z.SetAngleVisee(joueur.GetRectangleCenter());
                        z.SetVisee();
                    }
                }

                elapsedtime += gameTime.ElapsedGameTime.Milliseconds;

                if (elapsedtime / 500 > nombre_zombie && nombre_zombie < zombie.Length)
                {
                    zombie[nombre_zombie] = Zombie.SpawnZombie(Window.ClientBounds.Width, Window.ClientBounds.Height, Content);
                    nombre_zombie += 1;
                }

            }

            if (status == "Pause")
            {
                Bcontinuer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2 - Bcontinuer.GetTexturefr().Width, (Window.ClientBounds.Height - Bcontinuer.GetTexturefr().Height) / 2));
                Bquitter.SetPosition(new Vector2((Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2 + Bcontinuer.GetTexturefr().Width), (Window.ClientBounds.Height - Bcontinuer.GetTexturefr().Height) / 2));

                if ((souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && clique_souris) || (clavier.KeyPressed(Keys.Escape) && !clique_clavier) || (manette.IsPressed(Buttons.Start) && !clique_manette))
                {
                    status = "Jeu";
                }
                if (souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Principal";
                }

                clique_manette = manette.IsPressed(Buttons.Start);
                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Escape);
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
                    status = "Nouveau_Jeu";
                }
                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Jeu";
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
                    status = "Audio";
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


            if (status == "Audio")
            {
                Bmusique.SetPosition(new Vector2(positionBoutton1.X - (int)(1.5 * Bmusique.GetTexturefr().Width), positionBoutton1.Y));
                Bboxmusique.SetPosition(new Vector2(Bmusique.GetPosition().X - 40, positionBoutton1.Y + 8));
                Bmoinsmusic.SetPosition(new Vector2(Bmusique.GetPosition().X + 10 + Bmusique.GetTexturefr().Width, positionBoutton1.Y));
                Bplusmusic.SetPosition(new Vector2(Bmoinsmusic.GetPosition().X + 90 + Bmusique.GetTexturefr().Width, positionBoutton1.Y));

                Beffets.SetPosition(new Vector2(positionBoutton2.X - (int)(1.5 * Bmusique.GetTexturefr().Width), positionBoutton2.Y));
                Bboxeffects.SetPosition(new Vector2(Beffets.GetPosition().X - 40, positionBoutton2.Y + 8));
                Bmoinseffects.SetPosition(new Vector2(Bmusique.GetPosition().X + 10 + Bmusique.GetTexturefr().Width, positionBoutton2.Y));
                Bpluseffects.SetPosition(new Vector2(Bmoinsmusic.GetPosition().X + 90 + Bmusique.GetTexturefr().Width, positionBoutton2.Y));


                musicbar = new Rectangle((int)Bmoinsmusic.GetPosition().X + Bmoinsmusic.GetTexturefr().Width + 8, (int)Bmoinsmusic.GetPosition().Y + Bmoinsmusic.GetTexturefr().Height / 4, (int)(200 * (float)volumemusic / (float)10), Bmusique.GetTexturefr().Height / 2);
                effectsbar = new Rectangle((int)Bmoinsmusic.GetPosition().X + Bmoinsmusic.GetTexturefr().Width + 8, (int)Bmoinseffects.GetPosition().Y + Bmoinsmusic.GetTexturefr().Height / 4, (int)(200 * (float)volumeeffects / (float)10), Bmusique.GetTexturefr().Height / 2);


                Bretour.SetPosition(positionBoutton4);

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Bboxmusique.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Beffets.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    effets = !effets;
                }
                if (souris.GetRectangle().Intersects(Bboxeffects.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    effets = !effets;
                }

                //Volume du son
                if (souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    if (volumemusic < 10)
                        volumemusic += 1;
                    else
                        volumemusic = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    if (volumemusic > 0)
                        volumemusic -= 1;
                    else
                        volumemusic = 0;
                }


                if (souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    if (volumeeffects < 10)
                        volumeeffects += 1;
                    else
                        volumeeffects = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    if (volumeeffects > 0)
                        volumeeffects -= 1;
                    else
                        volumeeffects = 0;
                }



                if (!musique)
                    volumemusic = 0;
                if (!effets)
                    volumeeffects = 0;



                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Options";
                }

                clique_souris = souris.LeftClick();

                MediaPlayer.Volume = (float)volumemusic / 10f;
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
                    status = "Langues";
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

            if (status == "Langues")
            {
                Blangueen.SetPosition(new Vector2(-10000));
                Blangueit.SetPosition(new Vector2(-10000));
                Blanguefr.SetPosition(new Vector2(-10000));
                if (lang == 1) //francais
                {
                    Blangueen.SetPosition(positionBoutton1);
                    Blangueit.SetPosition(positionBoutton2);
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.SetPosition(positionBoutton1);
                    Blangueit.SetPosition(positionBoutton2);
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 3) //italien
                {
                    Blanguefr.SetPosition(positionBoutton1);
                    Blangueen.SetPosition(positionBoutton2);
                    Bretour.SetPosition(positionBoutton4);
                }

                if (souris.GetRectangle().Intersects(Blanguefr.GetRectangle()) && !souris.LeftClick() && clique_souris)
                    lang = 1;
                if (souris.GetRectangle().Intersects(Blangueen.GetRectangle()) && !souris.LeftClick() && clique_souris)
                    lang = 2;
                if (souris.GetRectangle().Intersects(Blangueit.GetRectangle()) && !souris.LeftClick() && clique_souris)
                    lang = 3;


                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    status = "Video";
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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if (status == "Jeu" || status == "Pause")
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                foreach (Zombie z in zombie)
                {
                    if (z != null)
                    {
                        z.DrawZombie(spriteBatch, false);
                    }
                }
                joueur.DrawJoueur(spriteBatch, false);
            }

            if (status == "Pause")
            {
                if (lang == 1)
                    spriteBatch.Draw(menupause, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                else
                {
                    if (lang == 2)
                        spriteBatch.Draw(pausemenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else
                        spriteBatch.Draw(menupausa, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }

                Bcontinuer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()));
                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()));
            }

            if (status == "Principal")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bjouer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bjouer.GetRectangle()));
                Bmulti.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmulti.GetRectangle()));
                Boptions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Boptions.GetRectangle()));
                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()));
            }
            if (status == "Jouer")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bnouveaujeu.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()));
                Bcontinuer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            if (status == "Multi")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bcreer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcreer.GetRectangle()));
                Brejoindre.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Brejoindre.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            if (status == "Options")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bvideo.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bvideo.GetRectangle()));
                Baudio.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Baudio.GetRectangle()));
                Bcommandes.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcommandes.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            if (status == "Video")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Blangue.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangue.GetRectangle()));
                if (!fullscreen)
                    Bfenetre.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfenetre.GetRectangle()));
                else
                    Bfullscreen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfullscreen.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }

            if (status == "Audio")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bmusique.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmusique.GetRectangle()));
                if (musique)
                    entiermusique = 1;
                else
                    entiermusique = 2;
                Bboxmusique.DrawButton(spriteBatch, entiermusique, false);

                Beffets.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Beffets.GetRectangle()));
                if (effets)
                    entiereffets = 1;
                else
                    entiereffets = 2;
                Bboxeffects.DrawButton(spriteBatch, entiereffets, false);


                spriteBatch.Draw(barreson, musicbar, Color.Orange);
                spriteBatch.Draw(barreson, effectsbar, Color.Orange);
                spriteBatch.Draw(contourson, new Rectangle(musicbar.X, musicbar.Y, 200, musicbar.Height), Color.White);
                spriteBatch.Draw(contourson, new Rectangle(effectsbar.X, effectsbar.Y, 200, effectsbar.Height), Color.White);


                Bplusmusic.DrawButton(spriteBatch, 1, souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()));
                Bmoinsmusic.DrawButton(spriteBatch, 1, souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()));
                Bpluseffects.DrawButton(spriteBatch, 1, souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()));
                Bmoinseffects.DrawButton(spriteBatch, 1, souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()));

                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }

            if (status == "Langues")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                if (lang == 1) //francais
                {
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 3) //italien
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
            }
            if (status == "Commandes")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bmanette.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmanette.GetRectangle()));
                if (jeu_manette)
                    entiermanette = 1;
                else
                    entiermanette = 2;
                Bbox.DrawButton(spriteBatch, entiermanette, false);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }






            spriteBatch.End();

            base.Draw(gameTime);
        }// End Draw

    }// End Game1
}
