using WFS.Entities.Models;

namespace WFS.Entities.Interfaces
{
    public interface IUserContext
    {
        CurrentUser CurrentUserIdentity { get; }
        bool IsLogged { get; }
    }
}