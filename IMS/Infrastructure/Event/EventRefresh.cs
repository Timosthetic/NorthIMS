
using Infrastructure.Model;
using Prism.Events;
using System.Collections.Generic;

namespace Infrastructure.Event
{
   public  class EventRefresh  : PubSubEvent
    {

    }

  
  
  public class EventClearWMS : PubSubEvent<int > { }
}
