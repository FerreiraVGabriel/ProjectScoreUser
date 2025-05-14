using Service.Interface;

namespace Service
{
    public class ScoreService : IScoreService
    {
        public int CalcularScore(decimal rendimentoAnual, int idade)
        {
            int score = 0;

            if (rendimentoAnual > 120000)
                score += 300;
            else if (rendimentoAnual >= 60000)
                score += 200;
            else
                score += 100;

            if (idade > 40)
                score += 200;
            else if (idade >= 25)
                score += 150;
            else
                score += 50;

            return score;
        }
    }
}
