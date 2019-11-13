using DefenseIO.Domain.Domains.Chatting;
using DefenseIO.Domain.Domains.Users;
using DefenseIO.Domain.Domains.Users.Interfaces;
using DefenseIO.Infra.ApiConfig.Abstracts;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Chat.Data.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DefenseIO.Services.Chat.Controllers
{
  [Route("messages")]
  [Authorize]
  [ApiController]
  public class MessagesController : BaseApiController
  {
    private readonly ChatContext _chatContext;

    public MessagesController(IMediator mediator, NotificationContext notificationContext, ChatContext chatContext) : base(mediator, notificationContext)
    {
      _chatContext = chatContext;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMessageOfUser(
      [FromRoute] string id, [FromServices] ILoggedUserAcessor userLoggedAcessor)
    {
      var userType = userLoggedAcessor.Type;
      Func<ChatMessage, bool> predicate = (x) => x.ClientId == userLoggedAcessor.UserId;
      Func<ChatMessage, bool> predicateDestination = (x) => x.ProviderId == id.SafeParse();

      if (userType == UserType.Provider)
      {
        predicate = (x) => x.ProviderId == userLoggedAcessor.UserId;
        predicateDestination = (x) => x.ClientId == id.SafeParse();
      }

      var messages = _chatContext.Messages
        .Where(predicate)
        .Where(predicateDestination)
        .OrderBy(x => x.SendedAt);

      return await ResponseOkAsync(messages);
    }

    [HttpGet()]
    public async Task<IActionResult> GetNegociations([FromServices] ILoggedUserAcessor userLoggedAcessor)
    {
      var userType = userLoggedAcessor.Type;
      Func<ChatMessage, bool> predicate = (x) => x.ClientId == userLoggedAcessor.UserId;
      Func<ChatMessage, (string userId, string username)> select = (x) => (x.ProviderId.ToString(), x.DestinationUserName);

      if (userType == UserType.Provider)
      {
        predicate = (x) => x.ProviderId == userLoggedAcessor.UserId;
        select = (x) => (x.ClientId.ToString(), x.DestinationUserName);
      }

      var messages = from mess in _chatContext.Messages
                     where predicate(mess)
                     group mess by @select(mess) into grp
                     let lastMessage = grp.OrderByDescending(x => x.SendedAt).FirstOrDefault()
                     select new
                     {
                       UserId = grp.Key.userId,
                       UserName = grp.Key.username,
                       lastMessage.IsProviderSend,
                       lastMessage.Content,
                       lastMessage.IsAttachment
                     };

      return await ResponseOkAsync(messages);
    }
  }
}
