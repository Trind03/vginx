using System;
using System.Drawing;

namespace server
{
    internal class Command
    {
        public Command(int x, int y)
        {
            _offset_x = x;
            _offset_y = y;
            _running_status = true;
        }

        public void command_handler()
        {
            while(_running_status)
            {

                System.Console.Write("> ");
                System.Console.ReadLine();
            }
        }

        private bool _running_status;
        private string _command = String.Empty;

        // X Y cordinates for cursor position for input field.
        private int _offset_x;
        private int _offset_y;
    }
}