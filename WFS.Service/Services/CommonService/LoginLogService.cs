﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WFS.Service.Services
{
    using System;
    using SimpleInjector;
    using WFS.Domain;
    using Entities.Contracts;
    using System.Linq;
    using System.Text;
    using WFS.Entities.Interfaces;
    using WFS.Domain.Query;
    using System.Data;
    using System.Xml;
    using WFS.Entities.Models;
    using WFS.Entities.Enumerations;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class LogLoginService
    {
        private readonly Container _container;
        public LogLoginService(Container container)
        {
            _container = container;
        }


        public ServiceResult<LogLogin> Add(LogLogin obj)
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                IUserContext currentUser = _container.GetInstance<IUserContext>();
                obj.IsDeleted = false;
                var query = new LogLoginAddQuery();
                query.LogLogin = obj;
                return new ServiceResult<LogLogin>(service.Proccess(query), message: ClientErrorMessage.Success(), state: ServiceResultStates.SUCCESS);
            }
            catch (ExceptionLog ex)
            {
                LoggerService.Logger.Log(_container, ex);
                return new ServiceResult<LogLogin>(result: null, message: ClientErrorMessage.Error(), state: ServiceResultStates.ERROR);
            }
        }
        public ServiceResult<LogLogin> Edit(LogLogin obj)
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                IUserContext currentUser = _container.GetInstance<IUserContext>();
                var query = new LogLoginEditQuery();
                query.LogLogin = obj;
                return new ServiceResult<LogLogin>(service.Proccess(query), message: ClientErrorMessage.Success(), state: ServiceResultStates.SUCCESS);
            }
            catch (ExceptionLog ex)
            {
                LoggerService.Logger.Log(_container, ex);
                return new ServiceResult<LogLogin>(result: null, message: ClientErrorMessage.Error(), state: ServiceResultStates.ERROR);
            }
        }
        public ServiceResult<LogLogin> Retrieve(int Id)
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                var query = new LogLoginRetrieveQuery { Id = Id };
                return new ServiceResult<LogLogin>(service.Proccess(query), message: ClientErrorMessage.Success(), state: ServiceResultStates.SUCCESS);
            }
            catch (ExceptionLog ex)
            {
                LoggerService.Logger.Log(_container, ex);
                return new ServiceResult<LogLogin>(result: null, message: ClientErrorMessage.Error(), state: ServiceResultStates.ERROR);
            }
        }
        public ServiceResult<IList<LogLogin>> GetAll()
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                var query = new LogLoginGetAllQuery();
                return new ServiceResult<IList<LogLogin>>(service.Proccess(query), message: ClientErrorMessage.Success(), state: ServiceResultStates.SUCCESS);
            }
            catch (ExceptionLog ex)
            {
                LoggerService.Logger.Log(_container, ex);
                return new ServiceResult<IList<LogLogin>>(result: null, message: ClientErrorMessage.Error(), state: ServiceResultStates.ERROR);
            }
        }
        public ServiceResult<string> Delete(int Id)
        {
            try
            {
                IMediator service = _container.GetInstance<IMediator>();
                var query = new LogLoginDeleteQuery { Id = Id };
                return new ServiceResult<string>(service.Proccess(query).ToString(), message: ClientErrorMessage.Success(), state: ServiceResultStates.SUCCESS);
            }
            catch (ExceptionLog ex)
            {
                LoggerService.Logger.Log(_container, ex);
                return new ServiceResult<string>(result: null, message: ClientErrorMessage.Error(), state: ServiceResultStates.ERROR);
            }
        }
    }
}
