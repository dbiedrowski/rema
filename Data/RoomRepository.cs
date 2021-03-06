﻿using REMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REMA.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _context;

        public RoomRepository(AppDbContext context)
        {
            _context = context;
        }
        public Room Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return room;
        }

        public Room Delete(int roomId)
        {
            Room room = GetById(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }

            return room;
        }

        public IEnumerable<Room> GetByApartment(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public Room GetById(int roomId)
        {
            Room room = _context.Rooms.FirstOrDefault<Room>(r => r.RoomId == roomId);
            return room;
        }

        public Room Update(Room room)
        {
            Room current = GetById(room.RoomId);
            if(current != null)
            {
                current.Area = room.Area;
                current.IsFurnished = room.IsFurnished;
                current.Price = room.Price;
                current.RoomType = room.RoomType;

                _context.SaveChanges();
            }
            
            return room;
        }
    }
}
