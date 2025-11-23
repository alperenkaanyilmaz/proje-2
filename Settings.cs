using System;
using System.IO;

namespace AstroTestPort
{
    public class Settings
    {
        public string StartLevel { get; set; } = "Main";
        public int TargetFps { get; set; } = 60;

        public static Settings Load(string path)
        {
            var s = new Settings();
            if (!File.Exists(path)) return s;
            foreach(var line in File.ReadAllLines(path))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed) || trimmed.StartsWith("#")) continue;
                var parts = trimmed.Split('=', 2);
                if(parts.Length!=2) continue;
                var key = parts[0].Trim().ToLower();
                var val = parts[1].Trim();
                if(key=="startlevel") s.StartLevel = val;
                if(key=="targetfps" && int.TryParse(val, out int fps)) s.TargetFps = fps;
            }
            return s;
        }
    }
}
