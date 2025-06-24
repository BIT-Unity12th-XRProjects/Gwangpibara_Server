using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    class DBInitializeTest
    {
        //테스트용 스크립트
        public static void Initialize(GameDBContext context)
        {
            /*context.Markers.RemoveRange(context.Markers);
            context.SaveChanges();*/
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

            var v = new Vector3Value();
            v.X = 10;
            v.Y = 30;
            v.Z = 2;

            var r = new QuaternionValue();
            r.X = 10;
            r.Y = 30;
            r.Z = 2;
            r.W = 2;
            var s = new Vector3Value();
            s.X = 10;
            s.Y = 30;
            s.Z = 2;
            var testing = new Marker
            {
                PrefabID = 1,
                DropItemID = 2,
                AcquireStep = 3,
                RemoveStep = 11,
                Position = v,
                Rotation = r,
                Scale = s,
                MarkerSpawnType = MarkerSpawnType.OnClose,
                MarkerType = MarkerType.Clue
            };
            //context.Markers.Add(testing);
            //context.SaveChanges();
        }
    }
}
