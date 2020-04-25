using System;
using System.Threading;
using SDL2;

namespace OrcCave
{
    public class Game
    {
        //game state
        private IGameState _gameState;
        public IGameState GameState { get => _gameState; set => _gameState = value; }

        private GameTime _gameTime;
        public GameTime GameTime { get => _gameTime; set => _gameTime = value; }

        private bool _firstStart;
        //variavel para representar a janela 
        private IntPtr _window = IntPtr.Zero;
        private int _wresolution, _hresolution;
        //renderizador
        private IntPtr _renderer;
        public IntPtr Renderer { get => _renderer; set => _renderer = value; }

        //content
        ContentManager _gameContent;
        public ContentManager GameContent { get => _gameContent; set => _gameContent = value; }

        private SpriteSheetContentManager _spriteSheetContentManager;
        public SpriteSheetContentManager SpriteSheetContentManager { get => _spriteSheetContentManager; set => _spriteSheetContentManager = value; }

        //content loaders
        IQuestLoader _questLoader;
        
        private ICharacterLoader _characterLoader;
        private IMapLoader _mapLoader;

        Quest _actualQuest;
        public Quest ActualQuest { get => _actualQuest; set => _actualQuest = value; }

        Map _actualMap;
        public Map ActualMap { get => _actualMap; set => _actualMap = value; }

        CharacterBase _player;
        public CharacterBase Player { get => _player; set => _player = value; }

        //singleton
        private static readonly object padlock = new object();
        private static Game instance = null;

        public static Game Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Game();
                    }
                    return instance;
                }
            }
        }



        Game()
        {
            GameConfig config = GameConfig.Instance;

            this._wresolution = config.Wresolution;
            this._hresolution = config.Hresolution;

            this._firstStart = true;

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            SDL_ttf.TTF_Init();

            _window = SDL.SDL_CreateWindow("OrcCave",
                        SDL.SDL_WINDOWPOS_CENTERED,
                        SDL.SDL_WINDOWPOS_CENTERED,
                        _wresolution, _hresolution,
                        SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

            Renderer = SDL.SDL_CreateRenderer(_window, -1, 0);

            this.GameState = new GameStatePlaying(this);
            this.GameTime = GameTime.Instance;

        }

        public void LoadContent()
        {
            //content management sprite sheet
            this.SpriteSheetContentManager = (new ContentManagerLoader(GameConfig.Instance)).LoadContent();

            this._questLoader = new QuestLoaderTest();
            this._characterLoader = new CharacterLoaderTest();

            //quest
            this._actualQuest = this._questLoader.LoadQuest(0);
            this._actualMap = this._actualQuest.ActualMap;

            //player
            this.Player = this._characterLoader.Load();
            this.Player.X = this.ActualMap.StartNode.BasicObject.X;
            this.Player.Y = this.ActualMap.StartNode.BasicObject.Y;

            this._gameState.LoadContent();
        }

        public void UnloadContent()
        {
            SDL.SDL_DestroyWindow(this._window);
            SDL_image.IMG_Quit();
            SDL.SDL_Quit();
            SDL_ttf.TTF_Quit();
        }

        public void Update()
        {
            this.GameState.Update();
        }

        public void Draw()
        {
            this.GameState.Draw();
        }

        public void Run()
        {
            if (_firstStart)
            {
                this._gameTime.StartClock();
                this.LoadContent();
                this._firstStart = false;
            }
            
            while (!(this._gameState is GameStateQuit))
            {
                this.Draw();

                this.Update();
                //too much fast
                //Thread.Sleep(20);
            }
        }
    }
}
