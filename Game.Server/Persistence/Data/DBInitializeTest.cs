using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    class DBInitializeTest
    {
        public static void Initialize(GameDBContext context)
        {
            var sampleObj = new Marker
            {
                ID = 1,
                Name = "hambugi",
                DropItemID = 1,
                AcquireStep = 1,
                RemoveStep = 3
            };

            Marker? m = context.Markers
                .AsNoTracking()
                .SingleOrDefault(p => p.ID == 1);
            if(m!=null)
                Console.WriteLine("부기부기" + m.Name);
            //context.Markers.AddRange(sampleObj);
            //context.SaveChanges();
        }
    }
}
