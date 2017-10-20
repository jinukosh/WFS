using System.Security.Cryptography.X509Certificates;

namespace WFS.Domain
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handler(TQuery query);
    }
}

