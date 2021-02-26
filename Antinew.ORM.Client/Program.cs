using Antinew.ORM.DAL;
using Antinew.ORM.Model.DbModel;
using System;
using System.Threading;

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
                UserModel user = sqlHelper.Find<UserModel>(1);
                user.ModifyTime = DateTime.Now;
                user.UserAge = 210;
                sqlHelper.Update<UserModel>(user);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
