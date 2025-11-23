using System;
using System.Collections.Generic;

namespace AstroTestPort
{
    public class SceneController
    {
        private readonly AssetLoader _assets;
        public string CurrentLevel { get; private set; }
        public int EntityCount => _entities.Count;
        private List<string> _entities = new List<string>();

        public SceneController(AssetLoader assets)
        {
            _assets = assets;
        }

        public void LoadLevel(string levelName)
        {
            Console.WriteLine($"Level Yükleniyor: {levelName}");
            CurrentLevel = levelName;
            _entities.Clear();

            if(_assets.TryGet($"level:{levelName}", out var asset))
            {
                Console.WriteLine($"Level asset bulundu: {asset}");
                
                _entities.Add("Player");
                _entities.Add("AstroBot_Alpha");
                _entities.Add("AstroBot_Beta");
            }
            else
            {
                Console.WriteLine("Level asset bulunamadı, placeholder sahne oluşturuluyor.");
                _entities.Add("Player");
            }
        }

        public void Update()
        {
           
            for (int i = 0; i < _entities.Count; i++)
            {
                
            }
        }
    }
}
