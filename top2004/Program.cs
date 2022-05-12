using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace top2004
{
    internal class Program
    {
        static UserEntities db = new UserEntities();
        static void Main(string[] args)
        {
            Task4();
        }

        static List<int> Task3()
        {
            List<int> idDocument = db.TimerArchive.Where(w => w.DocumentId != null).
                GroupBy(g => g.DocumentId)
                .Select(s => (int)s.Key)
                .ToList();

            List<Document> doc = db.Document.Where(w => idDocument.Contains(w.DocumentId)).ToList();
            return idDocument;

        }
        static void Task4()
        {
            List<int> doc = Task3();
            var data = db.Timer
                  .Where(w => w.DocumentId != null)
                  .Where(w => doc.Contains((int)w.DocumentId))
                  .Select(s => new
                  {
                      Hours = (s.DateFinish - s.DateStart).Value.Hours,
                      DocumentId = s.DocumentId

                  }).ToList();
        }
        static void Task5()
        {
            var data = db.Timer.GroupBy(g => g.UserId).Select(s => new
            {
                userid = s.Key,
                dur = s.Sum()
            });
        }
    }
}
