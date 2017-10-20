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
    
    public class LogDatabaseEditQuery : IQuery<WFS.Entities.Models.LogDatabase>
    {
    	public WFS.Entities.Models.LogDatabase LogDatabase{ get; set; }
    }
    
    public class LogDatabaseEditQueryHandler : IQueryHandler<LogDatabaseEditQuery, WFS.Entities.Models.LogDatabase>
    {
    	private readonly DbEntities _db;
    	public LogDatabaseEditQueryHandler()
    	{
    		_db = new DbEntities();
    	}
    
    	    
    	public WFS.Entities.Models.LogDatabase Handler(LogDatabaseEditQuery query)
    	{
    		try
    		{
    			var obj = new WFS.Db.LogDatabase();
    			obj = _db.LogDatabase.FirstOrDefault(x => x.Id == query.LogDatabase.Id);
    			obj.Id = query.LogDatabase.Id;
    			obj.UserId = query.LogDatabase.UserId;
    			obj.LogDate = query.LogDatabase.LogDate;
    			obj.LogType = query.LogDatabase.LogType;
    			obj.LogLevel = query.LogDatabase.LogLevel;
    			obj.ExceptionString = query.LogDatabase.ExceptionString;
    			obj.Comment = query.LogDatabase.Comment;
    			obj.IsDeleted = query.LogDatabase.IsDeleted;
    			_db.SaveChanges();
    			return query.LogDatabase;
    
    		}
    		catch (Exception ex)
    		{
    			throw new ExceptionLog(LogType.DATABASE_UPDATE, LogLevel.ERROR, ex, "EditQueryHandler");
    		}
    	}
    }
    
}