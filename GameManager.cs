using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AstroTestPort
{
    public class GameManager
    {
        private readonly Settings _settings;
        private readonly AssetLoader _assets;
        private readonly InputHandler _input;
        private readonly SceneController _scene;
        private bool _running = false;

        public GameManager(Settings settings)
        {
            _settings = settings;
            _assets = new AssetLoader();
            _input = new InputHandler();
            _scene = new SceneController(_assets);
        }

        public async Task StartAsync()
        {
            Console.WriteLine($"Ayarlanıyor: Level={_settings.StartLevel}, TargetFPS={_settings.TargetFps}");
            await _assets.InitializeAsync();

            _scene.LoadLevel(_settings.StartLevel);

            _running = true;
            var msPerFrame = 1000.0 / Math.Max(1, _settings.TargetFps);
            var sw = Stopwatch.StartNew();

            while (_running)
            {
                var frameStart = sw.ElapsedMilliseconds;
                Update();
                Render();
                var frameTime = sw.ElapsedMilliseconds - frameStart;
                var sleep = msPerFrame - frameTime;
                if (sleep > 0) Thread.Sleep((int)sleep);
            }
        }

        private void Update()
        {
            _input.Poll();
            if (_input.IsKeyPressed(ConsoleKey.Escape))
            {
                Console.WriteLine("Çıkış isteği alındı.");
                _running = false;
                return;
            }

            _scene.Update();
        }

        private void Render()
        {
            // Konsol çıktısı ile basit bir render simülasyonu
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"[{DateTime.Now:T}] Scene: {_scene.CurrentLevel} | Entities: {_scene.EntityCount}");
            Console.WriteLine("Kontroller: ESC çıkış.");
            Console.WriteLine(new string('-', 60));
        }
    }
}
