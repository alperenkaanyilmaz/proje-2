using System;
using System.Collections.Generic;

namespace AstroTestPort
{
    public class InputHandler
    {
        private HashSet<ConsoleKey> _pressed = new HashSet<ConsoleKey>();

        public void Poll()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                _pressed.Add(key);
            }
        }

        public bool IsKeyPressed(ConsoleKey key)
        {
            return _pressed.Remove(key);
        }
    }
}
