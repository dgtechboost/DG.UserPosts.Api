﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DG.UserPosts.Business.UserPosts.Queries.GetList
{
    public interface IGetUsersPostListQuery
    {
        Task<List<UsersPostListModel>> GetQuery();
    }
}
