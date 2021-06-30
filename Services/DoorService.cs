using ClayTest.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ClayTest.Services
{
    public class DoorService
    {
        static List<Door> Doors { get; }
        static DoorService()
        {
            Doors = new List<Door>
            {
                new Door { Id = 1, Name = "Tunnel", IsLocked = true },
                new Door { Id = 2, Name = "Office", IsLocked = true }
            };
        }

        public static List<Door> GetAll() => Doors;

        public static Door Get(int id) => Doors.FirstOrDefault(p => p.Id == id);

        public static void Update(Door door)
        {
            int index = Doors.FindIndex(p => p.Id == door.Id);
            if (index == -1)
                return;

            Doors[index] = door;
        }
    }
}
