using System.Configuration;
using System.Linq;

namespace TPHSampleEntityFramework6
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = ConfigurationManager.ConnectionStrings["TPHConnString"].ConnectionString;

            using (var context = new AppContext(conn))
            {
                var pessoas = context.Disciplinas.ToList();
            }
        }
    }
}
