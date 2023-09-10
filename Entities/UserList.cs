using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practice;

namespace ownpractice.Entities
{
    public class UserList
    {
        public int UserListId{get;set;}
        public List<DbMovie> LikedMovies{get;set;}
        public List<DbMovie> DislikedMovies{get;set;}
        public List<DbMovie> WantToSee{get;set;}
    }
}