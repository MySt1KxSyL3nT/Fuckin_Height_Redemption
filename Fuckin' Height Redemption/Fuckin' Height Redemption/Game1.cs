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

        //difficulté jeu
        int diff;
        Difficulté difficulté;


        Joueur joueur;
        Zombie[] zombie;
        List<Zombie> zombiesloins;
        List<Zombie> zombiesprets;
        //Zombie newzombie;
        int nombre_zombie;


        MouseEvent souris;
        KeyboardEvent clavier;
        GamePadEvent manette;

        //menu
        int gestionclavier;
        bool clique_bas;
        bool clique_haut;
        bool clique_back;

        Song sonprincipal;



        ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

        Texture2D background;
        Texture2D backgroundmenu;
        Texture2D pausemenu;
        Texture2D menupause;
        Texture2D menupausa;
        Texture2D barreson;
        Texture2D contourson;

        Texture2D HUD_vie;
        Texture2D HUD_arme;


        Texture2D cinematique1;
        Texture2D cinematiqueen1;
        Texture2D cinematiqueit1;
        Texture2D cinematique2;
        Texture2D cinematiqueen2;
        Texture2D cinematiqueit2;
        Texture2D cinematique3;
        Texture2D cinematiqueen3;
        Texture2D cinematiqueit3;
        Texture2D cinematique4;
        Texture2D cinematiqueen4;
        Texture2D cinematiqueit4;
        Texture2D cinematique5;
        Texture2D cinematiqueen5;
        Texture2D cinematiqueit5;
        Texture2D cinematique6;
        Texture2D cinematiqueen6;
        Texture2D cinematiqueit6;
        Texture2D cinematique7;
        Texture2D cinematiqueen7;
        Texture2D cinematiqueit7;

        MenuButton Bjouer;
        MenuButton Bmulti;
        MenuButton Boptions;
        MenuButton Bquitter;
        MenuButton Bretour;

        MenuButton Bnouveaujeu;
        MenuButton Bcontinuer;

        MenuButton Bfacile;
        MenuButton BIntermediaire;
        MenuButton Bdifficle;
        MenuButton Bimpossible;

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
        Vector2 positionBoutton5;



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

            joueur = new Joueur(Vector2.One, Content.Load<Texture2D>("Player 2d"), Content.Load<Texture2D>("Player 0"), Content.Load<Texture2D>("Player 45"), Content.Load<Texture2D>("Player 90"), Content.Load<Texture2D>("Player 135"), Content.Load<Texture2D>("Player 180"), Content.Load<Texture2D>("Player 225"), Content.Load<Texture2D>("Player 270"), Content.Load<Texture2D>("Player 315"));

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

            gestionclavier = -1;

            sonprincipal = Content.Load<Song>("sonprincipal");

            ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////

            background = Content.Load<Texture2D>("background");
            backgroundmenu = Content.Load<Texture2D>("menuprincipal");

            menupause = Content.Load<Texture2D>("menupause");
            pausemenu = Content.Load<Texture2D>("pausemenu");
            menupausa = Content.Load<Texture2D>("menupausa");
            barreson = Content.Load<Texture2D>("barreson");
            contourson = Content.Load<Texture2D>("contourson");

            HUD_vie = Content.Load<Texture2D>("vie");
            HUD_arme = Content.Load<Texture2D>("arme");


            cinematique1 = Content.Load<Texture2D>("cinematique1");
            cinematique2 = Content.Load<Texture2D>("cinematique2");
            cinematique3 = Content.Load<Texture2D>("cinematique3");
            cinematique4 = Content.Load<Texture2D>("cinematique4");
            cinematique5 = Content.Load<Texture2D>("cinematique5");
            cinematique6 = Content.Load<Texture2D>("cinematique6");
            cinematique7 = Content.Load<Texture2D>("cinematique7");
            cinematiqueen1 = Content.Load<Texture2D>("cinematiqueen1");
            cinematiqueen2 = Content.Load<Texture2D>("cinematiqueen2");
            cinematiqueen3 = Content.Load<Texture2D>("cinematiqueen3");
            cinematiqueen4 = Content.Load<Texture2D>("cinematiqueen4");
            cinematiqueen5 = Content.Load<Texture2D>("cinematiqueen5");
            cinematiqueen6 = Content.Load<Texture2D>("cinematiqueen6");
            cinematiqueen7 = Content.Load<Texture2D>("cinematiqueen7");
            cinematiqueit1 = Content.Load<Texture2D>("cinematiqueit1");
            cinematiqueit2 = Content.Load<Texture2D>("cinematiqueit2");
            cinematiqueit3 = Content.Load<Texture2D>("cinematiqueit3");
            cinematiqueit4 = Content.Load<Texture2D>("cinematiqueit4");
            cinematiqueit5 = Content.Load<Texture2D>("cinematiqueit5");
            cinematiqueit6 = Content.Load<Texture2D>("cinematiqueit6");
            cinematiqueit7 = Content.Load<Texture2D>("cinematiqueit7");





            // principal
            Bjouer = new MenuButton(Vector2.One, Content.Load<Texture2D>("jouer"), Content.Load<Texture2D>("play"), Content.Load<Texture2D>("jouerit"));
            Bmulti = new MenuButton(Vector2.One, Content.Load<Texture2D>("multijoueur"), Content.Load<Texture2D>("multiplayer"), Content.Load<Texture2D>("multijoueurit"));
            Boptions = new MenuButton(Vector2.One, Content.Load<Texture2D>("options"), Content.Load<Texture2D>("options"), Content.Load<Texture2D>("optionsit"));
            Bquitter = new MenuButton(Vector2.One, Content.Load<Texture2D>("quitter"), Content.Load<Texture2D>("exit"), Content.Load<Texture2D>("quitterit"));
            Bretour = new MenuButton(Vector2.One, Content.Load<Texture2D>("retour"), Content.Load<Texture2D>("back"), Content.Load<Texture2D>("retourit"));

            // Jouer
            Bnouveaujeu = new MenuButton(Vector2.One, Content.Load<Texture2D>("nouveaujeu"), Content.Load<Texture2D>("newgame"), Content.Load<Texture2D>("nouveaujeuit"));
            Bcontinuer = new MenuButton(Vector2.One, Content.Load<Texture2D>("continuer"), Content.Load<Texture2D>("continue"), Content.Load<Texture2D>("continuerit"));


            //Modes
            Bfacile = new MenuButton(Vector2.One, Content.Load<Texture2D>("facile"), Content.Load<Texture2D>("easy"), Content.Load<Texture2D>("facile"));
            BIntermediaire = new MenuButton(Vector2.One, Content.Load<Texture2D>("intermediaire"), Content.Load<Texture2D>("intermediate"), Content.Load<Texture2D>("intermedio"));
            Bdifficle = new MenuButton(Vector2.One, Content.Load<Texture2D>("difficile"), Content.Load<Texture2D>("difficult"), Content.Load<Texture2D>("difficile"));
            Bimpossible = new MenuButton(Vector2.One, Content.Load<Texture2D>("impossible"), Content.Load<Texture2D>("impossible"), Content.Load<Texture2D>("impossibile"));

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
            positionBoutton5 = new Vector2(positionBoutton4.X, positionBoutton4.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);


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
            if (status == "Principal" || status == "Choix_Niveau" || status == "Cinematiques" || status == "Jouer" || status == "Multi" || status == "Options" || status == "Video" || status == "Audio" || status == "Commandes" || status == "Langues")
            {
                if (MediaPlayer.State == MediaState.Stopped)
                    MediaPlayer.Play(sonprincipal);
            }
            else
            {
                MediaPlayer.Stop();
            }





            if (status == "Jeu")
            {
                if (jeu_manette && manette.Connected())
                {
                    joueur.MoveGamePad(manette, Window.ClientBounds.Height, Window.ClientBounds.Width, zombie);
                    if (manette.IsPressed(Buttons.Start) && !clique_manette)
                        status = "Pause";
                    clique_manette = manette.IsPressed(Buttons.Start);
                    if (manette.IsPressed(Buttons.RightTrigger))
                        joueur.Fire(zombie, Window.ClientBounds.Height, Window.ClientBounds.Width);
                    
                }
                else
                {
                    joueur.MoveKeyboard(clavier, Window.ClientBounds.Height, Window.ClientBounds.Width, zombie);
                    joueur.SetAngleVisee(souris.GetPosition()); // defini l'angle de la visee (vers la souris)
                    if (clavier.KeyPressed(Keys.Escape) && !clique_clavier)
                        status = "Pause";
                    clique_clavier = clavier.KeyPressed(Keys.Escape);
                    
                    if (souris.LeftClick())
                        joueur.Fire(zombie, Window.ClientBounds.Height, Window.ClientBounds.Width);

                    // update le bool pour le tir semi auto 
                    joueur.SetLastShoot(souris.LeftClick());
                }

                joueur.SetVisee(); // Creer un vecteur de visee avec l'angle







                foreach (Zombie z in zombie)
                {
                    if (z != null && !z.GetDead())
                    {
                        z.Move(joueur, zombie, gameTime.ElapsedGameTime.Milliseconds, Window.ClientBounds.Height, Window.ClientBounds.Width);
                        z.SetAngleVisee(joueur.GetRectangleCenter());
                        z.SetVisee();
                    }
                }

                elapsedtime += gameTime.ElapsedGameTime.Milliseconds;

                if (elapsedtime / difficulté.GetMilliseconds() > nombre_zombie && nombre_zombie < zombie.Length)
                {
                    zombie[nombre_zombie] = Zombie.SpawnZombie(Window.ClientBounds.Width, Window.ClientBounds.Height, Content, difficulté.GetMaxSpeed());
                    nombre_zombie += 1;
                }
               

            }





            //gestion: ok
            if (status == "Principal")
            {

                Bjouer.SetPosition(positionBoutton1);
                Bmulti.SetPosition(positionBoutton2);
                Boptions.SetPosition(positionBoutton3);
                Bquitter.SetPosition(positionBoutton4);


                if ((souris.GetRectangle().Intersects(Bjouer.GetRectangle()) && !souris.LeftClick() && clique_souris) || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Jouer";
                }
                if ((souris.GetRectangle().Intersects(Bmulti.GetRectangle()) && !souris.LeftClick() && clique_souris) || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Multi";
                }
                if ((souris.GetRectangle().Intersects(Boptions.GetRectangle()) && !souris.LeftClick() && clique_souris) || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Options";
                }
                if ((souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && clique_souris) || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    this.Exit();
                }



                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bjouer.GetRectangle()) || souris.GetRectangle().Intersects(Bmulti.GetRectangle()) || souris.GetRectangle().Intersects(Boptions.GetRectangle()) || souris.GetRectangle().Intersects(Bquitter.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);

            }

            //gestion: ok
            if (status == "Jouer")
            {

                Bnouveaujeu.SetPosition(positionBoutton1);
                Bcontinuer.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Choix_Niveau";
                }
                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    if (zombie != null)
                    {
                        gestionclavier = -1;
                        status = "Jeu";
                    }
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                }


                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
            }


            //gestion: ok
            if (status == "Choix_Niveau")
            {
                Bfacile.SetPosition(positionBoutton1);
                BIntermediaire.SetPosition(positionBoutton2);
                Bdifficle.SetPosition(positionBoutton3);
                Bimpossible.SetPosition(positionBoutton4);
                Bretour.SetPosition(positionBoutton5);

                if (souris.GetRectangle().Intersects(Bfacile.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 1;
                }
                if (souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 2;
                }
                if (souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 3;
                }
                if (souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 4;
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 4 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Jouer";
                }

                elapsedtime = 1;




                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 4)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 4;
                }

                if (souris.GetRectangle().Intersects(Bfacile.GetRectangle()) || souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) || souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) || souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
            }






            if (status == "Cinematiques")
            {

                if (elapsedtime < 35000 && !clavier.KeyPressed(Keys.Enter))
                    elapsedtime += gameTime.ElapsedGameTime.Milliseconds;
                else
                {
                    difficulté = new Difficulté(diff);
                    status = "Nouveau_Jeu";
                }
            }





            if (status == "Nouveau_Jeu")
            {
                joueur = new Joueur(Vector2.One, Content.Load<Texture2D>("Player 2d"), Content.Load<Texture2D>("Player 0"), Content.Load<Texture2D>("Player 45"), Content.Load<Texture2D>("Player 90"), Content.Load<Texture2D>("Player 135"), Content.Load<Texture2D>("Player 180"), Content.Load<Texture2D>("Player 225"), Content.Load<Texture2D>("Player 270"), Content.Load<Texture2D>("Player 315"));
                zombie = new Zombie[difficulté.GetMaxZombies()];
                nombre_zombie = 0;
                elapsedtime = 1;
                status = "Jeu";
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







            //gestion: ok
            if (status == "Multi")
            {

                Bcreer.SetPosition(positionBoutton1);
                Brejoindre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bcreer.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    //status = "Creer";
                }
                if (souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    //status = "Rejoindre";
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                }

                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bcreer.GetRectangle()) || souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
            }


            if (status == "Options")
            {

                Bvideo.SetPosition(positionBoutton1);
                Baudio.SetPosition(positionBoutton2);
                Bcommandes.SetPosition(positionBoutton3);
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Video";
                }
                if (souris.GetRectangle().Intersects(Baudio.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Audio";
                }
                if (souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Commandes";
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                }

                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) || souris.GetRectangle().Intersects(Baudio.GetRectangle()) || souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
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



                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                }

                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 0)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 0;
                }

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) || souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) || souris.GetRectangle().Intersects(Beffets.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);

                MediaPlayer.Volume = (float)volumemusic / 10f;
            }


            if (status == "Video")
            {

                Blangue.SetPosition(positionBoutton1);
                Bfullscreen.SetPosition(positionBoutton2);
                Bfenetre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Blangue.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    status = "Langues";
                }
                if (souris.GetRectangle().Intersects(Bfullscreen.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    fullscreen = !fullscreen;
                    graphics.ToggleFullScreen();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                }

                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
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

                if (souris.GetRectangle().Intersects(Blanguefr.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    lang = 1;
                }
                if (souris.GetRectangle().Intersects(Blangueen.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    lang = 2;
                }
                if (souris.GetRectangle().Intersects(Blangueit.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    gestionclavier = -1;
                    lang = 3;
                }


                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    status = "Video";
                }


                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
            }

            if (status == "Commandes")
            {

                Bmanette.SetPosition(positionBoutton1);
                Bbox.SetPosition(new Vector2(Bmanette.GetPosition().X + Bmanette.GetTexturefr().Width + 20, positionBoutton1.Y));

                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bmanette.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clique_clavier))
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bbox.GetRectangle()) && !souris.LeftClick() && clique_souris)
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && clique_souris || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clique_clavier) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                }


                if (!clavier.KeyPressed(Keys.Down) && clique_bas)
                {
                    if (gestionclavier < 1)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clique_haut)
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 1;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;


                clique_souris = souris.LeftClick();
                clique_clavier = clavier.KeyPressed(Keys.Enter);
                clique_bas = clavier.KeyPressed(Keys.Down);
                clique_haut = clavier.KeyPressed(Keys.Up);
                clique_back = clavier.KeyPressed(Keys.Escape);
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


            if (status == "Cinematiques")
            {
                if (elapsedtime < 5000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique1, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen1, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit1, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 5000 && elapsedtime < 10000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 10000 && elapsedtime < 15000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 15000 && elapsedtime < 20000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 20000 && elapsedtime < 25000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 25000 && elapsedtime < 30000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 30000 && elapsedtime < 35000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }

                    
            }



            if (status == "Jeu" || status == "Pause")
            {
                zombiesloins = new List<Zombie>();
                zombiesprets = new List<Zombie>();

                //sans scrolling
                //spriteBatch.Draw(background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                //avec
                spriteBatch.Draw(background, new Rectangle(Convert.ToInt32(-joueur.GetPosition().X), Convert.ToInt32(-joueur.GetPosition().Y), Window.ClientBounds.Width * 2, Window.ClientBounds.Height * 2), Color.White);

                foreach (Zombie z in zombie)
                {
                    if (z != null && !z.GetDead())
                    {
                        if (z.GetPosition().Y <= joueur.GetPosition().Y)
                            zombiesloins.Add(z);
                        else
                            zombiesprets.Add(z);
                    }
                }

                zombiesloins.Sort();
                zombiesprets.Sort();



                foreach (Zombie z in zombiesloins)
                    z.DrawZombie(spriteBatch, false/*bool 2d iso*/);

                joueur.DrawJoueur(spriteBatch, false/*idem*/);

                foreach (Zombie z in zombiesprets)
                    z.DrawZombie(spriteBatch, false/*idem*/);

                spriteBatch.Draw(HUD_arme, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 50), Color.White);
                spriteBatch.Draw(HUD_vie, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 100), Color.White);
                spriteBatch.Draw(barreson, new Rectangle(Window.ClientBounds.Width - 60 - HUD_vie.Width * 4, Window.ClientBounds.Height - 90, (int)(((float)joueur.GetHealth() / 100) * (HUD_vie.Width * 4)), HUD_vie.Height / 2), Color.White);
                spriteBatch.Draw(contourson, new Rectangle(Window.ClientBounds.Width - 60 - HUD_vie.Width * 4, Window.ClientBounds.Height - 90, HUD_vie.Width * 4, HUD_vie.Height / 2), Color.Black);
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


            if (status == "Choix_Niveau")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bfacile.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfacile.GetRectangle()) || gestionclavier == 0);
                BIntermediaire.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) || gestionclavier == 1);
                Bdifficle.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) || gestionclavier == 2);
                Bimpossible.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) || gestionclavier == 3);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 4);
            }


            if (status == "Principal")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bjouer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bjouer.GetRectangle()) || gestionclavier == 0);
                Bmulti.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmulti.GetRectangle()) || gestionclavier == 1);
                Boptions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Boptions.GetRectangle()) || gestionclavier == 2);
                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()) || gestionclavier == 3);
            }
            if (status == "Jouer")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bnouveaujeu.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || gestionclavier == 0);
                Bcontinuer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || gestionclavier == 1);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 2);
            }
            if (status == "Multi")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bcreer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcreer.GetRectangle()) || gestionclavier == 0);
                Brejoindre.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) || gestionclavier == 1);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 2);
            }
            if (status == "Options")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bvideo.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bvideo.GetRectangle()) || gestionclavier == 0);
                Baudio.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Baudio.GetRectangle()) || gestionclavier == 1);
                Bcommandes.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) || gestionclavier == 2);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 3);
            }
            if (status == "Video")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Blangue.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangue.GetRectangle()) || gestionclavier == 0);
                if (!fullscreen)
                    Bfenetre.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfenetre.GetRectangle()) || gestionclavier == 1);
                else
                    Bfullscreen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfullscreen.GetRectangle()) || gestionclavier == 1);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 2);
            }

            if (status == "Audio")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bmusique.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmusique.GetRectangle()) || gestionclavier == 0);
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
                Bmanette.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmanette.GetRectangle()) || gestionclavier == 0);
                if (jeu_manette)
                    entiermanette = 1;
                else
                    entiermanette = 2;
                Bbox.DrawButton(spriteBatch, entiermanette, false);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 1);
            }






            spriteBatch.End();

            base.Draw(gameTime);
        }// End Draw

    }// End Game1
}
