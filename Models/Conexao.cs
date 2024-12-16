using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;

public class Conexao
{
    private readonly string _connectionString;

    // Construtor recebe o IConfiguration para acessar a string de conexão
    public Conexao(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    // Método para obter uma nova conexão MySQL
    public MySqlConnection GetConnection()
    {
        try
        {
            // Retorna uma nova conexão MySQL com a string de conexão carregada
            return new MySqlConnection(_connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            throw;
        }
    }
}
