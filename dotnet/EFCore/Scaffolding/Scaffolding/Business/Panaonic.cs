using Scaffolding.PData;
using Scaffolding.PModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scaffolding.Business
{
    public class Panaonic
    {
        public void test()
        {

            using var context = new QTS_PanasonicContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var s = new SysSetting() { Settingkey = "Test", Settingvalue = "1", Settingdesc = "Test", Modifyuser = "konan", Modifydate = DateTime.Now };
                context.SysSettings.Add(s);
                context.SaveChanges();

                Console.WriteLine(context.SysSettings.Count());

                throw new Exception("Test");

                var s1 = context.SysSettings.Where(s => s.Settingkey == "Test").Single();
                s1.Settingvalue += 1;
                context.SaveChanges();

                //pdb.SysSettings.Remove(s1);
                //pdb.SaveChanges();

                Console.WriteLine(context.SysSettings.Count());

                transaction.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void add()
        {
            using var context = new QTS_PanasonicContext();
            var item = context.TestTables.Where(t => t.Id == 1).Single();
            item.Value +=1;
            context.SaveChanges();
        }

        public void test2context()
        {
            using var context = new QTS_PanasonicContext();
            using var context1 = new PLS_PanasonicContext();

            Console.WriteLine(context.SysSettings.Count());
            Console.WriteLine(context1.SysSettings.Count());
        }
    }
}
