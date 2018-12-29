using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterDal;
using CaterModel;

namespace CaterBll
{
    public partial class TableInfoBll
    {
        private TableInfoDal tableInfoDal=new TableInfoDal();

        public List<TableInfo> GetList(Dictionary<string,string> dictionary)
        {
            return tableInfoDal.GetList(dictionary);
        }

        public bool Add(TableInfo tableInfo)
        {
            return tableInfoDal.Insert(tableInfo) > 0;
        }

        public bool Edit(TableInfo tableInfo)
        {
            return tableInfoDal.Update(tableInfo) > 0;
        }

        public bool Delete(int id)
        {
            return tableInfoDal.Delete(id) > 0;
        }
    }
}
