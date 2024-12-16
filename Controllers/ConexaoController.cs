using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using navioasp.Models;

namespace navioasp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Conexao _conexao;

        // Injeção de dependência para receber a instância da classe Conexao
        public DatabaseController(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Endpoint para verificar a conexão com o banco de dados
        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            try
            {
                // Tentativa de conexão com o banco
                using (var connection = _conexao.GetConnection())
                {
                    connection.Open();
                    return Ok("Conexão com o banco de dados bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
