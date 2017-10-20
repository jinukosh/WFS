namespace WFS.Domain.Query
{
    using System;
    using WFS.Domain;
    using System.Linq;
    using System.Text;
    using WFS.Domain.Query;
    using System.Data;
    using System.Xml;
    using WFS.Db;
    using Entities.Models;
    using WFS.Entities.Enumerations;
    using AutoMapper;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ChangePasswordQuery : IQuery<bool>
    {
        public int Id { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordQueryHandler : IQueryHandler<ChangePasswordQuery, bool>
    {
        private readonly DbEntities _db;
        public ChangePasswordQueryHandler()
        {
            _db = new DbEntities();
        }


        public bool Handler(ChangePasswordQuery query)
        {
            try
            {
                var obj = new WFS.Db.User();
                obj = _db.User.FirstOrDefault(x => x.Id == query.Id);
                obj.Password = query.Password;
                obj.UpdatedDate = DateTime.Now;
                _db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new ExceptionLog(LogType.DATABASE_UPDATE, LogLevel.ERROR, ex, "ChangePasswordQuery");
            }
        }
    }

}
