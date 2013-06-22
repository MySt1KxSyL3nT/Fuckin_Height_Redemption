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
using System.IO;

//test

namespace Fuckin__Height_Redemption
{
    // A FAIRE !
    /*
     
     * multi
     * menus a animer
     * animation mort zombie
     * améliorations des armes
     * TRADUIRE TEXTE PRITEFONT SUR SET_NOM ET RESET
     * REFAIRE TOUTES AMELIORATIONS ARMES

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
        #region variables
        public static string status; // Statut du jeu: Principal,Jouer,Multi,Options,Jeu,Pause,Creer,Rejoindre,Audio,Video,Commandes
        public static bool fullscreen; // defini si le jeu est en fullscreen ou non
        public static bool jeu_manette; // defini si la manette est activée


        public static Map map;


        public static int elapsedtime;
        public static int lang; // 1 = francais, 2 = anglais, 3 = italien, 4 = allemand
        public static int entiermanette;
        public static int last_molette; // pour comparer le chgt de valeur de la molette


        // musique
        public static bool musique;
        public static bool effets;
        public static int entiermusique;
        public static int entiereffets;
        public static int volumemusic;
        public static int volumeeffects;
        public static int oldvolumemusic;
        public static int oldvolumeeffects;

        //difficulté jeu
        public static int diff;
        public static Difficulté difficulté;

        public static string set_nom;
        public static Joueur joueur;
        public static Joueur joueur1;
        public static Joueur joueur2;
        public static List<Zombie> zombie;
        public static List<Zombie> zombiesloins;
        public static List<Zombie> zombiesprets;
        //Zombie newzombie;
        public static int nombre_zombie;


        public static MouseEvent souris;
        public static KeyboardEvent clavier;
        public static GamePadEvent manette;

        public static MouseEvent souris_old;
        public static KeyboardEvent clavier_old;
        public static GamePadEvent manette_old;

        //menu
        public static int gestionclavier;
        public static bool clique_back;




        public static Song sonprincipal;
        public static Song sonmagasin;

        //magasin
        string level1 = "";
        string level2 = "";
        string level3 = "";
        string level4 = "";
        string level5 = "";
        string level6 = "";

        string prix_amelio_usp = "";
        string prix_amelio_m3 = "";
        string prix_amelio_mp5 = "";
        string prix_amelio_ak47 = "";
        #endregion

        ////////////////////////////////////// BOUTONS ! ////////////////////////////////////////////////////////
        #region boutons
        public static Texture2D background;
        public static Texture2D backgroundmenu;
        public static Texture2D pausemenu;
        public static Texture2D menupause;
        public static Texture2D menupausa;
        public static Texture2D menupausede;
        public static Texture2D barreson;
        public static Texture2D contourson;
        public static Texture2D viseur;


        public static Texture2D magasin;
        public static Texture2D negozio;
        public static Texture2D shop;
        public static Texture2D magasinde;

        public static Texture2D mortFR;
        public static Texture2D mortEN;
        public static Texture2D mortIT;
        public static Texture2D mortDE;

        public static Texture2D victoireFR;
        public static Texture2D victoireEN;
        public static Texture2D victoireIT;
        public static Texture2D victoireDE;

        public static Texture2D HUD_vie;
        public static Texture2D HUD_usp;
        public static Texture2D HUD_ak;
        public static Texture2D HUD_mp5;
        public static Texture2D HUD_m3;


        public static Texture2D cinematique1;
        public static Texture2D cinematiqueen1;
        public static Texture2D cinematiqueit1;
        public static Texture2D cinematique1de;
        public static Texture2D cinematique2;
        public static Texture2D cinematiqueen2;
        public static Texture2D cinematiqueit2;
        public static Texture2D cinematique2de;
        public static Texture2D cinematique3;
        public static Texture2D cinematiqueen3;
        public static Texture2D cinematiqueit3;
        public static Texture2D cinematique3de;
        public static Texture2D cinematique4;
        public static Texture2D cinematiqueen4;
        public static Texture2D cinematiqueit4;
        public static Texture2D cinematique4de;
        public static Texture2D cinematique5;
        public static Texture2D cinematiqueen5;
        public static Texture2D cinematiqueit5;
        public static Texture2D cinematique5de;
        public static Texture2D cinematique6;
        public static Texture2D cinematiqueen6;
        public static Texture2D cinematiqueit6;
        public static Texture2D cinematique6de;
        public static Texture2D cinematique7;
        public static Texture2D cinematiqueen7;
        public static Texture2D cinematiqueit7;
        public static Texture2D cinematique7de;

        public static MenuButton Bjouer;
        public static MenuButton Bmulti;
        public static MenuButton Boptions;
        public static MenuButton Bquitter;
        public static MenuButton Bretour;

        public static MenuButton Bnouveaujeu;
        public static MenuButton Bcontinuer;

        public static MenuButton Bfacile;
        public static MenuButton BIntermediaire;
        public static MenuButton Bdifficle;
        public static MenuButton Bimpossible;

        public static MenuButton Bcreer;
        public static MenuButton Brejoindre;

        public static MenuButton Bvideo;
        public static MenuButton Baudio;
        public static MenuButton Bcommandes;
        public static MenuButton Bjoueur;
        public static MenuButton Bnom;
        public static MenuButton Breset;
        public static MenuButton Bsave;

        public static MenuButton Bmusique;
        public static MenuButton Beffets;
        public static MenuButton Bboxmusique;
        public static MenuButton Bboxeffects;
        public static MenuButton Bmoinsmusic;
        public static MenuButton Bplusmusic;
        public static MenuButton Bmoinseffects;
        public static MenuButton Bpluseffects;
        public static Rectangle musicbar;
        public static Rectangle effectsbar;

        public static MenuButton Blangue;
        public static MenuButton Blanguefr;
        public static MenuButton Blangueen;
        public static MenuButton Blangueit;
        public static MenuButton Blanguede;
        public static MenuButton Bfullscreen;
        public static MenuButton Bfenetre;

        public static MenuButton Bmanette;
        public static MenuButton Bbox;


        //////////////// BOUTONS armes et drogues ///////////
        public static MenuButton Bak47;
        public static MenuButton Bm3;
        public static MenuButton Bmp5;
        public static MenuButton Busp;
        public static MenuButton Bshit;
        public static MenuButton Bcoke;
        public static MenuButton Bseringue;
        /////////////////////////////////////////////////////


        public static MenuButton Bacheter;
        public static MenuButton Bmunitions;
        public static MenuButton Bameliorer;


        public static Vector2 positionBoutton1;
        public static Vector2 positionBoutton2;
        public static Vector2 positionBoutton3;
        public static Vector2 positionBoutton4;
        public static Vector2 positionBoutton5;
        #endregion

        ///////////////////////////////////////////////////// ARMES ! /////////////////////////////////////////////////////////////
        #region armes
        public static Texture2D[,] usp;
        public static Texture2D[,] ak47;
        public static Texture2D[,] mp5;
        public static Texture2D[,] m3;
        public static Texture2D[,] textures_zombies;
        #endregion

        ///////////////////////////////////////////////////// FONTS ! /////////////////////////////////////////////////////////////
        #region fonts
        public static SpriteFont hud_font;
        #endregion








        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ////////////////////////////////////// VARIABLES ! //////////////////////////////////////////////////////
            #region variables
            status = "Principal";
            fullscreen = true;
            jeu_manette = true;

            nombre_zombie = 0;

            elapsedtime = 1;
            entiermanette = 1;
            lang = 2;
            last_molette = 0;


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

            souris_old = new MouseEvent();
            clavier_old = new KeyboardEvent();
            manette_old = new GamePadEvent(PlayerIndex.One);

            gestionclavier = -1;

            sonprincipal = Content.Load<Song>("sonprincipal");
            sonmagasin = Content.Load<Song>("sonmagasin");

            #endregion

            ////////////////////////////////////// BOUTONS & IMAGES ! ////////////////////////////////////////////////
            #region boutons et images
            backgroundmenu = Content.Load<Texture2D>("menuprincipal");

            menupause = Content.Load<Texture2D>("menupause");
            pausemenu = Content.Load<Texture2D>("pausemenu");
            menupausa = Content.Load<Texture2D>("menupausa");
            menupausede = Content.Load<Texture2D>("menupause-allemand");
            barreson = Content.Load<Texture2D>("barreson");
            contourson = Content.Load<Texture2D>("contourson");
            viseur = Content.Load<Texture2D>("viseur");


            magasin = Content.Load<Texture2D>("magasin");
            negozio = Content.Load<Texture2D>("negozio");
            shop = Content.Load<Texture2D>("shop");
            magasinde = Content.Load<Texture2D>("magasin-allemand");

            mortFR = Content.Load<Texture2D>("mortFR");
            mortEN = Content.Load<Texture2D>("mortEN");
            mortIT = Content.Load<Texture2D>("mortIT");
            mortDE = Content.Load<Texture2D>("mortDE");

            victoireFR = Content.Load<Texture2D>("victoireFR");
            victoireEN = Content.Load<Texture2D>("victoireEN");
            victoireIT = Content.Load<Texture2D>("victoireIT");
            victoireDE = Content.Load<Texture2D>("victoireDE");

            HUD_vie = Content.Load<Texture2D>("vie");
            HUD_usp = Content.Load<Texture2D>("hud_usp");
            HUD_ak = Content.Load<Texture2D>("hud_ak47");
            HUD_mp5 = Content.Load<Texture2D>("hud_mp5");
            HUD_m3 = Content.Load<Texture2D>("hud_m3");

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
            cinematique1de = Content.Load<Texture2D>("cinematique1de");
            cinematique2de = Content.Load<Texture2D>("cinematique2de");
            cinematique3de = Content.Load<Texture2D>("cinematique3de");
            cinematique4de = Content.Load<Texture2D>("cinematique4de");
            cinematique5de = Content.Load<Texture2D>("cinematique5de");
            cinematique6de = Content.Load<Texture2D>("cinematique6de");
            cinematique7de = Content.Load<Texture2D>("cinematique7de");




            // principal
            Bjouer = new MenuButton(Vector2.One, Content.Load<Texture2D>("jouer"), Content.Load<Texture2D>("play"), Content.Load<Texture2D>("jouerit"), Content.Load<Texture2D>("jouer-allemand"), false);
            Bmulti = new MenuButton(Vector2.One, Content.Load<Texture2D>("multijoueur"), Content.Load<Texture2D>("multiplayer"), Content.Load<Texture2D>("multijoueurit"), Content.Load<Texture2D>("multijoueur-allemand"), false);
            Boptions = new MenuButton(Vector2.One, Content.Load<Texture2D>("options"), Content.Load<Texture2D>("options"), Content.Load<Texture2D>("optionsit"), Content.Load<Texture2D>("options-allemand"), false);
            Bquitter = new MenuButton(Vector2.One, Content.Load<Texture2D>("quitter"), Content.Load<Texture2D>("exit"), Content.Load<Texture2D>("quitterit"), Content.Load<Texture2D>("quitter-allemand"), false);
            Bretour = new MenuButton(Vector2.One, Content.Load<Texture2D>("retour"), Content.Load<Texture2D>("back"), Content.Load<Texture2D>("retourit"), Content.Load<Texture2D>("retour-allemand"), false);

            // Jouer
            Bnouveaujeu = new MenuButton(Vector2.One, Content.Load<Texture2D>("nouveaujeu"), Content.Load<Texture2D>("newgame"), Content.Load<Texture2D>("nouveaujeuit"), Content.Load<Texture2D>("nouveaujeu-allemand"), false);
            Bcontinuer = new MenuButton(Vector2.One, Content.Load<Texture2D>("continuer"), Content.Load<Texture2D>("continue"), Content.Load<Texture2D>("continuerit"), Content.Load<Texture2D>("continuer-allemand"), false);


            //Modes
            Bfacile = new MenuButton(Vector2.One, Content.Load<Texture2D>("facile"), Content.Load<Texture2D>("easy"), Content.Load<Texture2D>("facile"), Content.Load<Texture2D>("facile-allemand"), false);
            BIntermediaire = new MenuButton(Vector2.One, Content.Load<Texture2D>("intermediaire"), Content.Load<Texture2D>("intermediate"), Content.Load<Texture2D>("intermedio"), Content.Load<Texture2D>("intermediaire-allemand"), false);
            Bdifficle = new MenuButton(Vector2.One, Content.Load<Texture2D>("difficile"), Content.Load<Texture2D>("difficult"), Content.Load<Texture2D>("difficile"), Content.Load<Texture2D>("difficile-allemand"), false);
            Bimpossible = new MenuButton(Vector2.One, Content.Load<Texture2D>("impossible"), Content.Load<Texture2D>("impossible"), Content.Load<Texture2D>("impossibile"), Content.Load<Texture2D>("impossible-allemand"), false);

            // Multi
            Bcreer = new MenuButton(Vector2.One, Content.Load<Texture2D>("créer"), Content.Load<Texture2D>("create"), Content.Load<Texture2D>("creerit"), Content.Load<Texture2D>("creer-allemand"), false);
            Brejoindre = new MenuButton(Vector2.One, Content.Load<Texture2D>("rejoindre"), Content.Load<Texture2D>("join"), Content.Load<Texture2D>("rejoindreit"), Content.Load<Texture2D>("rejoindre-allemand"), false);

            //Options
            Bvideo = new MenuButton(Vector2.One, Content.Load<Texture2D>("vidéo"), Content.Load<Texture2D>("video"), Content.Load<Texture2D>("video"), Content.Load<Texture2D>("video-allemand"), false);
            Baudio = new MenuButton(Vector2.One, Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio"), Content.Load<Texture2D>("audio-allemand"), false);
            Bcommandes = new MenuButton(Vector2.One, Content.Load<Texture2D>("commandes"), Content.Load<Texture2D>("controls"), Content.Load<Texture2D>("commandesit"), Content.Load<Texture2D>("commandes-allemand"), false);
            Bjoueur = new MenuButton(Vector2.One, Content.Load<Texture2D>("joueur"), Content.Load<Texture2D>("joueurEN"), Content.Load<Texture2D>("joueurIT"), Content.Load<Texture2D>("joueurDE"), false);
            Breset = new MenuButton(Vector2.One, Content.Load<Texture2D>("reset"), Content.Load<Texture2D>("resetEN"), Content.Load<Texture2D>("resetIT"), Content.Load<Texture2D>("reinitialiserDE"), false);
            Bnom = new MenuButton(Vector2.One, Content.Load<Texture2D>("nom"), Content.Load<Texture2D>("nomEN"), Content.Load<Texture2D>("nomIT"), Content.Load<Texture2D>("nomDE"), false);
            Bsave = new MenuButton(Vector2.One, Content.Load<Texture2D>("save"), Content.Load<Texture2D>("saveEN"), Content.Load<Texture2D>("saveIT"), Content.Load<Texture2D>("sauvegarderDE"), false);

            //Audio
            Bmusique = new MenuButton(Vector2.One, Content.Load<Texture2D>("musique"), Content.Load<Texture2D>("music"), Content.Load<Texture2D>("musica"), Content.Load<Texture2D>("musique-allemand"), false);
            Beffets = new MenuButton(Vector2.One, Content.Load<Texture2D>("effetssonores"), Content.Load<Texture2D>("soundeffects"), Content.Load<Texture2D>("effettisonori"), Content.Load<Texture2D>("effetssonores-allemand"), false);
            Bboxmusique = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), false);
            Bboxeffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), false);
            Bmoinsmusic = new MenuButton(Vector2.One, Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), false);
            Bplusmusic = new MenuButton(Vector2.One, Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), false);
            Bmoinseffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), Content.Load<Texture2D>("moins"), false);
            Bpluseffects = new MenuButton(Vector2.One, Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), Content.Load<Texture2D>("plus"), false);


            // Video
            Blangue = new MenuButton(Vector2.One, Content.Load<Texture2D>("langues"), Content.Load<Texture2D>("languages"), Content.Load<Texture2D>("languesit"), Content.Load<Texture2D>("langues-allemand"), false);
            Bfullscreen = new MenuButton(Vector2.One, Content.Load<Texture2D>("pleinecran"), Content.Load<Texture2D>("fullscreen"), Content.Load<Texture2D>("pleinecranit"), Content.Load<Texture2D>("pleinecran-allemand"), false);
            Bfenetre = new MenuButton(Vector2.One, Content.Load<Texture2D>("fenetre"), Content.Load<Texture2D>("windowed"), Content.Load<Texture2D>("fenetreit"), Content.Load<Texture2D>("fenetre-allemand"), false);

            //Langues
            Blanguefr = new MenuButton(Vector2.One, Content.Load<Texture2D>("french"), Content.Load<Texture2D>("french"), Content.Load<Texture2D>("francaisit"), Content.Load<Texture2D>("francais-allemand"), false);
            Blangueen = new MenuButton(Vector2.One, Content.Load<Texture2D>("anglais"), Content.Load<Texture2D>("anglaisit"), Content.Load<Texture2D>("anglaisit"), Content.Load<Texture2D>("anglais-allemand"), false);
            Blangueit = new MenuButton(Vector2.One, Content.Load<Texture2D>("italien"), Content.Load<Texture2D>("italian"), Content.Load<Texture2D>("anglaisit"), Content.Load<Texture2D>("italien-allemand"), false);
            Blanguede = new MenuButton(Vector2.One, Content.Load<Texture2D>("allemandFR"), Content.Load<Texture2D>("allemandEN"), Content.Load<Texture2D>("allemandIT"), Content.Load<Texture2D>("italien-allemand"), false);

            // Commandes
            Bmanette = new MenuButton(Vector2.One, Content.Load<Texture2D>("manette"), Content.Load<Texture2D>("controller"), Content.Load<Texture2D>("manetteit"), Content.Load<Texture2D>("manette-allemand"), false);
            Bbox = new MenuButton(Vector2.One, Content.Load<Texture2D>("checked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), Content.Load<Texture2D>("unchecked"), false);



            // Armes & Drogues ///////////////////////////////////////
            Bak47 = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_ak47"), Content.Load<Texture2D>("hud_ak47"), Content.Load<Texture2D>("hud_ak47"), Content.Load<Texture2D>("hud_ak47"), false);
            Bm3 = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_m3"), Content.Load<Texture2D>("hud_m3"), Content.Load<Texture2D>("hud_m3"), Content.Load<Texture2D>("hud_m3"), false);
            Bmp5 = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_mp5"), Content.Load<Texture2D>("hud_mp5"), Content.Load<Texture2D>("hud_mp5"), Content.Load<Texture2D>("hud_mp5"), false);
            Busp = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_usp"), Content.Load<Texture2D>("hud_usp"), Content.Load<Texture2D>("hud_usp"), Content.Load<Texture2D>("hud_usp"), false);

            Bshit = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_shit"), Content.Load<Texture2D>("hud_shit"), Content.Load<Texture2D>("hud_shit"), Content.Load<Texture2D>("hud_shit"), true);
            Bcoke = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_coke"), Content.Load<Texture2D>("hud_coke"), Content.Load<Texture2D>("hud_coke"), Content.Load<Texture2D>("hud_coke"), true);
            Bseringue = new MenuButton(Vector2.One, Content.Load<Texture2D>("hud_seringue"), Content.Load<Texture2D>("hud_seringue"), Content.Load<Texture2D>("hud_seringue"), Content.Load<Texture2D>("hud_seringue"), true);
            ////////////////////////////////////////////////////////////////////////

            //Armes bloquées-débloquées
            Bacheter = new MenuButton(Vector2.One, Content.Load<Texture2D>("acheter"), Content.Load<Texture2D>("acheterEN"), Content.Load<Texture2D>("acheterIT"), Content.Load<Texture2D>("acheterDE"), false);
            Bmunitions = new MenuButton(Vector2.One, Content.Load<Texture2D>("munitions"), Content.Load<Texture2D>("munitionsEN"), Content.Load<Texture2D>("munitionsIT"), Content.Load<Texture2D>("munitionsDE"), false);
            Bameliorer = new MenuButton(Vector2.One, Content.Load<Texture2D>("améliorer"), Content.Load<Texture2D>("améliorerEN"), Content.Load<Texture2D>("améliorerIT"), Content.Load<Texture2D>("améliorerDE"), false);


            // Positions
            positionBoutton1 = new Vector2(16 * Window.ClientBounds.Width / 24, Window.ClientBounds.Height / 8);
            positionBoutton2 = new Vector2(positionBoutton1.X, positionBoutton1.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            positionBoutton3 = new Vector2(positionBoutton2.X, positionBoutton2.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            positionBoutton4 = new Vector2(positionBoutton3.X, positionBoutton3.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            positionBoutton5 = new Vector2(positionBoutton4.X, positionBoutton4.Y + Bjouer.GetTexturefr().Height + Window.ClientBounds.Height / 18);
            #endregion

            ///////////////////////////////////////////////////// TEXTURES ! //////////////////////////////////////////////////////////////////////
            #region textures
            usp = new Texture2D[8, 4] { { Content.Load<Texture2D>("Player_usp_0_1"), Content.Load<Texture2D>("Player_usp_0_2"), Content.Load<Texture2D>("Player_usp_0_3"), Content.Load<Texture2D>("Player_usp_0_2") }, { Content.Load<Texture2D>("Player_usp_45_1"), Content.Load<Texture2D>("Player_usp_45_2"), Content.Load<Texture2D>("Player_usp_45_3"), Content.Load<Texture2D>("Player_usp_45_2") }, { Content.Load<Texture2D>("Player_usp_90_1"), Content.Load<Texture2D>("Player_usp_90_2"), Content.Load<Texture2D>("Player_usp_90_3"), Content.Load<Texture2D>("Player_usp_90_2") }, { Content.Load<Texture2D>("Player_usp_135_1"), Content.Load<Texture2D>("Player_usp_135_2"), Content.Load<Texture2D>("Player_usp_135_3"), Content.Load<Texture2D>("Player_usp_135_2") }, { Content.Load<Texture2D>("Player_usp_180_1"), Content.Load<Texture2D>("Player_usp_180_2"), Content.Load<Texture2D>("Player_usp_180_3"), Content.Load<Texture2D>("Player_usp_180_2") }, { Content.Load<Texture2D>("Player_usp_225_1"), Content.Load<Texture2D>("Player_usp_225_2"), Content.Load<Texture2D>("Player_usp_225_3"), Content.Load<Texture2D>("Player_usp_225_2") }, { Content.Load<Texture2D>("Player_usp_270_1"), Content.Load<Texture2D>("Player_usp_270_2"), Content.Load<Texture2D>("Player_usp_270_3"), Content.Load<Texture2D>("Player_usp_270_2") }, { Content.Load<Texture2D>("Player_usp_315_1"), Content.Load<Texture2D>("Player_usp_315_2"), Content.Load<Texture2D>("Player_usp_315_3"), Content.Load<Texture2D>("Player_usp_315_2") } };
            ak47 = new Texture2D[8, 4] { { Content.Load<Texture2D>("Player_ak_0_1"), Content.Load<Texture2D>("Player_ak_0_2"), Content.Load<Texture2D>("Player_ak_0_3"), Content.Load<Texture2D>("Player_ak_0_2") }, { Content.Load<Texture2D>("Player_ak_45_1"), Content.Load<Texture2D>("Player_ak_45_2"), Content.Load<Texture2D>("Player_ak_45_3"), Content.Load<Texture2D>("Player_ak_45_2") }, { Content.Load<Texture2D>("Player_ak_90_1"), Content.Load<Texture2D>("Player_ak_90_2"), Content.Load<Texture2D>("Player_ak_90_3"), Content.Load<Texture2D>("Player_ak_90_2") }, { Content.Load<Texture2D>("Player_ak_135_1"), Content.Load<Texture2D>("Player_ak_135_2"), Content.Load<Texture2D>("Player_ak_135_3"), Content.Load<Texture2D>("Player_ak_135_2") }, { Content.Load<Texture2D>("Player_ak_180_1"), Content.Load<Texture2D>("Player_ak_180_2"), Content.Load<Texture2D>("Player_ak_180_3"), Content.Load<Texture2D>("Player_ak_180_2") }, { Content.Load<Texture2D>("Player_ak_225_1"), Content.Load<Texture2D>("Player_ak_225_2"), Content.Load<Texture2D>("Player_ak_225_3"), Content.Load<Texture2D>("Player_ak_225_2") }, { Content.Load<Texture2D>("Player_ak_270_1"), Content.Load<Texture2D>("Player_ak_270_2"), Content.Load<Texture2D>("Player_ak_270_3"), Content.Load<Texture2D>("Player_ak_270_2") }, { Content.Load<Texture2D>("Player_ak_315_1"), Content.Load<Texture2D>("Player_ak_315_2"), Content.Load<Texture2D>("Player_ak_315_3"), Content.Load<Texture2D>("Player_ak_315_2") } };
            mp5 = new Texture2D[8, 4] { { Content.Load<Texture2D>("Player_mp5_0_1"), Content.Load<Texture2D>("Player_mp5_0_2"), Content.Load<Texture2D>("Player_mp5_0_3"), Content.Load<Texture2D>("Player_mp5_0_2") }, { Content.Load<Texture2D>("Player_mp5_45_1"), Content.Load<Texture2D>("Player_mp5_45_2"), Content.Load<Texture2D>("Player_mp5_45_3"), Content.Load<Texture2D>("Player_mp5_45_2") }, { Content.Load<Texture2D>("Player_mp5_90_1"), Content.Load<Texture2D>("Player_mp5_90_2"), Content.Load<Texture2D>("Player_mp5_90_3"), Content.Load<Texture2D>("Player_mp5_90_2") }, { Content.Load<Texture2D>("Player_mp5_135_1"), Content.Load<Texture2D>("Player_mp5_135_2"), Content.Load<Texture2D>("Player_mp5_135_3"), Content.Load<Texture2D>("Player_mp5_135_2") }, { Content.Load<Texture2D>("Player_mp5_180_1"), Content.Load<Texture2D>("Player_mp5_180_2"), Content.Load<Texture2D>("Player_mp5_180_3"), Content.Load<Texture2D>("Player_mp5_180_2") }, { Content.Load<Texture2D>("Player_mp5_225_1"), Content.Load<Texture2D>("Player_mp5_225_2"), Content.Load<Texture2D>("Player_mp5_225_3"), Content.Load<Texture2D>("Player_mp5_225_2") }, { Content.Load<Texture2D>("Player_mp5_270_1"), Content.Load<Texture2D>("Player_mp5_270_2"), Content.Load<Texture2D>("Player_mp5_270_3"), Content.Load<Texture2D>("Player_mp5_270_2") }, { Content.Load<Texture2D>("Player_mp5_315_1"), Content.Load<Texture2D>("Player_mp5_315_2"), Content.Load<Texture2D>("Player_mp5_315_3"), Content.Load<Texture2D>("Player_mp5_315_2") } };
            m3 = new Texture2D[8, 4] { { Content.Load<Texture2D>("Player_m3_0_1"), Content.Load<Texture2D>("Player_m3_0_2"), Content.Load<Texture2D>("Player_m3_0_3"), Content.Load<Texture2D>("Player_m3_0_2") }, { Content.Load<Texture2D>("Player_m3_45_1"), Content.Load<Texture2D>("Player_m3_45_2"), Content.Load<Texture2D>("Player_m3_45_3"), Content.Load<Texture2D>("Player_m3_45_2") }, { Content.Load<Texture2D>("Player_m3_90_1"), Content.Load<Texture2D>("Player_m3_90_2"), Content.Load<Texture2D>("Player_m3_90_3"), Content.Load<Texture2D>("Player_m3_90_2") }, { Content.Load<Texture2D>("Player_m3_135_1"), Content.Load<Texture2D>("Player_m3_135_2"), Content.Load<Texture2D>("Player_m3_135_3"), Content.Load<Texture2D>("Player_m3_135_2") }, { Content.Load<Texture2D>("Player_m3_180_1"), Content.Load<Texture2D>("Player_m3_180_2"), Content.Load<Texture2D>("Player_m3_180_3"), Content.Load<Texture2D>("Player_m3_180_2") }, { Content.Load<Texture2D>("Player_m3_225_1"), Content.Load<Texture2D>("Player_m3_225_2"), Content.Load<Texture2D>("Player_m3_225_3"), Content.Load<Texture2D>("Player_m3_225_2") }, { Content.Load<Texture2D>("Player_m3_270_1"), Content.Load<Texture2D>("Player_m3_270_2"), Content.Load<Texture2D>("Player_m3_270_3"), Content.Load<Texture2D>("Player_m3_270_2") }, { Content.Load<Texture2D>("Player_m3_315_1"), Content.Load<Texture2D>("Player_m3_315_2"), Content.Load<Texture2D>("Player_m3_315_3"), Content.Load<Texture2D>("Player_m3_315_2") } };

            textures_zombies = new Texture2D[8, 2] { { Content.Load<Texture2D>("Zombie_0_1"), Content.Load<Texture2D>("Zombie_0_2") }, { Content.Load<Texture2D>("Zombie_45_1"), Content.Load<Texture2D>("Zombie_45_2") }, { Content.Load<Texture2D>("Zombie_90_1"), Content.Load<Texture2D>("Zombie_90_2") }, { Content.Load<Texture2D>("Zombie_135_1"), Content.Load<Texture2D>("Zombie_135_2") }, { Content.Load<Texture2D>("Zombie_180_1"), Content.Load<Texture2D>("Zombie_180_2") }, { Content.Load<Texture2D>("Zombie_225_1"), Content.Load<Texture2D>("Zombie_225_2") }, { Content.Load<Texture2D>("Zombie_270_1"), Content.Load<Texture2D>("Zombie_270_2") }, { Content.Load<Texture2D>("Zombie_315_1"), Content.Load<Texture2D>("Zombie_315_2") } };
            #endregion

            ///////////////////////////////////////////////////// FONTS ! //////////////////////////////////////////////////////////////////////
            #region fonts
            hud_font = Content.Load<SpriteFont>("SpriteFont1");
            #endregion

            //////////////////////////////////////////////////// RECUP DE LA SAVE ///////////////////////////////////////////////////////////////
            #region save
            joueur = new Joueur("solo.save", usp, ak47, mp5, m3, Content, Window.ClientBounds.Height, Window.ClientBounds.Width);

            switch (joueur.GetWeapons("usp").GetLevel())
            {
                case 1:
                    prix_amelio_usp = "1000 $";
                    break;
                case 2:
                    prix_amelio_usp = "2000 $";
                    break;
                case 3:
                    prix_amelio_usp = "3000 $";
                    break;
                case 4:
                    prix_amelio_usp = "4000 $";
                    break;
                case 5:
                    prix_amelio_usp = "5000 $";
                    break;
                default:
                    prix_amelio_usp = "Max !";
                    break;
            }

            switch (joueur.GetWeapons("m3").GetLevel())
            {
                case 1:
                    prix_amelio_m3 = "1500 $";
                    break;
                case 2:
                    prix_amelio_m3 = "2000 $";
                    break;
                case 3:
                    prix_amelio_m3 = "4000 $";
                    break;
                case 4:
                    prix_amelio_m3 = "8000 $";
                    break;
                case 5:
                    prix_amelio_m3 = "10000 $";
                    break;
                default:
                    prix_amelio_m3 = "Max !";
                    break;
            }

            switch (joueur.GetWeapons("mp5").GetLevel())
            {
                case 1:
                    prix_amelio_mp5 = "2000 $";
                    break;
                case 2:
                    prix_amelio_mp5 = "3000 $";
                    break;
                case 3:
                    prix_amelio_mp5 = "5000 $";
                    break;
                case 4:
                    prix_amelio_mp5 = "10000 $";
                    break;
                case 5:
                    prix_amelio_mp5 = "15000 $";
                    break;
                default:
                    prix_amelio_mp5 = "Max !";
                    break;
            }

            switch (joueur.GetWeapons("ak47").GetLevel())
            {
                case 1:
                    prix_amelio_ak47 = "3000 $";
                    break;
                case 2:
                    prix_amelio_ak47 = "5000 $";
                    break;
                case 3:
                    prix_amelio_ak47 = "10000 $";
                    break;
                case 4:
                    prix_amelio_ak47 = "15000 $";
                    break;
                case 5:
                    prix_amelio_ak47 = "20000 $";
                    break;
                default:
                    prix_amelio_ak47 = "Max !";
                    break;
            }

            prix_amelio_m3 = "1500 $";
            prix_amelio_mp5 = "2500 $";
            prix_amelio_ak47 = "3000 $";
            #endregion



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


            // MUSIQUE
            #region musique menu
            if (status == "Principal" || status == "Choix_Niveau" || status == "Cinematiques" || status == "Jouer" || status == "Multi" || status == "Options" || status == "Video" || status == "Audio" || status == "Commandes" || status == "Langues" || status == "Pause" || status == "Pause Options" || status == "Pause Langues" || status == "Pause Audio")
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(sonprincipal);
                }
            }

            if (status == "Magasin" || status == "M3" || status == "MP5" || status == "AK47" || status == "USP UNLOCKED" || status == "M3 UNLOCKED" || status == "MP5 UNLOCKED" || status == "AK47 UNLOCKED")
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(sonmagasin);
                }
            }
            #endregion


            // JEU 
            #region update jeu
            if (status == "Jeu")
            {
                this.IsMouseVisible = false;
                MediaPlayer.Stop();

                joueur.Update(Window.ClientBounds.Height, Window.ClientBounds.Width, gameTime);
                //map.Update(joueur);                     

                List<Zombie> todelete = new List<Zombie>();
                foreach (Zombie z in zombie)
                {
                    if (!z.GetDead())
                    {
                        z.SetMarche();
                        z.Move(joueur, zombie, gameTime.ElapsedGameTime.Milliseconds, Window.ClientBounds.Height, Window.ClientBounds.Width);
                        z.SetAngleVisee(joueur.GetRectangleCenter());
                        z.SetVisee();
                    }
                    else
                    {
                        todelete.Add(z);
                    }
                }

                foreach (Zombie z in todelete)
                    zombie.Remove(z);



                elapsedtime += gameTime.ElapsedGameTime.Milliseconds;

                if (elapsedtime / difficulté.GetMilliseconds() > nombre_zombie && nombre_zombie < difficulté.GetMaxZombies())
                {
                    zombie.Add(Zombie.SpawnZombie(Window.ClientBounds.Width, Window.ClientBounds.Height, Content, difficulté.GetMaxSpeed()));
                    nombre_zombie += 1;
                }

                if (nombre_zombie == difficulté.GetMaxZombies() && zombie.Count == 0)
                {
                    status = "Fin_victoire";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (joueur.GetHealth() <= 0)
                {
                    status = "Fin_mort";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
            }
            #endregion


            // FIN MORT
            #region fin mort
            if (status == "Fin_mort")
            {
                joueur.Save("solo.save");
                this.IsMouseVisible = true;
                Bretour.SetPosition(new Vector2((Window.ClientBounds.Width - Bretour.GetTexturefr().Width) / 2, (Window.ClientBounds.Height - Bretour.GetTexturefr().Height) / 2 + 50));
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                }
            }
            #endregion


            // FIN VICTOIRE
            #region fin victoire
            if (status == "Fin_victoire")
            {
                joueur.Save("solo.save");
                this.IsMouseVisible = true;
                Bretour.SetPosition(new Vector2((Window.ClientBounds.Width - Bretour.GetTexturefr().Width) / 2, (Window.ClientBounds.Height - Bretour.GetTexturefr().Height) / 2 + 50));
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                }
            }
            #endregion


            // MAGASIN
            #region magasin
            if (status == "Magasin")
            {
                this.IsMouseVisible = true;
                Bquitter.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));
                Busp.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 3 * Bcontinuer.GetTexturefr().Height));
                Bm3.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 4 * Bcontinuer.GetTexturefr().Height));
                Bmp5.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 5 * Bcontinuer.GetTexturefr().Height));
                Bak47.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 6 * Bcontinuer.GetTexturefr().Height));
                Bshit.SetPosition(new Vector2((5 / 2) * Bcontinuer.GetTexturefr().Width + 2 * Bak47.GetTexturefr().Width, 3 * Bcontinuer.GetTexturefr().Height));
                Bcoke.SetPosition(new Vector2((5 / 2) * Bcontinuer.GetTexturefr().Width + 2 * Bak47.GetTexturefr().Width, 4 * Bcontinuer.GetTexturefr().Height));
                Bseringue.SetPosition(new Vector2((5 / 2) * Bcontinuer.GetTexturefr().Width + 2 * Bak47.GetTexturefr().Width, 5 * Bcontinuer.GetTexturefr().Height));

                if ((souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (!clavier.KeyPressed(Keys.X) && clavier_old.KeyPressed(Keys.X)) || (!manette.IsPressed(Buttons.Back) && manette_old.IsPressed(Buttons.Back)))
                {
                    status = "Jeu";
                }


                //ARMES
                if (souris.GetRectangle().Intersects(Busp.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    status = "USP UNLOCKED";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bm3.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("m3").unlocked == false)
                        status = "M3";
                    else
                        status = "M3 UNLOCKED";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bmp5.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("mp5").unlocked == false)
                        status = "MP5";
                    else
                        status = "MP5 UNLOCKED";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bak47.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("ak47").unlocked == false)
                        status = "AK47";
                    else
                        status = "AK47 UNLOCKED";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }


                //SHIT
                if (souris.GetRectangle().Intersects(Bshit.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 200 && joueur.GetHealth() < 100)
                    {
                        joueur.ChangeHealth("shit");
                    }
                }

                //COKE
                if (souris.GetRectangle().Intersects(Bcoke.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 500 && joueur.GetHealth() < 100)
                    {
                        joueur.ChangeHealth("coke");
                    }
                }

                //SERINGUE
                if (souris.GetRectangle().Intersects(Bseringue.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 1000 && joueur.GetHealth() < 100)
                    {
                        joueur.ChangeHealth("seringue");
                    }
                }
            }

            //USP UNLOCKED
            #region usp

            if (status == "USP UNLOCKED")
            {
                this.IsMouseVisible = true;

                Busp.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bameliorer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 + Bcontinuer.GetTexturefr().Width / 3, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bmunitions.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bameliorer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("usp").GetLevel() == 1 && joueur.GetMoney() >= 1000)
                    {
                        joueur.GetWeapons("usp").AddLevel();
                        joueur.SetMoney(-1000);
                        prix_amelio_usp = "2000 $";

                        joueur.Save("solo.save");
                    }
                    else
                        if (joueur.GetWeapons("usp").GetLevel() == 2 && joueur.GetMoney() >= 2000)
                        {
                            joueur.GetWeapons("usp").AddLevel();
                            joueur.SetMoney(-2000);
                            prix_amelio_usp = "3000 $";

                            joueur.Save("solo.save");
                        }
                        else
                            if (joueur.GetWeapons("usp").GetLevel() == 3 && joueur.GetMoney() >= 3000)
                            {
                                joueur.GetWeapons("usp").AddLevel();
                                joueur.SetMoney(-3000);
                                prix_amelio_usp = "4000 $";

                                joueur.Save("solo.save");
                            }
                            else
                                if (joueur.GetWeapons("usp").GetLevel() == 4 && joueur.GetMoney() >= 4000)
                                {
                                    joueur.GetWeapons("usp").AddLevel();
                                    joueur.SetMoney(-4000);
                                    prix_amelio_usp = "5000 $";

                                    joueur.Save("solo.save");
                                }
                                else
                                    if (joueur.GetWeapons("usp").GetLevel() == 5 && joueur.GetMoney() >= 5000)
                                    {
                                        joueur.GetWeapons("usp").AddLevel();
                                        joueur.SetMoney(-5000);
                                        prix_amelio_usp = "";

                                        joueur.Save("solo.save");
                                    }
                }

                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Busp.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }

            #endregion


            //M3
            #region m3
            if (status == "M3")
            {
                this.IsMouseVisible = true;
                Bm3.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bacheter.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bacheter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 5000)
                    {
                        status = "M3 UNLOCKED";
                        joueur.GetWeapons("m3").unlocked = true;
                        joueur.Debloque_Weapon(joueur.GetWeapons("m3"));
                        souris_old = new MouseEvent();
                        clavier_old = new KeyboardEvent();

                        joueur.Save("solo.save");
                    }
                }
                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bm3.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
            }
            #endregion


            //M3 UNLOCKED
            #region m3 unlocked
            if (status == "M3 UNLOCKED")
            {
                this.IsMouseVisible = true;

                Bm3.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bameliorer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 + Bcontinuer.GetTexturefr().Width / 3, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bmunitions.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bameliorer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("m3").GetLevel() == 1 && joueur.GetMoney() >= 1500)
                    {
                        joueur.GetWeapons("m3").AddLevel();
                        joueur.SetMoney(-1500);
                        prix_amelio_m3 = "2000 $";

                        joueur.Save("solo.save");
                    }
                    else
                        if (joueur.GetWeapons("m3").GetLevel() == 2 && joueur.GetMoney() >= 2000)
                        {
                            joueur.GetWeapons("m3").AddLevel();
                            joueur.SetMoney(-2000);
                            prix_amelio_m3 = "4000 $";

                            joueur.Save("solo.save");
                        }
                        else
                            if (joueur.GetWeapons("m3").GetLevel() == 3 && joueur.GetMoney() >= 4000)
                            {
                                joueur.GetWeapons("m3").AddLevel();
                                joueur.SetMoney(-4000);
                                prix_amelio_m3 = "8000 $";

                                joueur.Save("solo.save");
                            }
                            else
                                if (joueur.GetWeapons("m3").GetLevel() == 4 && joueur.GetMoney() >= 8000)
                                {
                                    joueur.GetWeapons("m3").AddLevel();
                                    joueur.SetMoney(-8000);
                                    prix_amelio_m3 = "10000 $";

                                    joueur.Save("solo.save");
                                }
                                else
                                    if (joueur.GetWeapons("m3").GetLevel() == 5 && joueur.GetMoney() >= 10000)
                                    {
                                        joueur.GetWeapons("m3").AddLevel();
                                        joueur.SetMoney(-10000);
                                        prix_amelio_m3 = "";

                                        joueur.Save("solo.save");
                                    }
                }

                if (souris.GetRectangle().Intersects(Bmunitions.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() && joueur.GetWeapons("m3").ammo <= joueur.GetWeapons("m3").ammo_max)
                {
                    if (joueur.GetMoney() >= 500)
                    {
                        joueur.GetWeapons("m3").ammo = joueur.GetWeapons("m3").ammo_max;
                    }
                }

                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bm3.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }
            #endregion


            //MP5
            #region mp5
            if (status == "MP5")
            {
                this.IsMouseVisible = true;
                Bmp5.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bacheter.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bacheter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 10000)
                    {
                        status = "MP5 UNLOCKED";
                        joueur.GetWeapons("mp5").unlocked = true;
                        joueur.Debloque_Weapon(joueur.GetWeapons("mp5"));

                        joueur.Save("solo.save");
                    }
                }

                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bmp5.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }
            #endregion


            //MP5 UNLOCKED
            #region mp5 unlocked
            if (status == "MP5 UNLOCKED")
            {
                this.IsMouseVisible = true;
                Bmp5.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bameliorer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 + Bcontinuer.GetTexturefr().Width / 3, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bmunitions.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bameliorer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("mp5").GetLevel() == 1 && joueur.GetMoney() >= 2000)
                    {
                        joueur.GetWeapons("mp5").AddLevel();
                        joueur.SetMoney(-2000);
                        prix_amelio_mp5 = "3000 $";

                        joueur.Save("solo.save");
                    }
                    else
                        if (joueur.GetWeapons("mp5").GetLevel() == 2 && joueur.GetMoney() >= 3000)
                        {
                            joueur.GetWeapons("mp5").AddLevel();
                            joueur.SetMoney(-3000);
                            prix_amelio_mp5 = "5000 $";

                            joueur.Save("solo.save");
                        }
                        else
                            if (joueur.GetWeapons("mp5").GetLevel() == 3 && joueur.GetMoney() >= 5000)
                            {
                                joueur.GetWeapons("mp5").AddLevel();
                                joueur.SetMoney(-5000);
                                prix_amelio_mp5 = "10000 $";

                                joueur.Save("solo.save");
                            }
                            else
                                if (joueur.GetWeapons("mp5").GetLevel() == 4 && joueur.GetMoney() >= 10000)
                                {
                                    joueur.GetWeapons("mp5").AddLevel();
                                    joueur.SetMoney(-10000);
                                    prix_amelio_mp5 = "15000 $";


                                    joueur.Save("solo.save");
                                }
                                else
                                    if (joueur.GetWeapons("mp5").GetLevel() == 5 && joueur.GetMoney() >= 15000)
                                    {
                                        joueur.GetWeapons("mp5").AddLevel();
                                        joueur.SetMoney(-15000);
                                        prix_amelio_mp5 = "";

                                        joueur.Save("solo.save");
                                    }
                }

                if (souris.GetRectangle().Intersects(Bmunitions.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() && joueur.GetWeapons("mp5").ammo <= joueur.GetWeapons("mp5").ammo_max)
                {
                    if (joueur.GetMoney() >= 500)
                    {
                        joueur.GetWeapons("mp5").ammo = joueur.GetWeapons("mp5").ammo_max;
                    }
                }


                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bmp5.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }
            #endregion


            //AK47
            #region ak47
            if (status == "AK47")
            {
                this.IsMouseVisible = true;

                Bak47.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bacheter.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bacheter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetMoney() >= 50000)
                    {
                        status = "AK47 UNLOCKED";
                        joueur.GetWeapons("ak47").unlocked = true;
                        joueur.Debloque_Weapon(joueur.GetWeapons("ak47"));

                        joueur.Save("solo.save");
                    }
                }
                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bak47.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }
            #endregion


            //AK47 UNLOCKED
            #region ak47 unlocked
            if (status == "AK47 UNLOCKED")
            {
                this.IsMouseVisible = true;

                Bak47.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height));
                Bameliorer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 + Bcontinuer.GetTexturefr().Width / 3, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bmunitions.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width - 2 * Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height - 3 * Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Bameliorer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (joueur.GetWeapons("ak47").GetLevel() == 1 && joueur.GetMoney() >= 3000)
                    {
                        joueur.GetWeapons("ak47").AddLevel();
                        joueur.SetMoney(-3000);
                        prix_amelio_ak47 = "5000 $";

                        joueur.Save("solo.save");
                    }
                    else
                        if (joueur.GetWeapons("ak47").GetLevel() == 2 && joueur.GetMoney() >= 5000)
                        {
                            joueur.GetWeapons("ak47").AddLevel();
                            joueur.SetMoney(-5000);
                            prix_amelio_ak47 = "10000 $";

                            joueur.Save("solo.save");
                        }
                        else
                            if (joueur.GetWeapons("ak47").GetLevel() == 3 && joueur.GetMoney() >= 10000)
                            {
                                joueur.GetWeapons("ak47").AddLevel();
                                joueur.SetMoney(-10000);
                                prix_amelio_ak47 = "15000 $";

                                joueur.Save("solo.save");
                            }
                            else
                                if (joueur.GetWeapons("ak47").GetLevel() == 4 && joueur.GetMoney() >= 15000)
                                {
                                    joueur.GetWeapons("ak47").AddLevel();
                                    joueur.SetMoney(-15000);
                                    prix_amelio_ak47 = "20000 $";

                                    joueur.Save("solo.save");
                                }
                                else
                                    if (joueur.GetWeapons("ak47").GetLevel() == 5 && joueur.GetMoney() >= 20000)
                                    {
                                        joueur.GetWeapons("ak47").AddLevel();
                                        joueur.SetMoney(-20000);
                                        prix_amelio_ak47 = "";

                                        joueur.Save("solo.save");
                                    }
                }

                if (souris.GetRectangle().Intersects(Bmunitions.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() && joueur.GetWeapons("ak47").ammo <= joueur.GetWeapons("ak47").ammo_max)
                {
                    if (joueur.GetMoney() >= 500)
                    {
                        joueur.GetWeapons("ak47").ammo = joueur.GetWeapons("ak47").ammo_max;
                    }
                }


                if ((souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (souris.GetRectangle().Intersects(Bak47.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()))
                {
                    status = "Magasin";
                }
            }
            #endregion

            #endregion


            // MENU PRINCIPAL
            #region menu principal
            if (status == "Principal")
            {

                Bjouer.SetPosition(positionBoutton1);
                Bmulti.SetPosition(positionBoutton2);
                Boptions.SetPosition(positionBoutton3);
                Bquitter.SetPosition(positionBoutton4);


                if ((souris.GetRectangle().Intersects(Bjouer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Jouer";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if ((souris.GetRectangle().Intersects(Bmulti.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Multi";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if ((souris.GetRectangle().Intersects(Boptions.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if ((souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    this.Exit();
                }



                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bjouer.GetRectangle()) || souris.GetRectangle().Intersects(Bmulti.GetRectangle()) || souris.GetRectangle().Intersects(Boptions.GetRectangle()) || souris.GetRectangle().Intersects(Bquitter.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion


            // MENU JOUER
            #region menu jouer
            if (status == "Jouer")
            {
                Bnouveaujeu.SetPosition(positionBoutton1);
                Bcontinuer.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Choix_Niveau";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    if (zombie != null)
                    {
                        gestionclavier = -1;
                        status = "Jeu";
                        souris_old = new MouseEvent();
                        clavier_old = new KeyboardEvent();
                    }
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }


                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion


            // MENU CHOIX NIVEAU
            #region choix niveau
            if (status == "Choix_Niveau")
            {
                Bfacile.SetPosition(positionBoutton1);
                BIntermediaire.SetPosition(positionBoutton2);
                Bdifficle.SetPosition(positionBoutton3);
                Bimpossible.SetPosition(positionBoutton4);
                Bretour.SetPosition(positionBoutton5);

                if (souris.GetRectangle().Intersects(Bfacile.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 1;
                }
                if (souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 2;
                }
                if (souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 3;
                }
                if (souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Cinematiques";
                    diff = 4;
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 4 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Jouer";
                }

                elapsedtime = 1;




                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 4)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 4;
                }

                if (souris.GetRectangle().Intersects(Bfacile.GetRectangle()) || souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) || souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) || souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;
            }
            #endregion


            // CINEMATIQUES
            #region cinematiques
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
            #endregion


            // NOUVEAU JEU
            #region nouveau jeu
            if (status == "Nouveau_Jeu")
            {
                this.IsMouseVisible = false;
                MediaPlayer.Stop();
                joueur = new Joueur("solo.save", usp, ak47, mp5, m3, Content, Window.ClientBounds.Height, Window.ClientBounds.Width);
                zombie = new List<Zombie>();
                nombre_zombie = 0;
                elapsedtime = 1;
                status = "Jeu";

                map = new Map(1, Window.ClientBounds.Height, Window.ClientBounds.Width, Content);
            }
            #endregion


            // PAUSE
            #region pause
            if (status == "Pause")
            {
                Bcontinuer.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                Boptions.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bquitter.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));

                if ((souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (!clavier.KeyPressed(Keys.Escape) && clavier_old.KeyPressed(Keys.Escape)) || (!manette.IsPressed(Buttons.Start) && manette_old.IsPressed(Buttons.Start)) || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Jeu";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                    manette_old = new GamePadEvent(PlayerIndex.One);
                }
                if ((souris.GetRectangle().Intersects(Boptions.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Pause Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if ((souris.GetRectangle().Intersects(Bquitter.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick()) || (!clavier.KeyPressed(Keys.Escape) && clavier_old.KeyPressed(Keys.Escape)) || (!manette.IsPressed(Buttons.Start) && manette_old.IsPressed(Buttons.Start)) || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bquitter.GetRectangle()) || souris.GetRectangle().Intersects(Boptions.GetRectangle()))
                    gestionclavier = -1;

            }

            #region pause options
            if (status == "Pause Options")
            {
                Blangue.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                Baudio.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bretour.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));

                if (souris.GetRectangle().Intersects(Blangue.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    status = "Pause Langues";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Baudio.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    status = "Pause Audio";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    status = "Pause";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
            }
            #endregion

            #region pause langues
            if (status == "Pause Langues")
            {

                Blangueen.SetPosition(new Vector2(-10000));
                Blangueit.SetPosition(new Vector2(-10000));
                Blanguefr.SetPosition(new Vector2(-10000));
                Blanguede.SetPosition(new Vector2(-10000));
                if (lang == 1) //francais
                {
                    Blangueen.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                    Blangueit.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                    Blanguede.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                    Blangueit.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                    Blanguede.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 3) //italien
                {
                    Blanguefr.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                    Blangueen.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                    Blanguede.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 4) //allemand
                {
                    Blanguefr.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                    Blangueen.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                    Blangueit.SetPosition(new Vector2(Window.ClientBounds.Width / 2 - Bcontinuer.GetTexturefr().Width / 2, Window.ClientBounds.Height / 2 + Bcontinuer.GetTexturefr().Height));
                    Bretour.SetPosition(positionBoutton4);
                }



                if (souris.GetRectangle().Intersects(Blanguefr.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 1;
                }
                if (souris.GetRectangle().Intersects(Blangueen.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 2;
                }
                if (souris.GetRectangle().Intersects(Blangueit.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 3;
                }
                if (souris.GetRectangle().Intersects(Blanguede.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 4;
                }



                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    status = "Pause Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }




                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion

            #region pause audio
            if (status == "Pause Audio")
            {
                Bmusique.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height * 2));
                Bboxmusique.SetPosition(new Vector2(Bmusique.GetPosition().X - 40, Bmusique.GetPosition().Y + 8));
                Bmoinsmusic.SetPosition(new Vector2(Bmusique.GetPosition().X + 10 + Bmusique.GetTexturefr().Width, Bmusique.GetPosition().Y));
                Bplusmusic.SetPosition(new Vector2(Bmoinsmusic.GetPosition().X + 90 + Bmusique.GetTexturefr().Width, Bmusique.GetPosition().Y));

                Beffets.SetPosition(new Vector2(Bcontinuer.GetTexturefr().Width, Window.ClientBounds.Height / 2 - Bcontinuer.GetTexturefr().Height / 2));
                Bboxeffects.SetPosition(new Vector2(Beffets.GetPosition().X - 40, Beffets.GetPosition().Y + 8));
                Bmoinseffects.SetPosition(new Vector2(Bmusique.GetPosition().X + 10 + Bmusique.GetTexturefr().Width, Beffets.GetPosition().Y));
                Bpluseffects.SetPosition(new Vector2(Bmoinsmusic.GetPosition().X + 90 + Bmusique.GetTexturefr().Width, Beffets.GetPosition().Y));


                musicbar = new Rectangle((int)Bmoinsmusic.GetPosition().X + Bmoinsmusic.GetTexturefr().Width + 8, (int)Bmoinsmusic.GetPosition().Y + Bmoinsmusic.GetTexturefr().Height / 4, (int)(200 * (float)volumemusic / (float)10), Bmusique.GetTexturefr().Height / 2);
                effectsbar = new Rectangle((int)Bmoinsmusic.GetPosition().X + Bmoinsmusic.GetTexturefr().Width + 8, (int)Bmoinseffects.GetPosition().Y + Bmoinsmusic.GetTexturefr().Height / 4, (int)(200 * (float)volumeeffects / (float)10), Bmusique.GetTexturefr().Height / 2);


                Bretour.SetPosition(positionBoutton4);

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Bboxmusique.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Beffets.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    effets = !effets;
                }
                if (souris.GetRectangle().Intersects(Bboxeffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    effets = !effets;
                }

                //Volume du son
                if (souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumemusic < 10)
                        volumemusic += 1;
                    else
                        volumemusic = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumemusic > 0)
                        volumemusic -= 1;
                    else
                        volumemusic = 0;
                }


                if (souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumeeffects < 10)
                        volumeeffects += 1;
                    else
                        volumeeffects = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
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



                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Pause Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }



                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 0)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 0;
                }

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) || souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) || souris.GetRectangle().Intersects(Beffets.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;



                MediaPlayer.Volume = (float)volumemusic / 10f;
            }
            #endregion
            #endregion


            // MULTI
            #region multi
            if (status == "Multi")
            {
                Bcreer.SetPosition(positionBoutton1);
                Brejoindre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bcreer.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    //status = "Creer";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    //status = "Rejoindre";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bcreer.GetRectangle()) || souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;



            }
            #endregion


            // OPTIONS
            #region options
            if (status == "Options")
            {

                Bvideo.SetPosition(positionBoutton1);
                Baudio.SetPosition(positionBoutton2);
                Bjoueur.SetPosition(positionBoutton3);
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Video";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Baudio.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Audio";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bjoueur.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Options_joueur";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Principal";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) || souris.GetRectangle().Intersects(Baudio.GetRectangle()) || souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;



            }
            #endregion


            // OPTIONS_JOUEUR
            #region options_joueur
            if (status == "Options_joueur")
            {

                Bnom.SetPosition(positionBoutton1);
                Bcommandes.SetPosition(positionBoutton2);
                Breset.SetPosition(positionBoutton3);
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bnom.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Preset_nom";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Commandes";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bjoueur.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Reset";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bvideo.GetRectangle()) || souris.GetRectangle().Intersects(Baudio.GetRectangle()) || souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;



            }
            #endregion


            // SET_NOM
            #region set_nom
            if (status == "Preset_nom")
            {
                try
                {
                    set_nom = joueur.name;
                }
                catch
                {
                    set_nom = "Joueur";
                }
                status = "Set_nom";
            }


            if (status == "Set_nom")
            {
                Bretour.SetPosition(new Vector2(positionBoutton4.X - (int)(2.5f * Bretour.GetTexturefr().Width), positionBoutton4.Y));
                Bsave.SetPosition(positionBoutton4);

                if (souris.GetRectangle().Intersects(Bsave.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {

                    string[] temp = File.ReadAllLines("solo.save");
                    temp[0] = set_nom;
                    StreamWriter file = new StreamWriter("solo.save");
                    foreach (string s in temp)
                        file.WriteLine(s);
                    file.Close();

                    joueur.SetName(set_nom);

                    gestionclavier = -1;
                    status = "Options_joueur";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options_joueur";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                Keys[] keysToCheck = new Keys[] {
                    Keys.A, Keys.B, Keys.C, Keys.D, Keys.E,
                    Keys.F, Keys.G, Keys.H, Keys.I, Keys.J,
                    Keys.K, Keys.L, Keys.M, Keys.N, Keys.O,
                    Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T,
                    Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y,
                    Keys.Z, Keys.Back, Keys.Space };

                foreach (Keys key in keysToCheck)
                {
                    if (clavier_old.KeyPressed(key) && !clavier.KeyPressed(key))
                    {
                        if (set_nom.Length < 16)
                        {
                            switch (key)
                            {
                                case Keys.A:
                                    set_nom += "A";
                                    break;
                                case Keys.B:
                                    set_nom += "B";
                                    break;
                                case Keys.C:
                                    set_nom += "C";
                                    break;
                                case Keys.D:
                                    set_nom += "D";
                                    break;
                                case Keys.E:
                                    set_nom += "E";
                                    break;
                                case Keys.F:
                                    set_nom += "F";
                                    break;
                                case Keys.G:
                                    set_nom += "G";
                                    break;
                                case Keys.H:
                                    set_nom += "H";
                                    break;
                                case Keys.I:
                                    set_nom += "I";
                                    break;
                                case Keys.J:
                                    set_nom += "J";
                                    break;
                                case Keys.K:
                                    set_nom += "K";
                                    break;
                                case Keys.L:
                                    set_nom += "L";
                                    break;
                                case Keys.M:
                                    set_nom += "M";
                                    break;
                                case Keys.N:
                                    set_nom += "N";
                                    break;
                                case Keys.O:
                                    set_nom += "O";
                                    break;
                                case Keys.P:
                                    set_nom += "P";
                                    break;
                                case Keys.Q:
                                    set_nom += "Q";
                                    break;
                                case Keys.R:
                                    set_nom += "R";
                                    break;
                                case Keys.S:
                                    set_nom += "S";
                                    break;
                                case Keys.T:
                                    set_nom += "T";
                                    break;
                                case Keys.U:
                                    set_nom += "U";
                                    break;
                                case Keys.V:
                                    set_nom += "V";
                                    break;
                                case Keys.W:
                                    set_nom += "W";
                                    break;
                                case Keys.X:
                                    set_nom += "X";
                                    break;
                                case Keys.Y:
                                    set_nom += "Y";
                                    break;
                                case Keys.Z:
                                    set_nom += "Z";
                                    break;
                                case Keys.Space:
                                    set_nom += " ";
                                    break;
                            }
                        }

                        if (key == Keys.Back)
                        {
                            string temp = "";
                            for (int i = 0; i < set_nom.Length - 1; i++)
                            {
                                temp += set_nom[i];
                            }
                            set_nom = temp;
                        }

                    }
                }
            }
            #endregion


            // RESET
            #region reset
            if (status == "Reset")
            {
                Bretour.SetPosition(new Vector2((Window.ClientBounds.Width - Bretour.GetTextureen().Width) / 2, (Window.ClientBounds.Height - Bretour.GetTextureen().Height) / 2));

                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options_joueur";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.R) && clavier_old.KeyPressed(Keys.R))
                {
                    try
                    {
                        StreamWriter file = new StreamWriter("solo.save");
                        file.WriteLine("Joueur");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.Close();
                        status = "Reset_done";
                    }
                    catch
                    {
                        status = "Reset_error";
                    }
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.M) && clavier_old.KeyPressed(Keys.M))
                {
                    try
                    {
                        StreamWriter file = new StreamWriter("j1.save");
                        file.WriteLine("Joueur");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.WriteLine("0");
                        file.Close();

                        StreamWriter file2 = new StreamWriter("j2.save");
                        file2.WriteLine("Joueur");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.WriteLine("0");
                        file2.Close();

                        status = "Reset_done";
                    }
                    catch
                    {
                        status = "Reset_error";
                    }
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
            }

            if (status == "Reset_done" || status == "Reset_error")
            {
                Bretour.SetPosition(new Vector2((Window.ClientBounds.Width - Bretour.GetTextureen().Width) / 2, (Window.ClientBounds.Height - Bretour.GetTextureen().Height) / 2));

                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options_joueur";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
            }


            #endregion


            // AUDIO
            #region audio
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

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Bboxmusique.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    musique = !musique;
                }
                if (souris.GetRectangle().Intersects(Beffets.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    effets = !effets;
                }
                if (souris.GetRectangle().Intersects(Bboxeffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    effets = !effets;
                }

                //Volume du son
                if (souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumemusic < 10)
                        volumemusic += 1;
                    else
                        volumemusic = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumemusic > 0)
                        volumemusic -= 1;
                    else
                        volumemusic = 0;
                }


                if (souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    if (volumeeffects < 10)
                        volumeeffects += 1;
                    else
                        volumeeffects = 10;
                }
                if (souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
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



                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 0)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 0;
                }

                if (souris.GetRectangle().Intersects(Bmusique.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinsmusic.GetRectangle()) || souris.GetRectangle().Intersects(Bplusmusic.GetRectangle()) || souris.GetRectangle().Intersects(Beffets.GetRectangle()) || souris.GetRectangle().Intersects(Bmoinseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bpluseffects.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;



                MediaPlayer.Volume = (float)volumemusic / 10f;
            }
            #endregion


            // VIDEO
            #region video
            if (status == "Video")
            {

                Blangue.SetPosition(positionBoutton1);
                Bfullscreen.SetPosition(positionBoutton2);
                Bfenetre.SetPosition(positionBoutton2);
                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Blangue.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    status = "Langues";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }
                if (souris.GetRectangle().Intersects(Bfullscreen.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    fullscreen = !fullscreen;
                    graphics.ToggleFullScreen();
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clavier_old.KeyPressed(Keys.Escape) && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }

                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 2)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 2;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion


            // LANGUES
            #region langues
            if (status == "Langues")
            {
                Blangueen.SetPosition(new Vector2(-10000));
                Blangueit.SetPosition(new Vector2(-10000));
                Blanguefr.SetPosition(new Vector2(-10000));
                Blanguede.SetPosition(new Vector2(-10000));
                if (lang == 1) //francais
                {
                    Blangueen.SetPosition(positionBoutton1);
                    Blangueit.SetPosition(positionBoutton2);
                    Blanguede.SetPosition(positionBoutton3);
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.SetPosition(positionBoutton1);
                    Blangueit.SetPosition(positionBoutton2);
                    Blanguede.SetPosition(positionBoutton3);
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 3) //italien
                {
                    Blanguefr.SetPosition(positionBoutton1);
                    Blangueen.SetPosition(positionBoutton2);
                    Blanguede.SetPosition(positionBoutton3);
                    Bretour.SetPosition(positionBoutton4);
                }
                if (lang == 4) //allemand
                {
                    Blanguefr.SetPosition(positionBoutton1);
                    Blangueen.SetPosition(positionBoutton2);
                    Blangueit.SetPosition(positionBoutton3);
                    Bretour.SetPosition(positionBoutton4);
                }

                if (souris.GetRectangle().Intersects(Blanguefr.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 1;
                }
                if (souris.GetRectangle().Intersects(Blangueen.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 2;
                }
                if (souris.GetRectangle().Intersects(Blangueit.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 3;
                }
                if (souris.GetRectangle().Intersects(Blanguede.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 2 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    gestionclavier = -1;
                    lang = 4;
                }


                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 3 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Video";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }


                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 3)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 3;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion


            // COMMANDES
            #region commandes
            if (status == "Commandes")
            {

                Bmanette.SetPosition(positionBoutton1);
                Bbox.SetPosition(new Vector2(Bmanette.GetPosition().X + Bmanette.GetTexturefr().Width + 20, positionBoutton1.Y));

                // vide
                Bretour.SetPosition(positionBoutton4);


                if (souris.GetRectangle().Intersects(Bmanette.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 0 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)))
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bbox.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick())
                {
                    jeu_manette = !jeu_manette;
                }
                if (souris.GetRectangle().Intersects(Bretour.GetRectangle()) && !souris.LeftClick() && souris_old.LeftClick() || (gestionclavier == 1 && !clavier.KeyPressed(Keys.Enter) && clavier_old.KeyPressed(Keys.Enter)) || (clique_back && !clavier.KeyPressed(Keys.Escape)))
                {
                    gestionclavier = -1;
                    status = "Options";
                    souris_old = new MouseEvent();
                    clavier_old = new KeyboardEvent();
                }


                if (!clavier.KeyPressed(Keys.Down) && clavier_old.KeyPressed(Keys.Down))
                {
                    if (gestionclavier < 1)
                        gestionclavier += 1;
                    else
                        gestionclavier = 0;
                }
                if (!clavier.KeyPressed(Keys.Up) && clavier_old.KeyPressed(Keys.Up))
                {
                    if (gestionclavier > 0)
                        gestionclavier -= 1;
                    else
                        gestionclavier = 1;
                }

                if (souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || souris.GetRectangle().Intersects(Bretour.GetRectangle()))
                    gestionclavier = -1;

            }
            #endregion

            souris_old.UpdateMouse();
            clavier_old.UpdateKeyboard();
            manette_old.UpdateGamepad();

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

            // CINEMATIQUES
            #region cinematiques
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
                    if (lang == 4)
                        spriteBatch.Draw(cinematique1de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 5000 && elapsedtime < 10000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit2, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique2de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 10000 && elapsedtime < 15000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit3, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique3de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 15000 && elapsedtime < 20000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit4, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique4de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 20000 && elapsedtime < 25000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit5, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique5de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 25000 && elapsedtime < 30000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit6, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique6de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                if (elapsedtime >= 30000 && elapsedtime < 35000)
                {
                    if (lang == 1)
                        spriteBatch.Draw(cinematique7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 2)
                        spriteBatch.Draw(cinematiqueen7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 3)
                        spriteBatch.Draw(cinematiqueit7, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    if (lang == 4)
                        spriteBatch.Draw(cinematique7de, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
            }
            #endregion


            // JEU + PAUSE + FIN + MAGASIN + ARMES
            #region jeu
            if (status == "Jeu" || status == "Pause" || status == "Pause Options" || status == "Pause Langues" || status == "Pause Audio" || status == "Fin_mort" || status == "Fin_victoire" || status == "Magasin" || status == "M3" || status == "MP5" || status == "AK47" || status == "USP UNLOCKED" || status == "M3 UNLOCKED" || status == "MP5 UNLOCKED" || status == "AK47 UNLOCKED")
            {

                zombiesloins = new List<Zombie>();
                zombiesprets = new List<Zombie>();
                zombie.Sort();

                map.Draw(spriteBatch);

                foreach (Zombie z in zombie)
                {
                    if (!z.GetDead() && map.GetRectangle().Contains(z.GetTarget()))
                    {
                        if (z.GetPosition().Y <= joueur.GetPosition().Y)
                            zombiesloins.Add(z);
                        else
                            zombiesprets.Add(z);
                    }
                }



                foreach (Zombie z in zombiesloins)
                {
                    z.DrawZombie(spriteBatch);
                }

                joueur.DrawJoueur(spriteBatch);

                foreach (Zombie z in zombiesprets)
                {
                    z.DrawZombie(spriteBatch);
                }


                ////////////////////////////////////////////////// HUD /////////////////////////////////////////////////////////////

                switch (joueur.GetCurrentWeapon())
                {
                    case 0:
                        {
                            spriteBatch.Draw(HUD_usp, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 50), Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(HUD_ak, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 50), Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(HUD_mp5, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 50), Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(HUD_m3, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 50), Color.White);
                            break;
                        }
                }

                if (jeu_manette && manette.Connected())
                {
                    spriteBatch.Draw(viseur, new Rectangle((int)(joueur.GetRectangleCenter().X + 100 * joueur.GetVisee().X - viseur.Width / 2), (int)(joueur.GetRectangleCenter().Y + 100 * joueur.GetVisee().Y - viseur.Height / 2), viseur.Width / 2, viseur.Height / 2), Color.White);
                }
                else
                {
                    spriteBatch.Draw(viseur, new Rectangle((int)(souris.GetPosition().X - viseur.Width / 4), (int)(souris.GetPosition().Y - viseur.Height / 4), viseur.Width / 2, viseur.Height / 2), Color.White);
                }

                spriteBatch.Draw(HUD_vie, new Vector2(Window.ClientBounds.Width - 50, Window.ClientBounds.Height - 100), Color.White);
                spriteBatch.Draw(barreson, new Rectangle(Window.ClientBounds.Width - 60 - HUD_vie.Width * 4, Window.ClientBounds.Height - 90, (int)(((float)joueur.GetHealth() / 100) * (HUD_vie.Width * 4)), HUD_vie.Height / 2), Color.White);
                spriteBatch.Draw(contourson, new Rectangle(Window.ClientBounds.Width - 60 - HUD_vie.Width * 4, Window.ClientBounds.Height - 90, HUD_vie.Width * 4, HUD_vie.Height / 2), Color.Black);
                string output_money = Convert.ToString(joueur.GetMoney()) + " $";
                spriteBatch.DrawString(hud_font, output_money, new Vector2(Window.ClientBounds.Width - 35 - 13 * Convert.ToString(joueur.GetMoney()).Length, Window.ClientBounds.Height - 130), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                string output_ammos;
                if (joueur.GetWeapons()[joueur.GetCurrentWeapon()].ammo_max > 5000)
                    output_ammos = Convert.ToString(joueur.GetWeapons()[joueur.GetCurrentWeapon()].current_clip) + "/oo";
                else
                    output_ammos = Convert.ToString(joueur.GetWeapons()[joueur.GetCurrentWeapon()].current_clip) + "/" + Convert.ToString(joueur.GetWeapons()[joueur.GetCurrentWeapon()].ammo);
                spriteBatch.DrawString(hud_font, output_ammos, new Vector2(Window.ClientBounds.Width - 52 - HUD_m3.Width - 13 * (output_ammos.Length - 3), Window.ClientBounds.Height - 47), Color.White, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
            }
            #endregion


            // PAUSE
            #region pause
            if (status == "Pause")
            {
                this.IsMouseVisible = true;
                if (lang == 1)
                    spriteBatch.Draw(menupause, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                else
                {
                    if (lang == 2)
                        spriteBatch.Draw(pausemenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else if (lang == 3)
                        spriteBatch.Draw(menupausa, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else
                        spriteBatch.Draw(menupausede, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }

                Bcontinuer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()));
                Boptions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Boptions.GetRectangle()));
                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()));
            }

            #region pause options
            if (status == "Pause Options")
            {
                this.IsMouseVisible = true;
                if (lang == 1)
                    spriteBatch.Draw(menupause, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                else
                {
                    if (lang == 2)
                        spriteBatch.Draw(pausemenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else if (lang == 3)
                        spriteBatch.Draw(menupausa, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else
                        spriteBatch.Draw(menupausede, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                Blangue.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangue.GetRectangle()));
                Baudio.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Baudio.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            #endregion

            #region pause langues
            if (status == "Pause Langues")
            {
                this.IsMouseVisible = true;
                if (lang == 1)
                    spriteBatch.Draw(menupause, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                else
                {
                    if (lang == 2)
                        spriteBatch.Draw(pausemenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else if (lang == 3)
                        spriteBatch.Draw(menupausa, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else
                        spriteBatch.Draw(menupausede, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }

                if (lang == 1) //francais
                {
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 3) //italien
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 4) //allemand
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
            }
            #endregion

            #region pause audio
            if (status == "Pause Audio")
            {
                this.IsMouseVisible = true;

                if (lang == 1)
                    spriteBatch.Draw(menupause, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                else
                {
                    if (lang == 2)
                        spriteBatch.Draw(pausemenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else if (lang == 3)
                        spriteBatch.Draw(menupausa, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    else
                        spriteBatch.Draw(menupausede, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }

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
            #endregion

            #endregion


            // FIN MORT
            #region fin mort
            if (status == "Fin_mort")
            {
                switch (lang)
                {
                    case 1:
                        {
                            spriteBatch.Draw(mortFR, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(mortEN, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(mortIT, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }
                    case 4:
                        {
                            spriteBatch.Draw(mortDE, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }
                }
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            #endregion


            // FIN VICTOIRE
            #region fin victoire
            if (status == "Fin_victoire")
            {
                switch (lang)
                {
                    case 1:
                        {
                            spriteBatch.Draw(victoireFR, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(victoireEN, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(victoireIT, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }
                    case 4:
                        {
                            spriteBatch.Draw(victoireDE, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            break;
                        }
                }
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
            }
            #endregion


            // MAGASIN
            #region magasin
            if (status == "Magasin")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }

                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()));
                Busp.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Busp.GetRectangle()));
                Bak47.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bak47.GetRectangle()));
                Bm3.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bm3.GetRectangle()));
                Bmp5.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmp5.GetRectangle()));

                string _usp = "USP";
                string _m3 = "M3";
                string _mp5 = "MP5";
                string _ak47 = "AK47";
                string les_drogues = "";
                string les_armes = "";
                string prix_shit = "200 $";
                string prix_coke = "500 $";
                string prix_seringue = "1000 $";


                switch (lang)
                {
                    case 1:
                        {
                            les_armes = "Les armes :";
                            les_drogues = "Les drogues :";
                            break;
                        }


                    case 2:
                        {
                            les_armes = "Weapons:";
                            les_drogues = "Drugs:";
                            break;
                        }


                    case 3:
                        {
                            les_armes = "Le armi:";
                            les_drogues = "Le droghe:";
                            break;
                        }

                    case 4:
                        {
                            les_armes = "Die Munition:";
                            les_drogues = "Die Drogen:";
                            break;
                        }
                }


                spriteBatch.DrawString(hud_font, les_armes, new Vector2(Bcontinuer.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height), Color.DarkOrange, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);



                /*spriteBatch.DrawString(hud_font, prix_ak47, new Vector2(Bcontinuer.GetTexturefr().Width, 3 * Bcontinuer.GetTexturefr().Height), Color.Black, 0, Vector2.One, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(hud_font, prix_m3, new Vector2(Bcontinuer.GetTexturefr().Width + Bak47.GetTexturefr().Width, 4 * Bcontinuer.GetTexturefr().Height), Color.Black, 0, Vector2.One, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(hud_font, prix_mp5, new Vector2(Bcontinuer.GetTexturefr().Width + Bak47.GetTexturefr().Width, 5 * Bcontinuer.GetTexturefr().Height), Color.Black, 0, Vector2.One, 1.0f, SpriteEffects.None, 0.5f);*/

