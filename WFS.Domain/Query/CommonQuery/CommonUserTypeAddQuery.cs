//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    
    public class CommonUserTypeAddQuery : IQuery<WFS.Entities.Models.CommonUserType>
    {
    	public WFS.Entities.Models.CommonUserType CommonUserType{ get; set; }
    }
    
    public class CommonUserTypeAddQueryHandler : IQueryHandler<CommonUserTypeAddQuery,WFS.Entities.Models.CommonUserType>
    {
    	private readonly DbEntities _db;
    	public CommonUserTypeAddQueryHandler()
    	{
    		_db = new DbEntities();
    	}
    
    	    
    	public WFS.Entities.Models.CommonUserType Handler(CommonUserTypeAddQuery query)
    	{
    		try
    		{
    			var obj = new WFS.Db.CommonUserType();
    			obj.Id = query.CommonUserType.Id;
    			obj.Name = query.CommonUserType.Name;
    			obj.IsDeleted = query.CommonUserType.IsDeleted;
    			_db.CommonUserType.Add(obj);
    			_db.SaveChanges();
    			query.CommonUserType.Id = obj.Id;
    			return query.CommonUserType;
    
    		}
    		catch (Exception ex)
    		{
    			throw new ExceptionLog(LogType.DATABASE_INSERT, LogLevel.ERROR, ex, "AddQueryHandler");
    		}
    	}
    }
    
    
}
