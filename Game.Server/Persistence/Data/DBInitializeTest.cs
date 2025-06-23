using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    class DBInitializeTest
    {
        public static void Initialize(GameDBContext context)
        {
            //context.Markers.RemoveRange(context.Markers);
            //context.SaveChanges();
            //var sampleObj = new Marker
            //{
            //    ID = 1,
            //    Name = "hambugi",
            //    DropItemID = 1,
            //    AcquireStep = 1,
            //    RemoveStep = 3
            //};

            //Marker? m = context.Markers
            //    .AsNoTracking()
            //    .SingleOrDefault(p => p.ID == 1);
            //if(m!=null)
            //    Console.WriteLine("부기부기" + m.Name);
            //context.Markers.AddRange(sampleObj);
            //context.SaveChanges();

            //var v = new Vector3Value();
            //v.X = 10;
            //v.Y = 30;
            //v.Z = 2;
            //var testing = new Marker
            //{
            //    PrefabID = 1,
            //    DropItemID = 2,
            //    AcquireStep = 3,
            //    RemoveStep = 11,
            //    Position = v

            //};
            //context.Markers.Add(testing);
            //context.SaveChanges();
        }
    }
}
