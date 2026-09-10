using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH.ENTITIES.Models;

namespace TH.DAL.Repositories.Abstracts
{
    public interface ITaskCommentRepository: IRepository<TaskComment>
    {
        //Bu yorum gerçekten bu kullanıcıya mı ait?
        Task<TaskComment> GetCommentByUserAsync(int commentId, int userId);

        //Yorum + Task + User bilgilerine ihtiyaç olduğunda kullanılacak.
        Task<TaskComment> GetCommentDetailsAsync(int commentId);

        Task<List<TaskComment>> GetCommentsByTeamIdsAsync(List<int> teamIds);
    }
}
