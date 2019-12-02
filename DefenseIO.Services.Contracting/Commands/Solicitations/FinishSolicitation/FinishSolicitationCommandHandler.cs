using DefenseIO.Domain.Domains.Contracting.Entities.Solicitation;
using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.Shared.Extensions;
using DefenseIO.Infra.Shared.Messages;
using DefenseIO.Infra.Shared.Notifications;
using DefenseIO.Services.Contracting.Commands.Solicitations.Create;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Services.Contracting.Commands.Solicitations
{
  public class FinishSolicitationCommandHandler : IRequestHandler<FinishSolicitationCommand, bool>
  {
    private readonly NotificationContext _notificationContext;
    private readonly ISolicitationRepository _solicitationRepository;
    private readonly ISolicitationEvaluationRepository _solicitationEvaluationRepository;
    private readonly IContractingUserRepository _contractingUserRepository;

    public FinishSolicitationCommandHandler(
      NotificationContext notificationContext,
      ISolicitationRepository solicitationRepository,
      ISolicitationEvaluationRepository solicitationEvaluationRepository,
      IContractingUserRepository contractingUserRepository)
    {
      _notificationContext = notificationContext;
      _solicitationRepository = solicitationRepository;
      _solicitationEvaluationRepository = solicitationEvaluationRepository;
      _contractingUserRepository = contractingUserRepository;
    }

    public async Task<bool> Handle(FinishSolicitationCommand request, CancellationToken cancellationToken)
    {
      var solicitation = await _solicitationRepository.FindById(request.Id);

      if (solicitation == null)
      {
        _notificationContext.BadRequest(nameof(Messages.ObjectNotExists), Messages.ObjectNotExists.FormatValues("Solicitação"));
        return false;
      }
      solicitation.Status = SolicitationStatus.Finished;

      await _solicitationRepository.Update(solicitation);

      if (request.SpeedGrade.HasValue && request.ExperienceGrade.HasValue && request.EfficiencyGrade.HasValue)
      {
        var evaluation = new SolicitationEvaluation()
        {
          Id = Guid.NewGuid(),
          SolicitationId = solicitation.Id,
          ClientId = solicitation.ClientId,
          ProviderId = solicitation.ProviderId,
          Comment = request.Comment,
          EfficiencyGrade = request.EfficiencyGrade.Value,
          ExperienceGrade = request.ExperienceGrade.Value,
          SpeedGrade = request.SpeedGrade.Value,
          EvaluationDate = DateTime.Now
        };

        await _solicitationEvaluationRepository.Add(evaluation);

        var evaluationsOfProvider = (from evalt in _solicitationEvaluationRepository.Query().Concat(new SolicitationEvaluation[] { evaluation })
                                     where evalt.ProviderId == evaluation.ProviderId
                                     group evalt by evalt.ProviderId into grp
                                     select new
                                     {
                                       ProviderId = grp.Key,
                                       Rate = grp.Average(x => (x.SpeedGrade + x.ExperienceGrade + x.EfficiencyGrade) / 3)
                                     }).Single();

        var provider = await _contractingUserRepository.FindById(solicitation.ProviderId);

        provider.CurrentRating = evaluationsOfProvider.Rate;

        await _contractingUserRepository.Update(provider);
      }

      return true;
    }
  }
}
