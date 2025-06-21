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

            context.Markers.AddRange(sampleObj);
            context.SaveChanges();
        }
    }
}