                spriteBatch.DrawString(hud_font, _usp, new Vector2(Busp.GetPosition().X + Busp.GetTexturefr().Width + 10, Busp.GetPosition().Y), Color.DarkOrange);
                spriteBatch.DrawString(hud_font, _m3, new Vector2(Bm3.GetPosition().X + Bm3.GetTexturefr().Width + 10, Bm3.GetPosition().Y), Color.DarkOrange);
                spriteBatch.DrawString(hud_font, _mp5, new Vector2(Bmp5.GetPosition().X + Bmp5.GetTexturefr().Width + 10, Bmp5.GetPosition().Y), Color.DarkOrange);
                spriteBatch.DrawString(hud_font, _ak47, new Vector2(Bak47.GetPosition().X + Bak47.GetTexturefr().Width + 10, Bak47.GetPosition().Y), Color.DarkOrange);
                spriteBatch.DrawString(hud_font, prix_shit, new Vector2(Bshit.GetPosition().X + Bshit.GetTexturefr().Width + 10, Bshit.GetPosition().Y), Color.Red);
                spriteBatch.DrawString(hud_font, prix_coke, new Vector2(Bcoke.GetPosition().X + Bcoke.GetTexturefr().Width + 10, Bcoke.GetPosition().Y), Color.Red);
                spriteBatch.DrawString(hud_font, prix_seringue, new Vector2(Bseringue.GetPosition().X + Bseringue.GetTexturefr().Width + 10, Bseringue.GetPosition().Y), Color.Red);

