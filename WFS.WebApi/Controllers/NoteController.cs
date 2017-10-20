namespace WFS.WebApi.Controllers
{
    using System;
    using SimpleInjector;
    using WFS.Entities;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Net.Http;
    using WFS.Entities.Models;
    using WFS.Service;
    using WFS.WebApi.Attributes;
    using WFS.Service.Services;
    using System.Collections.Generic;
    using Entities.Contracts;

    public class NoteController : ApiController
    {
        private readonly Container _container;
        public NoteController(Container container)
             : base()
        {
            _container = container;
        }


        [UserAuthorize]
        [HttpPost]
        public ServiceResult<Note> Add(Note obj)
        {
            NoteService service = new NoteService(_container);
            return service.Add(obj);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<Note> Edit(Note obj)
        {
            NoteService service = new NoteService(_container);
            return service.Edit(obj);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<Note> Retrieve(int Id)
        {
            NoteService service = new NoteService(_container);
            return service.Retrieve(Id);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<IList<Note>> GetAll()
        {
            NoteService service = new NoteService(_container);
            return service.GetAll();
        }

        [UserAuthorize]
        [HttpPost]
        public ServiceResult<IList<Note>> GetAll(string Id)
        {
            NoteService service = new NoteService(_container);
            return service.GetAll(Id);
        }
        [UserAuthorize]
        [HttpPost]
        public ServiceResult<string> Delete(int Id)
        {
            NoteService service = new NoteService(_container);
            return service.Delete(Id);
        }
    }
}
