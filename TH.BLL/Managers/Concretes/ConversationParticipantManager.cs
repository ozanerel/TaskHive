using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TH.BLL.Managers.Abstracts;
using TH.DAL.Repositories.Abstracts;
using TH.ENTITIES.Enums;
using TH.ENTITIES.Models;

namespace TH.BLL.Managers.Concretes
{
    public class ConversationParticipantManager
        : BaseManager<ConversationParticipant>,
          IConversationParticipantManager
    {

        private readonly IConversationParticipantRepository _repository;

        public ConversationParticipantManager(
            IConversationParticipantRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public async System.Threading.Tasks.Task AddParticipantAsync(
            int conversationId,
            int userId)
        {
            if (conversationId <= 0 || userId <= 0)
            {
                return;
            }

            // Daha önce eklenmiş kullanıcıyı kontrol ediyoruz.
            // Where metodu silinmiş kayıtları da getirebildiği için
            // daha önce silinmiş bir katılımcıyı tekrar aktif edebiliriz.
            var existingParticipant = _repository
                .Where(x =>
                    x.ConversationId == conversationId &&
                    x.UserId == userId)
                .FirstOrDefault();

            if (existingParticipant != null)
            {
                // Katılımcı daha önce silinmişse tekrar aktif ediyoruz.
                if (existingParticipant.Status == DataStatus.Deleted)
                {
                    existingParticipant.Status = DataStatus.Updated;
                    existingParticipant.DeletedDate = null;

                    await base.UpdateAsync(existingParticipant);
                }

                // Zaten aktifse tekrar eklemiyoruz.
                return;
            }

            var participant = new ConversationParticipant
            {
                ConversationId = conversationId,
                UserId = userId
            };

            await base.CreateAsync(participant);
        }

        public async System.Threading.Tasks.Task RemoveParticipantAsync(
            int conversationId,
            int userId)
        {
            if (conversationId <= 0 || userId <= 0)
            {
                return;
            }

            var participant = await GetParticipantAsync(
                conversationId,
                userId);

            if (participant == null)
            {
                return;
            }

            // Fiziksel silme yerine soft delete yapıyoruz.
            await base.MakePassiveAsync(participant);
        }

        public async Task<List<ConversationParticipant>>
            GetParticipantsAsync(int conversationId)
        {
            if (conversationId <= 0)
            {
                return new List<ConversationParticipant>();
            }

            return await ((IConversationParticipantRepository)_repository)
                .GetParticipantsAsync(conversationId);
        }

        public async Task<bool> IsUserParticipantAsync(
            int conversationId,
            int userId)
        {
            if (conversationId <= 0 || userId <= 0)
            {
                return false;
            }

            return await ((IConversationParticipantRepository)_repository)
                .IsUserParticipantAsync(conversationId, userId);
        }

        public async Task<ConversationParticipant>
            GetParticipantAsync(
                int conversationId,
                int userId)
        {
            if (conversationId <= 0 || userId <= 0)
            {
                return null;
            }

            return await ((IConversationParticipantRepository)_repository)
                .GetParticipantAsync(conversationId, userId);
        }
    }
}