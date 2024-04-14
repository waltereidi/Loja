namespace Dominio.loja.Interfaces.Context
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}