using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOne.Impl
{
    public class GameInputOutput : IGameInputOutput
    {
        public string PromptAndRead()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public void Say(string message)
        {
            Console.WriteLine(message);
        }
    }
}
