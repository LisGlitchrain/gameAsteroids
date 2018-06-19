using System;
using System.Windows.Forms;

namespace GameAsteroids2
{
    class GameObjectException: Exception
    {
        /// <summary>
        /// Shows MessageBox of exception with message.
        /// Выводит MessageBox c сообщением об исключении.
        /// </summary>
        /// <param name="message"></param>
        public GameObjectException(string message)
        {
            MessageBox.Show(message);
        }
        
    }
}
