using System;


namespace GameAsteroids2
{
    /// <summary>
    /// Class contains player's score
    /// Класс, содержащий текущее количество очков игрока.
    /// </summary>
    class Score
    {
        private int _score;
        public event EventHandler ScoreChanged;


        protected virtual void OnScoreChanged()
        {
            ScoreChanged?.Invoke(this, EventArgs.Empty);
        }
        /// <summary>
        /// Field contains score. When setted calls method OnScoreChanged.
        /// Поле, содержащее очки. При присвоении вызывает метод OnScoreChanged.
        /// </summary>
        public int ScoreValue
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                OnScoreChanged();
            }
        }
    }
}
