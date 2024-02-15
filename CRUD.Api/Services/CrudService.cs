﻿using CRUD.Api.Models;
using Npgsql;

namespace CRUD.Api.Services;

public class CrudService
{
    private NpgsqlConnection connection;
    
    private const string CONNECTION_STRING = "Host=localhost:5455;" +
                                             "Username=postgres;" +
                                             "Password=Code;" +
                                             "Database=Lesson";
    private const string TABLE_NAME = "Games";
    
    public CrudService()
    {
        connection = new NpgsqlConnection(CONNECTION_STRING);
        connection.Open();
    }
    
    public async Task Add(BoardGame game)
    {
        string commandText = $"INSERT INTO {TABLE_NAME} (id, Name, MinPlayers, MaxPlayers, AverageDuration) VALUES (@id, @name, @minPl, @maxPl, @avgDur)";
        await using (var cmd = new NpgsqlCommand(commandText, connection))
        {
            cmd.Parameters.AddWithValue("id", game.Id);
            cmd.Parameters.AddWithValue("name", game.Name);
            cmd.Parameters.AddWithValue("minPl", game.MinPlayers);
            cmd.Parameters.AddWithValue("maxPl", game.MaxPlayers);
            cmd.Parameters.AddWithValue("avgDur", game.AverageDuration);

            await cmd.ExecuteNonQueryAsync();
        }
    }
    
    public async Task<BoardGame> Get(int id)
    {
        string commandText = $"SELECT * FROM {TABLE_NAME} WHERE ID = @id";
        await using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection))
        {
            cmd.Parameters.AddWithValue("id", id);

            await using (NpgsqlDataReader reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                {
                    BoardGame game = ReadBoardGame(reader);
                    return game;
                }
        }
        return null;
    }
    
    private static BoardGame ReadBoardGame(NpgsqlDataReader reader)
    {
        int? id = reader["id"] as int?;
        string name = reader["name"] as string;
        short? minPlayers = reader["minplayers"] as Int16?;
        short? maxPlayers = reader["maxplayers"] as Int16?;
        short? averageDuration = reader["averageduration"] as Int16?;

        BoardGame game = new BoardGame
        {
            Id = id.Value,
            Name = name,
            MinPlayers = minPlayers.Value,
            MaxPlayers = maxPlayers.Value,
            AverageDuration = averageDuration.Value
        };
        return game;
    }
    
    public async Task Update(int id, BoardGame game)
    {
        var commandText = $@"UPDATE {TABLE_NAME}
                SET Name = @name, MinPlayers = @minPl, MaxPlayers = @maxPl, AverageDuration = @avgDur
                WHERE id = @id";

        await using (var cmd = new NpgsqlCommand(commandText, connection))
        {
            cmd.Parameters.AddWithValue("id", game.Id);
            cmd.Parameters.AddWithValue("name", game.Name);
            cmd.Parameters.AddWithValue("minPl", game.MinPlayers);
            cmd.Parameters.AddWithValue("maxPl", game.MaxPlayers);
            cmd.Parameters.AddWithValue("avgDur", game.AverageDuration);

            await cmd.ExecuteNonQueryAsync();
        }
    }
    
    
    public async Task Delete(int id)
    {
        string commandText = $"DELETE FROM {TABLE_NAME} WHERE ID=(@p)";
        await using (var cmd = new NpgsqlCommand(commandText, connection))
        {
            cmd.Parameters.AddWithValue("p", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
    
    public async Task CreateTableIfNotExists()
    {
        var sql = $"CREATE TABLE if not exists {TABLE_NAME}" +
                  $"(" +
                  $"id serial PRIMARY KEY, " +
                  $"Name VARCHAR (200) NOT NULL, " +
                  $"MinPlayers SMALLINT NOT NULL, " +
                  $"MaxPlayers SMALLINT, " +
                  $"AverageDuration SMALLINT" +
                  $")";

        using var cmd = new NpgsqlCommand(sql, connection);

        await cmd.ExecuteNonQueryAsync();
    }
    
    
}