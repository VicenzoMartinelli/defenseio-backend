using DefenseIO.Infra.Shared.Notifications;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DefenseIO.Infra.Shared.ViewModels
{
  public class ResultWithErrors
  {
    public Notification[] Erros { get; set; }

    public ResultWithErrors(IEnumerable<Notification> erros)
    {
      Erros = erros.ToArray();
    }

    public static ResultWithErrors GetFromJson(string json)
    {
      if (string.IsNullOrEmpty(json))
      {
        return new ResultWithErrors(new List<Notification>());
      }
      return JsonConvert.DeserializeObject<ResultWithErrors>(json);
    }
  }
}
