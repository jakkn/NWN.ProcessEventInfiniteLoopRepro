using Anvil.Services;

namespace Repro
{
  [ServiceBinding(typeof(NewPluginService))]
  public class NewPluginService
  {
    public NewPluginService()
    {
      // Your startup service code
    }
  }
}
