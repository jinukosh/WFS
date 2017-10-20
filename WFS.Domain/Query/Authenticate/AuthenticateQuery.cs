namespace WFS.Domain.Query
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using WFS.Domain;
    using System.Data;
    using System.Xml;
    using WFS.Db;
    using WFS.Entities.Enumerations;
    using AutoMapper;
    using Entities.Models;

    public class AuthenticateQuery : IQuery<WFS.Entities.Models.User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateQueryHandler : IQueryHandler<AuthenticateQuery, WFS.Entities.Models.User>
    {
        private readonly DbEntities _db;
        public AuthenticateQueryHandler()
        {
            _db = new DbEntities();
        }


        public WFS.Entities.Models.User Handler(AuthenticateQuery query)
        {
            try
            {
                var result = _db.User.Where(x => x.IsDeleted == false && x.Email == query.Email && x.Password == query.Password).FirstOrDefault();
                Mapper.CreateMap<WFS.Db.CommonUserType, WFS.Entities.Models.CommonUserType>();
                Mapper.CreateMap<WFS.Db.User, WFS.Entities.Models.User>().ForMember(c => c.CommonUserType, d => d.MapFrom(s => s.CommonUserType)).ForMember(c => c.User2, d => d.MapFrom(s => s.User2)).ForMember(c => c.User3, d => d.MapFrom(s => s.User3));
                return Mapper.Map<WFS.Db.User, WFS.Entities.Models.User>(result);
            }
            catch (Exception ex)
            {
                throw new ExceptionLog(LogType.DATABASE_SELECT, LogLevel.ERROR, ex, "AuthenticateQueryHandler");
            }
        }
    }
}

