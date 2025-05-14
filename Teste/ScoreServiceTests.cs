using Service;
using Xunit;

namespace ClienteScore.Tests
{
    public class ScoreServiceTests
    {
        private readonly ScoreService _scoreService;

        public ScoreServiceTests()
        {
            _scoreService = new ScoreService();
        }

        [Theory]
        [InlineData(130000, 45, 500)] 
        [InlineData(80000, 35, 350)]  
        [InlineData(59000, 22, 150)]  
        [InlineData(60000, 25, 350)]  
        [InlineData(120000, 40, 350)] 
        public void CalcularScore_DeveRetornarPontuacaoCorreta(decimal rendimentoAnual, int idade, int scoreEsperado)
        {
            // Act
            var resultado = _scoreService.CalcularScore(rendimentoAnual, idade);

            // Assert
            Assert.Equal(scoreEsperado, resultado);
        }
    }
}
