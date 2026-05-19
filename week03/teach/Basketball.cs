/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using System;
using System.Collections.Generic;
using System.Linq; // Necessary for OrderByDescending and Take
using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // ignore header row
        
        while (!reader.EndOfData) {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // If the player is not yet in the dictionary, add them with their points for this season
            if (!players.ContainsKey(playerId)) {
                players[playerId] = points;
            }
            // If the player is already in the dictionary, add the points for this season to their existing total
            else {
                players[playerId] += points;
            }
        }

        // Optional: Keeps the original line that BYU added for debugging all players
        // Console.WriteLine($"Players: {{{string.Join(", ", players)}}}");

        Console.WriteLine("\n=== TOP 10 PLAYERS WITH HIGHEST CAREER POINTS ===");

        // We can use LINQ to sort the players by their total points in descending order and take the top 10
        var sortedPlayers = players.OrderByDescending(pair => pair.Value).Take(10);

        int rank = 1;
        foreach (var player in sortedPlayers) {
            Console.WriteLine($"{rank}. Player ID: {player.Key} -> Total Points: {player.Value}");
            rank++;
        }
    }
}