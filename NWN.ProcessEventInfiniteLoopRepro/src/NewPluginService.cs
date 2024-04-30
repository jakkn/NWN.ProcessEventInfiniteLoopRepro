using System;
using Anvil.API;
using Anvil.API.Events;
using Anvil.Services;
using NLog;

namespace Repro
{
  [ServiceBinding(typeof(NewPluginService))]
  public class NewPluginService : IDisposable
  {
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public NewPluginService()
    {
      NwModule.Instance.OnStoreRequestSell += OnStoreRequestSell;
    }

    public void Dispose()
    {
      NwModule.Instance.OnStoreRequestSell -= OnStoreRequestSell;
    }

    private void OnStoreRequestSell(OnStoreRequestSell @event)
    {
      if (!@event.Result.Value || @event.Item is not NwItem item)
      {
        return;
      }

      logger.Info("{itemName}(${price}) sold by {seller} to {buyer}",
                  item.Name.StripColors(),
                  @event.Price,
                  @event.Creature?.Name,
                  @event.Store?.Name);
    }
  }
}