                Bshit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bshit.GetRectangle()));
                Bcoke.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcoke.GetRectangle()));
                Bseringue.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bseringue.GetRectangle()));


                spriteBatch.DrawString(hud_font, les_drogues, new Vector2((5 / 2) * Bcontinuer.GetTexturefr().Width + 2 * Bak47.GetTexturefr().Width, 2 * Bcontinuer.GetTexturefr().Height), Color.Red, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);

            }


            //USP UNLOCKED
            #region m3 unlocked
            if (status == "USP UNLOCKED")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }
                Busp.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Busp.GetRectangle()));
                Bameliorer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bameliorer.GetRectangle()));/////// "AMELIORER"
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                string _usp = "USP";
                spriteBatch.DrawString(hud_font, _usp, new Vector2(Busp.GetPosition().X + Busp.GetTexturefr().Width + 10, Busp.GetPosition().Y), Color.DarkOrange);


                if (joueur.GetWeapons("usp").GetLevel() == 1)
                    spriteBatch.DrawString(hud_font, level1, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("usp").GetLevel() == 2)
                    spriteBatch.DrawString(hud_font, level2, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("usp").GetLevel() == 3)
                    spriteBatch.DrawString(hud_font, level3, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("usp").GetLevel() == 4)
                    spriteBatch.DrawString(hud_font, level4, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                //lvl 5 et 6
                //
                //
                //
                //





                spriteBatch.DrawString(hud_font, prix_amelio_usp, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y + Bameliorer.GetTexturefr().Height), Color.White);
            }
            #endregion

            //M3
            #region m3
            if (status == "M3")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }

                Bm3.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bm3.GetRectangle()));
                Bacheter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bacheter.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                string _m3 = "M3";
                spriteBatch.DrawString(hud_font, _m3, new Vector2(Bm3.GetPosition().X + Bm3.GetTexturefr().Width + 10, Bm3.GetPosition().Y), Color.DarkOrange);
                string prix_m3 = "5000 $";
                spriteBatch.DrawString(hud_font, prix_m3, new Vector2(Bacheter.GetPosition().X, Bacheter.GetPosition().Y - Bacheter.GetTexturefr().Height / 2), Color.White);

            }
            #endregion


            //M3 UNLOCKED
            #region m3 unlocked
            if (status == "M3 UNLOCKED")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }
                Bm3.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bm3.GetRectangle()));
                Bameliorer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bameliorer.GetRectangle()));/////// "AMELIORER"
                Bmunitions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmunitions.GetRectangle()));//////// "MUNITIONS"
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                string _m3 = "M3";
                spriteBatch.DrawString(hud_font, _m3, new Vector2(Bm3.GetPosition().X + Bm3.GetTexturefr().Width + 10, Bm3.GetPosition().Y), Color.DarkOrange);


                if (joueur.GetWeapons("m3").GetLevel() == 1)
                    spriteBatch.DrawString(hud_font, level1, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("m3").GetLevel() == 2)
                    spriteBatch.DrawString(hud_font, level2, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("m3").GetLevel() == 3)
                    spriteBatch.DrawString(hud_font, level3, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("m3").GetLevel() == 4)
                    spriteBatch.DrawString(hud_font, level4, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);

                spriteBatch.DrawString(hud_font, prix_amelio_m3, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y + Bameliorer.GetTexturefr().Height), Color.White);
                spriteBatch.DrawString(hud_font, "500 $", new Vector2(Bmunitions.GetPosition().X, Bmunitions.GetPosition().Y + Bmunitions.GetTexturefr().Height), Color.White);
            }
            #endregion


            //MP5
            #region mp5
            if (status == "MP5")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                    Bmp5.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmp5.GetRectangle()));
                    Bacheter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bacheter.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                    string _mp5 = "MP5";
                    spriteBatch.DrawString(hud_font, _mp5, new Vector2(Bmp5.GetPosition().X + Bmp5.GetTexturefr().Width + 10, Bmp5.GetPosition().Y), Color.DarkOrange);
                    string prix_mp5 = "10000 $";
                    spriteBatch.DrawString(hud_font, prix_mp5, new Vector2(Bacheter.GetPosition().X, Bacheter.GetPosition().Y - Bacheter.GetTexturefr().Height / 2), Color.White);
                }
            }
            #endregion


            //MP5 UNLOCKED
            #region mp5 unlocked
            if (status == "MP5 UNLOCKED")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }
                Bmp5.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmp5.GetRectangle()));
                Bameliorer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bameliorer.GetRectangle()));
                Bmunitions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmunitions.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                string _mp5 = "MP5";
                spriteBatch.DrawString(hud_font, _mp5, new Vector2(Bmp5.GetPosition().X + Bmp5.GetTexturefr().Width + 10, Bmp5.GetPosition().Y), Color.DarkOrange);


                if (joueur.GetWeapons("mp5").GetLevel() == 1)
                    spriteBatch.DrawString(hud_font, level1, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("mp5").GetLevel() == 2)
                    spriteBatch.DrawString(hud_font, level2, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("mp5").GetLevel() == 3)
                    spriteBatch.DrawString(hud_font, level3, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("mp5").GetLevel() == 4)
                    spriteBatch.DrawString(hud_font, level4, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);

                spriteBatch.DrawString(hud_font, prix_amelio_mp5, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y + Bameliorer.GetTexturefr().Height), Color.White);
                spriteBatch.DrawString(hud_font, "1000 $", new Vector2(Bmunitions.GetPosition().X, Bmunitions.GetPosition().Y + Bmunitions.GetTexturefr().Height), Color.White);
            }
            #endregion


            //AK47
            #region ak47
            if (status == "AK47")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                    Bak47.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bak47.GetRectangle()));
                    Bacheter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bacheter.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                    string _ak47 = "AK47";
                    spriteBatch.DrawString(hud_font, _ak47, new Vector2(Bak47.GetPosition().X + Bak47.GetTexturefr().Width + 10, Bak47.GetPosition().Y), Color.DarkOrange);
                    string prix_ak47 = "50000 $";
                    spriteBatch.DrawString(hud_font, prix_ak47, new Vector2(Bacheter.GetPosition().X, Bacheter.GetPosition().Y - Bacheter.GetTexturefr().Height / 2), Color.White);
                }
            }
            #endregion


            //AK47 UNLOCKED
            #region ak47 unlocked
            if (status == "AK47 UNLOCKED")
            {
                if (lang == 1)
                {
                    spriteBatch.Draw(magasin, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                }
                else
                {
                    if (lang == 2)
                    {
                        spriteBatch.Draw(shop, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    }
                    else
                    {
                        if (lang == 3)
                        {
                            spriteBatch.Draw(negozio, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                        else
                        {
                            spriteBatch.Draw(magasinde, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                        }
                    }
                }
                Bak47.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bak47.GetRectangle()));
                Bameliorer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bameliorer.GetRectangle()));
                Bmunitions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmunitions.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));

                string _ak47 = "AK47";
                spriteBatch.DrawString(hud_font, _ak47, new Vector2(Bak47.GetPosition().X + Bak47.GetTexturefr().Width + 10, Bak47.GetPosition().Y), Color.DarkOrange);

                if (joueur.GetWeapons("ak47").GetLevel() == 1)
                    spriteBatch.DrawString(hud_font, level1, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("ak47").GetLevel() == 2)
                    spriteBatch.DrawString(hud_font, level2, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("ak47").GetLevel() == 3)
                    spriteBatch.DrawString(hud_font, level3, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);
                if (joueur.GetWeapons("ak47").GetLevel() == 4)
                    spriteBatch.DrawString(hud_font, level4, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y - Bameliorer.GetTexturefr().Height / 2), Color.White);

                spriteBatch.DrawString(hud_font, prix_amelio_ak47, new Vector2(Bameliorer.GetPosition().X, Bameliorer.GetPosition().Y + Bameliorer.GetTexturefr().Height), Color.White);
                spriteBatch.DrawString(hud_font, "2000 $", new Vector2(Bmunitions.GetPosition().X, Bmunitions.GetPosition().Y + Bmunitions.GetTexturefr().Height), Color.White);
            }
            #endregion

            #endregion


            // CHOIX NIVEAU
            #region choix niveau
            if (status == "Choix_Niveau")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bfacile.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bfacile.GetRectangle()) || gestionclavier == 0);
                BIntermediaire.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(BIntermediaire.GetRectangle()) || gestionclavier == 1);
                Bdifficle.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bdifficle.GetRectangle()) || gestionclavier == 2);
                Bimpossible.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bimpossible.GetRectangle()) || gestionclavier == 3);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 4);
            }
            #endregion


            // PRINCIPAL
            #region principal
            if (status == "Principal")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bjouer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bjouer.GetRectangle()) || gestionclavier == 0);
                Bmulti.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bmulti.GetRectangle()) || gestionclavier == 1);
                Boptions.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Boptions.GetRectangle()) || gestionclavier == 2);
                Bquitter.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bquitter.GetRectangle()) || gestionclavier == 3);
            }
            #endregion


            // JOUER
            #region jouer
            if (status == "Jouer")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bnouveaujeu.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bnouveaujeu.GetRectangle()) || gestionclavier == 0);
                Bcontinuer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcontinuer.GetRectangle()) || gestionclavier == 1);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 2);
            }
            #endregion


            // MULTI
            #region multi
            if (status == "Multi")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bcreer.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcreer.GetRectangle()) || gestionclavier == 0);
                Brejoindre.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Brejoindre.GetRectangle()) || gestionclavier == 1);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 2);
            }
            #endregion


            // OPTIONS
            #region options
            if (status == "Options")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bvideo.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bvideo.GetRectangle()) || gestionclavier == 0);
                Baudio.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Baudio.GetRectangle()) || gestionclavier == 1);
                Bjoueur.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bjoueur.GetRectangle()) || gestionclavier == 2);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 3);
            }
            #endregion


            // OPTIONS_JOUEUR
            #region options
            if (status == "Options_joueur")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bnom.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bnom.GetRectangle()) || gestionclavier == 0);
                Bcommandes.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bcommandes.GetRectangle()) || gestionclavier == 1);
                Breset.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Breset.GetRectangle()) || gestionclavier == 2);
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()) || gestionclavier == 3);
            }
            #endregion

            // SET_NOM
            #region set_nom
            if (status == "Set_nom")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                Bsave.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bsave.GetRectangle()));
                Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                if (lang == 1)
                {
                    spriteBatch.DrawString(hud_font, "Choisis ton nom ici", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "(1-15 chars et lettres/chiffres uniquement)", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "nom : " + set_nom, new Vector2(Window.ClientBounds.Width / 2 - 120, Window.ClientBounds.Height / 3), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                }
                if (lang == 2)
                {
                    spriteBatch.DrawString(hud_font, "Choose your name here", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "(1-15 chars and letters/numbers only)", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "name: " + set_nom, new Vector2(Window.ClientBounds.Width / 2 - 120, Window.ClientBounds.Height / 3), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                }
                if (lang == 3)
                {
                    spriteBatch.DrawString(hud_font, "Scegli il tuo nome qui", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "(1-15 chars and letters/numbers solo)", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "nome: " + set_nom, new Vector2(Window.ClientBounds.Width / 2 - 120, Window.ClientBounds.Height / 3), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                }
                if (lang == 4)
                {
                    spriteBatch.DrawString(hud_font, "Wahlen Sie hier Ihren Namen", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "(1-15 Zeichen und Buchstaben / Zahlen nur)", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                    spriteBatch.DrawString(hud_font, "Name: " + set_nom, new Vector2(Window.ClientBounds.Width / 2 - 120, Window.ClientBounds.Height / 3), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                }
            }
            #endregion


            // RESET
            #region reset
            switch (lang)
            {
                case 1:
                    {
                        if (status == "Reset")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Tes données vont être réinitialisées", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                            spriteBatch.DrawString(hud_font, "Appuie sur \"R\" pour réinitialiser le solo et \"M\" pour le multi", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_done")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Sauvegarde réussie, réinitialisation", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_error")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Erreur rencontrée, réessaie.", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }
                        break;
                    }
                case 2:
                    {
                        if (status == "Reset")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "You will reset your saves", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                            spriteBatch.DrawString(hud_font, "Press \"R\" to reset solo and \"M\" for multi", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_done")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Save successfully reset!", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_error")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "An error occured, please retry.", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }
                        break;
                    }
                case 3:
                    {
                        if (status == "Reset")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "I tuoi dati saranno resettati", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                            spriteBatch.DrawString(hud_font, "Preme \"R\" per azzezare il solo e \"M\" per il multi", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_done")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Salvataggio riuscito, rinizializzazione!", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_error")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Errore, prova di nuovo..", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }
                        break;
                    }
                case 4:
                    {
                        if (status == "Reset")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Sie setzen Ihre Backups", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                            spriteBatch.DrawString(hud_font, "Drücken Sie \"R\" um solo und \"M\" um Multi zuruckgesetzt", new Vector2(Window.ClientBounds.Width / 2 - 200, Window.ClientBounds.Height / 6), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_done")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Sie haben sich erfolgreich zurück!", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }

                        if (status == "Reset_error")
                        {
                            spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                            Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                            spriteBatch.DrawString(hud_font, "Ein Fehler ist aufgetreten, bitte versuchen Sie es erneut.", new Vector2(Window.ClientBounds.Width / 2 - 100, Window.ClientBounds.Height / 10), Color.Black, 0, Vector2.Zero, 1.0f, SpriteEffects.None, 0.5f);
                        }
                        break;
                    }
            }
            #endregion


            // VIDEO
            #region video
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
            #endregion


            // AUDIO
            #region audio
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
            #endregion


            // LANGUES
            #region langues
            if (status == "Langues")
            {
                spriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                if (lang == 1) //francais
                {
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 2) //anglais
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 3) //italien
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blanguede.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguede.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
                if (lang == 4) //allemand
                {
                    Blanguefr.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blanguefr.GetRectangle()));
                    Blangueen.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueen.GetRectangle()));
                    Blangueit.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Blangueit.GetRectangle()));
                    Bretour.DrawButton(spriteBatch, lang, souris.GetRectangle().Intersects(Bretour.GetRectangle()));
                }
            }
            #endregion


            // COMMANDES
            #region commandes
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
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }// End Draw

    }// End Game1
}
