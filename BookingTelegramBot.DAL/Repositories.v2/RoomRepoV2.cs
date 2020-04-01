using BookingTelegramBot.DAL.Entities;
using BookingTelegramBot.DAL.Interfaces.v2;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTelegramBot.DAL.Repositories.v2
{
    public class RoomRepoV2 : IRoomRepo
    {
        string connectionString = null;

        public RoomRepoV2(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DbConstr");
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = await conn.QueryAsync<Room>("SELECT * FROM Rooms");
                return query.ToList();
            }
        }

        public async Task<Room> GetRoomByIdAsync(int roomId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Rooms WHERE Id = @roomId";
                var result = await conn.QueryAsync<Room>(query, new { roomId });
                return result.FirstOrDefault();
            }
        }

        public void Insert(Room room)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Rooms (Name, Description, NumberOfPersons) VALUES(@Name, @Description, @NumberOfPersons)";
                conn.Execute(query, room);
            }
        }

        public void Update(Room room)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "UPDATE Rooms SET Name = @Name WHERE Id = @Id";
                conn.Execute(query, room);
            }
        }

        public void Delete(int roomId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Rooms WHERE Id = @roomId";
                conn.Execute(query, new { roomId });
            }
        }

        public async Task<IEnumerable<Room>> GetAllWithParametersAsync()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = @"SELECT * FROM Rooms r 
LEFT JOIN RoomsParameters rp ON r.Id = rp.RoomId 
LEFT JOIN Parameters p ON rp.ParameterId = p.Id";
                var query = await conn.QueryAsync<Room, RoomParameter, Parameter, Room>(sql, (r, rp, p) =>
                {
                    if (p != null)
                    {
                        rp.Parameter = p;
                        r.RoomParameters.Add(rp);
                    }
                    return r;
                }, splitOn: "ParameterId, NameOfParameter");
                var res = query.GroupBy(r => r.Id).Select(g =>
                {
                    var groupedRoom = g.First();
                    groupedRoom.RoomParameters = g.Select(rp => rp.RoomParameters.FirstOrDefault()).ToList();
                    return groupedRoom;
                });
                return res.ToList();
            }
        }

        public async Task<IEnumerable<Room>> GetAllFreeAsync()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = @"SELECT * FROM Rooms r 
LEFT JOIN RoomsUserReservations rur ON r.Id = rur.RoomId 
LEFT JOIN UsersReservations ur ON rur.UserReservationId = ur.Id";
                var query = await conn.QueryAsync<Room, RoomUserReservation, UserReservation, Room>(sql, (r, rur, ur) =>
                {
                    if (ur != null)
                    {
                        rur.UserReservation = ur;
                        r.RoomUserReservations.Add(rur);
                    }
                    return r;
                }, splitOn: "DateTimeFrom, DateTimeTo");
                var res = query.GroupBy(r => r.Id).Select(g =>
                {
                    var groupedRoom = g.First();
                    groupedRoom.RoomUserReservations = g.Select(rp => rp.RoomUserReservations.FirstOrDefault()).ToList();
                    return groupedRoom;
                });
                return res.ToList();
            }
        }        

        public int GetRoomIdByName(string roomName)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Rooms WHERE RoomName = @roomName";
                var result = conn.Query<Room>(query, new { RoomName = roomName }).FirstOrDefault();
                return result.Id;
            }
        }       
    }
}
