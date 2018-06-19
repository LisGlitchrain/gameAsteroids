using System;
using System.Windows.Forms;

namespace GameAsteroids2
{
    class ArgOutOfRangeException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Shows MessageBox with message of exception.
        /// Выводит в MessageBox сообщение об ошибке.
        /// </summary>
        /// <param name="message"></param>
        public ArgOutOfRangeException(string message)
        {
            MessageBox.Show(message);
            Environment.Exit(0);
        }

    }
}
