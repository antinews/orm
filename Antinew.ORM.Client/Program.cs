using Antinew.ORM.DAL;
using Antinew.ORM.Model.DbModel;
using System;

namespace Antinew.ORM.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Star..");
                SqlHelper sqlHelper = new SqlHelper();
                DncIconModel icon = sqlHelper.Find<DncIconModel>(1);
                sqlHelper.Insert<DncIconModel>(new DncIconModel { });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
