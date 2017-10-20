namespace WFS.Domain
{
    public interface IMediator
    {
        TResult Proccess<TResult>(IQuery<TResult> query);
    }
}
